
namespace WindowSystems.DL.DalApi;
public interface IDal
{
    IMap map { get; }

    IWeather weather { get; }

    IChatGpt chatGpt { get; }

    ILocation location { get; }

}
