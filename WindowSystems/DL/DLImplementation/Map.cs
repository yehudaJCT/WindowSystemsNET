using WindowSystems.DL.DalApi;
using WindowSystems.DL.SQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowSystems.DL.DLImplementation
{
    /// <summary>
    /// Implementation of the map data access layer.
    /// </summary>
    public class Map : IMap
    {
        MapRepository mapRepository = new MapRepository(new MyDbContext());
        WEBMap webMap = new WEBMap();

        /// <summary>
        /// Creates a new map entity.
        /// </summary>
        /// <param name="entity">The map entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.Map entity)
        {
            return mapRepository.Create(entity);
        }

        /// <summary>
        /// Deletes a map entity.
        /// </summary>
        /// <param name="entity">The map entity to delete.</param>
        public void Delete(DO.Map entity)
        {
            mapRepository.Delete(mapRepository.ObjectToId(m => m.URL == entity.URL));
        }

        /// <summary>
        /// Reads a map entity.
        /// </summary>
        /// <param name="entity">The map entity to read.</param>
        /// <returns>The read map entity.</returns>
        public async Task<DO.Map> Read(DO.Map entity)
        {
            int id = mapRepository.ObjectToId(m => m.URL == entity.URL);
            if (id == -1)
            {
                entity = await webMap.Read(entity);
                this.Create(entity);
            }
            else
            {
                entity = mapRepository.Read(id);
            }
            return entity;
        }

        /// <summary>
        /// Reads all map entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of map entities.</returns>
        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            return mapRepository.ReadAll(func);
        }

        /// <summary>
        /// Reads a single map entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read map entity.</returns>
        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            return mapRepository.ReadObject(func);
        }

        /// <summary>
        /// Updates a map entity.
        /// </summary>
        /// <param name="entity">The map entity to update.</param>
        public void Update(DO.Map entity)
        {
            mapRepository.Update(entity);
        }
    }
}
