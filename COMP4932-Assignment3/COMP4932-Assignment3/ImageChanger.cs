using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
    public static class ImageChanger
    {
        public static Bitmap RGBtoGrayscale(Bitmap orgBmp)
        {
            int width = orgBmp.Width, height = orgBmp.Height;
            Bitmap bmp = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    Color p = orgBmp.GetPixel(x, y);
                    int g = (int)(0 + (0.299 * p.R) + (0.587 * p.G) + (0.114 * p.B));
                    bmp.SetPixel(x, y, Color.FromArgb(255, g, g, g));
                }
            }
            return bmp;
        }
    }
}
