using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WindowSystems.DL.WEB;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.WEB.Tests
{
    [TestClass()]
    public class WEBMapTests
    {
        [TestMethod()]
        public async Task ReadTestAsync()
        {

            var webMap = new WEBMap();
            var location = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map = new Map(location, "test", 8);

            // Act
            var result = await webMap.Read(map);

            // Assert
            Assert.IsNotNull(map);
            Assert.AreEqual(map.URL, result.URL);//לא תקין
        }
    }
}

