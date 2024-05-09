using System;
using System.Collections.Generic;
using System.Linq;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    /// <summary>
    /// Repository for Location entities.
    /// </summary>
    public class LocationRepository
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public LocationRepository(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Location entity.
        /// </summary>
        /// <param name="entity">The Location entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Location entity)
        {
            var existingMap = _context.Location.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new DBLocation(entity);
                _context.Location.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(entity);
            }

            return entity.id;
        }

        /// <summary>
        /// Reads a Location entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Location entity to read.</param>
        /// <returns>The read Location entity.</returns>
        public DO.Location Read(int id)
        {
            var dbMap = _context.Location.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.LocationConverter(dbMap);
            }
            return new DO.Location();
        }

        /// <summary>
        /// Updates a Location entity.
        /// </summary>
        /// <param name="entity">The Location entity to update.</param>
        public void Update(DO.Location entity)
        {
            var dbMap = _context.Location.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.Address = entity.Address;
                dbMap.Latitude = entity.Latitude;
                dbMap.Longitude = entity.Longitude;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a Location entity by ID.
        /// </summary>
        /// <param name="id">The ID of the Location entity to delete.</param>
        public void Delete(int id)
        {
            var dbMap = _context.Location.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Location.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all Location entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of Location entities.</returns>
        public IEnumerable<DO.Location> ReadAll(Func<DO.Location, bool>? func = null)
        {
            IEnumerable<DBLocation> query = _context.Location;

            if (query.Count() <= 0)
            {
                return Enumerable.Empty<DO.Location>();
            }

            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.LocationConverter(m)));
            }
            return query.Select(m => m.LocationConverter(m));
        }

        /// <summary>
        /// Reads a single Location entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read Location entity.</returns>
        public DO.Location ReadObject(Func<DO.Location, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Location.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.LocationConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.LocationConverter(dbMap);
                }
            }
            return new DO.Location();
        }

        /// <summary>
        /// Converts a predicate function to an ID.
        /// </summary>
        /// <param name="func">The predicate function to apply.</param>
        /// <returns>The ID of the matching entity.</returns>
        public int ObjectToId(Func<DO.Location, bool>? func)
        {
            if (func != null)
            {
                var allLocations = _context.Location.ToList();

                var dbMap = allLocations.FirstOrDefault(m => func(m.LocationConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
