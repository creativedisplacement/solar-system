using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Concrete;
using System;
using System.Threading.Tasks;

namespace SolarSystem.WebApi.Tests.Repositories
{
    [TestClass]
    public class DetailedProfileTest
    {
        public Mock<IRepository<Profile>> repository { get; set; }
        public Profile profile { get; set; }

        ProfileRepository profileRepository;

        public DetailedProfileTest()
        {
            profile = new Profile
            {
                Id = 1,
                TypeId = 1,
                TypeName = "Star",
                Content = "Content",
                Introduction = "Introduction",
                HasRings = false
            };
            repository = new Mock<IRepository<Profile>>();
            repository
                .Setup(p => p.SingleOrDefaultAsync(x => x.Id == 1))
                .ReturnsAsync(profile);

            profileRepository = new ProfileRepository(repository.Object);
        }

        [TestMethod]
        public async Task Repository_Test_Get_Profile()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Add_Profile()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Update_Profile()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Delete_Profile()
        {
            throw new NotImplementedException();
        }
    }
}
