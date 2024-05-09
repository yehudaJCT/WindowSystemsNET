using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL;
using WindowSystems.DL.SQL;

namespace WindowSystems.DL.SQL.model;


public class DBMap
{
    [Key]
    public int id { get; set; }

    [StringLength(255)] 
    public string URL { get; set; }
    public int zoom { get; set; }

    DBMap()
    {

    }

    public DBMap(Map map)
    {
        this.id = map.id;
        this.URL = map.URL;
        this.zoom = map.zoom;
    }

    public Map MapConverter(DBMap Map, Location Location)
    {
        Map map = new Map(Location, Map.URL, Map.zoom);
        return map;
    }


};
