
using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model;

public class DBWeather
{
    [Key]
    public int id { get; set; }
    public DateTime Date { get; set; }
    public double Temp { get; set; }
    public int Humidity { get; set; }
    public int Visibility { get; set; }

    DBWeather()
    {

    }

    public DBWeather(Weather weather)
    {
        this.id = weather.id;
        this.Date = weather.Date;
        this.Temp = weather.Temp;
        this.Humidity = weather.Humidity;
        this.Visibility = weather.Visibility;
    }

    public Weather WeatherConverter(DBWeather Weather, DL.DO.Location location)
    {
        Weather weather = new Weather(location, Weather.Date, Weather.Temp, Weather.Humidity, Weather.Visibility);
        return weather;
    }

}
