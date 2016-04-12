namespace COMP4932_Assignment3.ViolaJones.Detection.HaarCascade
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    ///   Cascade of Haar-like features' weak classification stages.
    /// </summary>
    [Serializable]
    public class HaarCascade : ICloneable
    {
        /// <summary>
        ///   Gets the stages' base width.
        /// </summary>
        /// 
        public int Width { get; protected set; }

        /// <summary>
        ///   Gets the stages' base height.
        /// </summary>
        /// 
        public int Height { get; protected set; }

        /// <summary>
        ///   Gets the classification stages.
        /// </summary>
        /// 
        public HaarCascadeStage[] Stages { get; protected set; }

        /// <summary>
        ///   Gets a value indicating whether this cascade has tilted features.
        /// </summary>
        /// 
        /// <value>
        /// 	<c>true</c> if this cascade has tilted features; otherwise, <c>false</c>.
        /// </value>
        /// 
        public bool HasTiltedFeatures { get; protected set; }

        /// <summary>
        ///   Constructs a new Haar Cascade.
        /// </summary>
        /// 
        /// <param name="baseWidth">Base feature width.</param>
        /// <param name="baseHeight">Base feature height.</param>
        /// <param name="stages">Haar-like features classification stages.</param>
        /// 
        public HaarCascade(int baseWidth, int baseHeight, HaarCascadeStage[] stages)
        {
            Width = baseWidth;
            Height = baseHeight;
            Stages = stages;

            // check if the classifier has tilted features
            HasTiltedFeatures = checkTiltedFeatures(stages);
        }

        /// <summary>
        ///   Constructs a new Haar Cascade.
        /// </summary>
        /// 
        /// <param name="baseWidth">Base feature width.</param>
        /// <param name="baseHeight">Base feature height.</param>
        /// 
        protected HaarCascade(int baseWidth, int baseHeight)
        {
            Width = baseWidth;
            Height = baseHeight;
        }

        /// <summary>
        ///   Checks if the classifier contains tilted (rotated) features
        /// </summary>
        /// 
        private static bool checkTiltedFeatures(HaarCascadeStage[] stages)
        {
            foreach (var stage in stages)
                foreach (var tree in stage.Trees)
                    foreach (var node in tree)
                        if (node.Feature.Tilted == true)
                            return true;
            return false;
        }

        /// <summary>
        ///   Creates a new object that is a copy of the current instance.
        /// </summary>
        /// 
        /// <returns>
        ///   A new object that is a copy of this instance.
        /// </returns>
        /// 
        public object Clone()
        {
            HaarCascadeStage[] newStages = new HaarCascadeStage[Stages.Length];
            for (int i = 0; i < newStages.Length; i++)
                newStages[i] = (HaarCascadeStage)Stages[i].Clone();

            HaarCascade r = new HaarCascade(Width, Height);
            r.HasTiltedFeatures = this.HasTiltedFeatures;
            r.Stages = newStages;

            return r;
        }

        /// <summary>
        ///   Loads a HaarCascade from a OpenCV-compatible XML file.
        /// </summary>
        /// 
        /// <param name="stream">
        ///    A <see cref="Stream"/> containing the file stream
        ///    for the xml definition of the classifier to be loaded.</param>
        ///    
        /// <returns>The HaarCascadeClassifier loaded from the file.</returns>
        /// 
        public static HaarCascade FromXml(Stream stream)
        {
            return FromXml(new StreamReader(stream));
        }

        /// <summary>
        ///   Loads a HaarCascade from a OpenCV-compatible XML file.
        /// </summary>
        /// 
        /// <param name="path">
        ///    The file path for the xml definition of the classifier to be loaded.</param>
        ///    
        /// <returns>The HaarCascadeClassifier loaded from the file.</returns>
        /// 
        public static HaarCascade FromXml(string path)
        {
            return FromXml(new StreamReader(path));
        }

        /// <summary>
        ///   Loads a HaarCascade from a OpenCV-compatible XML file.
        /// </summary>
        /// 
        /// <param name="stringReader">
        ///    A <see cref="StringReader"/> containing the file stream
        ///    for the xml definition of the classifier to be loaded.</param>
        ///    
        /// <returns>The HaarCascadeClassifier loaded from the file.</returns>
        /// 
        public static HaarCascade FromXml(TextReader stringReader)
        {
            XmlTextReader xmlReader = new XmlTextReader(stringReader);

            // Gathers the base window size
            xmlReader.ReadToFollowing("size");
            string size = xmlReader.ReadElementContentAsString();

            // Proceeds to load the cascade stages
            xmlReader.ReadToFollowing("stages");
            XmlSerializer serializer = new XmlSerializer(typeof(HaarCascadeSerializationObject));
            var stages = (HaarCascadeSerializationObject)serializer.Deserialize(xmlReader);

            // Process base window size
            string[] s = size.Trim().Split(' ');
            int baseWidth = int.Parse(s[0], CultureInfo.InvariantCulture);
            int baseHeight = int.Parse(s[1], CultureInfo.InvariantCulture);

            // Create and return the new cascade
            return new HaarCascade(baseWidth, baseHeight, stages.Stages);
        }

        /// <summary>
        ///   Saves a HaarCascade to C# code.
        /// </summary>
        /// 
        public void ToCode(string path, string className)
        {
            ToCode(new StreamWriter(path), className);
        }

        /// <summary>
        ///   Saves a HaarCascade to C# code.
        /// </summary>
        /// 
        public void ToCode(TextWriter textWriter, string className)
        {
            new HaarCascadeWriter(textWriter).Write(this, className);
        }
    }
}
