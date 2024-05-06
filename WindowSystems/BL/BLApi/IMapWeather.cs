using WindowSystems.BL.BO;
namespace WindowSystems.BL.BLApi;

public interface IMapWeather
{
    public Weather GetWeather(double lon, double lat, DateTime dateTime);
}
