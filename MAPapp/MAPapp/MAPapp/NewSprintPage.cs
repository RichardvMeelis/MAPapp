using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewSprintPage : ContentPage
	{
        Entry sprintName , sprintDuration, tPoints;
        DatePicker startDate;
        Project project;

        public NewSprintPage(Project f) {
            project = f;
            Title = Globals.nieuwesprintpaginatitel;
            Button newSprint = new Button();
            newSprint.Clicked += newSprintClicked;
            sprintName = new Entry() ;
            sprintDuration = new Entry() { Keyboard = Keyboard.Numeric };
            tPoints = new Entry() { Keyboard = Keyboard.Numeric };
            startDate = new DatePicker();
			Content = new StackLayout {
				Children = {
					new Label { Text = Globals.sprintnaamlabel }, sprintName,new Label() {Text = Globals.sprintdurationlabel }, sprintDuration,new Label() {Text = Globals.sprinttargetpoints } ,tPoints,new Label() {Text = Globals.sprintstartdatum },startDate,newSprint
				}
			};
		}

        private void newSprintClicked(object sender, EventArgs e)
        {
            GetFromDatabase.createNewSprint(GetFromDatabase.currentUserName,GetFromDatabase.currentToken,sprintName.Text,Convert.ToInt32(sprintDuration.Text),Convert.ToInt32(tPoints.Text),startDate.Date,project.projectid);
        }
    }
}
