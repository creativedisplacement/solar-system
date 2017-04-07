using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Data.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetQueryable();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> where);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);
        Task<bool> DeleteAsync(T entity);
        Task<bool> AddAsync(T entity);
        Task<bool> AttachAsync(T entity);
        Task<bool> AttachAsync(T entity, EntityStatus status);
        Task<bool> DetachAsync(T entity);
    }
}
