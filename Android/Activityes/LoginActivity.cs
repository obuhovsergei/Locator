using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Locator.Android.Logic;
using System;

namespace Locator.Android.Activityes
{
    [Activity(Label = "Android", Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        TextView txt_Server;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Login);
            var b_signUp = FindViewById<Button>(Resource.Id.b_signUp);
            var b_signIn = FindViewById<Button>(Resource.Id.b_signIn);
            txt_Server = FindViewById<TextView>(Resource.Id.txt_serverIp);

            b_signUp.Click += B_sign_Click;
            b_signIn.Click += B_sign_Click;
        }

        private void B_sign_Click(object sender, EventArgs e)
        {
            if (REST.RequestGET(txt_Server.Text))
            {
                Manager.GetWorker().ServerURL = txt_Server.Text;
                if (((Button)sender).Id == Resource.Id.b_signUp)
                {
                    StartActivity(typeof(SignUpActivity));
                }
                else
                {
                    StartActivity(typeof(SignInActivity));
                }
            }

        }
    }
}

