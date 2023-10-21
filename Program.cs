using System;
using System.IO;
using Newtonsoft.Json; // You need to install the Newtonsoft.Json NuGet package.

class Program
{
    static void Main()
    {
        string jsonFile = "weatherData.json";
        if (File.Exists(jsonFile))
        {
            string json = File.ReadAllText(jsonFile);
            WeatherData data = JsonConvert.DeserializeObject<WeatherData>(json);

            Console.WriteLine($"Weather in {data.city}, {data.country}:");
            Console.WriteLine($"Current Temperature: {data.temperature.current} °C");
            Console.WriteLine($"Minimum Temperature: {data.temperature.min} °C");
            Console.WriteLine($"Maximum Temperature: {data.temperature.max} °C");
            Console.WriteLine($"Description: {data.description}");
        }
        else
        {
            Console.WriteLine("JSON file not found.");
        }
    }
}

public class WeatherData
{
    public string city { get; set; }
    public string country { get; set; }
    public Temperature temperature { get; set; }
    public string description { get; set; }
}

public class Temperature
{
    public double current { get; set; }
    public double min { get; set; }
    public double max { get; set; }
}
