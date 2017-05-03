using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Locator.Android.Logic;
using Locator.API;
using System;

namespace Locator.Android.Activityes
{
    [Activity(Label = "Android", Icon = "@drawable/icon")]
    public class SignInActivity : Activity
    {
        Button b_signin;

        TextView txt_Email;
        TextView txt_Password;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignIn);

            b_signin = FindViewById<Button>(Resource.Id.b_ok_signin);
            txt_Email = FindViewById<TextView>(Resource.Id.txt_email_singin);
            txt_Password = FindViewById<TextView>(Resource.Id.txt_pass_signin);

            b_signin.Click += B_signin_Click;
        }

        private void B_signin_Click(object sender, EventArgs e)
        {
            if (txt_Email.Text != null && txt_Password.Text !=null)
            {
                User auth = new User
                {
                    Email = txt_Email.Text,
                    Password = txt_Password.Text
                };
                Manager.GetWorker().User = REST.RequestPOST(Manager.GetWorker().ServerURL+"/signin", auth);
                StartActivity(typeof(MapActivity));
            }
        }

       
    }
}

