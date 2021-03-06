﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp {
    public class NewTaskPage : ContentPage {
        //Alle invoer velden voor de nieuwe project pagina
        Entry nameEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry descriptionEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry jobSizeEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black, Keyboard = Keyboard.Numeric };  //Kleuren nog met andere variablen doen
        Entry userBusinessValueEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black, Keyboard = Keyboard.Numeric };
        Entry timeCriticalityEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black, Keyboard = Keyboard.Numeric };
        Entry rroeValueEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black, Keyboard = Keyboard.Numeric };
        Entry uncertaintyEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black,Keyboard = Keyboard.Numeric };

        //Project waaraan de taak wordt toegevoegd 
        Project saved;
        Project project;
        Button addTask;
        public NewTaskPage(Project f)
        {
            project = f;
            Title = Globals.paginanieuwetaak;
            BackgroundColor = GeneralSettings.backgroundColor;

            //Member variabele wordt gelijk gemaakt aan de parameter
            saved = f;
            BackgroundColor = GeneralSettings.backgroundColor;

            //Er wordt een nieuwe scrollview gemaakt en de gemaakt elementen worden toegevoegd
            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label { Text = Globals.taaknaam, TextColor = GeneralSettings.textColor }, nameEntry, new Label { Text = Globals.beschrijving, TextColor = GeneralSettings.textColor}, descriptionEntry, new Label { Text = Globals.jobsize, TextColor = GeneralSettings.textColor }, jobSizeEntry, new Label { Text = Globals.ubv, TextColor = GeneralSettings.textColor }, userBusinessValueEntry, new Label { Text = Globals.timecrit, TextColor = GeneralSettings.textColor }, timeCriticalityEntry, new Label { Text = Globals.rroe, TextColor = GeneralSettings.textColor}, rroeValueEntry, new Label { Text = Globals.uncertainty, TextColor = GeneralSettings.textColor }, uncertaintyEntry } } };
            addTask = new Button() { Text = Globals.knopaanmaken, HorizontalOptions = LayoutOptions.Center, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor };
            addTask.Clicked += AddTask;
            Content = new StackLayout
            {
                Margin = GeneralSettings.pageMargin,
                Children = {
                    scroll, addTask
                }
            };
        }

        private async void AddTask(object sender, EventArgs e)
        {
            addTask.IsEnabled = false;
            int projectID;
           
          //De nieuwe taak toevoegen aan project in de database
            try
            {
                projectID = saved.projectid;
                ContactDataBase.addTaskToProject(ContactDataBase.currentUserName, ContactDataBase.currentToken, nameEntry.Text, descriptionEntry.Text, project.projectid, int.Parse(rroeValueEntry.Text), int.Parse(jobSizeEntry.Text), int.Parse(userBusinessValueEntry.Text), int.Parse(timeCriticalityEntry.Text), int.Parse(uncertaintyEntry.Text));
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
                // Het verwijderen van de oude pages in de stack
                for (int counter = 1; counter <= 2; counter++)
                {
                    Navigation.RemovePage(Navigation.NavigationStack[2]);
                }
                addTask.IsEnabled = true;
            }
            //Opvangen error
            catch
            {
               await DisplayAlert(Globals.taakallerttitel,Globals.taakallertmessage,"ok");
                addTask.IsEnabled = true;

            }
        }
    }
}

