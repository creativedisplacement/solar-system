using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IStarRepository : IDisposable
    {
        Task<IEnumerable<Star>> GetStarsAsync();
        Task<Star> GetStarAsync(int id);
        Task<IEnumerable<Star>> FindStarAsync(Expression<Func<Star, bool>> where);
        Task<bool> DeleteStarAsync(Star entity);
        Task<bool> AddOrUpdateStarAsync(Star entity);
    }
}
