using WindowSystems.DL.DalApi;
using WindowSystems.DL.SQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowSystems.DL.DLImplementation
{
    /// <summary>
    /// Implementation of the weather data access layer.
    /// </summary>
    public class Weather : IWeather
    {
        WeatherRepository weatherRepository = new WeatherRepository(new MyDbContext());
        WEBWeather webWeather = new WEBWeather();

        /// <summary>
        /// Creates a new weather entity.
        /// </summary>
        /// <param name="entity">The weather entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Weather entity)
        {
            return weatherRepository.Create(entity);
        }

        /// <summary>
        /// Deletes a weather entity.
        /// </summary>
        /// <param name="entity">The weather entity to delete.</param>
        public void Delete(DO.Weather entity)
        {
            weatherRepository.Delete(weatherRepository.ObjectToId(m => m.id == entity.id));
        }

        /// <summary>
        /// Reads a weather entity.
        /// </summary>
        /// <param name="entity">The weather entity to read.</param>
        /// <returns>The read weather entity.</returns>
        public async Task<DO.Weather> Read(DO.Weather entity)
        {
            int id = weatherRepository.ObjectToId(m => m.id == entity.id);
            if (id == -1)
            {
                entity = await webWeather.Read(entity);
                this.Create(entity);
            }
            else
            {
                entity = weatherRepository.Read(id);
            }
            return entity;
        }

        /// <summary>
        /// Reads all weather entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of weather entities.</returns>
        public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
        {
            return weatherRepository.ReadAll(func);
        }

        /// <summary>
        /// Reads a single weather entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read weather entity.</returns>
        public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
        {
            return weatherRepository.ReadObject(func);
        }

        /// <summary>
        /// Updates a weather entity.
        /// </summary>
        /// <param name="entity">The weather entity to update.</param>
        public void Update(DO.Weather entity)
        {
            weatherRepository.Update(entity);
        }
    }
}
