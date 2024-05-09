using System;
using System.Collections.Generic;
using System.Linq;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    /// <summary>
    /// Repository for ChatGPT entities.
    /// </summary>
    public class ChatGptRepository
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatGptRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ChatGptRepository(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new ChatGPT entity.
        /// </summary>
        /// <param name="entity">The ChatGPT entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.ChatGpt entity)
        {
            var existingMap = _context.ChatGpt.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new DBChatGpt(entity);
                _context.ChatGpt.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(entity);
            }

            return entity.id;
        }

        /// <summary>
        /// Reads a ChatGPT entity by ID.
        /// </summary>
        /// <param name="id">The ID of the ChatGPT entity to read.</param>
        /// <returns>The read ChatGPT entity.</returns>
        public DO.ChatGpt Read(int id)
        {
            var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.ChatGptConverter(dbMap);
            }
            return new DO.ChatGpt();
        }

        /// <summary>
        /// Updates a ChatGPT entity.
        /// </summary>
        /// <param name="entity">The ChatGPT entity to update.</param>
        public void Update(DO.ChatGpt entity)
        {
            var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.prompt = entity.prompt;
                dbMap.responde = entity.responde;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a ChatGPT entity by ID.
        /// </summary>
        /// <param name="id">The ID of the ChatGPT entity to delete.</param>
        public void Delete(int id)
        {
            var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.ChatGpt.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all ChatGPT entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of ChatGPT entities.</returns>
        public IEnumerable<DO.ChatGpt> ReadAll(Func<DO.ChatGpt, bool>? func = null)
        {
            IEnumerable<DBChatGpt> query = _context.ChatGpt;

            if (query.Count() <= 0)
            {
                return Enumerable.Empty<DO.ChatGpt>();
            }

            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.ChatGptConverter(m)));
            }
            return query.Select(m => m.ChatGptConverter(m));
        }

        /// <summary>
        /// Reads a single ChatGPT entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read ChatGPT entity.</returns>
        public DO.ChatGpt ReadObject(Func<DO.ChatGpt, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.ChatGpt.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.ChatGptConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.ChatGptConverter(dbMap);
                }
            }
            return new DO.ChatGpt();
        }

        /// <summary>
        /// Converts a predicate function to an ID.
        /// </summary>
        /// <param name="func">The predicate function to apply.</param>
        /// <returns>The ID of the matching entity.</returns>
        public int ObjectToId(Func<DO.ChatGpt, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.ChatGpt.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.ChatGptConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
