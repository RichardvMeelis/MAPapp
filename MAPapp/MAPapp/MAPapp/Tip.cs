using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
   
   public class Tip
    {
        String tipName, tipText, tipFirstPoint;
        public Tip(String tipName, String tipText, String tipFirstPoint)
        {
            this.tipName = tipName;
            this.tipText = tipText;
            this.tipFirstPoint = tipFirstPoint;
        }

        public String ACName
        {
            get { return tipName; }
            set { tipName = value; }
        }
        public String ACDescription
        {
            get { return tipText; }
            set { tipText = value; }
        }
        public String layer
        {
            get { return tipFirstPoint; }
            set { tipFirstPoint = value; }
        }

    }
}
