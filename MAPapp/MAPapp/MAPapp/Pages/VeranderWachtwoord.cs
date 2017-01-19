using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class VeranderWachtwoord : ContentPage
	{
        Entry oudwachtwoord = new Entry() { Placeholder = Globals.VWhuidigwachtwoord_Entery, IsPassword= true }, nieuwWachtwoord= new Entry() {Placeholder=Globals.VWnieuwwachtwoord_Entery, IsPassword=true }, nieuwwachtwoord2 = new Entry() {Placeholder=Globals.VWherhaalnieuwwachtwoord_Entery , IsPassword= true } ;
        Button change = new Button() { Text = Globals.VWverander , IsEnabled = false };
        Label warning = new Label {Text=null ,TextColor=Color.Red };

        public VeranderWachtwoord ()
		{

            oudwachtwoord.TextChanged += textverandert;
            nieuwWachtwoord.TextChanged += textverandert;
            nieuwwachtwoord2.TextChanged += textverandert;
            change.Clicked += pushed;

            Content = new StackLayout
            {
                Children = { new Label { Text = Globals.VWhuidigwachtwoord_Label , FontSize=15 }, oudwachtwoord, new Label() {Text=Globals.VWnieuwwachtwoord_Label}, nieuwWachtwoord, new Label() {Text=Globals.VWherhaalnieuwwachtwoord_Label }, nieuwwachtwoord2, change, warning }
			};

		}

        private void textverandert(object sender, TextChangedEventArgs e)
        {
            if (oudwachtwoord.Text != null && nieuwWachtwoord.Text != null && nieuwwachtwoord2 != null && nieuwWachtwoord.Text.Length >= 6 && nieuwWachtwoord.Text == nieuwwachtwoord2.Text) change.IsEnabled = true;
            else change.IsEnabled = false;
        }

        private void pushed(object sender, EventArgs e)
        {
            change.IsEnabled = false;
            if ((string)GetFromDatabase.UpdatePasword(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, oudwachtwoord.Text, nieuwWachtwoord.Text) == "NEW_PASS_HAS_BEEN_SET")
            {
                Navigation.PopAsync();
            }
            else
            {
                warning.Text = Globals.VWerror;
            }

        }
    }
}
