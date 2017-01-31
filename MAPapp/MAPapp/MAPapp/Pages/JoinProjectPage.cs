using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading;
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
           
            if (tasks != null)
                tasks = Sort.SortTasks(tasks);           

           b = new Button()
            {
                BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor
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
            string userName = ContactDataBase.currentUserName;
            string token = ContactDataBase.currentToken;
            int projectID = ding.projectid;
            if ((string)ContactDataBase.JoinProject(userName, token, projectID) == "JOIN_PROJECT_SUCCESS")
            {
                await DisplayAlert(Globals.joinpassname, Globals.joinpass, Globals.okknop);
                Project f = ding;
                var tokenSource2 = new CancellationTokenSource();
                await System.Threading.Tasks.Task.Run(() =>
                {
                    Boolean hasAccess = true;
                    Sprint s = null;
                    try
                    {
                        f.Tasks = (List<Task>)ContactDataBase.GetTasks(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
                        s = (Sprint)ContactDataBase.GetSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
                    }
                    catch { hasAccess = false; }

                    try
                    {

                        List<Task> tasks = new List<Task>();
                        foreach (Task t in f.Tasks)
                        {
                            if (s != null && t.sprintid == s.sprintid)
                            {
                                tasks.Add(t);
                            }
                        }
                        if (s != null)
                        {
                            s.Sprinttasks = tasks;
                            f.CurrentSprint = s;
                        }
                    }
                    catch { }
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //  List<Task> t = f.Tasks;
                        if (hasAccess)
                            Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint, f.Tasks, f), new NewSprintPage(f), new burndown(f) }, Title = f.projectname });
                        else
                            Navigation.PushAsync(new TabbedPage() { Children = { new JoinProjectPage(f), }, Title = f.projectname, BackgroundColor = GeneralSettings.mainColor });
                    });

                }, tokenSource2.Token);
                tokenSource2.Cancel();
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


