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
        Button addTask = new Button() {Text = Globals.knoptaaktoevoegenfinal };
        Sprint sprint;
        Project f;
		public AddTaskToSprintPage (Sprint givenSprint, List<Task> projectTasks, Project project)
		{
            this.f = project;
            sprint = givenSprint;
            addTask.Clicked += AddTaskClicked;
            List<Task> tasks = new List<Task>();
            foreach (Task t in projectTasks)
            {
                if(t.sprintid == 0)
                {
                    tasks.Add(t);
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
            addTask.IsEnabled = false;
            table.ItemTapped += Table_ItemTapped;
            Content = new StackLayout { Children = { new ScrollView {Content = table },addTask } };

        }

        private void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            addTask.IsEnabled = true;
        }

        private async void AddTaskClicked(object sender, EventArgs e)
        {
            Task s = (Task)table.SelectedItem;
            GetFromDatabase.addTaskToSprint(GetFromDatabase.currentUserName,GetFromDatabase.currentToken,s.taskid,s.projectid,sprint.sprintid);
            f.CurrentSprint = (Sprint)GetFromDatabase.GetSprint(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid);
            f.Tasks = (List<Task>)GetFromDatabase.GetTasks(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid);
           await Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint, f.Tasks, f) }, Title = f.projectname });
            int BackCount = 2;
            for (var counter = 1; counter < BackCount; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
            /*for (int i = 0; i < 2; i++)
            {
                int x = Navigation.NavigationStack.Count;
                Navigation.RemovePage(Navigation.NavigationStack[x-2]);
            }
            */
        }
    }
}
