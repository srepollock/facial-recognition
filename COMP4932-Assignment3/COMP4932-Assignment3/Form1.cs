using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP4932_Assignment3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Data object for the class. Contains information.
        /// </summary>
        Data dataObj;
        public Form1()
        {
            InitializeComponent();
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
        /// Open a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataObj = new Data();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG Files|*.png|JPG Files|*.jpg|BMP Files|*.bmp|All Files|*.*";
            DialogResult result = openFileDialog1.ShowDialog(); // I want to open this to the child window in the file
            if (result == DialogResult.OK) // checks if the result returned true
            {
                dataObj.setImage1((Bitmap) Bitmap.FromFile(openFileDialog1.FileName));
                pictureBox1.Image = (Image) dataObj.getImage1();
                grayscaleToolStripMenuItem.Enabled = true;
            }
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "PNG Files|*.png|JPG Files|*.jpg|BMP Files|*.bmp|All Files|*.*";
            DialogResult result2 = openFileDialog2.ShowDialog(); // I want to open this to the child window in the file
            if (result2 == DialogResult.OK) // checks if the result returned true
            {
                dataObj.setImage2((Bitmap)Bitmap.FromFile(openFileDialog2.FileName));
                pictureBox2.Image = (Image)dataObj.getImage2();
                grayscaleToolStripMenuItem.Enabled = true;
            }
        }

        Bitmap grayscaleImage(Bitmap i)
        {
            Bitmap g = RGBChanger.RGBtoYCbCr(i, ref dataObj);
            return g;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataObj.setGrayscale1(grayscaleImage(dataObj.getImage1()));
            pictureBox1.Image = (Image)dataObj.getGrayscale1();
            dataObj.setGrayscale2(grayscaleImage(dataObj.getImage2()));
            pictureBox2.Image = (Image)dataObj.getGrayscale2();
        }
    }
}
