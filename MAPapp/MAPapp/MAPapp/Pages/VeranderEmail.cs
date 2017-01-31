using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class VeranderEmail : ContentPage
	{
        // invoer velden aanmaken 
        Entry nieuwEmail = new Entry() { Placeholder = Globals.VEnieuwEmail_Entery, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor }, 
            nieuwEmail1 = new Entry() { Placeholder = Globals.VEhehaalnieuwEmail_Entery, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor }, 
            wachtwoord = new Entry() {Placeholder = Globals.VEwachtwoord_Entery, IsPassword= true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor };
        //Aanmaken button & label
        Button change_W8 = new Button() { Text= "Verander", IsEnabled= false, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor };
        Label Error = new Label { Text = null, TextColor = Color.Red };

        public VeranderEmail ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            //Voor het in en uitschakelen van de createNewUser knop
            nieuwEmail.TextChanged += Textaangepast;
            nieuwEmail1.TextChanged += Textaangepast;
            wachtwoord.TextChanged += Textaangepast;
            change_W8.Clicked += butonclicked;
            //Voeg content toe aan stacklayout
            Content = new StackLayout
            { 
                Children = {new Label { Text = Globals.VEnieuweEmail_Label, TextColor=GeneralSettings.textColor }, nieuwEmail, new Label {Text = Globals.VEherhaalnieuwEmail_Label, TextColor = GeneralSettings.textColor }, nieuwEmail1, new Label {Text = Globals.VEwachtwoord_Label, TextColor = GeneralSettings.textColor }, wachtwoord, change_W8, Error }
			};
		}
        // check of email mag worden verandert
        private void Textaangepast(object sender, TextChangedEventArgs e)
        {
            if (nieuwEmail.Text != null && nieuwEmail1.Text != null && wachtwoord.Text != null && nieuwEmail.Text == nieuwEmail1.Text && wachtwoord.Text.Length >= 6) change_W8.IsEnabled = true;
            else change_W8.IsEnabled = false;

        }

        //Maak url aan om email te veranderen
        private void butonclicked(object sender, EventArgs e)
        {
            change_W8.IsEnabled = false;
            //Check NEW_EMAIL success
            if ((string)ContactDataBase.UpdateEmail(ContactDataBase.currentUserName, ContactDataBase.currentToken, wachtwoord.Text, nieuwEmail.Text) == "NEW_EMAIL_HAS_BEEN_SET")
            {
                Application.Current.MainPage = new NavigationPage(new Login()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor };
            }
            else
            {
                //Error message
                Error.Text = Globals.VEerror ;
            }

            
        }


    }
}
