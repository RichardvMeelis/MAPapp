using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAPapp
{
    class ClickableLabel : Label
    {
        public ClickableLabel(int size)
        {
            TextColor = Color.Black;
            FontSize = size;
        }
        public ClickableLabel(Action<String> myMethodName)
        {
            TextColor = Color.Black;
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => myMethodName(this.Text)),
            });
        }
        public ClickableLabel(Action<String> myMethodName, int size)
        {
            TextColor = Color.Black;
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => myMethodName(this.Text)),
            });
            FontSize = size;
        }
        
    }
}
