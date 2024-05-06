using Microsoft.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowSystems.DL.DO;

public struct Weather
{
    public int id { get; set; }
    public Location Location { get; set; }
    public DateTime Date { get; set; }
    public double Temp { get; set; }
    public int Humidity { get; set; }
    public int Visibility { get; set; }

    public Weather(Weather weather)
    {
        Location = weather.Location;
        Date = weather.Date;
        Temp = weather.Temp;
        Humidity = weather.Humidity;
        Visibility = weather.Visibility;
    }

    public Weather(Location location, DateTime date, double temp, int humidity, int visibility)
    {
        this.id = location.id;
        this.Location = location;
        this.Date = date;
        this.Temp = temp;
        this.Humidity = humidity;
        this.Visibility = visibility;
    }
}
