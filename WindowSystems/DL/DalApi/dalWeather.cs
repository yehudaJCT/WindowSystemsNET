namespace WindowSystems.DL.DalApi;


using System;
using System.Collections.Generic;
using WindowSystems.DL.API;
using WindowSystems.DL.interfaces;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class DalWeather : IWeather
{
    private static readonly HttpClient client = new HttpClient();

    public int Create(Weather entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Weather entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Weather> Read(Weather entity)
    {
        string openweathermap_api_key = "df21d91a75fffd8fdbac469d792d0e69";
        string url = $"http://api.openweathermap.org/data/2.5/forecast?lat={entity.lat}&lon={entity.lon}&appid={openweathermap_api_key}";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        dynamic data = JsonConvert.DeserializeObject(responseBody);

        Weather weather = new Weather
        {
            lat = entity.lat,
            lon = entity.lon,
            Date = data.Date,
            Sunrise = data.city.sunrise,
            Sunset = data.city.sunset,
            CurrentTemperature = data.list[0].main.temp,
            CurrentHumidity = data.list[0].main.humidity,
            CurrentVisibility = data.list[0].visibility,
            CurrentWindSpeed = data.list[0].wind.speed,
            CurrentWeatherDescription = data.list[0].weather[0].description,
            HourlyForecasts = new List<HourlyForecast>(), // You need to map the hourly forecasts
        };

        // Map the hourly forecasts
        foreach (var item in data.list)
        {
            weather.HourlyForecasts.Add(new HourlyForecast
            {
                Time = item.dt_txt,
                Temperature = item.main.temp,
                WeatherDescription = item.weather[0].description
            });
        }

        return weather;

    }

    public IEnumerable<Weather?> ReadAll(Func<Weather?, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public Weather ReadObject(Func<Weather?, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(Weather entity)
    {
        throw new NotImplementedException();
    }
}
