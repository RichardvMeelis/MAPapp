using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using System.Threading;

namespace MAPapp
{
	public class HomePage : ContentPage
	{
        //Alle buttons die op het homescreen staan
        Button  pokerButton, accountSettingsButton, settingsButton, informatieButton;
        Button projectButton;
        public static Stopwatch stopwatch = new Stopwatch();
        ActivityIndicator ai = new ActivityIndicator() {Color = GeneralSettings.mainColor };
		public HomePage ()
		{
           
            Title = Globals.paginahome;
            BackgroundColor = GeneralSettings.backgroundColor;
            var grid = new Grid();
            // Grid defenities aangemaakt
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            //Knoppen toevoegen aan de grid 
            grid.Children.Add(projectButton = new Button() { Text = Globals.knopprojecten, BackgroundColor = GeneralSettings.mainColor }, 0, 0);
            grid.Children.Add(pokerButton = new Button() { Text = Globals.knoppoker, BackgroundColor = GeneralSettings.mainColor }, 0, 1);
            grid.Children.Add(accountSettingsButton = new Button() { Text = Globals.knopaccount, BackgroundColor = GeneralSettings.mainColor }, 1, 1);
            grid.Children.Add(settingsButton = new Button() { Text = Globals.knopinstellingen, BackgroundColor = GeneralSettings.mainColor }, 1, 2);
            grid.Children.Add(informatieButton = new Button() { Text = Globals.knopinformatie, BackgroundColor = GeneralSettings.mainColor }, 0, 2);
            
            Grid.SetColumnSpan(projectButton,2);
           
            //Eventhandlers toewijzen aan de knoppen
            projectButton.Clicked += ProjectButtonClicked;
            pokerButton.Clicked += PokerButtonClicked;
            accountSettingsButton.Clicked += AccountSettingButtonClicked;
            settingsButton.Clicked += SettingsButtonClicked;
            informatieButton.Clicked += InformationButtonClicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = GeneralSettings.pageMargin,
                Children = { grid,ai }
            };
			}

        private async void InformationButtonClicked(object sender, EventArgs e)
        {
            informatieButton.IsEnabled = false;
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new InformationPage());
            informatieButton.IsEnabled = true;

        }

        private async void SettingsButtonClicked(object sender, EventArgs e)
        {
            settingsButton.IsEnabled = false;
            // await Navigation.PushAsync(new burndown());
            await Navigation.PushAsync(new TestPage());
            settingsButton.IsEnabled = true;
        }

        private async void AccountSettingButtonClicked(object sender, EventArgs e)
        {
            accountSettingsButton.IsEnabled = false;
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new AccountSettings());
            accountSettingsButton.IsEnabled = true;
        }

        private async void PokerButtonClicked(object sender, EventArgs e)
        {
            pokerButton.IsEnabled = false;
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new PokerPage());
            pokerButton.IsEnabled = true;
        }

        private async void ProjectButtonClicked(object sender, EventArgs e)
        {
            projectButton.IsEnabled = false;
            ai.IsRunning = true;
            //Zet de nieuwe pagina op de stack.
            var tokenSource2 = new CancellationTokenSource();
            await System.Threading.Tasks.Task.Run(() =>
            {
                List<Project> s = (List<Project>)GetFromDatabase.GetProjects(GetFromDatabase.currentUserName, GetFromDatabase.currentToken);


                Device.BeginInvokeOnMainThread(() =>
                {
                     Navigation.PushAsync(new ProjectsPage(s));
                    projectButton.IsEnabled = true;
                    ai.IsRunning = false;
                });
            },tokenSource2.Token);
            tokenSource2.Cancel();
            
        }
    }
	}

