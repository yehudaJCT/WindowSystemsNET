using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.SQL;
using Google.Api;


namespace WindowSystems.DL.SQL
{
    public class MapRepository 
    {
        private readonly MyDbContext _context;

        public MapRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Create(DO.Map entity)
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


        public DO.Map Read(int id)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.MapConverter(dbMap);
            }
            return new Map();
        }

        public void Update(DO.Map entity)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.Latitude = entity.Location.Latitude;
                dbMap.Longitude = entity.Location.Longitude;
                dbMap.Address = entity.Location.Address;
                dbMap.URL = entity.URL;
                dbMap.zoom = entity.zoom;
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

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            IQueryable<MyDb> query = _context.DB;
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.MapConverter(m)));
            }
            return query.Select(m => m.MapConverter(m)).ToList();
        }

        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.MapConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.MapConverter(dbMap);
                }
            }
            return new Map();
        }

        public int ObjectToId(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.MapConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
