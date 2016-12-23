using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class newAccount : ContentPage
	{
        Entry username = new Entry(),password = new Entry(), fName = new Entry(), lName = new Entry(), joincode = new Entry();
        Label label = new Label() {TextColor = Color.Red };
		public newAccount() { 
            

            Button b = new Button() {Text = "Create" };
            b.Clicked += B_Clicked;
			Content = new StackLayout {
				Children = {
					new Label { Text = "Username:" },username,new Label {Text = "password:" },password,new Label {Text = "First Name:" },fName,new Label {Text = "Last Name:" },lName,new Label {Text = "Joincode:" },joincode,b,label
                }
			};
		}

        private void B_Clicked(object sender, EventArgs e)
        {
           if (GetFromDatabase.CreateUser(username.Text, password.Text, fName.Text, lName.Text, joincode.Text) == "NEW_USER_SUCCESS")
            {
                Navigation.PopAsync();
            }
            else
            {
                label.Text = "Creating new user failed";
            }
        }
    }
}
