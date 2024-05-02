using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL
{
    public class SMap
    {
        [Key]
        public Location Location { get; set; }
        //[Key]
        //[Column(Order = 1)]
        //public double Latitude { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //public double Longitude { get; set; }
        //public string Address { get; set; }
        [MaxLength(255)]
        public string URL { get; set; }
        public int zoom { get; set; }

        public SMap()
        {

        }

        public SMap(Map Map)
        {
            this.Location = Map.Location;
            this.URL = Map.URL;
            this.zoom = Map.zoom;
        }

        //public SMap(Map Map)
        //{
        //    this.Latitude = Map.Location.Latitude;
        //    this.Longitude = Map.Location.Longitude;
        //    this.Address = Map.Location.Address;
        //    this.URL = Map.URL;
        //    this.zoom = Map.zoom;
        //}

        //public SMap(double latitude, double longitude, string address, string uRL, int zoom)
        //{
        //    Latitude = latitude;
        //    Longitude = longitude;
        //    Address = address;
        //    URL = uRL;
        //    this.zoom = zoom;
        //}

        //public SMap(SMap map)
        //{
        //    this.Latitude = map.Latitude;
        //    this.Longitude = map.Longitude;
        //    this.Address = map.Address;
        //    this.URL = map.URL;
        //    this.zoom = map.zoom;
        //}
    }
    public class MapDbContext : DbContext
    {
        public DbSet<SMap> Maps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
        }
    }
}
