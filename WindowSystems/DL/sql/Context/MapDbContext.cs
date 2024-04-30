using Microsoft.EntityFrameworkCore;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.sql.Context
{
    public class MapDbContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
        }
    }
}
