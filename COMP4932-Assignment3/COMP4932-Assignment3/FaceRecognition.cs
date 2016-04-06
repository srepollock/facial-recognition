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

        public FaceRecognition()
        {
            InitializeComponent();
            grayTicker.Tick += new System.EventHandler(gifGrayPlay);
            diffTicker.Tick += new System.EventHandler(gifDiffPlay);
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

        // TODO Clean this up
        /// <summary>
        /// Open a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataObj = new Data();
            disableButtons();
            stopTickers();
            clearBoxes();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "GIF Files|*.gif|JPG Files|*.jpg|PNG Files|*.png|BMP Files|*.bmp|All Files|*.*";
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
                    // gif
                    getFrames(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    gIFToolStripMenuItem1.Enabled = true;
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
            Bitmap g = ImageChanger.RGBtoGrayscale(i);
            return g;
        }

        /// <summary>
        /// Gets the differences of between the frams at frame i and i+1
        /// </summary>
        /// <param name="i">Index where to grab the frames</param>
        /// <returns>Bitmap of the differences</returns>
        Bitmap getDifference(int i)
        {
            Bitmap f = dataObj.grayscales.ElementAt(i);
            Bitmap l;
            if(i + 1 >= dataObj.grayscales.Count) l = dataObj.grayscales.ElementAt(0); // Next image
            else l = dataObj.grayscales.ElementAt(i + 1); // Next image
            if(f.Width != l.Width) { MessageBox.Show("Images must be the same width!"); return null; }
            Bitmap diff = new Bitmap(f.Width, f.Height);
            for(int x = 0; x < f.Width; x++)
            {
                for(int y = 0; y < f.Height; y++)
                {
                    int fp = (int)f.GetPixel(x, y).R;
                    int lp = (int)l.GetPixel(x, y).R;
                    int dp = fp - lp; // Get pixel, minus first from last
                    if (dp < dataObj.threshold) dp = 0; // Threshold
                    diff.SetPixel(x, y, Color.FromArgb(255, dp, dp, dp));
                }
            }
            return diff;
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
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
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
            setupGifGrayArray();
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
            dataObj.diffs.Add(getDifference(0));
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
                dataObj.diffs.Add(getDifference(i));
            }
            setupGifDiffArray();
            diffTicker.Start();
        }

        // TODO Cleanup these functions. Do this in data?
        /// <summary>
        /// Puts the images into an array.
        /// </summary>
        void setupGifImageArray()
        {
            int size = dataObj.images.Count;
            dataObj.gifarray = new Bitmap[size];
            for(int i = 0; i < size; i++)
            {
                dataObj.gifarray[i] = dataObj.images.ElementAt(i);
            }
        }

        /// <summary>
        /// Puts the grayscale into an array.
        /// </summary>
        void setupGifGrayArray()
        {
            int size = dataObj.grayscales.Count;
            dataObj.gifgrayarray = new Bitmap[size];
            for (int i = 0; i < size; i++)
            {
                dataObj.gifgrayarray[i] = dataObj.grayscales.ElementAt(i);
            }
        }

        /// <summary>
        /// Puts the diff into an array.
        /// </summary>
        void setupGifDiffArray()
        {
            int size = dataObj.diffs.Count;
            dataObj.gifdiffsarray = new Bitmap[size];
            for (int i = 0; i < size; i++)
            {
                dataObj.gifdiffsarray[i] = dataObj.diffs.ElementAt(i);
            }
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
