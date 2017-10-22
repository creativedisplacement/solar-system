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
    public class MoonRepository : IMoonRepository
    {
        private readonly IRepository<Moon> repository;

        public MoonRepository(IRepository<Moon> repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddOrUpdateMoonAsync(Moon moon)
        {
            if (moon.Id == 0)
            {
                return await repository.AddAsync(moon);
            }

            return await repository.SaveAsync(moon);
        }

        public async Task<int> DeleteMoonAsync(int id, byte[] timestamp)
        {
            return await repository.DeleteAsync(new Moon { Id = id, Timestamp = timestamp });
        }

        public async Task<IEnumerable<Moon>> FindMoonAsync(Expression<Func<Moon, bool>> where)
        {
            return (await repository.FindAsync(where));
        }

        public async Task<Moon> GetMoonAsync(int id)
        {
            return (await repository.SingleOrDefaultAsync(s => s.Id == id));
        }

        public async Task<IEnumerable<Moon>> GetMoonsAsync()
        {
            return (await repository.GetAllAsync()).OrderBy(s => s.Ordinal);
        }
    }
}
