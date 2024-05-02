using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowSystems.DL.DO;

public struct Weather
{
    public Location Location { get; set; }
    public DateTime Date { get; set; }
    public double Temp { get; set; }
    public int Humidity { get; set; }
    public int Visibility { get; set; }

    public Weather(Weather weather)
    {
        Date = weather.Date;
        Temp = weather.Temp;
        Humidity = weather.Humidity;
        Visibility = weather.Visibility;
    }
}
