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
        SaveTestData.CreateTestData();
            GeneralSettings.GetColors();
            MainPage = new NavigationPage(new Login()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor };//master = new MasterDetailPage() {Detail = navigation =  new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new ContentPage() {Title = "titel" } };
            
            
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
