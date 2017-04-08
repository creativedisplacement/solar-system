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
        public Mock<IRepository<DetailedProfile>> repository { get; set; }
        public DetailedProfile detailedProfile { get; set; }

        DetailedProfileRepository detailedProfileRepository;

        public DetailedProfileTest()
        {
            detailedProfile = new DetailedProfile
            {
                Id = 1,
                TypeId = 1,
                TypeName = "Star",
                Content = "Content",
                Introduction = "Introduction",
                HasRings = false
            };
            repository = new Mock<IRepository<DetailedProfile>>();
            repository
                .Setup(p => p.SingleOrDefaultAsync(x => x.Id == 1))
                .ReturnsAsync(detailedProfile);

            detailedProfileRepository = new DetailedProfileRepository(repository.Object);
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
