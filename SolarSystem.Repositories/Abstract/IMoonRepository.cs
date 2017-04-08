using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IMoonRepository : IDisposable
    {
        Task<IEnumerable<Moon>> GetMoonsAsync();
        Task<Moon> GetMoonAsync(int id);
        Task<IEnumerable<Moon>> FindMoonAsync(Expression<Func<Moon, bool>> where);
        Task<bool> DeleteMoonAsync(Moon entity);
        Task<bool> AddOrUpdateMoonAsync(Moon entity);
    }
}
