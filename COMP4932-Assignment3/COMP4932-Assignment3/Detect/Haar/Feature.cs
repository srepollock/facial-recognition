using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP4932_Assignment3.Detect.Imaging;

namespace COMP4932_Assignment3.Detect.Haar
{
    [Serializable]
    public sealed class Feature : ICloneable
    {

        public bool tilted;

        public HaarRectangle[] Rectangles { get; set; }

        public Feature()
        {
            this.Rectangles = new HaarRectangle[2];
        }

        public Feature(params HaarRectangle[] rects)
        {
            this.Rectangles = rects;
        }

        public Feature(params int[][] rects)
            : this(false, rects)
        { 
        }

        public Feature(bool tilt, params int[][] rects)
        {
            this.tilted = tilt;
            this.Rectangles = new HaarRectangle[rects.Length];
            for (int i = 0; i < rects.Length; i++)
                this.Rectangles[i] = new HaarRectangle(rects[i]);
        }

        public double GetSum(FaceImage image, int x, int y)
        {
            double sum = 0.0;

            if (!tilted)
            {
                foreach (HaarRectangle rect in Rectangles)
                {
                    sum += image.GetSum(x + rect.ScaledX, y + rect.ScaledY,
                        rect.ScaledWidth, rect.ScaledHeight) * rect.ScaledWeight;
                }
            }
            else
            {
                foreach (HaarRectangle rect in Rectangles)
                {
                    sum += image.GetSumTilt(x + rect.ScaledX, y + rect.ScaledY,
                        rect.ScaledWidth, rect.ScaledHeight) * rect.ScaledWeight;
                }
            }
            return sum;
        }

        public void SetScaleAndWeight(float scale, float weight)
        {
            if (Rectangles.Length == 2)
            {
                HaarRectangle a = Rectangles[0];
                HaarRectangle b = Rectangles[1];

                b.ScaleRectangle(scale);
                b.ScaleWeight(weight);

                a.ScaleRectangle(scale);
                a.ScaledWeight = -(b.Area * b.ScaledWeight) / a.Area;
            }
            else
            {
                HaarRectangle a = Rectangles[0];
                HaarRectangle b = Rectangles[1];
                HaarRectangle c = Rectangles[2];

                c.ScaleRectangle(scale);
                c.ScaleWeight(weight);

                b.ScaleRectangle(scale);
                b.ScaleWeight(weight);

                a.ScaleRectangle(scale);
                a.ScaledWeight = -(b.Area * b.ScaledWeight
                    + c.Area * c.ScaledWeight) / (a.Area);
            }
        }

        public object Clone()
        {
            HaarRectangle[] newRects = new HaarRectangle[Rectangles.Length];
            for (int i = 0; i < newRects.Length; i++)
            {
                HaarRectangle rect = Rectangles[i];
                newRects[i] = new HaarRectangle(rect.X, rect.Y,
                    rect.Width, rect.Height, rect.Weight);
            }

            Feature r = new Feature();
            r.Rectangles = newRects;
            r.tilted = tilted;

            return r;
        }
    }
}
