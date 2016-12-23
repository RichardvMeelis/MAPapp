using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class newAccount : ContentPage
	{
        Entry username = new Entry() {Placeholder = "Email" },password = new Entry() {Placeholder = "Password", IsPassword = true  }, passwordReEnter = new Entry() { Placeholder = "Repeat password", IsPassword = true }, fName = new Entry() { Placeholder = "First name" }, lName = new Entry() { Placeholder = "Last name" }, joincode = new Entry() { Placeholder = "Joincode" };
        Label label = new Label() {TextColor = Color.Red };
        Button b;

        public newAccount() {
            username.TextChanged += TextChanged;
            password.TextChanged += TextChanged;
            fName.TextChanged += TextChanged;
            lName.TextChanged += TextChanged;
            joincode.TextChanged += TextChanged;

            b = new Button() { Text = "Create", IsEnabled = false };
            b.Clicked += B_Clicked;
			Content = new StackLayout {
				Children = {
					new Label { Text = "Username/ Email:" },username,new Label {Text = "password:" },password,passwordReEnter,new Label {Text = "First Name:" },fName,new Label {Text = "Last Name:" },lName,new Label {Text = "Joincode:" },joincode,b,label
                }
			};
		}

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (username.Text != null && password.Text != null && fName.Text != null && lName.Text != null && joincode.Text != null && password.Text.Length >= 6 && password.Text == passwordReEnter.Text) { b.IsEnabled = true; }
            else { b.IsEnabled = false; }

        }

        private void B_Clicked(object sender, EventArgs e)
        {
           if (GetFromDatabase.CreateUser(username.Text, password.Text, fName.Text, lName.Text, joincode.Text) == "NEW_USER_SUCCESS")
            {
                Navigation.PopAsync();
            }
            else
            {
                label.Text = "Creating new user failed";
            }
        }
    }
}
