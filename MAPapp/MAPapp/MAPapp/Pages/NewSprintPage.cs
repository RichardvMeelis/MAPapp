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
            //Button voor nieuwe sprint
            Button newSprint = new Button() {BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor, Text = "Aanmaken" };
            //Voor het in en uitschakelen van de createNewUser knop
            newSprint.Clicked += newSprintClicked;
            Title = "Nieuwe Sprint";
            //Pagina icon
            Icon = "Calender.png";
            sprintName = new Entry();
            sprintDuration = new Entry() { Keyboard = Keyboard.Numeric };
            tPoints = new Entry() { Keyboard = Keyboard.Numeric };
            startDate = new DatePicker();
            //Voeg content toe aan stacklayout
			Content = new StackLayout {
				Children = {
                    //Content aanmaken
					new Label { Text = Globals.sprintnaamlabel }, sprintName,new Label() {Text = Globals.sprintdurationlabel }, sprintDuration,new Label() {Text = Globals.sprinttargetpoints } ,tPoints,new Label() {Text = Globals.sprintstartdatum },startDate,newSprint
				}
			};
		}
        //Nieuwe sprint aan database toevoegen
        private void newSprintClicked(object sender, EventArgs e)
        {
            ContactDataBase.createNewSprint(ContactDataBase.currentUserName,ContactDataBase.currentToken,sprintName.Text,Convert.ToInt32(sprintDuration.Text),Convert.ToInt32(tPoints.Text),startDate.Date,project.projectid);
        }
    }
}
