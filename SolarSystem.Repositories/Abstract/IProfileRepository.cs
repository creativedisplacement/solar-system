using SolarSystem.Models;
using System;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IProfileRepository : IDisposable
    {
        Task<Profile> GetProfileAsync(int id, string type);
        void DeleteProfileAsync(Profile entity);
        void AddOrUpdateProfileAsync(Profile entity);
    }
}
