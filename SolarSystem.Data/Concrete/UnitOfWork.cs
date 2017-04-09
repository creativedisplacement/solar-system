using SolarSystem.Data.Abstract;
using SolarSystem.Data.DAL;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace SolarSystem.Data.Concrete
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly SolarSystemDbContext dataContext;

        public UnitOfWork(SolarSystemDbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Commit()
        {
            try
            {
                return dataContext.SaveChanges() == 0 ? false : true;
            }
            catch (OptimisticConcurrencyException oce)
            {
                throw new DBConcurrencyException(oce.Message, oce.InnerException);
            }
            catch (DbEntityValidationException deve)
            {
                throw new DbEntityValidationException(deve.Message, deve.InnerException);
            }
            catch (DataException de)
            {
                throw new DataException(de.Message, de.InnerException);
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                var result = (await dataContext.SaveChangesAsync());
                return result == 0 ? false : true;
            }
            catch (OptimisticConcurrencyException oce)
            {
                throw new DBConcurrencyException(oce.Message, oce.InnerException);
            }
            catch (DbEntityValidationException deve)
            {
                throw new DbEntityValidationException(deve.Message, deve.InnerException);
            }
            catch (DataException de)
            {
                throw new DataException(de.Message, de.InnerException);
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
