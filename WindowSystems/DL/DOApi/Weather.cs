public struct Weather
{
    public double lat { get; set; }
    public double lon { get; set; }
    public DateTime Date { get; set; }
    public DateTime Sunrise { get; set; }
    public DateTime Sunset { get; set; }
    public double CurrentTemperature { get; set; }
    public int CurrentHumidity { get; set; }
    public int CurrentVisibility { get; set; }
    public double CurrentWindSpeed { get; set; }
    public string CurrentWeatherDescription { get; set; }
    public List<HourlyForecast> HourlyForecasts { get; set; }

    public Weather(Weather weather)
    {
        lat = weather.lat;
        lon = weather.lon;
        Date = weather.Date;
        Sunrise = weather.Sunrise;
        Sunset = weather.Sunset;
        CurrentTemperature = weather.CurrentTemperature;
        CurrentHumidity = weather.CurrentHumidity;
        CurrentVisibility = weather.CurrentVisibility;
        CurrentWindSpeed = weather.CurrentWindSpeed;
        CurrentWeatherDescription = weather.CurrentWeatherDescription;
        HourlyForecasts = new List<HourlyForecast>(weather.HourlyForecasts);
    }

    public Weather(double lat, double lon, DateTime Date)
    {
        this.lat = lat;
        this.lon = lon;
        this.Date = Date;
        this.Sunrise = default;
        this.Sunset = default;
        this.CurrentTemperature = default;
        this.CurrentHumidity = default;
        this.CurrentVisibility = default;
        this.CurrentWindSpeed = default;
        this.CurrentWeatherDescription = default;
        this.HourlyForecasts = new List<HourlyForecast>();
    }
}

public struct HourlyForecast
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public string WeatherDescription { get; set; }

    public HourlyForecast(HourlyForecast hourly)
    {
        Time = hourly.Time;
        Temperature = hourly.Temperature;
        WeatherDescription = hourly.WeatherDescription;
    }
}