using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IMoonRepository
    {
        Task<IEnumerable<Moon>> GetMoonsAsync();
        Task<Moon> GetMoonAsync(int id);
        Task<IEnumerable<Moon>> FindMoonAsync(Expression<Func<Moon, bool>> where);
        Task<int> DeleteMoonAsync(int id, byte[] timestamp);
        Task<int> AddOrUpdateMoonAsync(Moon moon);
    }
}
