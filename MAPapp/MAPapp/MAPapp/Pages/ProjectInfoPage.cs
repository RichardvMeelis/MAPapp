using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class ProjectInfoPage : ContentPage {
        ListView table;
        Project ding;
        Button b;

        public ProjectInfoPage (Project s)
		{
            ding = s;
            Title = Globals.tabprojectinfo;
            BackgroundColor = GeneralSettings.backgroundColor;
            List<Task> tasks = s.Tasks;
            // tasks.Sort();
            if(tasks != null)
           tasks =  Sort.SortTasks(tasks);
            Icon = "Projecten.png";
            //   App.page.Title = "Projects";
            foreach(Task t in tasks)
            {
                if (t.timecompleted == null && t.firstname == null && t.lastname == null)
                    t.CompletedColor = Color.Red;
                else if (t.timecompleted == null && t.firstname != null && t.lastname != null)
                    t.CompletedColor = Color.Yellow;
                else
                {
                    t.CompletedColor = Color.Green;
                }
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

                    Label JSLabel = new Label();
                    JSLabel.SetBinding(Label.TextProperty,
                        new Binding("JSPoints", BindingMode.OneWay,
                            null, null, Globals.jobsize + ": {0:d}"));
                    JSLabel.TextColor = GeneralSettings.textColor;

                    Label importancePointsLabel = new Label();
                    importancePointsLabel.SetBinding(Label.TextProperty,
                        new Binding("UBVPoints", BindingMode.OneWay,
                            null, null, Globals.ubv + ": {0:d}"));
                    importancePointsLabel.TextColor = GeneralSettings.textColor;

////////////////////////////////////////////////////////////////////////
                    BoxView boxView = new BoxView();
                    //boxView.Opacity = 0.5;
                    boxView.HorizontalOptions = LayoutOptions.Fill;
                    boxView.VerticalOptions = LayoutOptions.Fill;
                    boxView.SetBinding(BoxView.ColorProperty, "CompletedColor");
//////////////////////////////////////////////////////////////////////////////////
                    //table.BackgroundColor = boxView.BackgroundColor;
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
                                    boxView,
                                    
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            //birthdayLabel,
                                            JSLabel,importancePointsLabel,

                                        }
                                        }
                                }
                        }
                    };
                })
            };
            table.VerticalOptions = LayoutOptions.StartAndExpand;
            b = new Button() {BackgroundColor = GeneralSettings.mainColor,
                Text = Globals.knopnieuwetaak, TextColor = GeneralSettings.textColor
            };
           
            b.Clicked += B_Clicked;
            
           
            //  BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {  new Label {Text = Globals.datumbegin + " " +  s.start_date.ToString("dd/MM/yyyy "), TextColor = GeneralSettings.textColor
        },
                                    new Label {Text = Globals.datumeind + " " +  s.EndingDate.ToString("dd/MM/yyyy "), TextColor =  GeneralSettings.textColor  },
                                    new Label {Text = Globals.deelnemers + " " + User.UserListToString(s.Users), TextColor =  GeneralSettings.textColor  },

                    new ScrollView() {Content = new Label {Text = Globals.beschrijving + " " + s.projectdescription, TextColor =  GeneralSettings.textColor}},
                    table, b  
                }
            };
            table.ItemTapped += Table_ItemTapped;
        }

       
        private async void B_Clicked(object sender, EventArgs e)
        {
            b.IsEnabled = false;
            await Navigation.PushAsync(new NewTaskPage(ding));
            b.IsEnabled = true;
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            table.IsEnabled = false;
           await Navigation.PushAsync(new TaskInfoPage((Task)e.Item));
            table.IsEnabled = true;
        }
    }
	}


