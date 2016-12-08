﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class ProjectsPage : ContentPage
	{
		public ProjectsPage ()
		{
            
            List<Project> projects = new List<Project>();
            
                for(int i =0; i<50; i++)
               projects.Add( new Project(DateTime.Today, new DateTime(2016, 12, 29), "Project " + i, "BlinkLaneMAPapp", "testproject") { Users = new List<User> {new User("Sam","test@test.com","test") } });

         //   App.page.Title = "Projects";

            ListView table = new ListView
            {
                
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = projects,
                HasUnevenRows = true,
                
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.FontSize = 20;
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("Company", BindingMode.OneWay,
                            null, null, "Company: {0:d}"));

                    Label birthdayLabel = new Label();
                    birthdayLabel.Text = "test";

                    BoxView boxView = new BoxView();
                    
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            
                            Padding = new Thickness(0, 2),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    //boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel,
                                            CompanyLabel,
                                            
                                        }
                                        }
                                }
                        }
                    };
                })
            };

            table.ItemTapped += Table_ItemTapped;
            

            //  BackgroundColor = Color.White;
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {
                    new ScrollView() { Content =  table, VerticalOptions =LayoutOptions.FillAndExpand  }
				}
			};
		}

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Project f = (Project)e.Item;

            await Navigation.PushAsync(new ProjectInfoPage(f));
        }
    }
}
