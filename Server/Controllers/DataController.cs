using System;
using Nancy.Hosting.Self;

namespace Locator.Server.Controllers
{
    public class DataController : Nancy.NancyModule
    {
        public DataController()
        {
            Get["/location"] = x =>
            {
                return "";
            };

            Post["/location"] = x =>
            {
                var body = this.Request.Body;
                int length = (int)body.Length;
                byte[] data = new byte[length];
                body.Read(data, 0, length);

                Console.WriteLine(System.Text.Encoding.Default.GetString(data));

                return "OK";
            };
        }
    }
}
