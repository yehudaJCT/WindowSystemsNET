using global::WindowSystems.DL.DalApi;
using global::WindowSystems.DL.SQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowSystems.DL.DLImplementation
{
    /// <summary>
    /// Implementation of the location data access layer.
    /// </summary>
    public class Location : ILocation
    {
        LocationRepository locationRepository = new LocationRepository(new MyDbContext());
        WEBLocation webLocation = new WEBLocation();

        /// <summary>
        /// Creates a new location entity.
        /// </summary>
        /// <param name="entity">The location entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Location entity)
        {
            return locationRepository.Create(entity);
        }

        /// <summary>
        /// Deletes a location entity.
        /// </summary>
        /// <param name="entity">The location entity to delete.</param>
        public void Delete(DO.Location entity)
        {
            locationRepository.Delete(locationRepository.ObjectToId(m => m.id == entity.id));
        }

        /// <summary>
        /// Reads a location entity.
        /// </summary>
        /// <param name="entity">The location entity to read.</param>
        /// <returns>The read location entity.</returns>
        public async Task<DO.Location> Read(DO.Location entity)
        {
            int id = locationRepository.ObjectToId(m => m.id == entity.id);
            if (id == -1)
            {
                entity = await webLocation.Read(entity);
                this.Create(entity);
            }
            else
            {
                entity = locationRepository.Read(id);
            }
            return entity;
        }

        /// <summary>
        /// Reads all location entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of location entities.</returns>
        public IEnumerable<DO.Location> ReadAll(Func<DO.Location, bool>? func = null)
        {
            return locationRepository.ReadAll(func);
        }

        /// <summary>
        /// Reads a single location entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read location entity.</returns>
        public DO.Location ReadObject(Func<DO.Location, bool>? func)
        {
            return locationRepository.ReadObject(func);
        }

        /// <summary>
        /// Updates a location entity.
        /// </summary>
        /// <param name="entity">The location entity to update.</param>
        public void Update(DO.Location entity)
        {
            int id = locationRepository.ObjectToId(m => m.id == entity.id);
            locationRepository.Update(entity);
        }
    }
}
