using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
   
   public class Tip
    {
        //Achter een tip zit een tekst pagina. Firstpoint wordt gebruikt om de informationobject de juiste naam te geven en de tips te sorteren
        String tipName, tipText, tipFirstPoint;
        public Tip(String tipName, String tipText, String tipFirstPoint)
        {
            this.tipName = tipName;
            this.tipText = tipText;
            this.tipFirstPoint = tipFirstPoint;
        }

        //Tip properties
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
        public String pname
        {
            get { return tipFirstPoint; }
            set { tipFirstPoint = value; }
        }

    }
}
