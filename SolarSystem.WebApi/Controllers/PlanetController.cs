using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class PlanetController : ApiController
    {
        private readonly IPlanetRepository repository;
        public PlanetController(IPlanetRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public async Task<IEnumerable<Planet>> Get()
        {
            return await repository.GetPlanetsAsync();
        }

        // GET api/values/5
        public async Task<Planet> Get(int id)
        {
            return await repository.GetPlanetAsync(id);
        }
    }
}
