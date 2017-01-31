using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class VeranderWachtwoord : ContentPage
	{
        //invoer velden aanmaken
        Entry oudwachtwoord = new Entry() { Placeholder = Globals.VWhuidigwachtwoord_Entery, IsPassword= true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor }, 
              nieuwWachtwoord= new Entry() {Placeholder=Globals.VWnieuwwachtwoord_Entery, IsPassword=true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor }, 
              nieuwwachtwoord2 = new Entry() {Placeholder=Globals.VWherhaalnieuwwachtwoord_Entery , IsPassword= true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor } ;
        //Aanmaken button & label
        Button change = new Button() { Text = Globals.VWverander , IsEnabled = false, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor };
        Label warning = new Label {Text=null ,TextColor=Color.Red };

        public VeranderWachtwoord ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            //Voor het in en uitschakelen van de createNewUser knop
            oudwachtwoord.TextChanged += textveranderd;
            nieuwWachtwoord.TextChanged += textveranderd;
            nieuwwachtwoord2.TextChanged += textveranderd;
            change.Clicked += pushed;

            //Voeg content toe aan stacklayout
            Content = new StackLayout
            {
                Children = { new Label { Text = Globals.VWhuidigwachtwoord_Label , TextColor=GeneralSettings.textColor }, oudwachtwoord, new Label() {Text=Globals.VWnieuwwachtwoord_Label, TextColor=GeneralSettings.textColor}, nieuwWachtwoord, new Label() {Text=Globals.VWherhaalnieuwwachtwoord_Label, TextColor = GeneralSettings.textColor }, nieuwwachtwoord2, change, warning }
			};
		}

        // check of de ingevoerde waarden voldoen om het wachtwoord te mogen veranderen
        private void textveranderd(object sender, TextChangedEventArgs e)
        {
            if (oudwachtwoord.Text != null && nieuwWachtwoord.Text != null && nieuwwachtwoord2 != null && nieuwWachtwoord.Text.Length >= 6 && nieuwWachtwoord.Text == nieuwwachtwoord2.Text) change.IsEnabled = true;
            else change.IsEnabled = false;
        }

        // maak een url aan om het wachtwoord te veranderen
        private void pushed(object sender, EventArgs e)
        {
            change.IsEnabled = false;
            //Check NEW_PASS success
            if ((string)ContactDataBase.UpdatePasword(ContactDataBase.currentUserName, ContactDataBase.currentToken, oudwachtwoord.Text, nieuwWachtwoord.Text) == "NEW_PASS_HAS_BEEN_SET")
            {
                Navigation.PopAsync();
            }
            else
            {
                //Error message
                warning.Text = Globals.VWerror;
            }
        }
    }
}
