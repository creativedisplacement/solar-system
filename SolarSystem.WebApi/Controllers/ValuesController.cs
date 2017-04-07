using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IPlanetRepository repository;
        public ValuesController(IPlanetRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public async Task<IEnumerable<Planet>> Get()
        {
            return await repository.GetPlanetsAsync();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
