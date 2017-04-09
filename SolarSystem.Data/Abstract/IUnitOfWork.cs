using System;
using System.Threading.Tasks;

namespace SolarSystem.Data.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
