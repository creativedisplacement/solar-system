namespace SolarSystem.Data.Migrations
{
    using SolarSystem.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SolarSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.SolarSystemDbContext context)
        {
            var star = new Star { Name = "Sun", Ordinal = 1, CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now };
            var planet = new Planet { Name = "Earth", Ordinal = 3, CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Star = star };
            var moon = new Moon { Name = "Moon", Ordinal = 1, CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Planet = planet };
            var detailedProfile = new Profile
            {
                Id = 1,
                Introduction = "Introduction",
                Content = "Content",
                HasRings = false,
                TypeId = 1,
                TypeName = "Planet"  
            };

            context.Stars.AddOrUpdate(star);
            context.Planets.AddOrUpdate(planet);
            context.Moons.AddOrUpdate(moon);
            context.DetailedProfiles.AddOrUpdate(detailedProfile);
        }
    }
}
