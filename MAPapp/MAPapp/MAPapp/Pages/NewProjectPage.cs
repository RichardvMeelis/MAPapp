using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewProjectPage : ContentPage
	{
        //Alle invoer velden voor de nieuwe project pagina
        Entry nameEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry descriptionEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
       
        //Kiezen van begin en eind datums
        DatePicker start = new DatePicker() { BackgroundColor = Color.FromRgb(230, 230, 230), };
        DatePicker end = new DatePicker() { BackgroundColor = Color.FromRgb(230, 230, 230), };

        public NewProjectPage ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label {Text = "Project Name:", TextColor = GeneralSettings.textColor },nameEntry,new Label {Text = "Descprition:", TextColor = GeneralSettings.textColor },descriptionEntry, new Label {Text = "Starting date:", TextColor = GeneralSettings.textColor },start,new Label {Text = "Ending date:", TextColor = GeneralSettings.textColor }, end } } };
            Button b = new Button() { Text = "Create", HorizontalOptions = LayoutOptions.Center };
            b.Clicked += B_Clicked;
            Content = new StackLayout {
				Children = {
					scroll, b
				}
			};
		}

        private async void B_Clicked(object sender, EventArgs e)
        {
            //Toevoegen van een nieuw project aan de test data (Tijdelijk/niet helemaal compleet)
            SaveTestData.projects.Add(new Project(start.Date, end.Date, nameEntry.Text, "Test Company", descriptionEntry.Text) { Users = new List<User> { new User("Sam", "test@test.com", "test") } });
            await Navigation.PushAsync(new ProjectsPage(), false);
            
            // Het verwijderen van de oude pages in de stack
            for (int counter = 1; counter <= 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[1]);
            }
        }
    }
}
