using SolarSystem.Models;
using SolarSystem.Models.ViewModels;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class StarController : ApiController
    {
        private readonly IStarRepository starRepository;
        private readonly IDetailedProfileRepository detailedProfileRepository;

        public StarController(IStarRepository starRepository, IDetailedProfileRepository detailedProfileRepository)
        {
            this.starRepository = starRepository;
            this.detailedProfileRepository = detailedProfileRepository;
        }

        // GET api/values
        public async Task<IEnumerable<Star>> Get()
        {
            return await starRepository.GetStarsAsync();
        }

        // GET api/values/5
        public async Task<FullProfile> Get(int id)
        {
            return new FullProfile
            {
                SpaceBody = await starRepository.GetStarAsync(id),
                MoreInformation = await detailedProfileRepository.GetDetailedProfileAsync(id, "Star")
            };
        }
    }
}
