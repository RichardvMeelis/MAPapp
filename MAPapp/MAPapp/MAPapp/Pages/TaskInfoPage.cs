using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TaskInfoPage : ContentPage
	{
        Button jointTask = new Button() { Text = "Ga bij de taak" , BackgroundColor = GeneralSettings.mainColor};
        Button completeTask = new Button() { Text = Globals.afrondenknop, BackgroundColor = GeneralSettings.mainColor,TextColor = GeneralSettings.textColor };
        Task t;
        Label userLabel;
		public TaskInfoPage (Task givenTask)
		{
            t = givenTask;
            BackgroundColor = GeneralSettings.backgroundColor;
            Title = t.taskname;

            userLabel = new Label() { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = GeneralSettings.textColor };
           

            if (t.firstname != null && t.lastname != null)
                jointTask.IsEnabled = false;
            else
                completeTask.IsEnabled = false;

            jointTask.Clicked += JointTask_Clicked;
            completeTask.Clicked += CompleteTask_Clicked;

           
            StackLayout stack;
            

            Content = stack = new StackLayout {
                Margin = GeneralSettings.pageMargin,
				Children = {

					new Label { Text = t.taskname, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "Beschrijving: " + t.taskdescription, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                 
                    new Label { Text = "Jobsize: " + t.JSPoints, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "RROE value: " + t.RroeValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor =  GeneralSettings.textColor},
                    new Label { Text = "Timecriticality: " + t.TimeCriticality, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "User-Business value: " + t.UBVPoints, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    new Label { Text = "Uncertainty: " + t.UCValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor =  GeneralSettings.textColor },
                    userLabel,
                    jointTask,
                    completeTask

                }
            };
            if (t.firstname != null && t.lastname != null) {
                userLabel.Text = "Wordt gedaan door: " + t.firstname + " " + t.lastname  ;
            }
            else
            {
                userLabel.Text = "Wordt gedaan door: T.B.D ";
            }
        }

        private void CompleteTask_Clicked(object sender, EventArgs e)
        {
            GetFromDatabase.completeTask(GetFromDatabase.currentUserName,GetFromDatabase.currentToken,t.taskid,t.projectid);
        }

        private void JointTask_Clicked(object sender, EventArgs e)
        {
            if (t.User == null)
            {
                t.User = GetFromDatabase.currentUser;
                GetFromDatabase.JoinTask(GetFromDatabase.currentUserName,GetFromDatabase.currentToken,t.taskid,t.projectid);
            }
        }
    }
}
