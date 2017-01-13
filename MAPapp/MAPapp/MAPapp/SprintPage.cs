using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp {
    public class SprintPage : ContentPage {
        public SprintPage(Sprint s)
        {
            List<Task> tasks = new List<Task>();
            Title = "Current Sprint";
            tasks = s.Sprinttasks;
            if (tasks != null)
                tasks = Sort.SortTasks(tasks);
            ListView table = new ListView
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

                    //Label birthdayLabel = new Label();
                    //birthdayLabel.Text = "test";
                    //birthdayLabel.TextColor = Color.Black;




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

            //  BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {

                         new Label {Text = s.sprintid.ToString() },
                    new ScrollView() { Content =  table , VerticalOptions =LayoutOptions.FillAndExpand  }, b
                }
            };
            table.ItemTapped += Table_ItemTapped;
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskInfoPage((Task) e.Item));
        }
    }
}
