using SolarSystem.Models;
using System;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IProfileRepository
    {
        Task<Profile> GetProfileAsync(int id, string type);
        Task<int> DeleteProfileAsync(int id, byte[] timestamp);
        Task<int> AddOrUpdateProfileAsync(Profile profile);
    }
}
