using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
    public class JoinProjectPage : ContentPage
    {
        Project ding;
        Boolean test = true;
        Label warning = new Label() { TextColor = Color.Red };
        public JoinProjectPage(Project s)
        {
            ding = s;
            Title = "Project information";
            BackgroundColor = GeneralSettings.backgroundColor;
            List<Task> tasks = s.Tasks;
            // tasks.Sort();
            if (tasks != null)
                tasks = Sort.SortTasks(tasks);
            //   App.page.Title = "Projects";


            Button b = new Button()
            {
                BackgroundColor = GeneralSettings.mainColor
            };
            b.Text = "Join Project";
            b.Clicked += B_Clicked;

            //  BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = { 
                                    new Label {Text ="Startdatum: " +  s.start_date.ToString("dd/MM/yyyy "), TextColor = GeneralSettings.textColor},
                                    new Label {Text ="Einddatum: " +  s.EndingDate.ToString("dd/MM/yyyy "), TextColor =  GeneralSettings.textColor  },
                                    new Label {Text = "Users: " + User.UserListToString(s.Users), TextColor =  GeneralSettings.textColor  },
                                    new Label {Text = "Beschrijving: " + s.projectdescription, TextColor =  GeneralSettings.textColor },
                                    b, warning
                                    
                }
            };
        }


        private async void B_Clicked(object sender, EventArgs e)
        {
            if (test == false)
            {
                test = true;
            }
            else
            {
                warning.Text = "Failed to join project";
            }
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskInfoPage((Task)e.Item));
        }
    }
}


