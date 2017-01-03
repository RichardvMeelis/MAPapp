using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    public class InformationObject
    {
        List<Tip> tips = new List<Tip>();
        string layer;

        public InformationObject(List<Tip> tips, string threeInfoPoint)
        {
            this.tips = tips;
            this.layer = threeInfoPoint;
        }

       
        public List<Tip> Tips
        {
            get { return tips; }
            set { tips = value; }
        }
        public string ThreeInfoPoint
        {
            get { return layer; }
            set { layer = value; }
        }

        }
    }

