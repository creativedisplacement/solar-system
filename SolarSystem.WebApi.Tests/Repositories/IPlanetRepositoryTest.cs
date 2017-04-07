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
    public class IPlanetRepositoryTest
    {
        public Mock<IRepository<Planet>> repository { get; set; }
        public List<Planet> planets { get; set; }

        PlanetRepository planetRepository;

        public IPlanetRepositoryTest()
        {
            planets = new List<Planet>
            {
                new Planet { Id = 1, Name = "Planet 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now },
                new Planet { Id = 2, Name = "Planet 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now },
            };
            repository = new Mock<IRepository<Planet>>();
            repository
                .Setup(p => p.GetAllAsync())
                .ReturnsAsync(planets);

            planetRepository = new PlanetRepository(repository.Object);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Planets()
        {
            IEnumerable<Planet> result = await planetRepository.GetPlanetsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Planet 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Planet 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Planets_Check_Ordinal()
        {
            IEnumerable<Planet> result = await planetRepository.GetPlanetsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreNotEqual("Planet 2", result.Take(1).SingleOrDefault().Name);
            Assert.AreNotEqual("Planet 1", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_Planet()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Planet()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Planets()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Delete_Planet()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Update_Planet()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Add_Planet()
        {
            throw new NotImplementedException();
        }
    }
}
