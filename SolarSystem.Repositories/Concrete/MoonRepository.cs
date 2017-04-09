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

        public void AddOrUpdateMoonAsync(Moon entity)
        {
            if (entity.Id == 0)
            {
                repository.Add(entity);
            }

            repository.Attach(entity, EntityStatus.Modified);
        }

        public void DeleteMoonAsync(Moon entity)
        {
            repository.Delete(entity);
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
