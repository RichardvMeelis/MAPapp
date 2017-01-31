using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class PokerPage : ContentPage
	{
       
        static Label label12;
        
		public PokerPage ()
		{
            //Maak fontsize op basis van schermgrootte
            int fontSize = App.ScreenWidth / 30;
            Title = "Planningpoker";
            BackgroundColor = GeneralSettings.backgroundColor;
            //Maak stacklayout voor de nummers
            StackLayout stack = new StackLayout { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp1 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp2 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp3 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp4 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp5 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp6 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp7 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp8 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp9 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp10 });
            stack.Children.Add(new ClickableLabel(OnLabelClicked, fontSize) { Text = Globals.pp11 });
            //Label voor output definiëren
            label12 = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = App.ScreenWidth/5,
                TextColor = GeneralSettings.textColor
            };

            //Voeg content toe aan stacklayout
            Content = new StackLayout {
                Margin = GeneralSettings.pageMargin,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {label12,stack}
			};
		}

        //Laat getal zien waar op gedrukt is
        public void OnLabelClicked(String s)
        {
            label12.Text = s;
        }
    }
}
