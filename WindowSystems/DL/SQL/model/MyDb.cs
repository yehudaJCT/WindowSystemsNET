using System.ComponentModel.DataAnnotations;
using System.Drawing;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model
{
    public class MyDb
    {
        [Key]
        public int id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string URL { get; set; }
        public int zoom { get; set; }
        public DateTime Date { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public MyDb()
        {

        }

        public MyDb(int id, Map Map)
        {
            this.id = id;
            this.Latitude = Map.Location.Latitude;
            this.Longitude = Map.Location.Longitude;
            this.Address = Map.Location.Address;
            this.URL = Map.URL;
            this.zoom = Map.zoom;
        }

        public MyDb(int id, double latitude, double longitude, string address, string uRL, int zoom)
        {
            this.id = id;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Address = address;
            this.URL = uRL;
            this.zoom = zoom;
        }

        public MyDb(MyDb map)
        {
            this.id = map.id;
            this.Latitude = map.Latitude;
            this.Longitude = map.Longitude;
            this.Address = map.Address;
            this.URL = map.URL;
            this.zoom = map.zoom;
        }

        public DO.Map converter(MyDb sMap)
        {
            DO.Location location = new Location(sMap.Address, sMap.Latitude, sMap.Longitude);
            DO.Map map = new Map(location, sMap.URL, sMap.zoom);
            return map;
        }
    }
}
