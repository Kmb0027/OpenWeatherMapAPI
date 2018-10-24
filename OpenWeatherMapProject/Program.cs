using System;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            string response = webClient.DownloadString("Https://api.chucknorris.io/jokes/random");
            JObject jo = JObject.Parse(response);
            Console.WriteLine(jo.GetValue("value"));
        }
    }
}
