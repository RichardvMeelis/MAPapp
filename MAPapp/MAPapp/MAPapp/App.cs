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
           MainPage = new NavigationPage(new Login()) { BarBackgroundColor = GeneralSettings.mainColor, Title = "test", BarTextColor = GeneralSettings.textColor };
        }

        protected override void OnStart ()
		{
        }

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}
