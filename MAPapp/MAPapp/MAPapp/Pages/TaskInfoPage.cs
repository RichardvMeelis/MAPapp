using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TaskInfoPage : ContentPage
	{
		public TaskInfoPage (Task t)
		{
            Title = t.Name;
            StackLayout stack;
            BackgroundColor = Color.White;
			Content = stack = new StackLayout {
				Children = {

					new Label { Text = t.Name, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },
                    new Label { Text = "Beschrijving: " + t.Description, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },
                 
                    new Label { Text = "Jobsize: " + t.JobSize, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },
                    new Label { Text = "RROE value: " + t.RroeValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = Color.Black},
                    new Label { Text = "Timecriticality: " + t.TimeCriticality, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },
                    new Label { Text = "User-Business value: " + t.UserBusinessValue, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },
                    new Label { Text = "Uncertainty: " + t.Uncertainty, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center,TextColor = Color.Black },


                }
            };
            if (t.User != null) {
              stack.Children.Add(  new Label { Text = "Wordt gedaan door: " + t.User.Name, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = Color.Black });
            }
            else
            {
                stack.Children.Add(new Label { Text = "Wordt gedaan door: T.B.D ", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, TextColor = Color.Black });
            }
        }
	}
}
