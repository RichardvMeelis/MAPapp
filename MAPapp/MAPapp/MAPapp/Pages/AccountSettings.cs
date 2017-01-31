using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class AccountSettings : ContentPage
	{
        Label bedrijflabel, naamlabel, achternaamlabel, emaillabel, naamlabel1, bedrijflabel1, achternaamlabel1, emaillabel1;
        ClickableLabel veranderWachtwoord, veranderEmail;
        public AccountSettings()

        {
            BackgroundColor = GeneralSettings.backgroundColor;
            Title = "Mijn Account";
         
           
            Button logOut = new Button() { Text = Globals.aclogout , TextColor = GeneralSettings.btextColor, BackgroundColor = GeneralSettings.mainColor};
            logOut.Clicked += LogOut;
                // het creëren van een Grid
                var grid1 = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

                // 16 rijen toevoegen aan de grid
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                // 3 colums toevoegen aan de grid
                grid1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // labels toevoegen aan pleken in de grid
            grid1.Children.Add(naamlabel = new Label() { Text = Globals.ACvoornaam, FontSize = 20, TextColor = GeneralSettings.textColor }, 0, 0);
            grid1.Children.Add(achternaamlabel = new Label() { Text = Globals.ACachternaam  , FontSize = 20, TextColor = GeneralSettings.textColor }, 0, 1);
            grid1.Children.Add(bedrijflabel = new Label() { Text = Globals.ACbedrijf , FontSize = 20, TextColor = GeneralSettings.textColor }, 0, 2);
            grid1.Children.Add(emaillabel = new Label() { Text = Globals.ACemail , FontSize = 20, TextColor = GeneralSettings.textColor }, 0, 3);
            grid1.Children.Add(naamlabel1 = new Label() { Text = ContactDataBase.currentUser.firstname, FontSize = 20, TextColor = GeneralSettings.textColor }, 1, 0);
            grid1.Children.Add(achternaamlabel1 = new Label() { Text = ContactDataBase.currentUser.lastname, FontSize = 20, TextColor = GeneralSettings.textColor }, 1, 1);
            grid1.Children.Add(bedrijflabel1 = new Label() { Text = ContactDataBase.currentUser.companyname, FontSize = 20, TextColor = GeneralSettings.textColor }, 1, 2);
            grid1.Children.Add(emaillabel1 = new Label() { Text = ContactDataBase.currentUser.username, FontSize = 20, TextColor = GeneralSettings.textColor }, 1, 3);
            grid1.Children.Add(veranderWachtwoord = new ClickableLabel(veranderwachtwoord) { Text = Globals.ACveranderW8, TextColor = Color.FromRgb(66,133,244) }, 0, 4);
            grid1.Children.Add(veranderEmail = new ClickableLabel(veranderemail) { Text = Globals.ACveranderEmail , TextColor = Color.FromRgb(66, 133, 244) }, 0, 5);

            // laat de tweede colom twee keer zo groot zijn als de eerste
            Grid.SetColumnSpan(naamlabel1, 2);
            Grid.SetColumnSpan(achternaamlabel1, 2);
            Grid.SetColumnSpan(emaillabel1, 2);
            Grid.SetColumnSpan(bedrijflabel1,2);
            Grid.SetColumnSpan(veranderWachtwoord, 2);
            Grid.SetColumnSpan(veranderEmail, 2);

            Content = new StackLayout { Children = { grid1, logOut } };
            }

        //Uitloggen (Destroy token)
        private void LogOut(object sender, EventArgs e)
        {
          String loginResult =   (string)ContactDataBase.logOut(ContactDataBase.currentUserName,ContactDataBase.currentToken);
           if (loginResult == "TK_DESTROY_SUCCESS")
            App.Current.MainPage = new Login();
        }

        // ga naar NewEmail page
        public async void veranderemail(string s)
            {
                await Navigation.PushAsync(new VeranderEmail ());
            }
            
            // ga naar NewWachtwoord page
            public async void veranderwachtwoord(string s)
            {
                await Navigation.PushAsync(new VeranderWachtwoord());
            }
        }
}
