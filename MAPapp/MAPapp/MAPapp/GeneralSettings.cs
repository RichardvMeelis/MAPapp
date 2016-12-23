using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
    class GeneralSettings 
    {
       public static Color mainColor = new Color();
        public static Color backgroundColor = new Color();
        public static Color textColor = new Color();
        public static Color s3 = new Color();
        public static void GetColors()
        {
         
            mainColor = Color.FromRgb(250,132,35);
            backgroundColor = Color.FromRgb(34,34,34);
            textColor = Color.White;
        }
       
    }
}
