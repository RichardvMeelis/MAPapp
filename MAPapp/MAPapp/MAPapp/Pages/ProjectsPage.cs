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
            Title = "Projects";
            BackgroundColor = Color.White;
            
           
            
         
            SaveTestData.projects = Sort.SortProjects(SaveTestData.projects);
            ListView table = new ListView
            {
                
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = SaveTestData.projects,
                HasUnevenRows = true,
                
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.FontSize = 20;
                    nameLabel.TextColor = Color.Black;
                   
                    //Label met binding voor het bedrijf
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("Company", BindingMode.OneWay,
                            null, null, "Company: {0:d}"));
                    CompanyLabel.TextColor = Color.Black;
                  
                    //Label met binding voor de datum
                    Label endingdateLabel = new Label();
                    endingdateLabel.SetBinding(Label.TextProperty,
                        new Binding("EndingDate", BindingMode.OneWay,
                            null, null, "Einddatum: {0: dd/MM/yyyy}"));
                    endingdateLabel.TextColor = Color.Black;
                   


                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            
                            Padding = new Thickness(0, 2),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                 
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            endingdateLabel,
                                            CompanyLabel,
                                            
                                        }
                                        }
                                }
                        }
                    };
                })
            };

            table.ItemTapped += Table_ItemTapped;


            Button b = new Button() {Text = "New Project" };
            b.Clicked += B_Clicked;
            
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.FillAndExpand,
               
                Children = {b,
                    new ScrollView() { Content =  table, VerticalOptions =LayoutOptions.FillAndExpand  }, 
				}
			};
		}

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Project f = (Project)e.Item;

            await Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f) , new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } },Title = f.Name });
        }   
    }
}
