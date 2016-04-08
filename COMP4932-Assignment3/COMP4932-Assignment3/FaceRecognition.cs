using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP4932_Assignment3
{
    public partial class FaceRecognition : Form
    {
        /// <summary>
        /// Data object for the class. Contains information.
        /// </summary>
        Data dataObj;
        /// <summary>
        /// Timer for the GIF image.
        /// </summary>
        System.Windows.Forms.Timer grayTicker = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer diffTicker = new System.Windows.Forms.Timer();

        // EigenStuff
        public const double SAME_FACE_THRESH = 7.0;
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

        public FaceRecognition()
        {
            InitializeComponent();
            grayTicker.Tick += new System.EventHandler(gifGrayPlay);
            diffTicker.Tick += new System.EventHandler(gifDiffPlay);
            mainBmp = new Bitmap(Image.FromFile("./plane.bmp")); // load in the first from the user
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
            string[] images = Directory.GetFiles(@directory, "*.jpg");
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
                            findFaceToolStripMenuItem.Enabled = true;
                            faceFinderToolstripJPEG(true);
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
            findFaceToolStripMenuItem.Enabled = false;
            faceFinderToolstripGIF(false);
            faceFinderToolstripJPEG(false);
        }

        /// <summary>
        /// Turns on face finder buttons for jpeg images.
        /// </summary>
        /// <param name="b">True/False</param>
        void faceFinderToolstripJPEG(Boolean b)
        {
            jPEGToolStripMenuItem2.Enabled = b;
            jPEGToolStripMenuItem3.Enabled = b;
            jPEGToolStripMenuItem4.Enabled = b;
        }

        /// <summary>
        /// Turns on face finder buttons for gif images.
        /// </summary>
        /// <param name="b">True/False</param>
        void faceFinderToolstripGIF(Boolean b)
        {
            gIFToolStripMenuItem.Enabled = b;
            gIFToolStripMenuItem3.Enabled = b;
            gIFToolStripMenuItem4.Enabled = b;
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
            findFaceToolStripMenuItem.Enabled = true; // Enables Face Finder
            faceFinderToolstripJPEG(true);
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
            findFaceToolStripMenuItem.Enabled = true; // Enables Face Finder
            faceFinderToolstripGIF(true);
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
    }
}
