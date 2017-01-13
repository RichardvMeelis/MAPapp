﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MAPapp {
    public class ProjectsPage : ContentPage {

        public ProjectsPage(List<Project> projects)
        {
            Title = "Projects";
            BackgroundColor = GeneralSettings.backgroundColor;
            System.Diagnostics.Debug.WriteLine("---------------------------------------------------------------------------------------------------------------" + HomePage.stopwatch.ElapsedMilliseconds);


            // String s = GetFromDatabase.SingIn("user%40test.com", "testtest");
            //System.Diagnostics.Debug.WriteLine(s);
            //  SaveTestData.projects = Sort.SortProjects(SaveTestData.projects);
            ListView table = new ListView
            {

                VerticalOptions = LayoutOptions.FillAndExpand,

                ItemsSource = projects,
                HasUnevenRows = true,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.

                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "projectname");
                    nameLabel.FontSize = 20;
                    nameLabel.TextColor = GeneralSettings.textColor;

                    //Label met binding voor het bedrijf
                    Label CompanyLabel = new Label();
                    CompanyLabel.SetBinding(Label.TextProperty,
                        new Binding("company_companyid", BindingMode.OneWay,
                            null, null, "Company: {0:d}"));
                    CompanyLabel.TextColor = GeneralSettings.textColor;

                    //Label met binding voor de datum
                    Label endingdateLabel = new Label();
                    endingdateLabel.SetBinding(Label.TextProperty,
                        new Binding("EndingDate", BindingMode.OneWay,
                            null, null, "Einddatum: {0: dd/MM/yyyy}"));
                    endingdateLabel.TextColor = GeneralSettings.textColor;



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
                                            endingdateLabel,
                                            CompanyLabel,

                                        }
                                        }
                                }
                        }
                    };
                })
            };

            table.ItemTapped += Table_ItemTapped;


            Button b = new Button() { Text = "New Project", BackgroundColor = GeneralSettings.mainColor };
            b.Clicked += B_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {b,
                    new ScrollView() { Content =  table, VerticalOptions =LayoutOptions.FillAndExpand  },
                }
            };
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Project f = (Project)e.Item;
            await System.Threading.Tasks.Task.Run(() =>
            {
                f.Tasks = GetFromDatabase.GetTasks(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid);
                int i = 0;
                foreach (Task t in f.Tasks)
                {
                    if (t.sprintid > i)
                    {
                        i = t.sprintid;
                    }
                }

                Sprint s = GetFromDatabase.GetSprint(GetFromDatabase.currentUserName, GetFromDatabase.currentToken, f.projectid, i);
                List < Task > tasks = new List<Task>();
                foreach (Task t in f.Tasks)
                {
                    System.Diagnostics.Debug.WriteLine("---------------------------------------------------------------TASKSPRINTID  "  + t.sprintid);
                    System.Diagnostics.Debug.WriteLine("---------------------------------------------------------------" + s.tpoints + " " + s.sprint_start_date + " " + s.project_projectid + " "+ s.sprintname +" " + s.sprintid);
                    if (t.sprintid == s.sprintid)
                    {
                        tasks.Add( t);
                    }
                }
                s.Sprinttasks = tasks;
                f.CurrentSprint = s;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint), new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } }, Title = f.projectname });

                });
            });


        }
    }
}
