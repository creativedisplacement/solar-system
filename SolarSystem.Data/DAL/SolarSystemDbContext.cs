using SolarSystem.Models;
using System.Data.Entity;

namespace SolarSystem.Data.DAL
{
    public class SolarSystemDbContext : DbContext
    {
        public SolarSystemDbContext() : base("name=SolarSystemDbContext")
        {

        }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Moon> Moons { get; set; }
        public DbSet<DetailedProfile> DetailedProfiles { get; set; }

    }
}
