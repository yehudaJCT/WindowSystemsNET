using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;
using System.Drawing;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
   
    public class MapDbContext : DbContext
    {
        public DbSet<DbMap> Maps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            //optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }

    }
}
