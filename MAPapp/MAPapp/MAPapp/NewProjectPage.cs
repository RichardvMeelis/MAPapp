using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewProjectPage : ContentPage
	{
		public NewProjectPage ()
		{
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(new Label {Text = "tekst" }, 0, 0);
            grid.Children.Add(new Entry(), 1, 0);
            grid.Children.Add(new Label { Text = "tekst" }, 0, 1);
            grid.Children.Add(new Entry(), 1, 1); grid.Children.Add(new Label { Text = "tekst" }, 0, 2);
            grid.Children.Add(new Entry(), 1, 2); grid.Children.Add(new Label { Text = "tekst" }, 0, 3);
            grid.Children.Add(new Entry(), 1, 3);
            Button b = new Button() { Text = "Create", HorizontalOptions = LayoutOptions.Center };
            b.Clicked += B_Clicked;
            Content = new StackLayout {
				Children = {
					grid, b
				}
			};
		}

        private void B_Clicked(object sender, EventArgs e)
        {
          
        }
    }
}
