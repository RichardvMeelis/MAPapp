using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class InformationPage : ContentPage
	{
        String a = "a", b = "b", c = "c";
        List<String> d = new List<string>() {"a","b","c","d","e" }, e = new List<string>() { "a", "b", "c", "d", "e" }, f = new List<string>() { "a", "b", "c", "d", "e" };
        public async void VolgendePagina(string s)
        {  if (s == a)
                await Navigation.PushAsync(new FivePointsMenu(d));
           else if (s == b)
                await Navigation.PushAsync(new FivePointsMenu(e));
           else
                await Navigation.PushAsync(new FivePointsMenu(f));

        }
        public InformationPage ()
		{
            BackgroundColor = Color.White;
			Content = new StackLayout {
				Children = {
					new ClickableLabel(VolgendePagina) { Text = a, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 },
                    new ClickableLabel(VolgendePagina) { Text = b, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 },
                    new ClickableLabel(VolgendePagina) { Text = c, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 }
                }
			};
		}
	} 
}
