using NUnit.Framework;
using System;

namespace TestApp.UnitTests
{
    public class PlanetTests
    {
        [Test]
        public void Test_CalculateGravity_ReturnsCorrectCalculation()
        {
            // Arrange
            Planet earth = new("Earth", 12742, 149600000, 1);
            double mass = 1000;
            double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

            // Act
            double actualGravity = earth.CalculateGravity(mass);

            // Assert
            Assert.AreEqual(expectedGravity, actualGravity);
        }

        [Test]
        public void Test_GetPlanetInfo_ReturnsCorrectInfo()
        {
            // Arrange
            Planet mars = new("Mars", 6779, 227900000, 2);

            // Act
            string info = mars.GetPlanetInfo();

            // Assert
            Assert.AreEqual("Planet: Mars\r\nDiameter: 6779 km\r\nDistance from the Sun: 227900000 km\r\nNumber of Moons: 2", info);
        }



    }
}
