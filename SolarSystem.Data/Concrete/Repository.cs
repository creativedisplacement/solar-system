using SolarSystem.Data.Abstract;
using SolarSystem.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SolarSystemDbContext dataContext;
        private DbSet<T> DbSet;

        public Repository(SolarSystemDbContext dataContext)
        {
            this.dataContext = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet;
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

        public async Task<bool> DeleteAsync(T entity)
        {
            DbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Deleted;
            int i = await dataContext.SaveChangesAsync();
            return i == 0 ? false : true;
        }

        public async Task<bool> AddAsync(T entity)
        {
            DbSet.Add(entity);
            int i = await dataContext.SaveChangesAsync();
            return i == 0 ? false : true;
        }

        public async Task<bool> AttachAsync(T entity)
        {
            await AttachAsync(entity, EntityStatus.Unchanged);
            int i = await dataContext.SaveChangesAsync();
            return i == 0 ? false : true;
        }

        public async Task<bool> AttachAsync(T entity, EntityStatus status)
        {
            DbSet.Attach(entity);
            dataContext.Entry(entity).State = GetEntityState(status);
            int i = await dataContext.SaveChangesAsync();
            return i == 0 ? false : true;
        }

        public async Task<bool> DetachAsync(T entity)
        {
            DbSet.Attach(entity);
            dataContext.Entry(entity).State = GetEntityState(EntityStatus.Detached);
            int i = await dataContext.SaveChangesAsync();
            return i == 0 ? false : true;

        }

        private EntityState GetEntityState(EntityStatus status)
        {
            switch (status)
            {
                case EntityStatus.Added:
                    return EntityState.Added;
                case EntityStatus.Deleted:
                    return EntityState.Deleted;
                case EntityStatus.Detached:
                    return EntityState.Detached;
                case EntityStatus.Modified:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
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
            if (!disposed)
            {
                if (disposing)
                {
                    if (dataContext != null)
                    {
                        dataContext.Dispose();
                    }
                }

                disposed = true;
            }
        }

        #endregion
    }
}
