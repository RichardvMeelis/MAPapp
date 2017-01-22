﻿using System;
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
        Image z;
        public HomePage ()
		{
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += InformationButtonClicked;
            z = new Image();
            z.Source = "InformatieButton2.png";
            z.GestureRecognizers.Add(tap);
           
            z.Scale = 1;
            Title = Globals.paginahome;
            BackgroundColor = GeneralSettings.backgroundColor;
            var grid = new Grid();
            // Grid defenities aangemaakt
            // grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.15, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.04, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            // grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.04, GridUnitType.Star) });

            //Knoppen toevoegen aan de grid 
            grid.Children.Add(projectButton = new Button() { /*Text = Globals.knopprojecten,*/ BackgroundColor = GeneralSettings.mainColor, Image = "ProjectenButton.png"}, 0, 0);
            grid.Children.Add(pokerButton = new Button() { /* Text = Globals.knoppoker,*/ BackgroundColor = GeneralSettings.mainColor, Image = "PlanningPokerButton.png" }, 0, 1);
            grid.Children.Add(accountSettingsButton = new Button() { /*Text = Globals.knopaccount,*/ BackgroundColor = GeneralSettings.mainColor, Image = "MijnAccountButton.png" }, 1, 1);
            grid.Children.Add(settingsButton = new Button() {/* Text = Globals.knopinstellingen,*/ BackgroundColor = GeneralSettings.mainColor, Image = "InstellingenButton.png" }, 1, 2);
            grid.Children.Add(z, 0, 2);//informatieButton = new Button() { /*Text = Globals.knopinformatie,*/ BackgroundColor = GeneralSettings.mainColor, Image = "InformatieButton.png" }, 0, 2);

            Grid.SetColumnSpan(projectButton, 2);

            //Eventhandlers toewijzen aan de knoppen
            projectButton.Clicked += ProjectButtonClicked;
            pokerButton.Clicked += PokerButtonClicked;
            accountSettingsButton.Clicked += AccountSettingButtonClicked;
            settingsButton.Clicked += SettingsButtonClicked;
          //  informatieButton.Clicked += InformationButtonClicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = GeneralSettings.pageMargin,
                Children = { grid }
            };
			}

        private async void InformationButtonClicked(object sender, EventArgs e)
        {
            await z.ScaleTo(0.9, 100);
            await z.ScaleTo(1, 100);
         //   informatieButton.IsEnabled = false;
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new InformationPage());
         //   informatieButton.IsEnabled = true;

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

