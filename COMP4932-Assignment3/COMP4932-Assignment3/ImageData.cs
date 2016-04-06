using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
    /// <summary>
    /// Holds all the images in a list. Easier?
    /// </summary>
    public class ImageData
    {
        public List<Bitmap> images = new List<Bitmap>();
        public List<Bitmap> grayscales = new List<Bitmap>();
    }
}
