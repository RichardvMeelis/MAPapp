
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TestPage : ContentPage
	{
        ImageButton b;
        Xamarin.Forms.Button c;Label s = new Label();
      
		public TestPage ()
		{
            b = new ImageButton() { BorderColor = Color.Red, BorderWidth = 10, BorderRadius = 10, Text = "dit is een test1" };
            c = new Xamarin.Forms.Button() { BorderColor = Color.Blue, BorderWidth = 10, BorderRadius = 10, Text = "Dit is een test2", Image ="Icon.png"};
            b.CompleteImage = new Image {Source = "Icon.png" };
            Content = new StackLayout {
                Children = {
                   b,c,s,
				}
			};
            
            b.Clicked += B_Clicked;
            c.Clicked += C_Clicked;
		}

        private void C_Clicked(object sender, EventArgs e)
        {
            s.Text = "Normale button";
        }

        private void B_Clicked(object sender, EventArgs e)
        {
            s.Text = "ImageButton";
        }
    }
}
