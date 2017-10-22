using SolarSystem.Data;
using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Concrete
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly IRepository<Planet> repository;

        public PlanetRepository(IRepository<Planet> repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddOrUpdatePlanetAsync(Planet planet)
        {
            if (planet.Id == 0)
            {
                return await repository.AddAsync(planet);
            }

            return await repository.SaveAsync(planet);
        }

        public async Task<int> DeletePlanetAsync(int id, byte[] timestamp)
        {
            return await repository.DeleteAsync(new Planet { Id = id, Timestamp = timestamp });
        }

        public async Task<IEnumerable<Planet>> FindPlanetAsync(Expression<Func<Planet, bool>> where)
        {
            return (await repository.FindAsync(where));
        }

        public async Task<Planet> GetPlanetAsync(int id)
        {
            return (await repository.SingleOrDefaultAsync(s => s.Id == id));
        }

        public async Task<IEnumerable<Planet>> GetPlanetsAsync()
        {
            return (await repository.GetAllAsync()).OrderBy(s => s.Ordinal);
        }
    }
}
