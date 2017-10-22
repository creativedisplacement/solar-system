using SolarSystem.Models;
using System.Data.Entity;

namespace SolarSystem.Data.DAL
{
    public class SolarSystemDbContext : DbContext
    {
        public SolarSystemDbContext() : base("name=SolarSystemDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Moon> Moons { get; set; }
        public virtual DbSet<Profile> DetailedProfiles { get; set; }

    }
}
