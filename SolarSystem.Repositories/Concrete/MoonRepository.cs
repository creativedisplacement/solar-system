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

        public async Task<bool> AddOrUpdateMoonAsync(Moon entity)
        {
            if (entity.Id == 0)
            {
                return (await repository.AddAsync(entity));
            }

            return (await repository.AttachAsync(entity, EntityStatus.Modified));
        }

        public async Task<bool> DeleteMoonAsync(Moon entity)
        {
            return (await repository.DeleteAsync(entity));
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
