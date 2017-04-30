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

namespace Locator.Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationListener
    {

        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;

        protected override void OnCreate(Bundle bundle)
        {
         
            base.OnCreate(bundle);
            InitializeLocationManager();
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            Console.WriteLine(_currentLocation);
        }
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                Console.WriteLine(_currentLocation.Longitude + "  " + _currentLocation.Latitude);
                
            }
            else
            {
                Console.WriteLine("no info");
            }
            sendData(location);
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }


        void sendData(Location location)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://zanzibarland.ddns.net:81");

            Data data = new Data { Longitude = location.Longitude, Latitude = location.Latitude };
            var body = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data));

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
        }

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.NoRequirement
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
            Console.WriteLine("Using " + _locationProvider + ".");
        }
    }
}

