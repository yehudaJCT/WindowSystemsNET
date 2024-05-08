using System.Drawing;

namespace WindowSystems.DL.DO;


public struct Map
{
    public int id { get; }
    public Location Location { get; }
    public string URL { get; }
    public int zoom { get; }

    public Map(Location location, string URL, int zoom)
    {
        this.id = location.id;
        this.Location = location;
        this.zoom = zoom;
    }

    public Map(Location location, int zoom)
    {
        this.id = location.id;
        this.Location = location;
        this.zoom = zoom;
    }


};
