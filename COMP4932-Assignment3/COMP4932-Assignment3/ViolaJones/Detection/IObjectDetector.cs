namespace COMP4932_Assignment3.ViolaJones.Detection
{
    using System.Drawing;
    using AForge.Imaging;

    /// <summary>
    ///   Object detector interface.
    /// </summary>
    public interface IObjectDetector
    {
        /// <summary>
        ///   Gets the location of the detected objects.
        /// </summary>
        Rectangle[] DetectedObjects { get; }

        /// <summary>
        ///   Process a new image scene looking for objects.
        /// </summary>
        Rectangle[] ProcessFrame(UnmanagedImage image);
    }
}
