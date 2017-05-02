using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Locator.Android
{
    public static class Manager
    {
        private static Worker worker;

        public static Worker GetWorker()
        {
            if (worker == null)
            {
                worker = new Worker();
            }
            return worker;
        }
    }
}