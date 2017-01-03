using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TextPageInformation : ContentPage
	{
		public TextPageInformation (string s)
		{
            BackgroundColor = GeneralSettings.backgroundColor;
			Content = new StackLayout {
				Children = {
					new ScrollView() {Content = new StackLayout() {Children = { new Label {Text = s} } } }
				}
			};
		}
	}
}
