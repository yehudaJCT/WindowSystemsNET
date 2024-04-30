using System;
using WindowSystems.model.DbData;

namespace WindowSystems.DL.interfaces
{
    public interface IWeather
    {
        // Create operation
        void CreateWeather(Weather weather);

        // Read operation
        Weather GetWeather(DateTime date);

        // Read all operation
        List<Weather> GetAllWeather();

        // Update operation
        void UpdateWeather(Weather weather);

        // Delete operation
        void DeleteWeather(DateTime date);
    }
}
