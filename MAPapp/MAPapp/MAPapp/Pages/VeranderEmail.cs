using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class VeranderEmail : ContentPage
	{
        Entry nieuwEmail = new Entry() { Placeholder = Globals.VEnieuwEmail_Entery }, nieuwEmail1 = new Entry() { Placeholder = Globals.VEhehaalnieuwEmail_Entery}, wachtwoord = new Entry() {Placeholder = Globals.VEwachtwoord_Entery, IsPassword= true };
        Button change_W8 = new Button() { Text= "verander", IsEnabled= false, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.textColor };
        Label Error = new Label { Text = null, TextColor = Color.Red };

        public VeranderEmail ()
		{
            nieuwEmail.TextChanged += Textaangepast;
            nieuwEmail1.TextChanged += Textaangepast;
            wachtwoord.TextChanged += Textaangepast;
            change_W8.Clicked += butonclicked;

            Content = new StackLayout
            { 
                Children = {new Label { Text = Globals.VEnieuweEmail_Label , FontSize = 15 }, nieuwEmail, new Label {Text = Globals.VEherhaalnieuwEmail_Label }, nieuwEmail1, new Label {Text = Globals.VEwachtwoord_Label , FontSize =15 }, wachtwoord, change_W8, Error }
			};
		}
        private void Textaangepast(object sender, TextChangedEventArgs e)
        {
            if (nieuwEmail.Text != null && nieuwEmail1.Text != null && wachtwoord.Text != null && nieuwEmail.Text == nieuwEmail1.Text && wachtwoord.Text.Length >= 6) change_W8.IsEnabled = true;
            else change_W8.IsEnabled = false;

        }
        private void butonclicked(object sender, EventArgs e)
        {
            change_W8.IsEnabled = false;
            if ((string)GetFromDatabase.UpdateEmail(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, wachtwoord.Text, nieuwEmail.Text) == "NEW_EMAIL_HAS_BEEN_SET")
            {
                Application.Current.MainPage = new NavigationPage(new Login()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor };
            }
            else
            {
                Error.Text = Globals.VEerror ;
            }

            
        }


    }
}
