using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.WEB.Tests
{
    [TestClass()]
    public class WEBWeatherTests
    {
        [TestMethod()]
        public async Task ReadTestAsync()
        {
            // Arrange
            var WEBweather = new WEBWeather();
            Weather weather = new Weather()
            var location = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);

            // Act
            var result = await WEBweather.Read(location);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(37.4223, result.Latitude, 0.001);
            Assert.AreEqual(-122.084, result.Longitude, 0.001);
            Assert.AreEqual(location.Address, result.Address);
        }
    }
}