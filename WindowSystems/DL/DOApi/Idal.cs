namespace WindowSystems.DL.DOApi;

public interface IDal
{
    IMap map { get; }

    IWeather weather { get; }

}
