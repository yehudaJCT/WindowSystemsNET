using System.Drawing;

namespace WindowSystems.DL.DO;


public struct Map
{
    public Location Location { get; }
    public string URL { get; }
    public int zoom { get; }

    public Map(Location location, string URL, int zoom)
    {
        this.Location = location;
        this.URL = URL;
        this.zoom = zoom;
    }

    public Map(Location location, int zoom)
    {
        this.Location = location;
        this.zoom = zoom;
    }


};
