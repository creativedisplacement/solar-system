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
    public class ValuesControllerTest
    {
        public Mock<IPlanetRepository> planetRepositories { get; set; }
        public List<Planet> planets { get; set; }

        public ValuesControllerTest()
        {
            planets = new List<Planet>
            {
                new Planet { Id = 1, Name = "Planet 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now },
                new Planet { Id = 2, Name = "Planet 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now },
            };
            planetRepositories = new Mock<IPlanetRepository>();
            planetRepositories
                .Setup(p => p.GetPlanetsAsync())
                .ReturnsAsync(planets);

        }

        [TestMethod]
        public async Task Controller_Get_All_Planets()
        {
            ValuesController controller = new ValuesController(planetRepositories.Object);

            IEnumerable<Planet> result = await controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Planet 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Planet 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        //[TestMethod]
        //public void GetById()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
