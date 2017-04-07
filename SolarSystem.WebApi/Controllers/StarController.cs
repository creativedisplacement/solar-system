using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class StarController : ApiController
    {
        private readonly IStarRepository repository;
        public StarController(IStarRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public async Task<IEnumerable<Star>> Get()
        {
            return await repository.GetStarsAsync();
        }

        // GET api/values/5
        public async Task<Star> Get(int id)
        {
            return await repository.GetStarAsync(id);
        }
    }
}
