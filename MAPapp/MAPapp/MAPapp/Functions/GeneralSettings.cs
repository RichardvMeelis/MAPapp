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
        public static Color entryColor = new Color();
        public static Color warningColor = new Color();
        public static Color fadedColor = new Color();
        public static Color btextColor = new Color();
        public static int pageMargin;
        public static void GetColors()
        {
         
            mainColor = Color.FromRgb(250,132,35);
            backgroundColor = Color.FromRgb(260,260,260);
            textColor = Color.Black;
            entryColor = Color.FromRgb(230,230,230);
            warningColor = Color.Red;
            pageMargin = 5;
            fadedColor = Color.FromRgb(100, 100, 100);
            btextColor = Color.White;

        }
       
    }
}
