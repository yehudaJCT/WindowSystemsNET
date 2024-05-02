using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.DO;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.SQL.Tests
{
    [TestClass()]
    public class MapRepositoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var mapRepository = new MapRepository();
            var location = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map = new Map(location, "test", 8);

            mapRepository.Create(map);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}