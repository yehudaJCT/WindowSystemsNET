using System;
using System.Threading.Tasks;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.API;

public partial class Program
{
    static async Task Main(string[] args)
    {
        var test = new Test();
        
        await test.TestReadWeather();
        await test.TestReadMap();
    }
}

public class Test
{

    public async Task<Location> test(string Address)
    {
        DalLocation dalLocation = new DalLocation();
        Location location = new Location(Address);
        return dalLocation.Read(location).Result;
    }

    public async Task TestReadWeather()
    {
        var dalWeather = new DalWeather();
        var weather = await dalWeather.Read(new Weather { lat = 0, lon = 0 , Date = DateTime.Now });
    }

    public async Task TestReadMap()
    {
        var dalMap = new DalMap();
        var map = await dalMap.Read(new Map { lan = 0, lon = 0, zoom = 10 });
    }
}