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
        Entry username = new Entry() {Placeholder = Globals.mail,Keyboard = Keyboard.Email },password = new Entry() {Placeholder = Globals.wachtwoord, IsPassword = true  }, passwordReEnter = new Entry() { Placeholder = Globals.herhwachtwoord, IsPassword = true }, fName = new Entry() { Placeholder = Globals.voornaam }, lName = new Entry() { Placeholder = Globals.achternaam }, joincode = new Entry() { Placeholder = Globals.joincode};
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

            createNewUser = new Button() { Text = Globals.knopaanmaken, IsEnabled = false };
            createNewUser.Clicked += B_Clicked;
			Content = new StackLayout {
                Margin = GeneralSettings.pageMargin,
				Children = {
                    //De elementen worden toegevoegd aan de stacklayout
					new Label { Text = Globals.mail },username,new Label {Text = Globals.wachtwoord },password,passwordReEnter,new Label {Text = Globals.voornaam },fName,new Label {Text = Globals.achternaam },lName,new Label {Text = Globals.joincode },joincode,createNewUser,warning
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
            createNewUser.IsEnabled = false;
           if ((string)GetFromDatabase.CreateUser(username.Text, password.Text, fName.Text, lName.Text, joincode.Text) == "NEW_USER_SUCCESS")
            {
                DisplayAlert("New user succes", "het is gelukt","jaja");
                Navigation.PopAsync();
            }
            else
            {
                warning.Text = Globals.nieuwaccfail;
            }
            createNewUser.IsEnabled = true;
        }
    }
}
