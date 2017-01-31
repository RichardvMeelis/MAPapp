using System.Threading.Tasks;
using MAPapp.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace MyApp.Droid
{
    //Nieuwe MainLauncher voor Android SplashScreen
    [Activity(Theme = "@style/MyTheme.Splash" ,Label = "MAPapp", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() =>
            {
                Task.Delay(50);
            });

            startupWork.ContinueWith(t =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}