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
    public class StarRepository : IStarRepository
    {
        private readonly IRepository<Star> repository;

        public StarRepository(IRepository<Star> repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddOrUpdateStarAsync(Star star)
        {
            if (star.Id == 0)
            {
               return await repository.AddAsync(star);
            }

            return await repository.SaveAsync(star);
        }

        public async Task<int> DeleteStarAsync(int id, byte[] timestamp)
        {
            return await repository.DeleteAsync(new Star { Id = id, Timestamp = timestamp });
        }

        public async Task<IEnumerable<Star>> FindStarAsync(Expression<Func<Star, bool>> where)
        {
            return (await repository.FindAsync(where));
        }

        public async Task<Star> GetStarAsync(int id)
        {
            return (await repository.SingleOrDefaultAsync(s => s.Id == id));
        }

        public async Task<IEnumerable<Star>> GetStarsAsync()
        {
            return (await repository.GetAllAsync()).OrderBy(s => s.Ordinal);
        }
    }
}
