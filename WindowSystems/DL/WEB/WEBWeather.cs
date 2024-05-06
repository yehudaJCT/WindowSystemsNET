using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.WEB;


public class WEBWeather
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Weather> Read(Weather entity)
    {
        try
        {
            string units = "metric";
            string openweathermap_api_key = "df21d91a75fffd8fdbac469d792d0e69";
            string url = $"http://api.openweathermap.org/data/2.5/forecast?lat={entity.Location.Latitude}&lon={entity.Location.Longitude}&units={units}&appid={openweathermap_api_key}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(responseBody);

            Weather weather = new Weather
            {
                Location = entity.Location,
                Date = DateTime.Parse((string)data.list[0].dt_txt),
                Temp = (double)data.list[0].main.temp_max,
                Humidity = (int)data.list[0].main.humidity,
                Visibility = (int)data.list[0].visibility,
            };

            return weather;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Error: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
    }
}
