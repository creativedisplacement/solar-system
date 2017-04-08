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
        private readonly IProfileRepository profileRepository;

        public PlanetController(IPlanetRepository planetRepository, IProfileRepository profileRepository)
        {
            this.planetRepository = planetRepository;
            this.profileRepository = profileRepository;
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
                Profile = await profileRepository.GetDetailedProfileAsync(id, "Planet")
            };
        }
    }
}
