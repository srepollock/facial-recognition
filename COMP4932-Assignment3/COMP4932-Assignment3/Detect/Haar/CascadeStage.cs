using COMP4932_Assignment3.Detect.Haar;
using COMP4932_Assignment3.Detect.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect.Haar
{
    [Serializable]
    public class CascadeStage : ICloneable
    {
        public FeatureNode[][] Trees;

        public double threshold { get; set; }

        public int parentIndex { get; set; }

        public int nextIndex { get; set; }

        public CascadeStage()
        {

        }

        public CascadeStage(double thresh)
        {
            this.threshold = thresh;
        }

        public CascadeStage(double thresh, int parentIn, int nextIn)
        {
            this.threshold = thresh;
            this.parentIndex = parentIn;
            this.nextIndex = nextIn;
        }

        //Classifies an image as having the searched object or not.
        public bool Classify(Imaging.FaceImage image, int x, int y, double factor)
        {
            double value = 0;

            foreach (FeatureNode[] tree in Trees)
            {
                int current = 0;

                do
                {
                    FeatureNode node = tree[current];

                    double sum = node.feature.GetSum(image, x, y);

                    if (sum < node.threshold * factor)
                    {
                        value += node.leftValue;
                        current += node._LeftNodeIndex;
                    }
                    else
                    {
                        value += node.rightValue;
                        current += node._RightNodeIndex;
                    }
                } while (current > 0);
            }

            if (value < this.threshold)
                return false;
            else
                return true;
        }

        public object Clone()
        {
            FeatureNode[][] newTrees = new FeatureNode[Trees.Length][];

            for (int i = 0; i < newTrees.Length; i++)
            {
                FeatureNode[] tree = Trees[i];
                FeatureNode[] newTree = newTrees[i] = new FeatureNode[tree.Length];

                for (int j = 0; j < newTree.Length; j++)
                    newTree[j] = (FeatureNode)tree[j].Clone();
            }

            CascadeStage r = new CascadeStage();
            r.nextIndex = nextIndex;
            r.parentIndex = parentIndex;
            r.threshold = threshold;
            r.Trees = newTrees;

            return r;
        }
    }
}
