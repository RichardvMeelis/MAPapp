using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class HomePage : ContentPage
	{
        //Alle buttons die op het homescreen staan
        Button projectButton, pokerButton, accountSettingsButton, settingsButton, informatieButton;
       public static Stopwatch stopwatch = new Stopwatch();
        ActivityIndicator ai = new ActivityIndicator() {Color = GeneralSettings.mainColor };
		public HomePage ()
		{

            Title = "Homepage";
            BackgroundColor = GeneralSettings.backgroundColor;
            var grid = new Grid();
            // Grid defenities aangemaakt
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            
            //Knoppen toevoegen aan de grid 
            grid.Children.Add(projectButton = new Button() { Text = "Projecten", BackgroundColor = GeneralSettings.mainColor},0,0);
            grid.Children.Add(pokerButton = new Button() { Text = "Poker", BackgroundColor = GeneralSettings.mainColor }, 0, 1);
            grid.Children.Add(accountSettingsButton = new Button() { Text = "Account Settings", BackgroundColor = GeneralSettings.mainColor }, 1, 1);
            grid.Children.Add(settingsButton = new Button() { Text = "Settings", BackgroundColor = GeneralSettings.mainColor }, 1, 2);
            grid.Children.Add(informatieButton = new Button() { Text = "Informatie", BackgroundColor = GeneralSettings.mainColor }, 0, 2);
            
            Grid.SetColumnSpan(projectButton,2);

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
                Margin = GeneralSettings.pageMargin,
                Children = { grid,ai }
            };
			}

        private async void E_Clicked(object sender, EventArgs e)
        {
            
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new InformationPage());
          
        }

        private async void D_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new burndown());
            
        }

        private async void C_Clicked(object sender, EventArgs e)
        {
            
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new AccountSettings());
           
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new PokerPage());
            
        }

        private async void A_Clicked(object sender, EventArgs e)
        {
            ai.IsRunning = true;
            //Zet de nieuwe pagina op de stack.
            await System.Threading.Tasks.Task.Run(() =>
            {
                List<Project> s = GetFromDatabase.getProjects(GetFromDatabase.currentUserName, GetFromDatabase.currentToken);


                Device.BeginInvokeOnMainThread(() =>
                {
                     Navigation.PushAsync(new ProjectsPage(s));
                    ai.IsRunning = false;
                });
            });
            
            
        }
    }
	}

