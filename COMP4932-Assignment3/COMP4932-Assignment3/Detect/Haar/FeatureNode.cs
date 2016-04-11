using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect.Haar
{
    [Serializable]
    public class FeatureNode : ICloneable
    {

        private int rightNodeIndex = -1;
        private int leftNodeIndex = -1;

        public double threshold;

        public double leftValue;
        public double rightValue;

        public int _LeftNodeIndex
        {
            get { return leftNodeIndex; }
            set { leftNodeIndex = value; }
        }

        public int _RightNodeIndex
        {
            get { return rightNodeIndex; }
            set { rightNodeIndex = value; }
        }

        public Feature feature { get; set; }

        public FeatureNode()
        {
        }

        public FeatureNode(double threshold, double lValue, double rValue, params int[][] rects)
            : this(threshold, lValue, rValue, false, rects)
        { 
        }

        public FeatureNode(double nThresh, double lValue, double rValue, bool tilted, params int[][] rects)
        {
            this.feature = new Feature(tilted, rects);
            this.threshold = nThresh;
            this.leftValue = lValue;
            this.rightValue = rValue;
        }

        public object Clone()
        {
            FeatureNode r = new FeatureNode();

            r.feature = (Feature)feature.Clone();
            r.threshold = threshold;

            r.rightValue = rightValue;
            r.leftValue = leftValue;

            r.leftNodeIndex = leftNodeIndex;
            r.rightNodeIndex = rightNodeIndex;

            return r;
        }
    }
}
