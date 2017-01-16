using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using MAPapp.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof (MAPapp.ImageButton), typeof (CustomButtonRenderer))]
namespace MAPapp.Droid {
    class CustomButtonRenderer : ButtonRenderer
        {
       
            private GradientDrawable _normal, _pressed;
        private Canvas s = new Canvas();
        Drawable d;

        protected override async void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            //   Bitmap s= 
            //  s.SetBitmap();
            s.DrawColor(Android.Graphics.Color.Blue);
            base.OnElementChanged(e);
           // await TryGetWritePermission();
            if (Control != null)
            {
                
                d = new BitmapDrawable();
                var button = (ImageButton)e.NewElement;
                Image i = button.CompleteImage;
              
                
                // Create a drawable for the button's normal state
                _normal = new Android.Graphics.Drawables.GradientDrawable();

                if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
                    _normal.SetColor(Android.Graphics.Color.ParseColor("#ff2c2e2f"));
                else
                    _normal.SetColor(button.BackgroundColor.ToAndroid());

                _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                _normal.SetCornerRadius(button.BorderRadius);

                // Create a drawable for the button's pressed state
                _pressed = new Android.Graphics.Drawables.GradientDrawable();
                var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
                _pressed.SetColor(highlight);
                _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                _pressed.SetCornerRadius(button.BorderRadius);
                //   _normal.Draw(s);
                Bitmap bitmap = Bitmap.CreateBitmap(1000, 1000, Bitmap.Config.Argb8888);
                // System.Diagnostics.Debug.WriteLine(button.Text);
               
                
                bitmap = BitmapFactory.DecodeFile(button.Image);

                // bitmap = ImageSource.FromFile("@drawable / icon");
             //   Bitmap bitmap = await GetBitmap(button.CompleteImage);
                d = new BitmapDrawable(bitmap);
              //  Canvas s = new Canvas(bitmap);
                //   Paint p = new Paint { Color = Android.Graphics.Color.Red };
                //    s.DrawCircle(10, 10, 10, p);

                // Add the drawables to a state list and assign the state list to the button
                var sld = new StateListDrawable();
                sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
                sld.AddState(new int[] { }, d);//_normal);
                Control.SetBackground(sld);
            }
        }
        Task<Bitmap> GetBitmap(Xamarin.Forms.Image image)
        {
            var handler = new ImageLoaderSourceHandler();
            return handler.LoadImageAsync(image.Source,Context);
        }
/*
        async Task TryGetWritePermission()
        {
           
                if ((int)Build.VERSION.SdkInt < 23)
                {
                   
                    return;
                }

            // await GetLocationPermissionAsync();
       const String permission = Manifest.Permission.READ_EXTERNAL_STORAGE;
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------------------"+CheckSelfPermission(permission));

        }
        */
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var button = (MAPapp.ImageButton)sender;

            if (_normal != null && _pressed != null)
            {
                if (e.PropertyName == "BorderRadius")
                {
                    _normal.SetCornerRadius(button.BorderRadius);
                    _pressed.SetCornerRadius(button.BorderRadius);
                }
                if (e.PropertyName == "BorderWidth" || e.PropertyName == "BorderColor")
                {
                    _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                    _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                }
                if (e.PropertyName == "Image" )
                {
                    
                }
                
              
            }
        }
    }
    }

