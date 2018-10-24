using System;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace OpenWeatherMapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the ZipCode of the area?");
            int zipCode = int.Parse(Console.ReadLine());
            Console.Clear();

            WebClient webClient = new WebClient();
#if DEBUG
            string apiKey = File.ReadAllText("appsetting.development.txt");
#else
            string apiKey = File.ReadAllText("appsetting.release.txt");
#endif
            string fullApiLink = $"Https://api.openweathermap.org/data/2.5/weather?zip={zipCode}" + apiKey;
            string ApiResponse = webClient.DownloadString(fullApiLink);
            JObject jo = JObject.Parse(ApiResponse);
            double tempMath = double.Parse(jo.GetValue("main")["temp"].ToString());
            double FahrenheitTemp = tempMath * 9 / 5 - 459.67;
            FahrenheitTemp = Math.Round(FahrenheitTemp, 1);
            Console.WriteLine($"The temperature is currently {FahrenheitTemp} degrees fahrenheit.");
        }
    }
}
