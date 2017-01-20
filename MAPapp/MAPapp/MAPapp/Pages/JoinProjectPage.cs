using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
    public class JoinProjectPage : ContentPage
    {
        Button b;
        Project ding;
        Label warning = new Label() { TextColor = Color.Red };
        public JoinProjectPage(Project s)
        {
            ding = s;
            Title = Globals.tabprojectinfo;
            BackgroundColor = GeneralSettings.backgroundColor;
            List<Task> tasks = s.Tasks;
            // tasks.Sort();
            if (tasks != null)
                tasks = Sort.SortTasks(tasks);
            //   App.page.Title = "Projects";


           b = new Button()
            {
                BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.textColor
            };
            b.Text = Globals.paginajoinproject;
            b.Clicked += B_Clicked;

            //  BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = { 
                                    new Label {Text =  Globals.datumbegin + " " +  s.start_date.ToString("dd/MM/yyyy "), TextColor = GeneralSettings.textColor},
                                    new Label {Text =  Globals.datumeind + " " +  s.EndingDate.ToString("dd/MM/yyyy "), TextColor =  GeneralSettings.textColor  },
                                    new Label {Text =  Globals.deelnemers + " " + User.UserListToString(s.Users), TextColor =  GeneralSettings.textColor  },
                                    new Label {Text =  Globals.beschrijving + " " + s.projectdescription, TextColor =  GeneralSettings.textColor },
                                    b, warning
                                    
                }
            };
        }


        private async void B_Clicked(object sender, EventArgs e)
        {
            b.IsEnabled = false;
            string userName = GetFromDatabase.currentUserName;
            string token = GetFromDatabase.currentToken;
            int projectID = ding.projectid;
            if ((string)GetFromDatabase.JoinProject(userName, token, projectID) == "JOIN_PROJECT_SUCCESS")
            {
                await DisplayAlert(Globals.joinpassname, Globals.joinpass, Globals.okknop);
                Project f = ding;
                await System.Threading.Tasks.Task.Run(() =>
                {
                    f.Tasks = (List<Task>)GetFromDatabase.GetTasks(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid);
                    /*
                    int i = 0;
                    foreach (Task t in f.Tasks)
                    {
                        if (t.sprintid >= i)
                        {
                            i = t.sprintid;
                        }
                    }
                    */
                    f.CurrentSprint = (Sprint)GetFromDatabase.GetSprint(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (f.Tasks.Count != 0)
                        {
                            if (f.Tasks[0].HasAccess)
                            {
                                Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint,f.Tasks,f), new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } }, Title = f.projectname, BackgroundColor = GeneralSettings.backgroundColor });
                                b.IsEnabled = true;
                            }
                            else
                            {
                                Navigation.PushAsync(new JoinProjectPage(f));
                                DisplayAlert(Globals.error, Globals.nojoin, Globals.okknop);
                                b.IsEnabled = true;
                            }
                        }
                        else Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint,f.Tasks,f), new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } }, Title = f.projectname , BackgroundColor = GeneralSettings.backgroundColor});
                    });
                });
            }
            else
            {
                await DisplayAlert(Globals.error, Globals.joinfail, Globals.okknop);
                b.IsEnabled = true;
            }
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskInfoPage((Task)e.Item));
        }
    }
}


