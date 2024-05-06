BL

1. request to chack if the address 

namespace WindowSystems.BL.BO;
public struct Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(string address, double latitude, double longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }
}

2. request based on Date and lat lon the weather and the map for the present step 

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

3. request responde from ChatGpt

namespace WindowSystems.BL.BO;
public struct ChatGpt
{
    public string responde;

    public ChatGpt(string responde)
    {
        this.responde = responde;
    }
}





4. get all DS (for hestory)

5. delete 

6. edit prompt of an existing Entity


