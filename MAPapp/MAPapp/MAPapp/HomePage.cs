using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            grid.Children.Add(new Button() {Text = "hoi" },0,0);
            grid.Children.Add(new Button() { Text = "hoi" }, 0, 1);
            grid.Children.Add(new Button() { Text = "hoi" }, 1, 0);
            grid.Children.Add(new Button() { Text = "hoi" }, 1, 1);

            Content = new StackLayout
            {
                Children = { grid }
            };
			}
		}
	}

