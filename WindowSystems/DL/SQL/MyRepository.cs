using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.SQL;

namespace WindowSystems.DL.SQL
{
    public class MyRepository
    {
        private readonly MyDbContext _context;

        public MyRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Create(int id, DO.Map entity)
        {
            var dbMap = new MyDb(id, entity);
            _context.Maps.Add(dbMap);
            _context.SaveChanges();
            return dbMap.id;
        }

        public DO.Map Read(int id)
        {
            var dbMap = _context.Maps.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.converter(dbMap);
            }
            return new Map();
        }

        public void Update(int id, DO.Map entity)
        {
            var dbMap = _context.Maps.FirstOrDefault(m => m.id == id);
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
            var dbMap = _context.Maps.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Maps.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map?, bool>? func = null)
        {
            IQueryable<MyDb> query = _context.Maps;
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.converter(m)));
            }
            return query.Select(m => m.converter(m)).ToList();
        }

        public DO.Map ReadObject(Func<DO.Map?, bool>? func)
        {
            if (func != null)
            {
                var dbMap = _context.Maps.FirstOrDefault(m => func.Invoke(m.converter(m)));
                if (dbMap != null)
                {
                    return dbMap.converter(dbMap);
                }
            }
            return new Map();
        }
    }
}
