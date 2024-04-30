using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.API;

namespace Tests
{
    [TestClass]
    public class DalMapTests
    {
        private DalMap _dalMap;

        [TestInitialize]
        public void Setup()
        {
            _dalMap = new DalMap();
        }

        [TestMethod]
        public async Task TestReadMap()
        {
            var map = new Map { lan = 0, lon = 0, zoom = 10 };
            var result = await _dalMap.Read(map);
            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class DalWeatherTests
    {
        private DalWeather _dalWeather;

        [TestInitialize]
        public void Setup()
        {
            _dalWeather = new DalWeather();
        }

        [TestMethod]
        public async Task TestReadWeather()
        {
            var weather = new Weather { lat = 0, lon = 0, Date = DateTime.Now };
            var result = await _dalWeather.Read(weather);
            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class DalLocationTests
    {
        private DalLocation _dalLocation;

        [TestInitialize]
        public void Setup()
        {
            _dalLocation = new DalLocation();
        }

        [TestMethod]
        public async Task TestReadLocation()
        {
            var location = new Location { Address = "Immanuel, Israel" };
            var result = await _dalLocation.Read(location);
            Assert.IsNotNull(result);
            Assert.AreEqual("Immanuel, Israel", result.Address);
            Assert.AreNotEqual(0, result.Latitude);
            Assert.AreNotEqual(0, result.Longitude);

        }
    }
}