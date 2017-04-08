using SolarSystem.Models;
using SolarSystem.Models.ViewModels;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class PlanetController : ApiController
    {
        private readonly IPlanetRepository planetRepository;
        private readonly IDetailedProfileRepository detailedProfileRepository;

        public PlanetController(IPlanetRepository planetRepository, IDetailedProfileRepository detailedProfileRepository)
        {
            this.planetRepository = planetRepository;
            this.detailedProfileRepository = detailedProfileRepository;
        }

        // GET api/values
        public async Task<IEnumerable<Planet>> Get()
        {
            return await planetRepository.GetPlanetsAsync();
        }

        // GET api/values/5
        public async Task<FullProfile> Get(int id)
        {
            return new FullProfile
            {
                SpaceBody = await planetRepository.GetPlanetAsync(id),
                MoreInformation = await detailedProfileRepository.GetDetailedProfileAsync(id, "Planet")
            };
        }
    }
}
