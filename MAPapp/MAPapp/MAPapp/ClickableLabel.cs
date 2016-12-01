using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAPapp
{
    class ClickableLabel : Label
    {
        public ClickableLabel(Action<String> myMethodName)
        {
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => myMethodName(this.Text)),
            });
        }
    }
}
