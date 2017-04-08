using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IPlanetRepository : IDisposable
    {
        Task<IEnumerable<Planet>> GetPlanetsAsync();
        Task<Planet> GetPlanetAsync(int id);
        Task<IEnumerable<Planet>> FindPlanetAsync(Expression<Func<Planet, bool>> where);
        Task<bool> DeletePlanetAsync(Planet entity);
        Task<bool> AddOrUpdatePlanetAsync(Planet entity);
    }
}
