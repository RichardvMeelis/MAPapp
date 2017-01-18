using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewWachtwoord : ContentPage
	{
        Entry oudwachtwoord = new Entry() { Placeholder = "huidig wachtwoord", IsPassword= true }, nieuwWachtwoord= new Entry() {Placeholder="nieuw wachtwoord", IsPassword=true }, nieuwwachtwoord2 = new Entry() {Placeholder="herhaal nieuw wachtwoord", IsPassword= true } ;
        Button change = new Button() { Text = "verander", IsEnabled = false };

        public NewWachtwoord ()
		{

            oudwachtwoord.TextChanged += textverandert;
            nieuwWachtwoord.TextChanged += textverandert;
            nieuwwachtwoord2.TextChanged += textverandert;

            Content = new StackLayout
            {
                Children = { new Label { Text = "huidig wachtwoord:", FontSize=15 }, oudwachtwoord, new Label() {Text="nieuw wachtwoord:"}, nieuwWachtwoord, new Label() {Text="herhaal nieuw wachtwoord" }, nieuwwachtwoord2, change }
			};

		}

        private void textverandert(object sender, TextChangedEventArgs e)
        {
            if (oudwachtwoord.Text != null && nieuwWachtwoord.Text != null && nieuwwachtwoord2 != null && nieuwWachtwoord.Text.Length >= 6 && nieuwWachtwoord.Text == nieuwwachtwoord2.Text) change.IsEnabled = true;
            else change.IsEnabled = false;
        }
	}
}
