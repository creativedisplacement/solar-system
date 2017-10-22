using SolarSystem.Data.Abstract;
using SolarSystem.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Data.Concrete
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly SolarSystemDbContext dataContext;
        private DbSet<T> DbSet;

        public Repository(SolarSystemDbContext dataContext)
        {
            this.dataContext = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetQueryableAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.Where(where).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.SingleOrDefaultAsync(where);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.FirstOrDefaultAsync(where);
        }

        public Task<int> AddAsync(T entity)
        {
            DbSet.Add(entity);
            return SaveChangesAsync();
        }

        public Task<int> AddRangeAsync(IList<T> entities)
        {
            DbSet.AddRange(entities);
            return SaveChangesAsync();
        }

        public Task<int> SaveAsync(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public Task<int> DeleteAsync(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (CommitFailedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
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
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                dataContext.Dispose();
            }
            disposed = true;
        }
        #endregion
    }
}
