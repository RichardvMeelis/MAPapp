using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    public class InformationObject
    {
        List<string> textPages;
        List<string> fivePoints;
        string threeInfoPoint;

        public InformationObject(List<string> textPages, List<string> fivePoints, string threeInfoPoint)
        {
            this.textPages = textPages;
            this.fivePoints = fivePoints;
            this.threeInfoPoint = threeInfoPoint;
        }

        public List<string> TextPages
        {
            get { return textPages; }
            set { textPages = value; }
        }
        public List<string> FivePoints
        {
            get { return fivePoints; }
            set { fivePoints = value; }
        }
        public string ThreeInfoPoint
        {
            get { return threeInfoPoint; }
            set { threeInfoPoint = value; }
        }

        }
    }

