using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class ProjectInfoPage : ContentPage
	{
		public ProjectInfoPage (Project s)
		{
            List<Task> tasks = s.Tasks;
           // tasks.Sort();
            //   App.page.Title = "Projects";

            ListView table = new ListView
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = tasks,
                HasUnevenRows = true,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.

                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.FontSize = 20;
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("difficultyPoints", BindingMode.OneWay,
                            null, null, "difficultyPoints: {0:d}"));
                    Label importancePointsLabel = new Label();
                    importancePointsLabel.SetBinding(Label.TextProperty,
                        new Binding("importancePoints", BindingMode.OneWay,
                            null, null, "importancePoints: {0:d}"));

                    Label birthdayLabel = new Label();
                    birthdayLabel.Text = "test";

                    BoxView boxView = new BoxView();

                    

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
                                            CompanyLabel,importancePointsLabel,

                                        }
                                        }
                                }
                        }
                    };
                })
            };

          


            //  BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {  new Label {Text ="Startdatum: " +  s.StartingDate.ToString("dd/MM/yyyy ") },
                                    new Label {Text ="Einddatum: " +  s.EndingDate.ToString("dd/MM/yyyy ") },
                                    new Label {Text = "Users: " + User.UserListToString(s.Users) },
                                    new Label {Text = "Beschrijving: " + s.Description },
                    new ScrollView() { Content =  table , VerticalOptions =LayoutOptions.FillAndExpand  }
                }
            };
        }
    }
	}


