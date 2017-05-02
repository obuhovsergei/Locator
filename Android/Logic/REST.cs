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
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Locator.Android.Logic
{
    public static class REST
    {
        public static T RequestPOST<T>(string url, T model)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://" + url);
                request.Method = "GET";

                var body = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(model));

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = body.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());

                var objText = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<T>(objText);

                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }

        public static bool RequestGET(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://" + url + "/check");
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}