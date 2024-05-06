using System.Drawing;

namespace WindowSystems.DL.DO;


public struct Map
{
    public int id { get; set; }
    public Location Location { get; set; }
    public string URL { get; set; }
    public int zoom { get; set; }


    public Map(Location location, string URL, int zoom)
    {
        this.id = location.id;
        this.Location = location;
        this.URL = URL;
        this.zoom = zoom;
    }


};
