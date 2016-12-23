using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewTaskPage : ContentPage
	{
        //Alle invoer velden voor de nieuwe project pagina
        Entry nameEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry descriptionEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };

        Entry jobSizeEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry userBusinessValueEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry timeCriticalityEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry rroeValueEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry uncertaintyEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Project saved;


        public NewTaskPage(Project f)
        {
            Title = "New Task";
            saved = f;
            BackgroundColor = GeneralSettings.backgroundColor;
            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label { Text = "TaskName:", TextColor = Color.Black }, nameEntry, new Label { Text = "Descprition:", TextColor = Color.Black }, descriptionEntry, new Label { Text = "Job size:", TextColor = Color.Black }, jobSizeEntry, new Label { Text = "User business value:", TextColor = Color.Black }, userBusinessValueEntry, new Label { Text = "time criticality:", TextColor = Color.Black }, timeCriticalityEntry, new Label { Text = "RROE value:", TextColor = Color.Black }, rroeValueEntry, new Label { Text = "Uncertainty:", TextColor = Color.Black }, uncertaintyEntry } } };
            Button b = new Button() { Text = "Create", HorizontalOptions = LayoutOptions.Center };
            b.Clicked += B_Clicked;
            Content = new StackLayout
            {
                Children = {
                    scroll, b
                }
            };
        }

        private async void B_Clicked(object sender, EventArgs e)
        {

            //Toevoegen van een nieuw project aan de test data (Tijdelijk/niet helemaal compleet)
            try
            {
                saved.Tasks.Add(new Task(new DateTime(), nameEntry.Text, descriptionEntry.Text, int.Parse(jobSizeEntry.Text), int.Parse(userBusinessValueEntry.Text), false, null, int.Parse(timeCriticalityEntry.Text), int.Parse(rroeValueEntry.Text), int.Parse(userBusinessValueEntry.Text)));
                await Navigation.PushAsync(new TabbedPage() { Children = { new ProjectInfoPage(saved), new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" }, new ContentPage() { Title = "Test" } }, Title = saved.Name });

                // Het verwijderen van de oude pages in de stack
                for (int counter = 1; counter <= 2; counter++)
                {
                    Navigation.RemovePage(Navigation.NavigationStack[2]);
                }
            }
            catch
            {

            }
        }
    }
}

