using SolarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Abstract
{
    public interface IDetailedProfileRepository : IDisposable
    {
        Task<DetailedProfile> GetDetailedProfileAsync(int id, string type);
        Task<bool> DeleteDetailedProfileAsync(DetailedProfile entity);
        Task<bool> AddOrUpdateDetailedProfileAsync(DetailedProfile entity);
    }
}
