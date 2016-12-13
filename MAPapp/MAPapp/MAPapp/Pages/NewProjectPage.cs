using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewProjectPage : ContentPage
	{
        Entry nameEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        Entry descriptionEntry = new Entry() { BackgroundColor = Color.FromRgb(230, 230, 230), TextColor = Color.Black };
        DatePicker start = new DatePicker() { BackgroundColor = Color.FromRgb(230, 230, 230), };
        DatePicker end = new DatePicker() { BackgroundColor = Color.FromRgb(230, 230, 230), };
        public NewProjectPage ()
		{
            BackgroundColor = Color.White;
            /*
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(new Label {Text = "tekst" }, 0, 0);
            grid.Children.Add(new Entry(), 1, 0);
            grid.Children.Add(new Label { Text = "tekst" }, 0, 1);
            grid.Children.Add(new Entry(), 1, 1); grid.Children.Add(new Label { Text = "tekst" }, 0, 2);
            grid.Children.Add(new Entry(), 1, 2); grid.Children.Add(new Label { Text = "tekst" }, 0, 3);
            grid.Children.Add(new Entry(), 1, 3);
            */

            

            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label {Text = "Project Name:", TextColor = Color.Black },nameEntry,new Label {Text = "Descprition:", TextColor = Color.Black },descriptionEntry, new Label {Text = "Starting date:", TextColor = Color.Black },start,new Label {Text = "Ending date:", TextColor = Color.Black }, end } } };
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
            SaveTestData.projects.Add(new Project(start.Date, end.Date, nameEntry.Text, "Test Company", descriptionEntry.Text) { Users = new List<User> { new User("Sam", "test@test.com", "test") } });
            await Navigation.PushAsync(new ProjectsPage(), false);
            int i = Navigation.NavigationStack.Count;
            
            for (int counter = 1; counter <= 2; counter++)
            {
                int z = Navigation.NavigationStack.Count;
                
                Navigation.RemovePage(Navigation.NavigationStack[1]);
              //  var x = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
            }
           
            
            // await Navigation.PopAsync();



            //await Navigation.PushAsync(new ProjectsPage());

        }
    }
}
