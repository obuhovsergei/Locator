using Android.App;
using Android.Locations;
using Android.OS;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.Android.Activityes
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, ILocationListener
    {
        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;


        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Map);
            InitLocationManager();

            Manager.GetWorker().needUpdate += MapActivity_needUpdate;
        }

 

        private void MapActivity_needUpdate(object sender, EventArgs e)
        {
            if (_currentLocation != null)
            {
                //Sending message
                var data = new API.Data
                {
                    UserID = Manager.GetWorker().User.ID,
                    DT = DateTime.Now,
                    Latitude = _currentLocation.Latitude,
                    Longitude = _currentLocation.Longitude
                };
                Logic.REST.RequestPOST(Manager.GetWorker().ServerURL + "/location", data);
            }
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (location != null)
            {
                Console.WriteLine(_currentLocation.Longitude + "  " + _currentLocation.Latitude);
            }
            else
            {
                Console.WriteLine("no info");
            }
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }


        void InitLocationManager()
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
            _locationManager.RequestLocationUpdates(_locationProvider, 2000, 1, this);
            Console.WriteLine("Using " + _locationProvider + ".");
        }
    }
}