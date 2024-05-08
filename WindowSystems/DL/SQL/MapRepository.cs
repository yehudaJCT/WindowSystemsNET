using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WindowSystems.DL.DO;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.SQL;
using Google.Api;
using WindowSystems.SQL.model;


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


        public DO.Map Read(int id)
        {
            var dbMap = _context.Map.FirstOrDefault(m => m.id == id);
            if (dbMap != null) {
                LocationRepository locationRepository = new LocationRepository(_context);//?
                DO.Location location = locationRepository.Read(id);
                return dbMap.MapConverter(dbMap, location);
            }
            return new Map();
        }

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

        public void Delete(int id)
        {
            var dbMap = _context.Map.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Map.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            IQueryable<DBMap> query = _context.Map;
            LocationRepository locationRepository = new LocationRepository(_context);//?
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.MapConverter(m, locationRepository.Read(m.id))));
            }
            return query.Select(m => m.MapConverter(m, locationRepository.Read(m.id))).ToList();
        }

        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Map.ToList();

                LocationRepository locationRepository = new LocationRepository(_context);//?
                var dbMap = allMaps.FirstOrDefault(m => func(m.MapConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.MapConverter(dbMap, locationRepository.Read(dbMap.id));
                }
            }
            return new Map();
        }

        public int ObjectToId(Func<DO.Map, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Map.ToList();

                LocationRepository locationRepository = new LocationRepository(_context);//?
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
