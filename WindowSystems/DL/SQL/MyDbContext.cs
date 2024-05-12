using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;
using System.Drawing;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{

    public class MyDbContext : DbContext
    {
        public DbSet<DBMap> Map { get; set; }
        public DbSet<DBChatGpt> ChatGpt { get; set; }
        public DbSet<DBLocation> Location { get; set; }
        public DbSet<DBWeather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Configure your connection string here
            //optionsBuilder.UseSqlServer("Server=localhost;Database=WSDB;Trusted_Connection=True;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=WSDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=WSDB;Trusted_Connection=True;");
            // optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            // TrustServerCertificate=True
            //"Server=localhost;Database=master;Trusted_Connection=True;"


            optionsBuilder.UseInMemoryDatabase("MyDb");
        }

    }
}
