using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace XamarinCrossPlatformNative.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash",MainLauncher = true,NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        private static readonly string Tag = "X:" + typeof(SplashActivity).Name;
        public  override void OnCreate(Bundle savedInstanceState,PersistableBundle persistableBundle)
        {
            base.OnCreate(savedInstanceState);

            Log.Debug(Tag, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();
            var startupWork=new Task(SimulateStartup);
            startupWork.Start();
        }

        public async void SimulateStartup()
        {
            Log.Debug(Tag, "Performing some startup work that takes a bit of time.");
            await Task.Delay(3000);
            Log.Debug(Tag, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context,typeof(MainActivity)));
        }

        public override void OnBackPressed() { }
    }
}