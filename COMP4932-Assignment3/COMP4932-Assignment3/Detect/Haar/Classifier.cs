using COMP4932_Assignment3.Detect.Imaging;
using COMP4932_Assignment3.Detect.Haar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect.Haar
{
    class Classifier
    {
        private Cascade cascade;

        private float invArea;
        private float scale;

        public Classifier(Cascade cas)
        {
            cascade = cas;
        }

        public Classifier(int baseWidth, int baseHeight, CascadeStage[] stages)
            : this(new Cascade(baseWidth, baseHeight, stages))
        {

        }

        public Cascade Cascade
        {
            get { return cascade; }
        }

        public float Scale
        {
            get { return this.scale; }
            set
            {
                if (this.scale == value)
                    return;

                this.scale = value;
                this.invArea = 1f / (cascade.width * cascade.height * scale * scale);

                //Yay tree traversal
                foreach (CascadeStage stage in cascade.Stages)
                    foreach (FeatureNode[] tree in stage.Trees)
                        foreach (FeatureNode node in tree)
                            node.feature.SetScaleAndWeight(value, invArea);
            }
        }

        public bool Compute(Imaging.FaceImage image, Rectangle rectangle)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int w = rectangle.Width;
            int h = rectangle.Height;

            double mean = image.GetSum(x, y, w, h) * invArea;
            double factor = image.GetSumSquare(x, y, w, h) * invArea - (mean * mean);

            factor = (factor >= 0) ? Math.Sqrt(factor) : 1;

            //Check for rejection
            foreach (CascadeStage stage in cascade.Stages)
                if (stage.Classify(image, x, y, factor) == false)
                    return false; //Image has been rejected

            return true; //Image has been detected
        }
    }
}
