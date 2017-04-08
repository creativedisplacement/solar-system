using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem.WebApi.Tests.Repositories
{
    [TestClass]
    public class MoonRepositoryTest
    {
        public Mock<IRepository<Moon>> repository { get; set; }
        public List<Moon> moons { get; set; }

        MoonRepository moonRepository;

        public MoonRepositoryTest()
        {
            moons = new List<Moon>
            {
                new Moon { Id = 1, Name = "Moon 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 1 },
                new Moon { Id = 2, Name = "Moon 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 2 },
            };
            repository = new Mock<IRepository<Moon>>();
            repository
                .Setup(p => p.GetAllAsync())
                .ReturnsAsync(moons);

            moonRepository = new MoonRepository(repository.Object);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Moons()
        {
            IEnumerable<Moon> result = await moonRepository.GetMoonsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Moon 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Moon 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Moons_Check_Ordinal()
        {
            IEnumerable<Moon> result = await moonRepository.GetMoonsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreNotEqual("Moon 2", result.Take(1).SingleOrDefault().Name);
            Assert.AreNotEqual("Moon 1", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_Moon()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Moon()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Moons()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Delete_Moon()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Update_Moon()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Add_Moon()
        {
            throw new NotImplementedException();
        }
    }
}
