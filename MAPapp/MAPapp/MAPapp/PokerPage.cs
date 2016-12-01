using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class PokerPage : ContentPage
	{
       static ClickableLabel label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11;
        static Label label12;
        //List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11};
		public PokerPage ()
		{
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(label12 = new Label() {  }, 6, 0);
            grid.Children.Add(label1 = new ClickableLabel(OnLabelClicked) { Text = "1" }, 0, 5);
            grid.Children.Add(label2 = new ClickableLabel(OnLabelClicked) { Text = "2" }, 1, 5);
            grid.Children.Add(label3 = new ClickableLabel(OnLabelClicked) { Text = "3" }, 2, 5);
            grid.Children.Add(label4 = new ClickableLabel(OnLabelClicked) { Text = "4" }, 3, 5);
            grid.Children.Add(label5 = new ClickableLabel(OnLabelClicked) { Text = "5" }, 4, 5);
            grid.Children.Add(label6 = new ClickableLabel(OnLabelClicked) { Text = "6" }, 5, 5);
            grid.Children.Add(label7 = new ClickableLabel(OnLabelClicked) { Text = "7" }, 6, 5);
            grid.Children.Add(label8 = new ClickableLabel(OnLabelClicked) { Text = "8" }, 7, 5);
            grid.Children.Add(label9 = new ClickableLabel(OnLabelClicked) { Text = "9" }, 8, 5);
            grid.Children.Add(label10 = new ClickableLabel(OnLabelClicked) { Text = "10" }, 9, 5);
            grid.Children.Add(label11 = new ClickableLabel(OnLabelClicked) { Text = "?" }, 10, 5);

            label12.FontSize = 40;
            
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {grid}
			};
		}

        public void OnLabelClicked(String s)
        {
            label12.Text = s;
        }
    }
}
