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
            //Vergelijkt de doorgegeven string met alle tipobjecten
            foreach (Tip b in b.Tips)
                if (s ==b.ACName)
                    //Open de tekstpagina met de string uit de juiste tip
                    await Navigation.PushAsync(new TextPageInformation(b.ACDescription));
        }
        public FivePointsMenu(InformationObject b)
        {
            BackgroundColor = GeneralSettings.backgroundColor;
            this.b = b;
            //Maak een nieuwe Stacklayout
            StackLayout stack = new StackLayout() {Margin = GeneralSettings.pageMargin };
            if (b.Tips != null)
            {
               //Creërt ClickableLabels. Hierdoor kan er zelf bepaald worden hoeveel tips er zijn. 
                foreach (Tip s in b.Tips)
                    stack.Children.Add(new ClickableLabel(VolgendePagina,24) { Text = s.ACName, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center });
            }
                
            Content = stack;
            
        }
	}
}
