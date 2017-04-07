using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using SolarSystem.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem.WebApi.Tests.Controllers
{
    [TestClass]
    public class StarControllerTest
    {
        public Mock<IStarRepository> repository { get; set; }
        public List<Star> stars { get; set; }
        public StarController controller { get; set; }

        public StarControllerTest()
        {
            stars = new List<Star>
            {
                new Star { Id = 1, Name = "Star 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 1 },
                new Star { Id = 2, Name = "Star 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 2 },
            };
            repository = new Mock<IStarRepository>();
            repository
                .Setup(p => p.GetStarsAsync())
                .ReturnsAsync(stars);

            controller = new StarController(repository.Object);
        }

        [TestMethod]
        public async Task Controller_Get_All_Stars()
        {
            IEnumerable<Star> result = await controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Star 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Star 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Controller_Get_Star()
        {
            throw new NotImplementedException();
        }
    }
}
