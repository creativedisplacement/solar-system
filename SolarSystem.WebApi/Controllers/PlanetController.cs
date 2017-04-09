using SolarSystem.Core;
using SolarSystem.Data.Abstract;
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
        private readonly IUnitofWork unitOfWork;

        public PlanetController(IPlanetRepository planetRepository, IProfileRepository profileRepository, IUnitofWork unitOfWork)
        {
            this.planetRepository = planetRepository;
            this.profileRepository = profileRepository;
            this.unitOfWork = unitOfWork;
        }

        //GET api/planet
        public async Task<IEnumerable<Planet>> Get()
        {
            return await planetRepository.GetPlanetsAsync();
        }

        // GET api/planet/5
        public async Task<FullProfile> Get(int id)
        {
            var planet = await planetRepository.GetPlanetAsync(id);
            return new FullProfile
            {
                SpaceBody = planet,
                Profile = await profileRepository.GetProfileAsync(id, Helper.GetModelName(planet))
            };
        }

        //public async Task<bool> Get()
        //{
        //    var x = new Planet();
        //    var fullProfile = new FullProfile
        //    {
        //        SpaceBody = await planetRepository.GetPlanetAsync(1),
        //        Profile = await profileRepository.GetProfileAsync(1, x.GetType().Name)
        //    };

        //    fullProfile.SpaceBody.Name = "Earth!";
        //    fullProfile.Profile.Introduction = "Introduction!";

        //    planetRepository.AddOrUpdatePlanetAsync((Planet)fullProfile.SpaceBody);
        //    profileRepository.AddOrUpdateProfileAsync(fullProfile.Profile);

        //    return await unitOfWork.CommitAsync();
        //}
    }
}
