using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class newAccount : ContentPage
	{
        
        //Invoervelden voor het aanmaken van een account
        Entry username = new Entry() {Placeholder = "Email" },password = new Entry() {Placeholder = "Password", IsPassword = true  }, passwordReEnter = new Entry() { Placeholder = "Repeat password", IsPassword = true }, fName = new Entry() { Placeholder = "First name" }, lName = new Entry() { Placeholder = "Last name" }, joincode = new Entry() { Placeholder = "Joincode" };
        Label warning = new Label() {TextColor = Color.Red };
        Button createNewUser;

        public newAccount() {
            BackgroundColor = GeneralSettings.backgroundColor;
            //Voor het in en uitschakelen van de createNewUser knop
            username.TextChanged += TextChanged;
            password.TextChanged += TextChanged;
            fName.TextChanged += TextChanged;
            lName.TextChanged += TextChanged;
            joincode.TextChanged += TextChanged;

            createNewUser = new Button() { Text = "Create", IsEnabled = false };
            createNewUser.Clicked += B_Clicked;
			Content = new StackLayout {
				Children = {
                    //De elementen worden toegevoegd aan de stacklayout
					new Label { Text = "Username/ Email:" },username,new Label {Text = "password:" },password,passwordReEnter,new Label {Text = "First Name:" },fName,new Label {Text = "Last Name:" },lName,new Label {Text = "Joincode:" },joincode,createNewUser,warning
                }
			};
		}

        //Voor het in- en uitschakelen van de createNewUser knop
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (username.Text != null && password.Text != null && fName.Text != null && lName.Text != null && joincode.Text != null && password.Text.Length >= 6 && password.Text == passwordReEnter.Text) { createNewUser.IsEnabled = true; }
            else { createNewUser.IsEnabled = false; }

        }

        //De data wordt opgestuurd en de ouput vergeleken
        private void B_Clicked(object sender, EventArgs e)
        {
           if (GetFromDatabase.CreateUser(username.Text, password.Text, fName.Text, lName.Text, joincode.Text) == "NEW_USER_SUCCESS")
            {
                Navigation.PopAsync();
            }
            else
            {
                warning.Text = "Creating new user failed";
            }
        }
    }
}
