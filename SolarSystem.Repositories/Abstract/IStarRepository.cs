using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IStarRepository
    {
        Task<IEnumerable<Star>> GetStarsAsync();
        Task<Star> GetStarAsync(int id);
        Task<IEnumerable<Star>> FindStarAsync(Expression<Func<Star, bool>> where);
        Task<int> DeleteStarAsync(int id, byte[] timestamp);
        Task<int> AddOrUpdateStarAsync(Star entity);
    }
}
