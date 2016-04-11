using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using COMP4932_Assignment3.Detect.Haar;
using COMP4932_Assignment3.Detect.Imaging;
using System.Collections.Concurrent;

namespace COMP4932_Assignment3.Detect
{

    public enum ObjDetectorSearchMode
    {
        Default = 0,
        Single,
        NoOverlap,
    }

    public enum ObjDetectorScalingMode
    {
        GreaterToSmaller,
        SmallerToGreater,
    }

    class ObjectDetector : IObjectDetector
    {
        private List<Rectangle> detectedObjects;
        private Classifier classifier;

        private ObjDetectorSearchMode searchMode = ObjDetectorSearchMode.NoOverlap;
        private ObjDetectorScalingMode scalingMode = ObjDetectorScalingMode.GreaterToSmaller;

        private Size minSize = new Size(15, 15);
        private Size maxSize = new Size(500, 500);
        private float factor = 1.2f;
        private int channel = RGB.R;
        
        private Rectangle[] lastObjects;
        private int steadyThreshold = 2;

        private int baseWidth;
        private int baseHeight;

        private int lastWidth;
        private int lastHeight;
        private float[] steps;

        public ObjectDetector(Cascade cascade)
            : this(cascade, 15)
        {
        }

        public ObjectDetector(Cascade cascade, int minSize)
            :this(cascade, minSize, ObjDetectorSearchMode.NoOverlap)
        {
        }

        public ObjectDetector(Cascade cascade, int minSize, ObjDetectorSearchMode searchMode)
            : this(cascade, minSize, searchMode, 1.2f)
        {
        }

        public ObjectDetector(Cascade cascade, int minSize, ObjDetectorSearchMode searchMode, float scaleFactor)
            : this(cascade, minSize, searchMode, scaleFactor, ObjDetectorScalingMode.SmallerToGreater)
        {
        }

        public ObjectDetector(Cascade cascade, int minSize, ObjDetectorSearchMode searchMode, float scaleFactor,
                    ObjDetectorScalingMode scalingMode)
        {
            this.classifier = new Classifier(cascade);
            this.minSize = new Size(minSize, minSize);
            this.searchMode = searchMode;
            this.factor = scaleFactor;
            this.detectedObjects = new List<Rectangle>();

            this.baseWidth = cascade.width;
            this.baseHeight = cascade.height;
        }

        public bool UseParallelProcessing
        {
            get; set;
        }

        public Size MinSize
        {
            get { return minSize; }
            set { minSize = value; }
        }

        public Size MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        public int Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        public float ScalingFactor
        {
            get { return factor; }
            set
            {
                if (value != factor)
                {
                    factor = value;
                    steps = null;
                }
            }
        }

        public ObjDetectorSearchMode SearchMode
        {
            get { return searchMode; }
            set { searchMode = value; }
        }

        public ObjDetectorScalingMode ScalingMode
        {
            get { return scalingMode; }
            set
            {
                if (value != scalingMode)
                {
                    scalingMode = value;
                    steps = null;
                }
            }
        }

        public Rectangle[] DetectedObjects
        {
            get
            {
                return detectedObjects.ToArray(); 
            }
        }

        public int Steady { get; private set; }

        public Rectangle[] ProcessFrame(Bitmap frame)
        {
            return ProcessFrame(UnmanagedImage.FromManagedImage(frame));
        }

        public Rectangle[] ProcessFrame(UnmanagedImage image)
        {
            Imaging.FaceImage im = Imaging.FaceImage.FromBitmap(
                image, channel, classifier.Cascade.hasTilt);

            this.detectedObjects.Clear();

            int width = im.getWidth();
            int height = im.getHeight();

            if (steps == null || width != lastWidth || height != lastHeight)
                update(width, height);

            Rectangle window = Rectangle.Empty;

            for (int i = 0; i < steps.Length; i++)
            {
                float scaling = steps[i];

                classifier.Scale = scaling;

                window.Width = (int)(baseWidth * scaling);
                window.Height = (int)(baseHeight * scaling);

                if (window.Width < minSize.Width && window.Height < minSize.Height &&
                     window.Width > maxSize.Width && window.Height > maxSize.Height)
                {
                    if (scalingMode == ObjDetectorScalingMode.GreaterToSmaller)
                        goto EXIT; //at max size
                    else
                        continue; //increase size
                }

                int xStep = window.Width >> 3;
                int yStep = window.Height >> 3;

                int xEnd = width - window.Width;
                int yEnd = height - window.Height;

                if (!UseParallelProcessing)
                {
                    for (int y = 0; y < yEnd; y += yStep)
                    {
                        window.Y = y;

                        // For every pixel in the window row
                        for (int x = 0; x < xEnd; x += xStep)
                        {
                            window.X = x;

                            if (searchMode == ObjDetectorSearchMode.NoOverlap && overlaps(window))
                                continue; // We have already detected something here, moving along.

                            // Try to detect and object inside the window
                            if (classifier.Compute(im, window))
                            {
                                // an object has been detected
                                detectedObjects.Add(window);

                                if (searchMode == ObjDetectorSearchMode.Single)
                                    goto EXIT; // Stop on first object found
                            }
                        }
                    }
                }

                else
                {
                    ConcurrentBag<Rectangle> bag = new ConcurrentBag<Rectangle>();

                    int numSteps = (int)Math.Ceiling((double)yEnd / yStep);

                    Parallel.For(0, numSteps, (j, options) =>
                    {
                        int y = j * yStep;

                        Rectangle localWindow = window;

                        localWindow.Y = y;

                        //For each pixel in the window row
                        for (int x = 0; x < xEnd; x += xStep)
                        {
                            if (options.ShouldExitCurrentIteration) return;

                            localWindow.X = x;

                            //Try to detect an object inside the window
                            if (classifier.Compute(im, localWindow))
                            {
                                bag.Add(localWindow);

                                if (searchMode == ObjDetectorSearchMode.Single)
                                    options.Stop();
                            }
                        }
                    });

                    if (searchMode == ObjDetectorSearchMode.NoOverlap)
                    {
                        foreach (Rectangle obj in bag)
                            if (!overlaps(obj))
                                detectedObjects.Add(obj);
                    }
                    else if (searchMode == ObjDetectorSearchMode.Single)
                    {
                        if (bag.TryPeek(out window))
                        {
                            detectedObjects.Add(window);
                            goto EXIT;
                        }
                    }
                    else
                    {
                        foreach (Rectangle obj in bag)
                            detectedObjects.Add(obj);
                    }
                }
            }

            EXIT:
            Rectangle[] objects = detectedObjects.ToArray();
            checkSteadiness(objects);
            lastObjects = objects;

            return objects;
        }

        private void update(int width, int height)
        {
            List<float> listSteps = new List<float>();

            if (scalingMode == ObjDetectorScalingMode.SmallerToGreater)
            {
                float start = 1f;
                float stop = Math.Min(width / (float)baseWidth, height / (float)baseHeight);
                float step = factor;

                for (float f = start; f < stop; f *= step)
                    listSteps.Add(f);
            }
            else
            {
                float start = Math.Min(width / (float)baseWidth, height / (float)baseHeight);
                float stop = 1f;
                float step = 1f / factor;

                for (float f = start; f > stop; f *= step)
                    listSteps.Add(f);
            }

            steps = listSteps.ToArray();

            lastWidth = width;
            lastHeight = height;
        }

        private void checkSteadiness(Rectangle[] rectangles)
        {
            if (lastObjects == null || rectangles == null || rectangles.Length == 0)
            {
                Steady = 0;
                return;
            }

            bool equals = true;
            foreach (Rectangle current in rectangles)
            {
                bool found = false;
                foreach (Rectangle last in lastObjects)
                {
                    //Fix
                    if (IsEqual(current, last, steadyThreshold))
                    {
                        found = true;
                        continue;
                    }
                }

                if (!found)
                {
                    equals = false;
                    break;
                }
            }

            if (equals)
                Steady++;
            else
                Steady = 0;
        }

        private bool overlaps(Rectangle rect)
        {
            foreach (Rectangle r in detectedObjects)
            {
                if (rect.IntersectsWith(r))
                    return true;
            }
            return false;
        }

        public static bool IsEqual(Rectangle objA, Rectangle objB, int threshold)
        {
            return (Math.Abs(objA.X - objB.X) < threshold) &&
                   (Math.Abs(objA.Y - objB.Y) < threshold) &&
                   (Math.Abs(objA.Width - objB.Width) < threshold) &&
                   (Math.Abs(objA.Height - objB.Height) < threshold);
        }
    }
}


