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
        Entry nameEntry = new Entry() {  TextColor = GeneralSettings.textColor };
        Entry descriptionEntry = new Entry() { TextColor = GeneralSettings.textColor };

        Button b;

        //Kiezen van begin en eind datums
        DatePicker start = new DatePicker() ;
        DatePicker end = new DatePicker() ;

        public NewProjectPage ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label {Text = Globals.projnaam, TextColor = GeneralSettings.textColor },nameEntry,new Label {Text = Globals.beschrijving, TextColor = GeneralSettings.textColor },descriptionEntry, new Label {Text = Globals.datumbegin, TextColor = GeneralSettings.textColor },start,new Label {Text = Globals.datumeind, TextColor = GeneralSettings.textColor }, end } } };
            b = new Button() { Text = Globals.knopaanmaken, HorizontalOptions = LayoutOptions.Center };
            b.Clicked += B_Clicked;
            Content = new StackLayout {
                Margin = GeneralSettings.pageMargin,
				Children = {
					scroll, b
				}
			};
		}

        private async void B_Clicked(object sender, EventArgs e)
        {
            b.IsEnabled = false;
            //Toevoegen van een nieuw project aan de test data (Tijdelijk/niet helemaal compleet)
            SaveTestData.projects.Add(new Project(start.Date, end.Date, nameEntry.Text, "Test Company", descriptionEntry.Text) { Users = new List<User> { new User("Sam", "test@test.com", "test") } });
            await Navigation.PushAsync(new ProjectsPage((List<Project>)GetFromDatabase.GetProjects(GetFromDatabase.currentUserName, GetFromDatabase.currentToken)), false);
            
            // Het verwijderen van de oude pages in de stack
            for (int counter = 1; counter <= 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[1]);
            }
        }
    }
}
