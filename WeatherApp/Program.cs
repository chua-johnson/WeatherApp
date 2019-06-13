using System;
using Weather.DomainModel.JSONModel;
using Weather.DomainModel.XMLModel;
using Weather.Service;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            printWeatherInfoJSON();
            printWeatherInfoXML();
        }

        private static RootObject getWeatherJSON()
        {
            RootObject rootObject = new RootObject();
            WeatherService<RootObject> weatherService = new WeatherService<RootObject>();

            rootObject = weatherService.GetWeather(false);
            return rootObject;
        }

        private static Current getWeatherXML()
        {
            Current current = new Current();
            WeatherService<Current> weatherService = new WeatherService<Current>();

            current = weatherService.GetWeather(true);
            return current;
        }

        private static void printWeatherInfoJSON()
        {
            RootObject rootObject = getWeatherJSON();
            if (rootObject == null && rootObject.main == null && rootObject.sys == null)
            {
                Console.WriteLine("Something went wrong.");
            }

            Console.WriteLine("---------------- Weather (JSON) -----------------");
            Console.WriteLine($"Country : {rootObject.sys.country}");
            Console.WriteLine($"Temperature: {rootObject.main.temp}");
            Console.WriteLine($"Humidity: {rootObject.main.humidity}");
            Console.WriteLine($"Temp Min: {rootObject.main.temp_min}");
            Console.WriteLine($"Temp Max: {rootObject.main.temp_max}");
            Console.WriteLine("--------- End here ----------------------------");
        }

        private static void printWeatherInfoXML()
        {
            Current current = getWeatherXML();
            if (current == null && current.City == null && current.Humidity == null && current.Temperature == null)
            {
                Console.WriteLine("Something went wrong.");
            }

            Console.WriteLine("---------------- Weather (XML) -----------------");
            Console.WriteLine($"Country : {current.City.Country}");
            Console.WriteLine($"Temperature: {current.Temperature.Value}");
            Console.WriteLine($"Humidity: {current.Humidity.Value}");
            Console.WriteLine($"Temp Min: {current.Temperature.Min}");
            Console.WriteLine($"Temp Max: {current.Temperature.Max}");
            Console.WriteLine("--------- End here ----------------------------");
        }
    }
}
