namespace COMP4932_Assignment3.ViolaJones.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using AForge.Imaging;

    /// <summary>
    ///   Static tool functions for imaging.
    /// </summary>
    public static class Tools
    {
        private const double SQRT2 = 1.4142135623730951;

        /// <summary>
        ///   Compares two rectangles for equality, considering an acceptance threshold.
        /// </summary>
        public static bool IsEqual(this Rectangle objA, Rectangle objB, int threshold)
        {
            return (Math.Abs(objA.X - objB.X) < threshold) &&
                   (Math.Abs(objA.Y - objB.Y) < threshold) &&
                   (Math.Abs(objA.Width - objB.Width) < threshold) &&
                   (Math.Abs(objA.Height - objB.Height) < threshold);
        }
    }
}
