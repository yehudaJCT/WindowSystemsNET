namespace WindowSystems.DL.API;

public struct WeatherDetails
{
    public double lat { get; set; }
    public double lon { get; set; }
    public DateTime Sunrise { get; set; }
    public DateTime Sunset { get; set; }
    public double CurrentTemperature { get; set; }
    public int CurrentHumidity { get; set; }
    public int CurrentVisibility { get; set; }
    public double CurrentWindSpeed { get; set; }
    public string CurrentWeatherDescription { get; set; }
    public List<HourlyForecast> HourlyForecasts { get; set; }
    public List<DailyForecast> DailyForecasts { get; set; }

    public WeatherDetails(WeatherDetails weather)
    {
        lat = weather.lat;
        lon = weather.lon;
        Sunrise = weather.Sunrise;
        Sunset = weather.Sunset;
        CurrentTemperature = weather.CurrentTemperature;
        CurrentHumidity = weather.CurrentHumidity;
        CurrentVisibility = weather.CurrentVisibility;
        CurrentWindSpeed = weather.CurrentWindSpeed;
        CurrentWeatherDescription = weather.CurrentWeatherDescription;
        HourlyForecasts = new List<HourlyForecast>(weather.HourlyForecasts);
        DailyForecasts = new List<DailyForecast>(weather.DailyForecasts);
    }

    public WeatherDetails()
    { 

    }
}


public struct HourlyForecast
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public string WeatherDescription { get; set; }
}

public struct DailyForecast
{
    public DateTime Date { get; set; }
    public double DayTemperature { get; set; }
    public double NightTemperature { get; set; }
    public string WeatherDescription { get; set; }
}