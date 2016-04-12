// Accord Vision Library
// The Accord.NET Framework (LGPL)
// http://accord.googlecode.com
//
// Copyright © César Souza, 2009-2012
// cesarsouza at gmail.com
//
// Copyright © Masakazu Ohtsuka, 2008
//   This work is partially based on the original Project Marilena code,
//   distributed under a 2-clause BSD License. Details are listed below.
//
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
//   * Redistribution's of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//
//   * Redistribution's in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//
// This software is provided by the copyright holders and contributors "as is" and
// any express or implied warranties, including, but not limited to, the implied
namespace COMP4932_Assignment3.ViolaJones.Detection.HaarCascade
{
    using System;
    using System.Drawing;
    using COMP4932_Assignment3.ViolaJones.IntegralImage;

    /// <summary>
    ///   Strong classifier based on a weaker cascade of
    ///   classifiers using Haar-like rectangular features.
    /// </summary>
    [Serializable]
    public class HaarClassifier 
    {
        private HaarCascade cascade;
        private float invArea;
        private float scale;

        /// <summary>
        ///   Constructs a new classifier.
        /// </summary>
        /// 
        public HaarClassifier(HaarCascade cascade)
        {
            this.cascade = cascade;
        }

        /// <summary>
        ///   Constructs a new classifier.
        /// </summary>
        /// 
        public HaarClassifier(int baseWidth, int baseHeight, HaarCascadeStage[] stages)
            : this(new HaarCascade(baseWidth, baseHeight, stages))
        {
        }

        /// <summary>
        ///   Gets the cascade of weak-classifiers
        ///   used by this strong classifier.
        /// </summary>
        public HaarCascade Cascade
        {
            get { return cascade; }
        }

        /// <summary>
        ///   Gets or sets the scale of the search window
        ///   being currently used by the classifier.
        /// </summary>
        /// 
        public float Scale
        {
            get { return this.scale; }
            set
            {
                if (this.scale == value)
                    return;

                this.scale = value;
                this.invArea = 1f / (cascade.Width * cascade.Height * scale * scale);

                // For each stage in the cascade 
                foreach (HaarCascadeStage stage in cascade.Stages)
                {
                    // For each tree in the cascade
                    foreach (HaarFeatureNode[] tree in stage.Trees)
                    {
                        // For each feature node in the tree
                        foreach (HaarFeatureNode node in tree)
                        {
                            // Set the scale and weight for the node feature
                            node.Feature.SetScaleAndWeight(value, invArea);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Detects the presence of an object in a given window.
        /// </summary>
        /// 
        public bool Compute(SIntegralImage image, Rectangle rectangle)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int w = rectangle.Width;
            int h = rectangle.Height;

            double mean = image.GetSum(x, y, w, h) * invArea;
            double factor = image.GetSum2(x, y, w, h) * invArea - (mean * mean);

            factor = (factor >= 0) ? Math.Sqrt(factor) : 1;


            // For each classification stage in the cascade
            foreach (HaarCascadeStage stage in cascade.Stages)
            {
                // Check if the stage has rejected the image
                if (stage.Classify(image, x, y, factor) == false)
                {
                    return false; // The image has been rejected.
                }
            }

            // If the object has gone all stages and has not
            //  been rejected, the object has been detected.

            return true; // The image has been detected.
        }
    }
}
