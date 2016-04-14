using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
    using System.Diagnostics;
    using COMP4932_Assignment3.ViolaJones.Detection;
    public partial class FaceRecognition : Form
    {
        /// <summary>
        /// Data object for the class. Contains information.
        /// </summary>
        Data dataObj;
        /// <summary>
        /// Timer for the GIF image.
        /// </summary>
        Timer grayTicker = new Timer();
        Timer diffTicker = new Timer();
        // Video Capture Devices
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        // Face Recognition
        HaarObjectDetector objDet = new HaarObjectDetector(new ViolaJones.Detection.HaarCascade.Def.FaceHaarCascade(), 30);
        Rectangle[] rekt;

        // EigenStuff
        public const double SAME_FACE_THRESH = 7.4;
        public const double FACE_THRESH = 16000;
        public const int REGULAR = 0, DIFFERENCE = 1, EIGEN = 2;
        public const int FACES_PER_PERSON = 3;
        public double[][,] lib;
        public double[][,] difLib;
        public double[][,] eigFaces;
        public double[,] avg;
        public double[,] recon;
        public double[][] libWeights;
        public double[] comp;
        public int display;
        public Bitmap mainBmp;
        public Bitmap libBmp;
        public double faceSpace;

        /// <summary>
        /// Called when the class is loaded up.
        /// </summary>
        public FaceRecognition()
        {
            InitializeComponent();
            grayTicker.Tick += new System.EventHandler(gifGrayPlay);
            diffTicker.Tick += new System.EventHandler(gifDiffPlay);

            // Student code
            ///*
            mainBmp = new Bitmap(Image.FromFile("./plane.bmp")); // load in the first from the user
            pictureBox1.Image = mainBmp;
            double[,] img = ImageTool.GetGreyScale(mainBmp);
            ImageTool.SetImage(mainBmp, img);
            int libCount = LoadLibrary("./imgLib", mainBmp.Width, mainBmp.Height, FACES_PER_PERSON); // Loads the library with images that are the same size as the main bitmap
            avg = ImageTool.GetAvg(lib);
            difLib = ImageTool.GetDifferenceArray(lib, avg);
            libBmp = new Bitmap(mainBmp.Width, mainBmp.Height);
            EigenObject eigVects = ImageTool.GetEigen(ImageTool.GetA(lib));
            ImageTool.normalize(eigVects.Vectors);
            eigFaces = ImageTool.getEigenFaces(eigVects.Vectors, difLib);
            libWeights = new double[lib.Length][];
            for (int i = 0; i < lib.Length; i++)
            {
                libWeights[i] = ImageTool.getWeights(eigFaces, lib[i], avg);
            }
            double[] weights = ImageTool.getWeights(eigFaces, img, avg);
            comp = ImageTool.compareWeigths(libWeights, weights);
            int p = ImageTool.smallestVal(comp);
            recon = ImageTool.reconstruct(weights, eigFaces, avg);
            ImageTool.normalize(recon, 255);
            ImageTool.SetImage(libBmp, lib[p]);
            //*/
        }

        /// <summary>
        /// Closes the source when the form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

        /// <summary>
        /// Loads in the library for the faces
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="subSet"></param>
        /// <returns></returns>
        public int LoadLibrary(string directory, int width, int height, int subSet)
        {
            string[] images = Directory.GetFiles(@directory, "*.bmp"); // *.jpg || *.bmp (bmp for my lib)
            if (subSet < 1)
                subSet = 1;
            lib = new double[images.Length][,];
            int i = 0;
            foreach (string image in images)
            {
                lib[i++] = ImageTool.GetArray(new Bitmap(image));
            }
            if (subSet > 1)
                lib = ImageTool.avgSubsets(lib, subSet);
            return images.Length / subSet;
        }

        /// <summary>
        /// Show help in GitHub README
        /// </summary>
        /// <remarks>
        /// Or show README in rich textbox
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Basic function calls called on program startup, or reopening.
        /// </summary>
        void startup()
        {
            dataObj = new Data();
            disableButtons();
            stopTickers();
            clearBoxes();
        }

        /// <summary>
        /// Open a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startup();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files|*.jpg|GIF Files|*.gif|PNG Files|*.png|BMP Files|*.bmp|All Files|*.*";
            DialogResult result = openFileDialog1.ShowDialog(); // I want to open this to the child window in the file
            if (result == DialogResult.OK) // checks if the result returned true
            {
                string ext = Path.GetExtension(openFileDialog1.FileName); // includes the period
                if (ext == ".jpg")
                {
                    dataObj.images.Add((Bitmap)Bitmap.FromFile(openFileDialog1.FileName));
                    pictureBox1.Image = (Image)dataObj.images.ElementAt(0);

                    OpenFileDialog openFileDialog2 = new OpenFileDialog();
                    openFileDialog2.Filter = "JPG Files|*.jpg|PNG Files|*.png|BMP Files|*.bmp|All Files|*.*";
                    DialogResult result2 = openFileDialog2.ShowDialog(); // I want to open this to the child window in the file
                    if (result2 == DialogResult.OK) // checks if the result returned true
                    {
                        string ext2 = Path.GetExtension(openFileDialog2.FileName); // includes the period
                        if (ext == ".jpg")
                        {
                            dataObj.images.Add((Bitmap)Bitmap.FromFile(openFileDialog2.FileName));
                            pictureBox2.Image = (Image)dataObj.images.ElementAt(1);
                            jPEGToolStripMenuItem.Enabled = true; // Enables JPEG Grayscale
                        }
                        else
                        {
                            MessageBox.Show("Only jpg's are accepted for the second image.");
                        }
                    }
                }
                else
                {
                    getFrames(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    gIFToolStripMenuItem1.Enabled = true; // Enables GIF Grayscale
                }
            }
        }

        /// <summary>
        /// Disables Grayscale, Difference buttons.
        /// </summary>
        void disableButtons()
        {
            jPEGToolStripMenuItem.Enabled = false;
            jPEGToolStripMenuItem1.Enabled = false;
            gIFToolStripMenuItem1.Enabled = false;
            gIFToolStripMenuItem2.Enabled = false;
        }

        /// <summary>
        /// Stops all tickers.
        /// </summary>
        void stopTickers()
        {
            grayTicker.Stop();
            diffTicker.Stop();
        }

        /// <summary>
        /// Sets the picture boxes to null.
        /// </summary>
        void clearBoxes()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        /// <summary>
        /// Grayscales an image.
        /// </summary>
        /// <param name="i">Image to grayscale</param>
        /// <returns>Grayscaled image</returns>
        Bitmap grayscaleImage(Bitmap i)
        {
            Bitmap g = ImageTool.grayscale(i);
            return g;
        }

        /// <summary>
        /// Gets the frames from GIF file. Saves it into the images array.
        /// </summary>
        /// <param name="FileName">Path to the .gif file</param>
        void getFrames(String FileName)
        {
            Image gif = Image.FromFile(FileName);
            FrameDimension dimension = new FrameDimension(gif.FrameDimensionsList[0]);
            int framecount = gif.GetFrameCount(dimension);
            for(int i = 0; i < framecount; i++)
            {
                gif.SelectActiveFrame(dimension, i); // Selects the frame
                dataObj.images.Add((Bitmap)gif.Clone()); // Adds the image to the list
            }
        }
        
        /// <summary>
        /// Doesn't do anything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        /// Doesn't do anything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Grayscales the two images saved in the Data Object. JPEG GRAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jPEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataObj.grayscales.Add(grayscaleImage(dataObj.images.ElementAt(0)));
            pictureBox1.Image = (Image)dataObj.grayscales.ElementAt(0);
            dataObj.grayscales.Add(grayscaleImage(dataObj.images.ElementAt(1)));
            pictureBox2.Image = (Image)dataObj.grayscales.ElementAt(1);
            jPEGToolStripMenuItem1.Enabled = true; // Diff JPEG
        }

        /// <summary>
        /// Grayscales the gif image. GIF GRAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gIFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataObj.images.Count; i++)
            {
                dataObj.grayscales.Add(grayscaleImage(dataObj.images.ElementAt(i)));
            }
            dataObj.setupGifGrayArray();
            grayTicker.Start();
            gIFToolStripMenuItem2.Enabled = true; // Diff GIF
        }

        /// <summary>
        /// Gets the difference between the two jpeg images. JPEG DIFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jPEGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataObj.diffs.Add(ImageTool.getDifference(0, ref dataObj));
            pictureBox3.Image = dataObj.diffs.ElementAt(0);
        }

        /// <summary>
        /// Gets the difference between each frame in the gif. GIF DIFF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gIFToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataObj.images.Count; i++)
            {
                dataObj.diffs.Add(ImageTool.getDifference(i, ref dataObj));
            }
            dataObj.setupGifDiffArray();
            diffTicker.Start();
        }

        /// <summary>
        /// Called when the combo box changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when the combo box is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ticker function to play the grayscale image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gifGrayPlay(Object sender, EventArgs e)
        {
            if (dataObj.curgimage >= dataObj.gifgrayarray.Length) dataObj.curgimage = 0;
            pictureBox2.Image = dataObj.gifgrayarray[dataObj.curgimage++];
        }

        /// <summary>
        /// Ticker function to play the diff image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gifDiffPlay(Object sender, EventArgs e)
        {
            if (dataObj.curdimage >= dataObj.gifgrayarray.Length) dataObj.curdimage = 0;
            pictureBox3.Image = dataObj.gifdiffsarray[dataObj.curdimage++];
        }

        /// <summary>
        /// Gets the cameras in the system.
        /// </summary>
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox1.Items.Add("No capture device on your system");
            }
        }

        /// <summary>
        /// Sets combobox2 to the resolutions of the selected camera.
        /// </summary>
        private void getResList()
        {
            VideoCaptureDevice temp = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            for (int i = 0; i < temp.VideoCapabilities.Length; i++)
            {
                comboBox2.Items.Add(temp.VideoCapabilities[i].FrameSize.ToString());
            }
            comboBox2.SelectedIndex = 0;
            temp.Stop();
        }

        /// <summary>
        /// Refereshes the cameras listed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refCamera_Click(object sender, EventArgs e)
        {
            getCamList();
            getResList();
        }

        /// <summary>
        /// Starts the camera listed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ldCamera_Click(object sender, EventArgs e)
        {
            if (start.Text == "&Start")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    videoSource.VideoResolution = videoSource.VideoCapabilities[comboBox2.SelectedIndex];
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    CloseVideoSource();
                    videoSource.Start();
                    videoInfo.Text = "Device running...";
                    start.Text = "&Stop";
                    timer1.Enabled = true;
                    captureFaceToolStripMenuItem.Enabled = true;
                }
                else
                {
                    videoInfo.Text = "Error: No Device selected.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    videoInfo.Text = "Device stopped.";
                    start.Text = "&Start";
                    captureFaceToolStripMenuItem.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Updates the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            // Get the faces in the image as rects

            // TODO Thread here

            //rekt = objDet.ProcessFrame(img); // Gets the faces


            //using (Graphics g = Graphics.FromImage(img))
            //{
            //    Color color = Color.FromArgb(255, Color.Red);
            //    Pen brush = new Pen(color);
            //    rekt = objDet.ProcessFrame(img);
            //    if (rekt.Length > 0)
            //        g.DrawRectangles(brush, rekt); // Draw the all the rectangles
            //}

            pictureBox1.Image = img;
        }

        /// <summary>
        /// Stops the video.
        /// </summary>
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        /// <summary>
        /// For every tiimer tick refresh.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            videoInfo.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
        }

        /// <summary>
        /// Runs task to process the image taken in.
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Rectangle[] processDatImage(Bitmap img)
        {
            Rectangle[] kappa;
            var kek = Task.Run<Rectangle[]>(() => objDet.ProcessFrame(img));
            kappa = kek.Result;
            return kappa;
        }

        /// <summary>
        /// Take a photo of the first selected face.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void captureFaceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try {
                rekt = processDatImage((Bitmap)pictureBox1.Image); // Starts a new task to get the pictures
                if (rekt.Length > 0)
                {
                    if (rekt[0] != null)
                    {
                        // Get the rectangles position and save it
                        Bitmap org = (Bitmap)pictureBox1.Image;
                        Rectangle ripp = rekt[0];
                        ripp.Inflate(20, 20);
                        //Bitmap img = org.Clone(rekt[0], org.PixelFormat);
                        Bitmap img = org.Clone(ripp, org.PixelFormat);
                        Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
                        img = filter.Apply(img);
                        capFacePic.Image = img;
                        findFaceToolStripMenuItem1.Enabled = true;
                    }
                }
            }catch(Exception kappa)
            {
                Debug.WriteLine(kappa.ToString());
                for (int i = 0; i < 11; i++)
                {
                    Debug.WriteLine("kappabilities not found");
                }
            }
        }

        // TODO Not working. Get the image here and I need to either scale/resize to 256 x 256. Here lies the issue
        /// <summary>
        /// Finds the face in the capFacePick picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findFaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainBmp = (Bitmap)capFacePic.Image;
            mainBmp = ImageTool.ResizeImage(mainBmp, 256, 256);
            fndFacePic.Image = mainBmp;
            double[,] img = ImageTool.GetGreyScale(mainBmp);
            ImageTool.SetImage(mainBmp, img); // Breaking here
            double[] weights = ImageTool.getWeights(eigFaces, img, avg);
            comp = ImageTool.compareWeigths(libWeights, weights);
            int p = ImageTool.smallestVal(comp);

            if (comp[p] > SAME_FACE_THRESH)
            {
                lb_person.Text = "Person: Unknown";
            }
            else
            {
                lb_person.Text = "Person: " + p;
            }
            recon = ImageTool.reconstruct(weights, eigFaces, avg);

            //pb_lib.Image = libBmp;
            ImageTool.SetImage(libBmp, lib[p]);
            lb_distance.Text = "Distance : " + comp[p];
            faceSpace = ImageTool.difference(img, recon);
            lb_faceSpace.Text = "Face Space : " + faceSpace;
            if (faceSpace > FACE_THRESH)
            {
                lb_faceSpace.Text += "\nNot a face";
            }
        }
    }
}
