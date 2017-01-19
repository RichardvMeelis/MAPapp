using System;
using System.Linq;
using Xamarin.Auth;
using System.IO;
using Xamarin.Forms;
using System.Threading;

namespace MAPapp {
    public class Login : ContentPage {
        // Invoervelden voor het inloggen
        Entry userName;
        Entry password;

        //Label om meldingen weer te geven
        Label warning;

        Button signIn;
        Switch rememberMe;

        ActivityIndicator working = new ActivityIndicator() { Color = GeneralSettings.mainColor };
        public Login()
        {
           
            BackgroundColor = GeneralSettings.backgroundColor;
            //Invoervelden worden toegewezen en eventuele opgeslagen waarden worden ingeladen
            userName = new Entry() { Placeholder = "Email", };
            userName.Text = UserName;
            password = new Entry() { Placeholder = "Password", IsPassword = true };
            password.Text = Password;
           
            /////////////////////////////////
           // working.IsRunning = true;
            working.IsEnabled = true;
            working.BindingContext = this;
          //  working.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            /////////////////////////////////
            
            //Path voor het opslaan van de switch stand
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "MySettings.txt");

            rememberMe = new Switch();
           // System.Diagnostics.Debug.WriteLine(File.ReadAllText(filename));
            
            try
            {
                //Opgeslagen waarde van de switch wordt teruggezet
                if (File.ReadAllText(filename) == "True")
                {
                    rememberMe.IsToggled = true;
                }
            }
            catch { }
            //Voor het in en uitschakelen van de signIn button
            userName.TextChanged += EntryTextChanged;
            password.TextChanged += EntryTextChanged;

            warning = new Label() { TextColor = Color.Red, Text = "" };
            signIn = new Button() { Text = Globals.login, IsEnabled = false };
            signIn.Clicked += SignInClicked;
            
            //Button inschakelen na ophalen wachtwoorden
            if( password.Text != null && userName.Text != null && password.Text.Length > 3 && userName.Text.Length > 3)
            {
                signIn.IsEnabled = true;
            }

            Content = new StackLayout
            {Margin = GeneralSettings.pageMargin,
                Children = {
                    //De aangemaakt elementen worden toegevoegd aan de stacklayout
                    new Label { Text = Globals.mail }, userName, new Label {Text = Globals.wachtwoord},password ,signIn ,new StackLayout {Children = { new Label {Text = Globals.onthouden },rememberMe },Orientation = StackOrientation.Horizontal },new ClickableLabel(NewAccountClicked) {Text = Globals.nieuwacc },warning,working, new ClickableLabel(AccountRecoveryClicked) {Text = Globals.accounntrecovery }
                }
            };
        }

        //Voor het in- en uitschakelen van de signIn button
        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (userName.Text != null && password.Text != null && userName.Text.Length >= 3 && password.Text.Length >= 3)
            {
                signIn.IsEnabled = true;
            }
            else
            {
                signIn.IsEnabled = false;
            }
        }

        //Eventhandler voor de signIn button
        private async void SignInClicked(object sender, EventArgs e)
        {
            signIn.IsEnabled = false;
               working.IsRunning = true;
            //  this.IsBusy = true;
            //De workload verdelen over meerdere Threads
            var tokenSource2 = new CancellationTokenSource();
            await System.Threading.Tasks.Task.Run(() =>
            {

                if (this.rememberMe.IsToggled)
                {
                    //Als er wordt opgeslagen moet de oude er uit, anders krijg je twee opgeslagen waarden
                    DeleteCredentials();
                    SaveCredentials(userName.Text, password.Text);
                }
                else
                    //Als iemand rememberme uit zet moet het verwijderd worden
                    DeleteCredentials();

                //Opslaan van de switch stand
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "MySettings.txt");
                File.WriteAllText(filename, this.rememberMe.IsToggled.ToString());
                string s1 = (string)GetFromDatabase.SingIn(userName.Text, password.Text);

                Device.BeginInvokeOnMainThread(() =>
                {
                    
                    if (s1.Length == 120)
                    {
                        GetFromDatabase.currentToken = s1;
                        GetFromDatabase.currentUserName = userName.Text;
                        Application.Current.MainPage = new MasterDetailPage() { Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new MasterPage() { Title = "titel" } };
                        //this.working.IsRunning = false;
                    }
                    else
                    {
                        signIn.IsEnabled = true;
                        warning.Text = Globals.warnlogin;
                        working.IsRunning = false;
                    }
                });
            },tokenSource2.Token);

            tokenSource2.Cancel();  
            
        }

        //Eventhandler van nieuwAccount label
        public async void NewAccountClicked(String s)
        {
            await Navigation.PushAsync(new newAccount());
        }

        //Eventhandler Wachtwoord vergeten
        public async void AccountRecoveryClicked(String s)
        {
            await Navigation.PushAsync(new AccountRecoveryPage());
        }

        //Het opslaan van signIn gegevens
        public void SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                //Er wordt gebruikt gemaakt van Xamrin.Auth.Account dit is een klasse die gebruikt van gelijke klassen in android en IOS, waarmee je veilig wachtwoorden kan opslaan
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create().Save(account, App.Current.ToString());
            }
        }
        //Username property(Username wordt opgehaald uit het opgeslagen account object)
        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.Current.ToString()).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }
        
        //Password property(Password wordt opgehaald uit het opgeslagen account object)
        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.Current.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }
        
        //Opgeslagen account wordt verweiderd
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
