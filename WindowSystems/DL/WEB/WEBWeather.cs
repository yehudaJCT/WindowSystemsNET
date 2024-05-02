using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowSystems.DL.DO;
using WindowSystems.DL.DOApi;

namespace WindowSystems.DL.WEB;


public class WEBWeather
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Weather> Read(Weather entity)
    {
        string openweathermap_api_key = "df21d91a75fffd8fdbac469d792d0e69";
        string url = $"http://api.openweathermap.org/data/2.5/forecast?lat={entity.Location.Latitude}&lon={entity.Location.Longitude}&appid={openweathermap_api_key}";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        dynamic data = JsonConvert.DeserializeObject(responseBody);

        Weather weather = new Weather
        {
            Date = data.Date,
            Temp = data.list[0].main.temp,
            Humidity = data.list[0].main.humidity,
            Visibility = data.list[0].visibility,
        };

        return weather;
    }
}
