using System.Drawing;

namespace WindowSystems.BL.BO;


public struct MapWeather
{
    public string URL { get; set; }
    public double Temp { get; set; }
    public int Humidity { get; set; }
    public int Visibility { get; set; }


    public MapWeather(MapWeather map)
    {
        this.URL = map.URL;
    }

    public MapWeather(string URL)
    {
       
        this.URL = URL;
        
    }

};
