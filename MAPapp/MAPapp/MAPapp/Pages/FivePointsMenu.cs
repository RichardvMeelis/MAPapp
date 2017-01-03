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
            foreach(Tip b in b.Tips)
                if (s == b.ACName)
                    await Navigation.PushAsync(new TextPageInformation(b.ACDescription));
        }
        public FivePointsMenu(InformationObject b)
        {
            BackgroundColor = GeneralSettings.backgroundColor;
            this.b = b;
            StackLayout stack = new StackLayout();
            if (b.Tips != null)
            {
               
                foreach (Tip s in b.Tips)
                    stack.Children.Add(new ClickableLabel(VolgendePagina) { Text = s.ACName, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 });
            }
                
            Content = stack;
            
        }
	}
}
