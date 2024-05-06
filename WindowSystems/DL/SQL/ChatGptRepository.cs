﻿using WindowSystems.DL.SQL.model;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    public class ChatGptRepository
    {
        private readonly MyDbContext _context;

        public ChatGptRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Create(DO.ChatGpt entity)
        {
            var existingMap = _context.DB.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new MyDb(entity);
                _context.DB.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(entity);
            }

            return entity.id;
        }


        public DO.ChatGpt Read(int id)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.ChatGptConverter(dbMap);
            }
            return new DO.ChatGpt();
        }

        public void Update(DO.ChatGpt entity)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.prompt = entity.prompt;
                dbMap.responde = entity.responde;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.DB.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DO.ChatGpt> ReadAll(Func<DO.ChatGpt, bool>? func = null)
        {
            IQueryable<MyDb> query = _context.DB;
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.ChatGptConverter(m)));
            }
            return query.Select(m => m.ChatGptConverter(m)).ToList();
        }

        public DO.ChatGpt ReadObject(Func<DO.ChatGpt, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.ChatGptConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.ChatGptConverter(dbMap);
                }
            }
            return new DO.ChatGpt();
        }

        public int ObjectToId(Func<DO.ChatGpt, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

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
