using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect.Haar
{
    [Serializable]
    public class Cascade : ICloneable
    {

        public int width;
        public int height;
        public CascadeStage[] Stages { get; protected set; }

        public bool hasTilt { get; protected set; }

        public Cascade(int baseWidth, int baseHeight, CascadeStage[] states)
        {
            width = baseWidth;
            height = baseHeight;
            Stages = Stages;

            hasTilt = checkTilt(Stages);
        }

        protected Cascade(int baseWidth, int baseHeight)
        {
            width = baseWidth;
            height = baseHeight;
        }

        private static bool checkTilt(CascadeStage[] stages)
        {
            foreach (var stage in stages)
                foreach (var tree in stage.Trees)
                    foreach (var node in tree)
                        if (node.feature.tilted == true)
                            return true;
            return false;
        }

        public object Clone()
        {
            CascadeStage[] newStages = new CascadeStage[Stages.Length];
            for (int i = 0; i < newStages.Length; i++)
                newStages[i] = (CascadeStage)Stages[i].Clone();

            Cascade r = new Cascade(width, height);
            r.hasTilt = hasTilt;
            r.Stages = newStages;

            return r;
        }
    }
}
