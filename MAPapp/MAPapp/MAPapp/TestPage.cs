
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class TestPage : ContentPage
	{
      //  ImageButton b;
        Image z;
        Image iim;
        Xamarin.Forms.Button c;Label s = new Label();
      
		public TestPage ()
		{
            
            
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            z = new Image();
            iim = new Image();

            iim.Source = "InstellingenButton.png";
            z.Source = "InformatieButton2.png";
            z.Scale = 0.75;
          
            z.GestureRecognizers.Add(tap);
     //       b = new ImageButton() { BorderColor = Color.Red, BorderWidth = 10, BorderRadius = 10,Image = "InformatieButton.png" };
          //  c = new Xamarin.Forms.Button() { BorderColor = Color.Blue, BorderWidth = 10, BorderRadius = 10, Text = "Dit is een test2", Image ="Icon.png"};
            //b.CompleteImage = new Image {Source = "Icon.png" };
            Content = new StackLayout {
                Children = {
                 z,  s,
				}
			};
            
            //b.Clicked += B_Clicked;
          //  c.Clicked += C_Clicked;
		}

        private async void Tap_Tapped(object sender, EventArgs e)
        {
           
            //      if (z.Rotation == 0) { 
            await  z.ScaleTo(0.65,100);
            await z.ScaleTo(0.75,100);
            Navigation.PushAsync(new TestPage());
            //     else
            //await z.RotateTo(0, 2000);

            z.IsOpaque = true;
       //     z.IsEnabled = false;
            
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
