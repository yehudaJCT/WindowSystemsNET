using Microsoft.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowSystems.DL.DO;

public struct Weather
{
    public int id { get;}
    public Location Location { get; }
    public DateTime Date { get; }
    public double Temp { get; }
    public int Humidity { get; }
    public int Visibility { get; }

    public Weather(Location location, DateTime date, double temp, int humidity, int visibility)
    {
        this.id = location.id;
        this.Location = location;
        this.Date = date;
        this.Temp = temp;
        this.Humidity = humidity;
        this.Visibility = visibility;
    }

    public Weather(Location location)
    {
        this.id = location.id;
        this.Location = location;
    }
}
