using System;
using System.Collections.Generic;
using System.Linq;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    /// <summary>
    /// Repository for Weather entities.
    /// </summary>
    public class WeatherRepository
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public WeatherRepository(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Weather entity.
        /// </summary>
        /// <param name="entity">The Weather entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Weather entity)
        {
            var existingMap = _context.Weather.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new DBWeather(entity);
                _context.Weather.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(entity);
            }

            return entity.id;
        }

        /// <summary>
        /// Reads a Weather entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Weather entity to read.</param>
        /// <returns>The read Weather entity.</returns>
        public DO.Weather Read(int id)
        {
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                LocationRepository locationRepository = new LocationRepository(_context);
                DO.Location location = locationRepository.Read(id);
                return dbMap.WeatherConverter(dbMap, location);
            }
            return new DO.Weather();
        }

        /// <summary>
        /// Updates a Weather entity.
        /// </summary>
        /// <param name="entity">The Weather entity to update.</param>
        public void Update(DO.Weather entity)
        {
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.Date = entity.Date;
                dbMap.Temp = entity.Temp;
                dbMap.Humidity = entity.Humidity;
                dbMap.Visibility = entity.Visibility;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a Weather entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Weather entity to delete.</param>
        public void Delete(int id)
        {
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Weather.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all Weather entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of Weather entities.</returns>
        public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
        {
            IEnumerable<DBWeather> query = _context.Weather;

            if (query.Count() <= 0)
            {
                return Enumerable.Empty<DO.Weather>();
            }

            LocationRepository locationRepository = new LocationRepository(_context);
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.WeatherConverter(m, locationRepository.Read(m.id))));
            }
            return query.Select(m => m.WeatherConverter(m, locationRepository.Read(m.id)));
        }

        /// <summary>
        /// Reads a single Weather entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read Weather entity.</returns>
        public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Weather.ToList();
                LocationRepository locationRepository = new LocationRepository(_context);
                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.WeatherConverter(dbMap, locationRepository.Read(dbMap.id));
                }
            }
            return new DO.Weather();
        }

        /// <summary>
        /// Converts a predicate function to an ID.
        /// </summary>
        /// <param name="func">The predicate function to apply.</param>
        /// <returns>The ID of the matching entity.</returns>
        public int ObjectToId(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Weather.ToList();
                LocationRepository locationRepository = new LocationRepository(_context);
                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
