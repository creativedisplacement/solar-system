using SolarSystem.Data;
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
        Task<bool> DeleteAsync(Star entity);
        Task<bool> AddStarAsync(Star entity);
        Task<bool> AttachStarAsync(Star entity);
        Task<bool> AttachStarAsync(Star entity, EntityStatus status);
        Task<bool> DetachStarAsync(Star entity);
    }
}
