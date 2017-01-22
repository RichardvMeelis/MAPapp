using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp {
    public class SprintPage : ContentPage {
        ListView table;
        
        Sprint givenSprint;
        List<Task> givenTasks = new List<Task>();
        Project f;
        public SprintPage(Sprint s, List<Task> projectTasks,Project project)
        {
            Title = Globals.nieuwesprintpaginatitel;
            givenTasks = projectTasks;
            givenSprint = s;
            this.f = project;
            List<Task> tasks = new List<Task>();
            Title = Globals.paginasprint;
            BackgroundColor = GeneralSettings.backgroundColor;
            Icon = "Calender.png";

            if (s != null && s.Sprinttasks != null)
            {
                tasks = s.Sprinttasks;
                tasks = Sort.SortTasks(tasks);
            }
             table = new ListView
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = tasks,
                HasUnevenRows = true,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "taskname");
                    nameLabel.FontSize = 20;
                    nameLabel.TextColor = GeneralSettings.textColor;

                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("JSPoints", BindingMode.OneWay,
                            null, null, "Job Size: {0:d}"));
                    CompanyLabel.TextColor = GeneralSettings.textColor;

                    Label importancePointsLabel = new Label();
                    importancePointsLabel.SetBinding(Label.TextProperty,
                        new Binding("UBVPoints", BindingMode.OneWay,
                            null, null, "User- business value: {0:d}"));
                    importancePointsLabel.TextColor = GeneralSettings.textColor;


                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Margin = GeneralSettings.pageMargin,
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
                                            //birthdayLabel,
                                            CompanyLabel,importancePointsLabel,

                                        }
                                        }
                                }
                        }
                    };
                })
            };

            Button b = new Button()
            {
                BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.textColor

            };
            b.Text = Globals.knoptaaktoevoegen;
            b.Clicked += B_Clicked;

            Label sprintName, sprintStartDate, sprintDuration, sprintTimeRemaining;
            if(s!= null)
            {
                sprintName = new Label {Text ="Name: "+ s.sprintname, TextColor = GeneralSettings.textColor};
                sprintDuration = new Label {Text ="Sprint duration: "+ s.duration, TextColor = GeneralSettings.textColor};
                sprintStartDate = new Label {Text = "Start date: "+s.sprint_start_date.ToString("dd/MM/yyyy"), TextColor = GeneralSettings.textColor};
                sprintTimeRemaining = new Label {Text ="Time Remaining: " + TimeRemaining(s.sprint_start_date,s.duration) + " Dagen", TextColor = GeneralSettings.textColor};
            }
            else
            {
                sprintName = new Label { Text = "No Sprint available",TextColor = GeneralSettings.warningColor};
                sprintDuration = new Label { Text = " " , TextColor = GeneralSettings.textColor };
                sprintStartDate = new Label { Text = "", TextColor = GeneralSettings.textColor };
                sprintTimeRemaining = new Label { Text = "" , TextColor = GeneralSettings.textColor};
            }
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                        
                         sprintName,
                         sprintStartDate,
                         sprintDuration,
                         sprintTimeRemaining,
                         table, b
                }
            };
            table.ItemTapped += Table_ItemTapped;
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskToSprintPage(givenSprint,givenTasks, f));
        }

        public int TimeRemaining(DateTime startDate, int duration)
        {
           DateTime adjusted =  startDate.AddDays(duration);
            return adjusted.Subtract(DateTime.Today).Days;
        }
        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            table.IsEnabled = false;
            await Navigation.PushAsync(new TaskInfoPage((Task) e.Item));
            table.IsEnabled = true;
        }
    }
}
