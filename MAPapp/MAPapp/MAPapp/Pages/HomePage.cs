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
        Image infoImage, projectImage, pokerImage, accountImage, settingImage;

        public HomePage ()
		{
            Title = Globals.paginahome;
            BackgroundColor = GeneralSettings.backgroundColor;

            //Images worden aangemaakt en krijgen een TapGestureRecognizer om als knop te kunnen werken
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

            // Grid defenities aangemaakt
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            //Knoppen toevoegen aan de grid 
            grid.Children.Add(projectImage, 0, 0);
            grid.Children.Add(pokerImage, 0, 1);
            grid.Children.Add(accountImage, 1, 1);
            grid.Children.Add(settingImage, 1, 2);
            grid.Children.Add(infoImage, 0, 2);

            //ProjectImage twee vakken laten vullen
            Grid.SetColumnSpan(projectImage, 2);
           
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
            //Animeren van de knop
            await infoImage.ScaleTo(0.9, 100);
            await infoImage.ScaleTo(1, 100);
   
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new InformationPage());
    

        }

        private async void SettingButtonClicked(object sender, EventArgs e)
        {
            //Animeren van de knop
            await settingImage.ScaleTo(0.9, 100);
            await settingImage.ScaleTo(1, 100);
        }

        private async void AccountSettingButtonClicked(object sender, EventArgs e)
        {
            //Animeren van de knop
            await accountImage.ScaleTo(0.9, 100);
            await accountImage.ScaleTo(1, 100);
            
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new AccountSettings());
        }

        private async void PokerButtonClicked(object sender, EventArgs e)
        {
            //Animeren van de knop
            await pokerImage.ScaleTo(0.9, 100);
            await pokerImage.ScaleTo(1, 100);
            
            //Zet de nieuwe pagina op de stack.
            await Navigation.PushAsync(new PokerPage());
        }

        private async void ProjectButtonClicked(object sender, EventArgs e)
        {
            //Animeren van de knop
            await projectImage.ScaleTo(0.9, 100);
            await projectImage.ScaleTo(1, 100);
              
            var tokenSource2 = new CancellationTokenSource();

            //Een nieuwe thread openen
            await System.Threading.Tasks.Task.Run(() =>
            {
                List<Project> s = (List<Project>)ContactDataBase.GetProjects(ContactDataBase.currentUserName, ContactDataBase.currentToken);
                Device.BeginInvokeOnMainThread(() =>
                {
                    //Zet de nieuwe pagina op de stack.
                    Navigation.PushAsync(new ProjectsPage(s));                  
                });
            },tokenSource2.Token);
            
            //Sluit de thread af
            tokenSource2.Cancel();
            
        }
    }
	}

