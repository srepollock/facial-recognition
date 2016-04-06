using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
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
    }
}
