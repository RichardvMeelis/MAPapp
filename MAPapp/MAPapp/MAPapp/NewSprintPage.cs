using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class NewSprintPage : ContentPage
	{
        Entry sprintName, sprintDuration, tPoints;
        DatePicker startDate;
		public NewSprintPage ()
		{
            sprintName = new Entry();
            sprintDuration = new Entry();
            tPoints = new Entry();
            startDate = new DatePicker();
			Content = new StackLayout {
				Children = {
					new Label { Text = Globals.sprintnaamlabel }, sprintName,new Label() {Text = Globals.sprintdurationlabel }, sprintDuration,new Label() {Text = Globals.sprinttargetpoints } ,tPoints,new Label() {Text = Globals.sprintstartdatum },startDate
				}
			};
		}
	}
}
