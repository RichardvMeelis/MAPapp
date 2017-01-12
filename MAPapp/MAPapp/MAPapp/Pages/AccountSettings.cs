using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class AccountSettings : ContentPage
	{
		public AccountSettings ()

		{
			Content = new StackLayout { 
                Margin = GeneralSettings.pageMargin,
				Children = {
					new Label { Text = "Wachtwoord" }
                    
				}
			};
		}
	}
}
