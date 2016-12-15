using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class HomePage : ContentPage
	{
        Button projectButton, pokerButton, accountSettingsButton, settingsButton, informatieButton;
		public HomePage ()
		{
            Title = "Homepage";
            BackgroundColor = Color.White;
            var grid = new Grid();
            // Grid defenities aangemaakt
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            
            //Knoppen toevoegen aan de grid 
            grid.Children.Add(projectButton = new Button() { Text = "Projecten", BackgroundColor = Color.FromRgb(0, 192, 129) },0,0);
            grid.Children.Add(pokerButton = new Button() { Text = "Poker", BackgroundColor = Color.FromRgb(0, 192, 129) }, 0, 1);
            grid.Children.Add(accountSettingsButton = new Button() { Text = "Account Settings", BackgroundColor = Color.FromRgb(0, 192, 129) }, 1, 0);
            grid.Children.Add(settingsButton = new Button() { Text = "Settings", BackgroundColor = Color.FromRgb(0, 192, 129) }, 1, 1);
            grid.Children.Add(informatieButton = new Button() { Text = "Informatie", BackgroundColor = Color.FromRgb(0, 192, 129) }, 0, 2);

            Grid.SetColumnSpan(informatieButton,2);

            //Eventhandlers toewijzen aan de knoppen
            projectButton.Clicked += A_Clicked;
            pokerButton.Clicked += B_Clicked;
            accountSettingsButton.Clicked += C_Clicked;
            settingsButton.Clicked += D_Clicked;
            informatieButton.Clicked += E_Clicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { grid }
            };
			}

        private async void E_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformationPage());

        }

        private void D_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void C_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountSettings());
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

