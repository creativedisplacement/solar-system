using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class MoonController : ApiController
    {
        private readonly IMoonRepository repository;
        public MoonController(IMoonRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public async Task<IEnumerable<Moon>> Get()
        {
            return await repository.GetMoonsAsync();
        }

        // GET api/values/5
        public async Task<Moon> Get(int id)
        {
            return await repository.GetMoonAsync(id);
        }
    }
}
