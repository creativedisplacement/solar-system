using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IPlanetRepository
    {
        Task<IEnumerable<Planet>> GetPlanetsAsync();
        Task<Planet> GetPlanetAsync(int id);
        Task<IEnumerable<Planet>> FindPlanetAsync(Expression<Func<Planet, bool>> where);
        Task<int> DeletePlanetAsync(int id, byte[] timestamp);
        Task<int> AddOrUpdatePlanetAsync(Planet planet);
    }
}
