using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TaskInfoPage : ContentPage
	{
        Button jointTask = new Button() { Text = "Ga bij de taak" , BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor};
        Button completeTask = new Button() { Text = Globals.afrondenknop, BackgroundColor = GeneralSettings.mainColor,TextColor = GeneralSettings.btextColor };
        Task t;
        Label userLabel;
		public TaskInfoPage (Task givenTask)
		{
            t = givenTask;
            BackgroundColor = GeneralSettings.backgroundColor;
            Title = t.taskname;

            userLabel = new Label() { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = GeneralSettings.textColor };
           

            if (t.firstname != null && t.lastname != null)
                jointTask.IsEnabled = false;
            else
                completeTask.IsEnabled = false;

            jointTask.Clicked += JointTask_Clicked;
            completeTask.Clicked += CompleteTask_Clicked;

           
            StackLayout stack;
            

            Content = stack = new StackLayout {
                Margin = GeneralSettings.pageMargin,
				Children = {

					new Label { Text = t.taskname, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "Beschrijving: " + t.taskdescription, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                 
                    new Label { Text = "Jobsize: " + t.JSPoints, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "RROE value: " + t.RroeValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor =  GeneralSettings.textColor},
                    new Label { Text = "Timecriticality: " + t.TimeCriticality, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "User-Business value: " + t.UBVPoints, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "Uncertainty: " + t.UCValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    userLabel,
                    jointTask,
                    completeTask

                }
            };
            if (t.firstname != null && t.lastname != null) {
                userLabel.Text = "Wordt gedaan door: " + t.firstname + " " + t.lastname  ;
            }
            else
            {
                userLabel.Text = "Wordt gedaan door: T.B.D ";
            }
        }

        private async void CompleteTask_Clicked(object sender, EventArgs e)
        {
            try
            {
                GetFromDatabase.completeTask(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, t.taskid, t.projectid);
                refreshPage();
            }
            catch { }
        }
        private async void refreshPage()
        {
            int projectID = t.projectid;
            try
            {
                // saved.Tasks.Add(new Task(new DateTime(), nameEntry.Text, descriptionEntry.Text, int.Parse(jobSizeEntry.Text), int.Parse(userBusinessValueEntry.Text), 0, null, int.Parse(timeCriticalityEntry.Text), int.Parse(rroeValueEntry.Text), int.Parse(userBusinessValueEntry.Text)));
                GetFromDatabase.completeTask(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, t.taskid, t.projectid);
                List<Project> projects = (List<Project>)GetFromDatabase.GetProjects(GetFromDatabase.currentUserName, GetFromDatabase.currentToken);
                foreach (Project project in projects)
                {
                    if (project.projectid == projectID)
                    {
                        project.Tasks = (List<Task>)GetFromDatabase.GetTasks(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, project.projectid);
                        Sprint s = (Sprint)GetFromDatabase.GetSprint(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, project.projectid);
                        List<Task> tasks = new List<Task>();
                        foreach (Task t in project.Tasks)
                        {
                            if (s != null && t.sprintid == s.sprintid)
                            {
                                tasks.Add(t);
                            }
                        }
                        if (s != null)
                        {
                            s.Sprinttasks = tasks;
                            project.CurrentSprint = s;
                        }
                        await Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(project), new SprintPage(project.CurrentSprint, project.Tasks, project), new NewSprintPage(project), new burndown(project) }, Title = project.projectname });
                    }
                }

                ////////////////
                //        Project ding = null;
                //      ding.projectid = 1;
                ///////////////////
                // Het verwijderen van de oude pages in de stack
                for (int counter = 1; counter <= 2; counter++)
                {

                    Navigation.RemovePage(Navigation.NavigationStack[2]);
                }
                //b.IsEnabled = true;
            }
            catch
            {
                await DisplayAlert(Globals.taakallerttitel, Globals.taakallertmessage, "ok");
                //  b.IsEnabled = true;

            }
        }
        private void JointTask_Clicked(object sender, EventArgs e)
        {
            if (t.lastname == null && t.firstname == null)
            {
                t.firstname = GetFromDatabase.currentUser.firstname;
                t.lastname = GetFromDatabase.currentUser.lastname;
                GetFromDatabase.JoinTask(GetFromDatabase.currentUserName,GetFromDatabase.currentToken,t.taskid,t.projectid);
                refreshPage();

            }
        }
    }
}
