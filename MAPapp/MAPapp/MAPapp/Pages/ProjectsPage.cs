using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MAPapp {
    public class ProjectsPage : ContentPage {
        ListView table;
        public ProjectsPage(List<Project> projects)
        {
            Title = Globals.paginaprojecten;
            BackgroundColor = GeneralSettings.backgroundColor;
            //Pagina icon
            Icon = "Projecten.png";
            //Nieuwe tabel voor projecten
            table = new ListView
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
                        new Binding("companyname", BindingMode.OneWay,
                            null, null, Globals.bedrijf + ": {0:d}"));
                    CompanyLabel.TextColor = GeneralSettings.textColor;

                    //Label met binding voor de datum
                    Label endingdateLabel = new Label();
                    endingdateLabel.SetBinding(Label.TextProperty,
                        new Binding("EndingDate", BindingMode.OneWay,
                            null, null, Globals.datumeind + ": {0: dd/MM/yyyy}"));
                    endingdateLabel.TextColor = GeneralSettings.textColor;

                    if (nameLabel.Text == "Project 1 - Blink")
                    {
                        BackgroundColor = Color.Gray;
                    }

                    //Nieuwe ViewCell met stacklayout
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Margin = GeneralSettings.pageMargin,
                            Padding = new Thickness(0, 2),
                            Orientation = StackOrientation.Horizontal,
                            //Content toevoegen aan stacklayout
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
            //Button nieuw project
            Button b = new Button() { Text = Globals.knopnieuwproject, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor };
            b.Clicked += B_Clicked;
            //Content toevoegen aan stacklayout
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = {
                   table, b
                }
            };
        }
        //Push new project page
        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        private async void Table_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            table.IsEnabled = false;
            Project f = (Project)e.Item;
            var tokenSource2 = new CancellationTokenSource();
            await System.Threading.Tasks.Task.Run(() =>
            {
                Boolean hasAccess = true;
                Sprint s = null;
                //Krijg taken en sprints van database
                try
                {
                    f.Tasks = (List<Task>)ContactDataBase.GetTasks(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
                     s = (Sprint)ContactDataBase.GetSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, f.projectid);
                }
                catch { hasAccess = false; }

                    try
                    {
                        //Voeg taken en sprints toe
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
                //Laat normale pagina of join pagina zien (afhankelijk van hasAccess)
                Device.BeginInvokeOnMainThread(() =>
                    {
                        if(hasAccess)
                        Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(f), new SprintPage(f.CurrentSprint, f.Tasks, f), new NewSprintPage(f),new burndown(f) }, Title = f.projectname });
                        else
                            Navigation.PushAsync(new TabbedPage() { Children = { new JoinProjectPage(f), }, Title = f.projectname, BackgroundColor = GeneralSettings.mainColor });
                    });
                  
            }, tokenSource2.Token);
            tokenSource2.Cancel();
            table.IsEnabled = true;
        }
    }
}
