using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAPapp {
    class CustomRendererNames {
    }

    public class ImageButton : Button {
        Image image;
        public ImageButton()
        {

        }

        public Image CompleteImage
        {
            get { return image; }
            set { image = value; }
        }
    }
}
