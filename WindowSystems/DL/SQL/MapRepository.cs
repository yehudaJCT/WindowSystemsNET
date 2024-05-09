using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    /// <summary>
    /// Repository for Map entities.
    /// </summary>
    public class MapRepository
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public MapRepository(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Map entity.
        /// </summary>
        /// <param name="entity">The Map entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Map entity)
        {
            var existingMap = _context.Map.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new DBMap(entity);
                _context.Map.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(entity);
            }

            return entity.id;
        }

        /// <summary>
        /// Reads a Map entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Map entity to read.</param>
        /// <returns>The read Map entity.</returns>
        public DO.Map Read(int id)
        {
            var dbMap = _context.Map.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                LocationRepository locationRepository = new LocationRepository(_context);
                DO.Location location = locationRepository.Read(id);
                return dbMap.MapConverter(dbMap, location);
            }
            return new DO.Map();
        }

        /// <summary>
        /// Updates a Map entity.
        /// </summary>
        /// <param name="entity">The Map entity to update.</param>
        public void Update(DO.Map entity)
        {
            var dbMap = _context.Map.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.URL = entity.URL;
                dbMap.zoom = entity.zoom;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a Map entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Map entity to delete.</param>
        public void Delete(int id)
        {
            var dbMap = _context.Map.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Map.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all Map entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of Map entities.</returns>
        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            IEnumerable<DBMap> query = _context.Map;

            if (query.Count() <= 0)
            {
                return Enumerable.Empty<DO.Map>();
            }

            LocationRepository locationRepository = new LocationRepository(_context);
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.MapConverter(m, locationRepository.Read(m.id))));
            }
            return query.Select(m => m.MapConverter(m, locationRepository.Read(m.id)));
        }

        /// <summary>
        /// Reads a single Map entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read Map entity.</returns>
        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Map.ToList();

                LocationRepository locationRepository = new LocationRepository(_context);
                var dbMap = allMaps.FirstOrDefault(m => func(m.MapConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.MapConverter(dbMap, locationRepository.Read(dbMap.id));
                }
            }
            return new DO.Map();
        }

        /// <summary>
        /// Converts a predicate function to an ID.
        /// </summary>
        /// <param name="func">The predicate function to apply.</param>
        /// <returns>The ID of the matching entity.</returns>
        public int ObjectToId(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Map.ToList();

                LocationRepository locationRepository = new LocationRepository(_context);
                var dbMap = allMaps.FirstOrDefault(m => func(m.MapConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
