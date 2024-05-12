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
            try
            {
                var existingMap = _context.ChatGpt.FirstOrDefault(m => m.id == entity.id);

                if (existingMap == null)
                {
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
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while creating ChatGpt entity.", ex);
            }
        }

        /// <summary>
        /// Reads a ChatGPT entity by ID.
        /// </summary>
        /// <param name="id">The ID of the ChatGPT entity to read.</param>
        /// <returns>The read ChatGPT entity.</returns>
        public DO.ChatGpt Read(int id)
        {
            try
            {
                var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == id);
                if (dbMap != null)
                {
                    return dbMap.ChatGptConverter(dbMap);
                }
                return new DO.ChatGpt();
            }
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while reading ChatGpt entity.", ex);
            }
        }

        /// <summary>
        /// Updates a ChatGPT entity.
        /// </summary>
        /// <param name="entity">The ChatGPT entity to update.</param>
        public void Update(DO.ChatGpt entity)
        {
            try
            {
                var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == entity.id);
                if (dbMap != null)
                {
                    dbMap.prompt = entity.prompt;
                    dbMap.responde = entity.responde;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while updating ChatGpt entity.", ex);
            }
        }

        /// <summary>
        /// Deletes a ChatGPT entity by ID.
        /// </summary>
        /// <param name="id">The ID of the ChatGPT entity to delete.</param>
        public void Delete(int id)
        {
            try
            {
                var dbMap = _context.ChatGpt.FirstOrDefault(m => m.id == id);
                if (dbMap != null)
                {
                    _context.ChatGpt.Remove(dbMap);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while deleting ChatGpt entity.", ex);
            }
        }

        /// <summary>
        /// Reads all ChatGPT entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of ChatGPT entities.</returns>
        public IEnumerable<DO.ChatGpt> ReadAll(Func<DO.ChatGpt, bool>? func = null)
        {
            try
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
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while reading all ChatGpt entities.", ex);
            }
        }

        /// <summary>
        /// Reads a single ChatGPT entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read ChatGPT entity.</returns>
        public DO.ChatGpt ReadObject(Func<DO.ChatGpt, bool>? func)
        {
            try
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
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while reading ChatGpt entity based on predicate function.", ex);
            }
        }

        /// <summary>
        /// Converts a predicate function to an ID.
        /// </summary>
        /// <param name="func">The predicate function to apply.</param>
        /// <returns>The ID of the matching entity.</returns>
        public int ObjectToId(Func<DO.ChatGpt, bool>? func)
        {
            try
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
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw new Exception("Error occurred while converting a predicate function to an ID.", ex);
            }
        }
    }
}
