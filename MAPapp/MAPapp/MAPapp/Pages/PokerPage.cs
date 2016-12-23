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
            Title = "Planningpoker";
            BackgroundColor = GeneralSettings.backgroundColor;
            var grid = new Grid();
            //Grid defenitions toevoegen
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
         
            //Nieuwe labels toevoegen aan het grid
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 1 " }, 0, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 2 " }, 1, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 3 " }, 2, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 4 " }, 3, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 5 " }, 4, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 6 " }, 5, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 7 " }, 6, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 8 " }, 7, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 9 " }, 8, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " 10 "}, 9, 5);
            grid.Children.Add(new ClickableLabel(OnLabelClicked,20) { Text = " ? " }, 10,5);
            
            //Label voor output definiëren
            label12 = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 80,
                TextColor = GeneralSettings.textColor
            };

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {label12,grid}
			};
		}

        public void OnLabelClicked(String s)
        {
            label12.Text = s;
        }
    }
}
