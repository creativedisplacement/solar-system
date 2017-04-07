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

        public async Task<bool> AddStarAsync(Star entity)
        {
            return (await repository.AddAsync(entity));
        }

        public async Task<bool> AttachStarAsync(Star entity)
        {
            return (await repository.AttachAsync(entity));
        }

        public async Task<bool> AttachStarAsync(Star entity, EntityStatus status)
        {
            return (await repository.AttachAsync(entity, status));
        }

        public async Task<bool> DeleteAsync(Star entity)
        {
            return (await repository.DeleteAsync(entity));
        }

        public async Task<bool> DetachStarAsync(Star entity)
        {
            return (await repository.DetachAsync(entity));
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
