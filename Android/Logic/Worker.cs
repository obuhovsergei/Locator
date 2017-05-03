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
using Locator.API;
using System.Threading;

namespace Locator.Android
{
    public class Worker
    {
        public string ServerURL { get; set; }
        public User User { get; set; }

        public event EventHandler needUpdate;

        public Worker()
        {
            Thread updater = new Thread(loop);
            //updater.IsBackground = true;
            updater.Start();
        }

        private void loop()
        {
            while (true)
            {
                if (needUpdate != null) needUpdate(this, new EventArgs());
                Thread.Sleep(15000);
            }
        }
    }
}