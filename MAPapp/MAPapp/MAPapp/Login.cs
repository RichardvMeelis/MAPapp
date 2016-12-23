using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class Login : ContentPage
	{
        Entry c;
        Entry d;
        Label z;
        Button b;
        public Login ()
		{
            c = new Entry() { Placeholder = "Email" ,};
            d = new Entry() { Placeholder = "Password", IsPassword = true };
            c.TextChanged += EntryTextChanged;
            d.TextChanged += EntryTextChanged;
            z = new Label() { TextColor = Color.Red, Text = "" };
             b = new Button() { Text = "Sign in",IsEnabled = false };
            b.Clicked += B_Clicked;
            Content = new StackLayout {
				Children = {
					new Label { Text = "Username" }, c, new Label {Text = "Password" },d ,b ,new ClickableLabel(newAccountClicked) {Text = "New Account" },z
				}
			};
		}

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
           if(c.Text != null && d.Text != null && c.Text.Length >=3 && d.Text.Length >= 3)
            {
                b.IsEnabled = true;
            }
            else
            {
                b.IsEnabled = false;
            }
        }

        private void B_Clicked(object sender, EventArgs e)
        {
            string s = GetFromDatabase.SingIn(c.Text, d.Text);
            if (s.Length == 120) {
                GetFromDatabase.token = s;
            GetFromDatabase.Username = c.Text;
                Application.Current.MainPage = new MasterDetailPage() { Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new ContentPage() { Title = "titel" } };
            }
            else
            {
                z.Text = "Wrong username or password";
            }
            }

        public async void newAccountClicked(String s)
        {
           await Navigation.PushAsync( new newAccount());
        }
    }
}
