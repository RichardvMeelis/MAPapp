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
        public static Stopwatch stopwatch = new Stopwatch();
        ActivityIndicator ai = new ActivityIndicator() {Color = GeneralSettings.mainColor };
        Image infoImage, projectImage, pokerImage, accountImage, settingImage;
        public HomePage ()
		{
            TapGestureRecognizer tapInfo = new TapGestureRecognizer();
            tapInfo.Tapped += InformationButtonClicked;
            infoImage = new Image();
            infoImage.Source = "infoButton.png";
            infoImage.GestureRecognizers.Add(tapInfo);
            infoImage.Scale = 1;
            TapGestureRecognizer tapSetting = new TapGestureRecognizer();
            tapSetting.Tapped += SettingButtonClicked;
            settingImage = new Image();
            settingImage.Source = "instellingButton.png";
            settingImage.GestureRecognizers.Add(tapSetting);
            settingImage.Scale = 1;
            TapGestureRecognizer tapPoker = new TapGestureRecognizer();
            tapPoker.Tapped += PokerButtonClicked;
            pokerImage = new Image();
            pokerImage.Source = "pokerButton.png";
            pokerImage.GestureRecognizers.Add(tapPoker);
            pokerImage.Scale = 1;
            TapGestureRecognizer tapAccount = new TapGestureRecognizer();
            tapAccount.Tapped += AccountSettingButtonClicked;
            accountImage = new Image();
            accountImage.Source = "accountButton.png";
            accountImage.GestureRecognizers.Add(tapAccount);
            accountImage.Scale = 1;
            TapGestureRecognizer tapProject = new TapGestureRecognizer();
            tapProject.Tapped += ProjectButtonClicked;
            projectImage = new Image();
            projectImage.Source = "projectButton.png";
            projectImage.GestureRecognizers.Add(tapProject);
            projectImage.Scale = 1;

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
            grid.Children.Add(projectImage, 0, 0);
            grid.Children.Add(pokerImage, 0, 1);
            grid.Children.Add(accountImage, 1, 1);
            grid.Children.Add(settingImage, 1, 2);
            grid.Children.Add(infoImage, 0, 2);//informatieButton = new Button() { /*Text = Globals.knopinformatie,*/ BackgroundColor = GeneralSettings.mainColor, Image = "InformatieButton.png" }, 0, 2);

            Grid.SetColumnSpan(projectImage, 2);
            //Eventhandlers toewijzen aan de knoppen
            // projectButton.Clicked += ProjectButtonClicked;
            // pokerButton.Clicked += PokerButtonClicked;
            // accountSettingsButton.Clicked += AccountSettingButtonClicked;
            //settingsButton.Clicked += SettingsButtonClicked;
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
            await infoImage.ScaleTo(0.9, 100);
            await infoImage.ScaleTo(1, 100);
         //   informatieButton.IsEnabled = false;
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new InformationPage());
         //   informatieButton.IsEnabled = true;

        }

        private async void SettingButtonClicked(object sender, EventArgs e)
        {
            await settingImage.ScaleTo(0.9, 100);
            await settingImage.ScaleTo(1, 100);
            // await Navigation.PushAsync(new burndown());
            await Navigation.PushAsync(new TestPage());
        }

        private async void AccountSettingButtonClicked(object sender, EventArgs e)
        {
            await accountImage.ScaleTo(0.9, 100);
            await accountImage.ScaleTo(1, 100);
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new AccountSettings());

        }

        private async void PokerButtonClicked(object sender, EventArgs e)
        {
            await pokerImage.ScaleTo(0.9, 100);
            await pokerImage.ScaleTo(1, 100);
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new PokerPage());
        }

        private async void ProjectButtonClicked(object sender, EventArgs e)
        {
            await projectImage.ScaleTo(0.9, 100);
            await projectImage.ScaleTo(1, 100);
            ai.IsRunning = true;
            //Zet de nieuwe pagina op de stack.
            var tokenSource2 = new CancellationTokenSource();
            await System.Threading.Tasks.Task.Run(() =>
            {
                List<Project> s = (List<Project>)GetFromDatabase.GetProjects(GetFromDatabase.currentUserName, GetFromDatabase.currentToken);


                Device.BeginInvokeOnMainThread(() =>
                {
                     Navigation.PushAsync(new ProjectsPage(s));
                    ai.IsRunning = false;
                });
            },tokenSource2.Token);
            tokenSource2.Cancel();
            
        }
    }
	}

