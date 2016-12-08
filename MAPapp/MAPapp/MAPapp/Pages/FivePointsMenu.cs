using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class FivePointsMenu : ContentPage
	{
        String a = "a", b = "b", c = "c", d = "d", e = "e";
        public async void VolgendePagina(string s)
        {
            if (s == a)
                await Navigation.PushAsync(new ContentPage() { Content = new StackLayout { Children = { new Label() { Text = "Hii" } } } });
            if (s == b)
                await Navigation.PushAsync(new ContentPage() { Content = new StackLayout { Children = { new Label() { Text = "Hoi" } } } });
            if (s == c)
                await Navigation.PushAsync(new ContentPage() { Content = new StackLayout { Children = { new Label() { Text = "Hai" } } } });
            if (s == d)
                await Navigation.PushAsync(new ContentPage() { Content = new StackLayout { Children = { new Label() { Text = "Hui" } } } });
            if (s == e)
                await Navigation.PushAsync(new ContentPage() { Content = new StackLayout { Children = { new Label() { Text = "Hei" } } } });
        }
        public FivePointsMenu(List<String> f)
        {
            StackLayout stack = new StackLayout();
            if (f != null)
            {
               
                foreach (String s in f)
                    stack.Children.Add(new ClickableLabel(VolgendePagina) { Text = s, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 });
            }
                BackgroundColor = Color.White;
            Content = stack;
            
        }
	}
}
