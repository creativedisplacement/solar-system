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
    public class IStarRepositoryTest
    {
        public Mock<IRepository<Star>> repository { get; set; }
        public List<Star> stars { get; set; }

       StarRepository starRepository;

        public IStarRepositoryTest()
        {
            stars = new List<Star>
            {
                new Star { Id = 1, Name = "Star 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 1 },
                new Star { Id = 2, Name = "Star 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 2 },
            };
            repository = new Mock<IRepository<Star>>();
            repository
                .Setup(p => p.GetAllAsync())
                .ReturnsAsync(stars);

            starRepository = new StarRepository(repository.Object);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Stars()
        {
            IEnumerable<Star> result = await starRepository.GetStarsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Star 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Star 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_All_Stars_Check_Ordinal()
        {
            IEnumerable<Star> result = await starRepository.GetStarsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreNotEqual("Star 2", result.Take(1).SingleOrDefault().Name);
            Assert.AreNotEqual("Star 1", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Repository_Test_Get_Star()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Star()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Find_Stars()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Delete_Star()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Update_Star()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Repository_Test_Add_Star()
        {
            throw new NotImplementedException();
        }
    }
}
