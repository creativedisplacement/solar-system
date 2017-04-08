using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IProfileRepository : IDisposable
    {
        Task<Profile> GetDetailedProfileAsync(int id, string type);
        Task<bool> DeleteDetailedProfileAsync(Profile entity);
        Task<bool> AddOrUpdateDetailedProfileAsync(Profile entity);
    }
}
