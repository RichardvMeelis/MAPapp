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
            Title = "Projects";
            BackgroundColor = Color.White;
            
            List<Project> projects = new List<Project>();
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                projects.Add(new Project(DateTime.Today, new DateTime(2016, r.Next(1, 12), r.Next(1, 30)), "Project " + i, "BlinkLaneMAPapp", "testproject") { Users = new List<User> { new User("Sam", "test@test.com", "test") }, Tasks = new List<Task> { new Task(new DateTime(), "Taak 1", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)), new Task(new DateTime(), "Taak 2", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)) } });
                
            }
            //   App.page.Title = "Projects";
            projects = Sort.SortProjects(projects);
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
                    nameLabel.TextColor = Color.Black;
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("Company", BindingMode.OneWay,
                            null, null, "Company: {0:d}"));
                    CompanyLabel.TextColor = Color.Black;
                    Label birthdayLabel = new Label();
                    birthdayLabel.Text = "test";
                    birthdayLabel.TextColor = Color.Black;
                    BoxView boxView = new BoxView();
                    boxView.Color = Color.Black;
              

                  
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


            Button b = new Button() {Text = "New Project" };
            b.Clicked += B_Clicked;
            //  BackgroundColor = Color.White;
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

            await Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } },Title = f.Name });
        }
    }
}
