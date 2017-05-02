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
using Locator.Android.Logic;

namespace Locator.Android
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
                Auth auth = new Auth
                {
                    Email = txt_Email.Text,
                    Password = txt_Password.Text
                };
                REST.RequestPOST(Manager.GetWorker().serverURL+"/signin",auth);
            }
        }

       
    }
}

