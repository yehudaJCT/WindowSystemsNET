using System.Drawing;

namespace WindowSystems.DL.DO;


public struct Map
{
    public Location Location { get; set; }
    public string URL { get; set; }
    public int zoom { get; set; }


    public Map(Map map)
    {
        this.Location = map.Location;
        this.URL = map.URL;
        this.zoom = map.zoom;
    }

    public Map(Location location, string URL, int zoom)
    {
        this.Location = location;
        this.URL = URL;
        this.zoom = zoom;
    }


};
