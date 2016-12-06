using System;
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
               projects.Add( new Project(DateTime.Today,new DateTime(2016,12,5),"Project "+ i,"BlinkLaneMAPapp","testproject"));



            ListView table = new ListView
            {
                // Source of data items.
                ItemsSource = projects,
                RowHeight = 100,
                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
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
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
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




            //  BackgroundColor = Color.White;
            Content = new StackLayout {
				Children = {new Label() { Text = "Titel" },
                    new ScrollView() { Content =  table  }
				}
			};
		}
	}
}
