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
        Entry username = new Entry() {Placeholder = Globals.mail,Keyboard = Keyboard.Email,TextColor = GeneralSettings.textColor,BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor },
            password = new Entry() {Placeholder = Globals.wachtwoord, IsPassword = true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor }, 
            passwordReEnter = new Entry() { Placeholder = Globals.herhwachtwoord, IsPassword = true, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor }, 
            fName = new Entry() { Placeholder = Globals.voornaam, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor }, 
            lName = new Entry() { Placeholder = Globals.achternaam, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor }, 
            joincode = new Entry() { Placeholder = Globals.joincode, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor, PlaceholderColor = GeneralSettings.textColor };
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
            Title = "Nieuw Account";

            createNewUser = new Button() { Text = Globals.knopaanmaken, IsEnabled = false, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor};
            createNewUser.Clicked += B_Clicked;
			Content = new StackLayout {
                Margin = GeneralSettings.pageMargin,
				Children = {
                    //De elementen worden toegevoegd aan de stacklayout
					new Label { Text = Globals.mail, TextColor = GeneralSettings.textColor },username,new Label {Text = Globals.wachtwoord, TextColor = GeneralSettings.textColor },password,new Label {Text = Globals.herhwachtwoord , TextColor = GeneralSettings.textColor }, passwordReEnter,new Label {Text = Globals.voornaam, TextColor = GeneralSettings.textColor },fName,new Label {Text = Globals.achternaam, TextColor = GeneralSettings.textColor },lName,new Label {Text = Globals.joincode, TextColor = GeneralSettings.textColor },joincode,createNewUser,warning
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
                DisplayAlert("Nieuw Account","Aanmaken succesvol. U heeft een email ontvangen met een link om het account te verifiëren","OK");
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
