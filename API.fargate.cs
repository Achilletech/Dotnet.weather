using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string city = "New York";
        string country = "US";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = $"https://api.open-meteo.com/v1/forecast?city={city}&country={country}&daily=temperature_2m_min_max";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherData data = WeatherData.FromJson(json);

                    Console.WriteLine($"Weather in {city}, {country}:");
                    Console.WriteLine($"Minimum Temperature: {data.Daily.Temperature2m.Min} °C");
                    Console.WriteLine($"Maximum Temperature: {data.Daily.Temperature2m.Max} °C");
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve weather data. Error code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

public class WeatherData
{
    public Daily Daily { get; set; }

    public static WeatherData FromJson(string json) => System.Text.Json.JsonSerializer.Deserialize<WeatherData>(json);
}

public class Daily
{
    public Temperature2m Temperature2m { get; set; }
}

public class Temperature2m
{
    public double Min { get; set; }
    public double Max { get; set; }
}
