using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WindowSystems.DL.WEB;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.WEB.Tests;

[TestClass()]
public class WEBWeatherTests
{
    [TestMethod()]
    public async Task ReadTestAsync()
    {
        var WEBLocation = new WEBLocation();
        var webWeather = new WEBWeather();
        var address = "1600 Amphitheatre Parkway, Mountain View, CA";
        var location = WEBLocation.Read(new Location(1, address)).Result;
        var weather = new Weather(location, DateTime.Now, 0, 0, 0);

        // Act
        var result = await webWeather.Read(weather);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Temp > 0);
        Assert.IsTrue(result.Humidity > 0);
        Assert.IsTrue(result.Visibility > 0);
    }
}