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

        public async Task<bool> AddMoonAsync(Moon entity)
        {
            return (await repository.AddAsync(entity));
        }

        public async Task<bool> AttachMoonAsync(Moon entity)
        {
            return (await repository.AttachAsync(entity));
        }

        public async Task<bool> AttachMoonAsync(Moon entity, EntityStatus status)
        {
            return (await repository.AttachAsync(entity, status));
        }

        public async Task<bool> DeleteAsync(Moon entity)
        {
            return (await repository.DeleteAsync(entity));
        }

        public async Task<bool> DetachMoonAsync(Moon entity)
        {
            return (await repository.DetachAsync(entity));
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
