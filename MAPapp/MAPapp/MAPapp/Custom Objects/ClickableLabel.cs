using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAPapp
{
    class ClickableLabel : Label
    {
        //Contructor neemt methode naam mee voor de eventhandler
        public ClickableLabel(Action<String> myMethodName)
        {
            TextColor = GeneralSettings.textColor;
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                // Clickablelabel geeft een string terug, dit was handig
                Command = new Command(() => myMethodName(this.Text)),
            });
        }
        //In deze alternatieve methode zet je naast de methode ook de fontsize
        public ClickableLabel(Action<String> myMethodName, int size)
        {
            TextColor = GeneralSettings.textColor;
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => myMethodName(this.Text)),
            });
            FontSize = size;
        }
        
    }
}
