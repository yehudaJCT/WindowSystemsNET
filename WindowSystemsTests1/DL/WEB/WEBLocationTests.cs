using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WindowSystems.DL.WEB;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.WEB.Tests
{
    [TestClass()]
    public class WEBLocationTests
    {
        [TestMethod()]
        public async Task ReadTest()
        {
            // Arrange
            var webLocation = new WEBLocation();
            var location = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);

            // Act
            var result = await webLocation.Read(location);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(37.4223, result.Latitude, 0.001);
            Assert.AreEqual(-122.084, result.Longitude, 0.001);
            Assert.AreEqual(location.Address, result.Address);
        }
    }
}
