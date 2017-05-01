using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using Locator.API;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Android.Views;

namespace Locator.Android
{
    [Activity(Label = "Android", Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Login);
            var b_signUp = FindViewById<Button>(Resource.Id.b_signUp);
            var b_signIn = FindViewById<Button>(Resource.Id.b_signIn);
            var txt_Server = FindViewById<TextView>(Resource.Id.txt_serverIp);

            b_signUp.Click += B_signUp_Click;
            b_signIn.Click += B_signIn_Click;
        }

        private void B_signIn_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SignInActivity));
        }

        private void B_signUp_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
        }
    }
}

