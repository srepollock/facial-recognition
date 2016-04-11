using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect
{
    using System.Drawing;
    using AForge.Imaging;
    public interface IObjectDetector
    {

        Rectangle[] DetectedObjects { get; }

        Rectangle[] ProcessFrame(UnmanagedImage image);
    }
}
