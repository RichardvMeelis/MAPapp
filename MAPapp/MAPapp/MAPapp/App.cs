using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class App : Application
	{
       public  NavigationPage page;
		public App ()
		{
            // The root page of your application
            
            MainPage = page =new NavigationPage(new HomePage()) { BarBackgroundColor = Color.FromRgb(0, 192, 129), Title = "test", BarTextColor = Color.Black, };

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
