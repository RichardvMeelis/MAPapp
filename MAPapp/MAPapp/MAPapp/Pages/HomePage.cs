﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class HomePage : ContentPage
	{
        Button a, b, c, d;
		public HomePage ()
		{
            BackgroundColor = Color.White;
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(a = new Button() { Text = "Projecten", BackgroundColor = Color.FromRgb(0, 192, 129) },0,0);
            grid.Children.Add(b = new Button() { Text = "Poker", BackgroundColor = Color.FromRgb(0, 192, 129) }, 0, 1);
            grid.Children.Add(c = new Button() { Text = "Accout Settings", BackgroundColor = Color.FromRgb(0, 192, 129) }, 1, 0);
            grid.Children.Add(d = new Button() { Text = "Settings", BackgroundColor = Color.FromRgb(0, 192, 129) }, 1, 1);
            a.Clicked += A_Clicked;
            b.Clicked += B_Clicked;
            c.Clicked += C_Clicked;
            d.Clicked += D_Clicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { grid }
            };
			}

        private void D_Clicked(object sender, EventArgs e)
        {
            
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokerPage());
            
        }

        private async void A_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectsPage());
        }
    }
	}
