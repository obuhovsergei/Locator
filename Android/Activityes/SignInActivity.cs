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
    public class SignInActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignIn);
        }
    }
}

