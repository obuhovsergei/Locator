using Android.App;
using Android.OS;

namespace Locator.Android.Activityes
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/Icon")]
    public class SplashActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(LoginActivity));
        }
    }
}