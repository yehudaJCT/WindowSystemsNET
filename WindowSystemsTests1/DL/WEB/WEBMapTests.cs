using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WindowSystems.DL.WEB;
using WindowSystems.DL.DO;


namespace WindowSystems.DL.WEB.Tests;

[TestClass()]
public class WEBMapTests
{
    [TestMethod()]
    public async Task ReadTestAsync()
    {
        var WEBLocation = new WEBLocation();
        var webMap = new WEBMap();
        var address = "1600 Amphitheatre Parkway, Mountain View, CA";
        var location = WEBLocation.Read(address).Result;
        var map = new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

        // Act
        var result = await webMap.Read(map);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(map.URL, result.URL);
    }
}

