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
        Bitmap image1, image2;
        Bitmap grayscale1, grayscale2;

        // 1
        public Bitmap getImage1() { return image1; }
        public Bitmap getGrayscale1() { return grayscale1; }
        public void setImage1(Bitmap i) { image1 = i; }
        public void setGrayscale1(Bitmap i) { grayscale1 = i; }

        // 2
        public Bitmap getImage2() { return image2; }
        public Bitmap getGrayscale2() { return grayscale2; }
        public void setImage2(Bitmap i) { image2 = i; }
        public void setGrayscale2(Bitmap i) { grayscale2 = i; }
    }
}
