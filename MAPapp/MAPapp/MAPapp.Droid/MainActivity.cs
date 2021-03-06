﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MAPapp.Droid 
{
    //Mianlauncher naar False voor override
	[Activity (Label = "MAPapp", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            App.ScreenWidth = Resources.DisplayMetrics.WidthPixels;

            base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();

            LoadApplication (new MAPapp.App ());
		}
	}
}

