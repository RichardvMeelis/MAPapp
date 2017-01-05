using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Auth;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace MAPapp {
    public class Login : ContentPage {
        Entry c;
        Entry d;
        Label z;
        Button b;
        Switch s;
        public Login()
        {
            c = new Entry() { Placeholder = "Email", };
            c.Text = UserName;
            d = new Entry() { Placeholder = "Password", IsPassword = true };
            d.Text = Password;
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "MySettings.txt");
            s = new Switch();
            System.Diagnostics.Debug.WriteLine(File.ReadAllText(filename));
            
            try
            {
                if (File.ReadAllText(filename) == "True")
                {
                    s.IsToggled = true;
                }
            }
            catch { }
            c.TextChanged += EntryTextChanged;
            d.TextChanged += EntryTextChanged;
            z = new Label() { TextColor = Color.Red, Text = "" };
            b = new Button() { Text = "Sign in", IsEnabled = false };
            b.Clicked += B_Clicked;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Username" }, c, new Label {Text = "Password" },d ,b ,new StackLayout {Children = { new Label {Text = "Remember me" },s },Orientation = StackOrientation.Horizontal },new ClickableLabel(newAccountClicked) {Text = "New Account" },z
                }
            };
        }

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (c.Text != null && d.Text != null && c.Text.Length >= 3 && d.Text.Length >= 3)
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
            if (this.s.IsToggled)
            {
                DeleteCredentials();
                SaveCredentials(c.Text, d.Text);
            }
            else
                DeleteCredentials();
           var documents =  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents,"MySettings.txt");
            File.WriteAllText(filename, this.s.IsToggled.ToString());
            string s = GetFromDatabase.SingIn(c.Text, d.Text);
            if (s.Length == 120)
            {
                GetFromDatabase.currentToken = s;
                GetFromDatabase.currentUserName = c.Text;
                Application.Current.MainPage = new MasterDetailPage() { Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new ContentPage() { Title = "titel" } };
            }
            else
            {
                z.Text = "Wrong username or password";
            }
        }

        public async void newAccountClicked(String s)
        {
            await Navigation.PushAsync(new newAccount());
        }
        public void SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create().Save(account, App.Current.ToString());
            }
        }
        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.Current.ToString()).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.Current.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }
        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(App.Current.ToString()).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.Current.ToString());
            }
        }
    }
}
