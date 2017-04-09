using SolarSystem.Data;
using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Concrete
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IRepository<Profile> repository;

        public ProfileRepository(IRepository<Profile> repository)
        {
            this.repository = repository;
        }

        public void AddOrUpdateProfileAsync(Profile entity)
        {
            if (entity.Id == 0)
            {
                repository.Add(entity);
            }

            repository.Attach(entity, EntityStatus.Modified);
        }

        public void DeleteProfileAsync(Profile entity)
        {
            repository.Delete(entity);
        }

        public async Task<Profile> GetProfileAsync(int id, string type)
        {
            return (await repository.SingleOrDefaultAsync(s => s.TypeId == id && s.TypeName == type));
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
