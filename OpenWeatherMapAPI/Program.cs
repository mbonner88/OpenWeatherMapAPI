using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var apiKey = "89db265be99412b8e3d044cc91a322c5";
            Console.WriteLine($"Welcome to this weather app.");
            while (true)
            {
                Console.WriteLine($"Please enter city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";
                var weatherResponse = client.GetStringAsync(weatherURL).Result;
                Console.WriteLine(JObject.Parse(weatherResponse).GetValue("main").ToString());
                Console.WriteLine($"Do you want to enter another city?");
                if(Console.ReadLine().ToUpper() == "NO") { break; }
            }
        }
    }
}
