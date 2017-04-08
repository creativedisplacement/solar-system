using SolarSystem.Models;
using SolarSystem.Models.ViewModels;
using SolarSystem.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SolarSystem.WebApi.Controllers
{
    public class MoonController : ApiController
    {
        private readonly IMoonRepository moonRepository;
        private readonly IProfileRepository detailedProfileRepository;

        public MoonController(IMoonRepository moonRepository, IProfileRepository detailedProfileRepository)
        {
            this.moonRepository = moonRepository;
            this.detailedProfileRepository = detailedProfileRepository;
        }

        // GET api/values
        public async Task<IEnumerable<Moon>> Get()
        {
            return await moonRepository.GetMoonsAsync();
        }

        // GET api/values/5
        public async Task<FullProfile> Get(int id)
        {
            return new FullProfile
            {
                SpaceBody = await moonRepository.GetMoonAsync(id),
                Profile = await detailedProfileRepository.GetDetailedProfileAsync(id, "Moon")
            };
        }
    }
}
