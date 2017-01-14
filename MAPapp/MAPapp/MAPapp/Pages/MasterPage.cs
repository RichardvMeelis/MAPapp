using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class MasterPage : ContentPage
	{
		public MasterPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello Page" }
				}
			};
		}
	}
}
