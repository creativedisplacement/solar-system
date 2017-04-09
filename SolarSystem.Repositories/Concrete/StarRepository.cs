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

        public void AddOrUpdateStarAsync(Star entity)
        {
            if (entity.Id == 0)
            {
                repository.Add(entity);
            }

            repository.Attach(entity, EntityStatus.Modified);
        }

        public void DeleteStarAsync(Star entity)
        {
            repository.Delete(entity);
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

        #region "disposing methods"

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (repository != null)
                    {
                        repository.Dispose();
                    }
                }

                disposed = true;
            }
        }

        #endregion
    }
}
