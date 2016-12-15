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
            Title = "Project information";
            BackgroundColor = Color.White;
            List<Task> tasks = s.Tasks;
            // tasks.Sort();
            if(tasks != null)
            tasks =  Sort.SortTasks(tasks);
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
                    nameLabel.TextColor = Color.Black;
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("difficultyPoints", BindingMode.OneWay,
                            null, null, "difficultyPoints: {0:d}"));
                    CompanyLabel.TextColor = Color.Black;
                    Label importancePointsLabel = new Label();
                    importancePointsLabel.SetBinding(Label.TextProperty,
                        new Binding("importancePoints", BindingMode.OneWay,
                            null, null, "importancePoints: {0:d}"));
                    importancePointsLabel.TextColor = Color.Black;
                    Label birthdayLabel = new Label();
                    birthdayLabel.Text = "test";
                    birthdayLabel.TextColor = Color.Black;
                    BoxView boxView = new BoxView();
                    boxView.Color = Color.Black;



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

                Children = {  new Label {Text ="Startdatum: " +  s.StartingDate.ToString("dd/MM/yyyy "), TextColor = Color.Black },
                                    new Label {Text ="Einddatum: " +  s.EndingDate.ToString("dd/MM/yyyy "), TextColor = Color.Black  },
                                    new Label {Text = "Users: " + User.UserListToString(s.Users), TextColor = Color.Black  },
                                    new Label {Text = "Beschrijving: " + s.Description, TextColor = Color.Black  },
                    new ScrollView() { Content =  table , VerticalOptions =LayoutOptions.FillAndExpand  }
                }
            };
            table.ItemTapped += Table_ItemTapped;
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           await Navigation.PushAsync(new TaskInfoPage((Task)e.Item));
        }
    }
	}


