using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp {
    public class SprintPage : ContentPage {
        ListView table;

        public SprintPage(Sprint s)
        {
            List<Task> tasks = new List<Task>();
            Title = "Current Sprint";

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
                BackgroundColor = GeneralSettings.mainColor
            };
            b.Text = "New Task";
            //  b.Clicked += B_Clicked;

            //  BackgroundColor = Color.White;]
            Label sprintName, sprintStartDate, sprintDuration, sprintTimeRemaining;
            if(s!= null)
            {
                sprintName = new Label {Text ="Name: "+ s.sprintname };
                sprintDuration = new Label {Text ="Sprint duration: "+ s.duration   };
                sprintStartDate = new Label {Text = "Start date: "+s.sprint_start_date.ToString("dd/MM/yyyy") };
                sprintTimeRemaining = new Label {Text ="Time Remaining: " + TimeRemaining(s.sprint_start_date,s.duration) };
            }
            else
            {
                sprintName = new Label { Text = "No Sprint available",TextColor = GeneralSettings.warningColor};
                sprintDuration = new Label { Text = " "  };
                sprintStartDate = new Label { Text = "" };
                sprintTimeRemaining = new Label { Text = "" };
            }
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {
                        
                         sprintName,
                         sprintStartDate,
                         sprintDuration,
                         sprintTimeRemaining,
                    new ScrollView() { Content =  table , VerticalOptions =LayoutOptions.FillAndExpand  }, b
                }
            };
            table.ItemTapped += Table_ItemTapped;
        }
        public int TimeRemaining(DateTime startDate, int duration)
        {
            startDate.AddDays(duration);
            return startDate.Subtract(DateTime.Today).Days;
        }
        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            table.IsEnabled = false;
            await Navigation.PushAsync(new TaskInfoPage((Task) e.Item));
            table.IsEnabled = true;
        }
    }
}
