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
        void DeleteMoonAsync(Moon entity);
        void AddOrUpdateMoonAsync(Moon entity);
    }
}
