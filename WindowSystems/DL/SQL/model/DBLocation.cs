using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model;

public class DBLocation
{
    [Key]
    public int id { get; set; }
    public string Address;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    DBLocation()
    {

    }

    public DBLocation(Location location)
    {
        this.id = location.id;
        this.Address = location.Address;
        this.Latitude = location.Latitude;
        this.Longitude = location.Longitude;
    }

    public Location LocationConverter(DBLocation Location)
    {
        Location location = new Location(Location.id, Location.Address, Location.Latitude, Location.Longitude);
        return location;
    }


}