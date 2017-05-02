using SolarSystem.Core;
using SolarSystem.Models;
using SolarSystem.Models.ViewModels;
using SolarSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class PlanetController : ApiController
    {
        private readonly IPlanetRepository planetRepository;
        private readonly IProfileRepository profileRepository;
        private static Helpers.CircuitBreaker.CircuitBreaker circuitBreaker;

        public PlanetController(IPlanetRepository planetRepository, IProfileRepository profileRepository)
        {
            this.planetRepository = planetRepository;
            this.profileRepository = profileRepository;

            if (circuitBreaker == null)
            {
                circuitBreaker = new Helpers.CircuitBreaker.CircuitBreaker("planet_breaker", Constants.API.FAILURE_THRESHOLD, TimeSpan.FromSeconds(Constants.API.OPEN_CIRCUIT_TIMEOUT));
            }
        }

        //GET api/planet
        public async Task<IEnumerable<Planet>> Get()
        {
            return await circuitBreaker.ExecuteAsync(async () => { return await planetRepository.GetPlanetsAsync(); });
        }

        // GET api/planet/5
        public async Task<FullProfile> Get(int id)
        {
            var planet = circuitBreaker.ExecuteAsync(async () => { return await planetRepository.GetPlanetAsync(id); });

            return new FullProfile
            {
                SpaceBody = await planet,
                Profile = await circuitBreaker.ExecuteAsync(async () => { return await profileRepository.GetProfileAsync(id, Helper.GetModelName(planet)); })
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
