namespace WindowSystems.DL.API;


public struct Map
{
    public string URL { get; set;}
    public double lan {  get; set;}
    public double lon { get; set; }
    public double zoom { get; set; }

    public Map(Map map)
    {
        this.URL = map.URL;
        this.lan = map.lan;
        this.lon = map.lon;
        this.zoom = map.zoom;

    }

};
