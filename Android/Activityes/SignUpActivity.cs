﻿using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Locator.Android.Logic;
using Locator.API;
using System;

namespace Locator.Android.Activityes
{
    [Activity(Label = "Android", Icon = "@drawable/icon")]
    public class SignUpActivity : Activity
    {
        Button b_signUp;

        TextView txt_Name;
        TextView txt_Email;
        TextView txt_Password;
        TextView txt_Password_repeat;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignUp);
            b_signUp = FindViewById<Button>(Resource.Id.b_ok_signUp);

            txt_Name = FindViewById<TextView>(Resource.Id.txt_name_signup);
            txt_Email = FindViewById<TextView>(Resource.Id.txt_email_signup);
            txt_Password = FindViewById<TextView>(Resource.Id.txt_pass_signup);
            txt_Password_repeat = FindViewById<TextView>(Resource.Id.txt_pass_repeat_signup);

            b_signUp.Click += B_signUp_Click;
        }

        private void B_signUp_Click(object sender, EventArgs e)
        {

            //Check if all txt field not null
            if (txt_Name.Text != null && txt_Email.Text != null && txt_Password.Text != null && txt_Password_repeat.Text != null)
            {
                if (txt_Password.Text == txt_Password_repeat.Text)
                {
                    Manager.GetWorker().User = REST.RequestPOST(Manager.GetWorker().ServerURL + "/signup",
                   new User
                   {
                       Email = txt_Email.Text,
                       Name = txt_Name.Text,
                       Password = txt_Password.Text
                   });
                    StartActivity(typeof(MapActivity));
                }
            }
        }
    }
}

