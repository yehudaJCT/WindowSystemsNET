using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    public class LocationRepository
    {
        private readonly MyDbContext _context;

        public LocationRepository(MyDbContext context)
        {
            _context = context;
        }

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


        public DO.Location Read(int id)
        {
            var dbMap = _context.Location.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.LocationConverter(dbMap);
            }
            return new DO.Location();
        }

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

        public void Delete(int id)
        {
            var dbMap = _context.Location.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Location.Remove(dbMap);
                _context.SaveChanges();
            }
        }

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
