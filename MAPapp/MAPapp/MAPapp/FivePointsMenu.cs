using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MAPapp
{
	public class FivePointsMenu : ContentPage
	{
        InformationObject b;

        public async void VolgendePagina(string s)
        {
            if (s == b.FivePoints[0])
                await Navigation.PushAsync(new TextPageInformation(b.TextPages[0]));
            if (s == b.FivePoints[1])
                await Navigation.PushAsync(new TextPageInformation(b.TextPages[1]));
            if (s == b.FivePoints[2])
                await Navigation.PushAsync(new TextPageInformation(b.TextPages[2]));
            if (s == b.FivePoints[3])
                await Navigation.PushAsync(new TextPageInformation(b.TextPages[3]));
            if (s == b.FivePoints[4])
                await Navigation.PushAsync(new TextPageInformation(b.TextPages[4]));
        }
        public FivePointsMenu(InformationObject b)
        {
            this.b = b;
            StackLayout stack = new StackLayout();
            if (b.FivePoints != null)
            {
               
                foreach (String s in b.FivePoints)
                    stack.Children.Add(new ClickableLabel(VolgendePagina) { Text = s, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 });
            }
                BackgroundColor = Color.White;
            Content = stack;
            
        }
	}
}
