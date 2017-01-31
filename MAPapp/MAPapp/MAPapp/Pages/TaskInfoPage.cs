using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TaskInfoPage : ContentPage
	{
        //Buttons aanmaken
        Button jointTask = new Button() { Text = "Ga bij de taak" , BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor};
        Button completeTask = new Button() { Text = Globals.afrondenknop, BackgroundColor = GeneralSettings.mainColor,TextColor = GeneralSettings.btextColor };
        Task t;
        Label userLabel;
		public TaskInfoPage (Task givenTask)
		{
            t = givenTask;
            BackgroundColor = GeneralSettings.backgroundColor;
            Title = t.taskname;
            //Nieuwe label voor user
            userLabel = new Label() { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = GeneralSettings.textColor };
            if (t.firstname != null && t.lastname != null)
                jointTask.IsEnabled = false;
            else
                completeTask.IsEnabled = false;
            //Voor het in en uitschakelen van de knop
            jointTask.Clicked += JointTask_Clicked;
            completeTask.Clicked += CompleteTask_Clicked;
            //Nieuwe stacklayout
            StackLayout stack;
            Content = stack = new StackLayout {
                Margin = GeneralSettings.pageMargin,
                //Content aanmaken en toevoegen aan de stacklayout
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
            //User van de taak laten zien
            if (t.firstname != null && t.lastname != null) {
                userLabel.Text = "Wordt gedaan door: " + t.firstname + " " + t.lastname  ;
            }
            else
            {
                userLabel.Text = "Wordt gedaan door: T.B.D ";
            }
        }
        //Complete task
        private void CompleteTask_Clicked(object sender, EventArgs e)
        {
            try
            {
                ContactDataBase.completeTask(ContactDataBase.currentUserName, ContactDataBase.currentToken, t.taskid, t.projectid);
                refreshPage();
            }
            catch { }
        }
        //Refresh de pagina
        private async void refreshPage()
        {
            int projectID = t.projectid;
            try
            {
                ContactDataBase.completeTask(ContactDataBase.currentUserName, ContactDataBase.currentToken, t.taskid, t.projectid);
                List<Project> projects = (List<Project>)ContactDataBase.GetProjects(ContactDataBase.currentUserName, ContactDataBase.currentToken);
                foreach (Project project in projects)
                {
                    if (project.projectid == projectID)
                    {
                        project.Tasks = (List<Task>)ContactDataBase.GetTasks(ContactDataBase.currentUserName, ContactDataBase.currentToken, project.projectid);
                        Sprint s = (Sprint)ContactDataBase.GetSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, project.projectid);
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
                //Haal de oude pagina weg
                for (int counter = 1; counter <= 2; counter++)
                {

                    Navigation.RemovePage(Navigation.NavigationStack[2]);
                }
            }
            catch
            {
                //error opvangen
                await DisplayAlert(Globals.taakallerttitel, Globals.taakallertmessage, "ok");
            }
        }
        //Join task
        private void JointTask_Clicked(object sender, EventArgs e)
        {
            if (t.lastname == null && t.firstname == null)
            {
                t.firstname = ContactDataBase.currentUser.firstname;
                t.lastname = ContactDataBase.currentUser.lastname;
                ContactDataBase.JoinTask(ContactDataBase.currentUserName,ContactDataBase.currentToken,t.taskid,t.projectid);
                refreshPage();

            }
        }
    }
}
