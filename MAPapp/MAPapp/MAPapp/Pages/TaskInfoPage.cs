using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TaskInfoPage : ContentPage
	{
        Button jointTask = new Button() { Text = "Ga bij de taak" };
        Task t;
		public TaskInfoPage (Task givenTask)
		{
            t = givenTask;
            jointTask.Clicked += JointTask_Clicked;
            Title = t.taskname;
            StackLayout stack;
            BackgroundColor = GeneralSettings.backgroundColor;
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
                    jointTask,

                }
            };
            if (t.firstname != null && t.lastname != null) {
                stack.Children.Add(new Label { Text = "Wordt gedaan door: " + t.firstname + " " + t.lastname , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = GeneralSettings.textColor });
            }
            else
            {
                stack.Children.Add(new Label { Text = "Wordt gedaan door: T.B.D ", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = GeneralSettings.textColor });
            }
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
