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
        private readonly IProfileRepository detailedProfileRepository;

        public StarController(IStarRepository starRepository, IProfileRepository detailedProfileRepository)
        {
            this.starRepository = starRepository;
            this.detailedProfileRepository = detailedProfileRepository;
        }

        // GET api/star
        public async Task<IEnumerable<Star>> Get()
        {
            return await starRepository.GetStarsAsync();
        }

        // GET api/star/5
        public async Task<FullProfile> Get(int id)
        {
            return new FullProfile
            {
                SpaceBody = await starRepository.GetStarAsync(id),
                Profile = await detailedProfileRepository.GetProfileAsync(id, "Star")
            };
        }
    }
}
