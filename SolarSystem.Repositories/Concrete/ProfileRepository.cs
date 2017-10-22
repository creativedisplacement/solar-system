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

        public async Task<int> AddOrUpdateProfileAsync(Profile profile)
        {
            if (profile.Id == 0)
            {
                return await repository.AddAsync(profile);
            }

            return await repository.SaveAsync(profile);
        }

        public async Task<int> DeleteProfileAsync(int id, byte[] timestamp)
        {
            return await repository.DeleteAsync(new Profile { Id = id, Timestamp = timestamp });
        }

        public async Task<Profile> GetProfileAsync(int id, string type)
        {
            return (await repository.SingleOrDefaultAsync(s => s.TypeId == id && s.TypeName == type));
        }
    }
}
