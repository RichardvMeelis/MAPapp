using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class App : Application
	{

        static public int ScreenWidth;
        public App ()
		{
            
        // The root page of your application
            GeneralSettings.GetColors();
            try
            {
                MainPage = new NavigationPage(new Login()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor };//master = new MasterDetailPage() {Detail = navigation =  new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new ContentPage() {Title = "titel" } };
            }
            catch
            {
                List<Page> pages = App.Current.MainPage.Navigation.NavigationStack.ToList();
                pages[App.Current.MainPage.Navigation.NavigationStack.Count - 1].DisplayAlert("Something went wrong", "Oops something went wrong, please restart the app", "OK");
                App.Current.MainPage.DisplayAlert("Something went wrong", "Oops something went wrong, please restart the app", "OK");
            };
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
          
            List<Page> pages = App.Current.MainPage.Navigation.NavigationStack.ToList();
            pages[App.Current.MainPage.Navigation.NavigationStack.Count - 1].DisplayAlert("Something went wrong", "Oops something went wrong, please restart the app", "OK");
            App.Current.MainPage.DisplayAlert("Something went wrong","Oops something went wrong, please restart the app","OK" );
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            System.Diagnostics.Debug.WriteLine(newExc.StackTrace);
        }
        protected override void OnStart ()
		{
           
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
