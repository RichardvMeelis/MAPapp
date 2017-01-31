using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class AddTaskToSprintPage : ContentPage
	{   
        ListView table;
        Button addTask = new Button() {Text = Globals.knoptaaktoevoegenfinal , BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor};

        //Er moet in de sprint gewerkt worden, waarvoor ook project informatie nodig is
        Sprint sprint;
        Project f;
       
		public AddTaskToSprintPage (Sprint givenSprint, List<Task> projectTasks, Project project)
		{
            this.f = project;
            sprint = givenSprint;
            addTask.Clicked += AddTaskClicked;
            BackgroundColor = GeneralSettings.backgroundColor;
            List<Task> tasks = new List<Task>();
            foreach (Task t in projectTasks)
            {
                //Als een taak nog niet af is en nog geen sprint heeft kan hij worden toegevoegd
                if (t.sprintid == 0 && t.timecompleted == null)
                {
                    tasks.Add(t);
                }
            }
            //Listview met alle taken die aan de sprint kunnen worden toegevoegd
            table = new ListView
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemsSource = tasks,
                HasUnevenRows = true,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Creëer de labels met bindings
                        
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "taskname");
                    nameLabel.FontSize = 20;
                    nameLabel.TextColor = GeneralSettings.textColor;

                    Label jobSizeLabel = new Label();
                    jobSizeLabel.SetBinding(Label.TextProperty,
                        new Binding("JSPoints", BindingMode.OneWay,
                            null, null, "Job Size: {0:d}"));
                    jobSizeLabel.TextColor = GeneralSettings.textColor;

                    Label importancePointsLabel = new Label();
                    importancePointsLabel.SetBinding(Label.TextProperty,
                        new Binding("UBVPoints", BindingMode.OneWay,
                            null, null, "User- business value: {0:d}"));
                    importancePointsLabel.TextColor = GeneralSettings.textColor;


                   //Maak viewcell met stacklayout
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Margin = GeneralSettings.pageMargin,
                            Padding = new Thickness(0, 2),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            jobSizeLabel,importancePointsLabel,
                                        }
                                        }
                                }
                        }
                    };
                })
            };
            
            addTask.IsEnabled = false;
            table.ItemTapped += Table_ItemTapped;
            Content = new StackLayout { Children = { table,addTask } };

        }

        private void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            addTask.IsEnabled = true;
        }

        //Taak toevoegen aan de sprint 
        private async void AddTaskClicked(object sender, EventArgs e)
        {
            Task s = (Task)table.SelectedItem;
            ContactDataBase.addTaskToSprint(ContactDataBase.currentUserName,ContactDataBase.currentToken,s.taskid,s.projectid,sprint.sprintid);
            f.CurrentSprint = (Sprint)ContactDataBase.GetSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
            f.Tasks = (List<Task>)ContactDataBase.GetTasks(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
             
            List<Task> tasks2 = new List<Task>();
            foreach (Task t in f.Tasks)
            {
                if (s != null && t.sprintid == f.CurrentSprint.sprintid)
                {
                    tasks2.Add(t);
                }
            }
            if (s != null)
            {
                f.CurrentSprint.Sprinttasks = tasks2;
                
            }
            var page1 = new ProjectInfoPage(f);
            var page2 = new SprintPage(f.CurrentSprint, f.Tasks, f);
            var page3 = new NewSprintPage(f);
            var page4 = new burndown(f);
            //Push de nieuwe pagina op de stack
            await Navigation.PushAsync(new TabbedPage() { Children = { page1, page2,page3,page4 }, Title = f.projectname , BackgroundColor = GeneralSettings.backgroundColor,CurrentPage = page2});

            //Verweider de oude pagina's uit de stack
            for (int counter = 1; counter <= 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[2]);
            }
           
        }
    }
}
