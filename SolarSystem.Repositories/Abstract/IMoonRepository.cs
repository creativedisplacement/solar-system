using SolarSystem.Data;
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
        Task<bool> DeleteAsync(Moon entity);
        Task<bool> AddMoonAsync(Moon entity);
        Task<bool> AttachMoonAsync(Moon entity);
        Task<bool> AttachMoonAsync(Moon entity, EntityStatus status);
        Task<bool> DetachMoonAsync(Moon entity);
    }
}
