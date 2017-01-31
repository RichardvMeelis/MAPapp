using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewSprintPage : ContentPage
	{
        //Maak entry velden aan voor nieuwe sprint
        Entry sprintName , sprintDuration, tPoints;
        DatePicker startDate;
        Project project;

        public NewSprintPage(Project f) {
            project = f;
            BackgroundColor = GeneralSettings.backgroundColor;
            //Button voor nieuwe sprint
            Button newSprint = new Button() {BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor, Text = "Aanmaken" };
            //Voor het in en uitschakelen van de knop
            newSprint.Clicked += newSprintClicked;
            Title = "Nieuwe Sprint";
            //Pagina icon
            Icon = "Calender.png";
            sprintName = new Entry() {TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor };
            sprintDuration = new Entry() { Keyboard = Keyboard.Numeric, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor };
            tPoints = new Entry() { Keyboard = Keyboard.Numeric, TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor };
            startDate = new DatePicker() {TextColor = GeneralSettings.textColor,BackgroundColor = GeneralSettings.entryColor };
            //Voeg content toe aan stacklayout
			Content = new StackLayout {
				Children = {
                    //Content aanmaken
					new Label { Text = Globals.sprintnaamlabel,TextColor = GeneralSettings.textColor }, sprintName,new Label() {Text = Globals.sprintdurationlabel,TextColor = GeneralSettings.textColor }, sprintDuration,new Label() {Text = Globals.sprinttargetpoints,TextColor = GeneralSettings.textColor } ,tPoints,new Label() {Text = Globals.sprintstartdatum ,TextColor = GeneralSettings.textColor},startDate,newSprint
				}
			};
		}
        //Nieuwe sprint aan database toevoegen
        private async void newSprintClicked(object sender, EventArgs e)
        {
            
            ContactDataBase.createNewSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, sprintName.Text, Convert.ToInt32(sprintDuration.Text), Convert.ToInt32(tPoints.Text), startDate.Date, this.project.projectid);
            project.CurrentSprint = (Sprint)ContactDataBase.GetSprint(ContactDataBase.currentUserName, ContactDataBase.currentToken, project.projectid);
            project.Tasks = (List<Task>)ContactDataBase.GetTasks(ContactDataBase.currentUserName, ContactDataBase.currentToken, project.projectid);

            //Push de nieuwe pagina op de stack
            var page1 = new ProjectInfoPage(project);
            var page2 = new SprintPage(project.CurrentSprint, project.Tasks, project);
            var page3 = new NewSprintPage(project);
            var page4 = new burndown(project);
            await Navigation.PushAsync(new TabbedPage() { Children = { page1,page2, page3,page4  }, Title = project.projectname, BackgroundColor = GeneralSettings.backgroundColor,CurrentPage = page2 });

            //Verweider de oude pagina's uit de stack
           
                Navigation.RemovePage(Navigation.NavigationStack[2]);
            
        }
    }
}
