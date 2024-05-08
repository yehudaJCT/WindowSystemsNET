using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;
using System.Drawing;
using WindowSystems.DL.SQL.model;
using WindowSystems.SQL.model;

namespace WindowSystems.DL.SQL
{

    public class MyDbContext : DbContext
    {
        public DbSet<DBChatGpt> ChatGpt { get; set; }
        public DbSet<DBLocation> Location { get; set; }
        public DbSet<DBMap> Map { get; set; }
        public DbSet<DBWeather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            //optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }

    }
}
