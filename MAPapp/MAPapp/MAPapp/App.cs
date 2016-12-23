using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class App : Application
	{
       
        MasterDetailPage master;
        NavigationPage navigation;
		public App ()
		{
            
        // The root page of your application
        SaveTestData.CreateTestData();
            GeneralSettings.GetColors();
            MainPage = master = new MasterDetailPage() {Detail = navigation =  new NavigationPage(new HomePage()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor }, Master = new ContentPage() {Title = "titel" } };
            
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
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
