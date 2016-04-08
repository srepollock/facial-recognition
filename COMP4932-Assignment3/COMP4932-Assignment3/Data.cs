using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
    /// <summary>
    /// Class to handle all the data needed.
    /// </summary>
    public class Data
    {
        public List<Bitmap> images = new List<Bitmap>();
        public List<Bitmap> grayscales = new List<Bitmap>();
        public List<Bitmap> diffs = new List<Bitmap>();
        public int threshold = 50;

        // GIF stuff
        public Bitmap[] gifarray;
        public Bitmap[] gifgrayarray;
        public Bitmap[] gifdiffsarray;
        public int curgimage = 0;
        public int curdimage = 0;

        /// <summary>
        /// Puts the images into an array.
        /// </summary>
        public void setupGifImageArray()
        {
            int size = images.Count;
            gifarray = new Bitmap[size];
            for (int i = 0; i < size; i++)
            {
                gifarray[i] = images.ElementAt(i);
            }
        }

        /// <summary>
        /// Puts the grayscale into an array.
        /// </summary>
        public void setupGifGrayArray()
        {
            int size = grayscales.Count;
            gifgrayarray = new Bitmap[size];
            for (int i = 0; i < size; i++)
            {
                gifgrayarray[i] = grayscales.ElementAt(i);
            }
        }

        /// <summary>
        /// Puts the diff into an array.
        /// </summary>
        public void setupGifDiffArray()
        {
            int size = diffs.Count;
            gifdiffsarray = new Bitmap[size];
            for (int i = 0; i < size; i++)
            {
                gifdiffsarray[i] = diffs.ElementAt(i);
            }
        } 
    }
}
