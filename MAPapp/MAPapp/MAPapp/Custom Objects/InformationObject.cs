using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    public class InformationObject
    {
        //Een informationobject heeft een lijst van tips en een naam
        List<Tip> tips = new List<Tip>();
        string name;

        public InformationObject(List<Tip> tips, string threeInfoPoint)
        {
            this.tips = tips;
            this.name = threeInfoPoint;
        }

       //Get of set de lijst met tips
        public List<Tip> Tips
        {
            get { return tips; }
            set { tips = value; }
        }

        //Get of set de naam
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        }
    }

