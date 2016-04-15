namespace COMP4932_Assignment3
{
    using System.Diagnostics;
    using COMP4932_Assignment3.ViolaJones.Detection;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using AForge.Video;
    using AForge.Video.DirectShow;
    using AForge.Imaging.Filters;
    using System.Threading.Tasks;
    using EigenFace;

    public partial class FaceRecognition : Form
    {
        /* Variables */
        // Video Capture Devices

        /// <summary>
        /// Bool for if the camera device exists or not.
        /// </summary>
        private bool DeviceExist = false;

        /// <summary>
        /// All the video devices in a collection.
        /// </summary>
        private FilterInfoCollection videoDevices;

        /// <summary>
        /// The video capture device.
        /// </summary>
        private VideoCaptureDevice videoSource = null;

        // Face Recognition

        /// <summary>
        /// Object detection with HarrObjectDetector.
        /// </summary>
        HaarObjectDetector objDet = new HaarObjectDetector(new ViolaJones.Detection.HaarCascade.Def.FaceHaarCascade(), 30);

        /// <summary>
        /// The rectangles found in an array.
        /// </summary>
        Rectangle[] rekt;

        // EigenStuff

        /// <summary>
        /// A threshold to check if we found the same face.
        /// </summary>
        public const double SAME_FACE_THRESH = 7.7;

        /// <summary>
        /// Face threshold, check to see if the face is within a reasonable face space.
        /// </summary>
        public const double FACE_THRESH = 20000;

        /// <summary>
        /// Constants for the regular, difference and eigen values.
        /// </summary>
        public const int REGULAR = 0, DIFFERENCE = 1, EIGEN = 2;

        /// <summary>
        /// The number of faces per person.
        /// </summary>
        /// <remarks>
        /// Changes here effect the library. Increasing or decreasing will require a refreshed library of faces.
        /// </remarks>
        public const int FACES_PER_PERSON = 3;

        /// <summary>
        /// Constants for the image width to pass into the previous student's code.
        /// </summary>
        public const int IMG_WIDTH = 256, IMAGE_HEIGHT = 256;

        /// <summary>
        /// Image library of faces. Determined by the value and a double array of the 'image' in double 2D array format.
        /// </summary>
        public double[][,] lib;

        /// <summary>
        /// Differences of all the images in the library compared to the current picture.
        /// </summary>
        public double[][,] difLib;

        /// <summary>
        /// Stores the eigen faces of the current difLib data arrays.
        /// </summary>
        public double[][,] eigFaces;

        /// <summary>
        /// Average face as double 2D array.
        /// </summary>
        public double[,] avg;

        /// <summary>
        /// Reconstructed face from the library and the eigen face of the current face.
        /// </summary>
        public double[,] recon;

        /// <summary>
        /// Double array of the libraries weights to the current image.
        /// </summary>
        public double[][] libWeights;

        /// <summary>
        /// Compared weights of the image to those in the library.
        /// </summary>
        public double[] comp;

        /// <summary>
        /// Index of the found face to dispaly, if found.
        /// </summary>
        public int display;

        /// <summary>
        /// Main bitmap to store the current found face.
        /// </summary>
        public Bitmap mainBmp;

        /// <summary>
        /// Library bitmap, usually the reconstructed face.
        /// </summary>
        public Bitmap libBmp;

        /// <summary>
        /// Current face space.
        /// </summary>
        public double faceSpace;
        /* End of Variables */

        /// <summary>
        /// Called when the class is loaded up.
        /// </summary>
        public FaceRecognition()
        {
            InitializeComponent();
            // Student code
            mainBmp = new Bitmap(Image.FromFile("./imgLib/temp1.bmp")); // load in the first from the user
            mainPicture.Image = mainBmp;
            double[,] img = ImageTool.GetGreyScale(mainBmp);
            ImageTool.SetImage(mainBmp, img);
            int libCount = LoadLibrary("./imgLib", IMG_WIDTH, IMAGE_HEIGHT, FACES_PER_PERSON);
            avg = ImageTool.GetAvg(lib);
            difLib = ImageTool.GetDifferenceArray(lib, avg);
            libBmp = new Bitmap(IMG_WIDTH, IMAGE_HEIGHT);
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
            avgFace.Image = libBmp;
        }

        /// <summary>
        /// Closes the source when the form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaceRecognition_Close(object sender, FormClosedEventArgs e)
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

        // TOOL STRIP

        // TODO Thread this function. Can take a long time on the UI for hi-res
        // TODO Update progress bar for the image
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /********************/
            /*Find the best face*/
            // This is among our rectangles
            Bitmap org = (Bitmap)mainPicture.Image; // Take the current image in the picturebox
            double min = double.MaxValue; // Minimum value
            Rectangle ripp = new Rectangle();
            try // just in case
            {
                rekt = processTheImage(org); // Process the current image and get all the 'faces' in it
                if (rekt.Length >= 1) // We found at least one
                {
                    // Now find the best face
                    for (int i = 0; i < rekt.Length; i++)
                    {
                        // Get a copy of the image in the box
                        Rectangle rectTemp = rekt[i]; // Copy, we need to inflate the rectangle
                        rectTemp.Inflate(4, 4); // Inflate a bit, we have to resize anyways
                        Bitmap temp = org.Clone(rectTemp, org.PixelFormat); // Get a copy of what is inside the box // may need to rescale
                        double[,] tempAr = ImageTool.GetArray(temp); // Change the temp bitmap into a double 2D array
                        // Already grayscaled
                        double[] w = ImageTool.getWeights(eigFaces, tempAr, avg); // Gets the weights of the current selected face. eigFaces and avg are setup from the library
                        double[] compW = ImageTool.compareWeigths(libWeights, w); // Compare all the weights in the library with their images and the weights of the current image
                        int p = ImageTool.smallestVal(compW); // Gets the face that has the smallest weight
                        if (compW[p] < SAME_FACE_THRESH)
                        {
                            // Possible face
                            if (compW[p] < min)
                            {
                                ripp = rectTemp; // Inflated rect
                            }
                        }
                    }
                    if (!ripp.IsEmpty) // We actually have one
                    {
                        ripp.Inflate(20, 20);
                        //Bitmap img = org.Clone(rekt[0], org.PixelFormat);
                        Bitmap img = org.Clone(ripp, org.PixelFormat);
                        Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
                        img = filter.Apply(img);
                        img = ImageTool.ResizeImage(img, 256, 256);
                        capFacePic.Image = img;
                        findToolStripMenuItem.Enabled = true;
                        addToolStripMenuItem.Enabled = true;
                    }
                }
            }
            catch (Exception trollception)
            {
                Debug.WriteLine(trollception.ToString());
                Debug.WriteLine("Something went wrong with finding the face."); // Print something pretty troll
            }
        }

        // TODO Update progress bar on status of finding
        /// <summary>
        /// Finds the face in the toolstrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBmp = (Bitmap)capFacePic.Image;
            mainBmp = ImageTool.ResizeImage(mainBmp, 256, 256);
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
            ImageTool.SetImage(libBmp, lib[p]);
            fndFacePic.Image = libBmp;
            lb_distance.Text = "Distance : " + comp[p];
            faceSpace = ImageTool.difference(img, recon);
            lb_faceSpace.Text = "Face Space : " + faceSpace;
            if (faceSpace > FACE_THRESH)
            {
                lb_faceSpace.Text += "... Not a face";
            }
        }

        /// <summary>
        /// Adds a face to the testbank.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently Disabled. Please read up about it at 'http://github.com/srepollock/comp4932-assignment3/wiki'"); // TODO Update wiki // TODO Update website name when changed
        }

        /// <summary>
        /// Opens up the readme file in GitHub for how the program works.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/srepollock/comp4932-assignment3"); // TODO Update when the Github changes
        }

        // MAIN FUNCTIONALITY

        /// <summary>
        /// Basic function calls called on program startup, or reopening.
        /// </summary>
        void startup()
        {
            disableButtons(false);
        }

        /// <summary>
        /// Turns buttons on/off.
        /// </summary>
        void disableButtons(bool change)
        {
            captureToolStripMenuItem.Enabled = change;
            findToolStripMenuItem.Enabled = change;
            addToolStripMenuItem.Enabled = false; // TODO Get adding faces working for the '.exe' version
        }

        /// <summary>
        /// Sets the picture boxes to null.
        /// </summary>
        void clearBoxes()
        {
            mainPicture.Image = null;
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
                    captureToolStripMenuItem.Enabled = true;
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
                    disableButtons(false);
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
            /*TESTING FOR THE FACE BOXES*/
            /*using (Graphics g = Graphics.FromImage(img))
            {
                Color color = Color.FromArgb(255, Color.Red);
                Pen brush = new Pen(color);
                rekt = objDet.ProcessFrame(img);
                if (rekt.Length > 0)
                    g.DrawRectangles(brush, rekt); // Draw the all the rectangles
            }*/
            mainPicture.Image = img;
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
        private Rectangle[] processTheImage(Bitmap img)
        {
            try
            {
                Rectangle[] kappa;
                var kek = Task.Run<Rectangle[]>(() => objDet.ProcessFrame(img));
                kappa = kek.Result;
                return kappa;
            }
            catch(Exception trollception)
            {
                Debug.WriteLine(trollception.ToString());
                Debug.WriteLine("Something went wrong. Possible task error, or no faces found as a result."); // Print something pretty troll
            }
            return null;
        }
    }
}
