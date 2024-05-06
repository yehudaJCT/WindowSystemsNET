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

        public int Create(DO.Location entity, int id = -1)
        {
            if (id == -1)
            {
                // If id is -1, assign a new id for the entity to be added to the end
                var maxId = _context.DB.Max(m => m.id);
                id = maxId + 1;
            }

            var existingMap = _context.DB.FirstOrDefault(m => m.id == id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new MyDb(id, entity);
                _context.DB.Add(dbMap);
                _context.SaveChanges();
            }
            else
            {
                this.Update(id, entity);
            }

            return id;
        }


        public DO.Location Read(int id)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.LocationConverter(dbMap);
            }
            return new DO.Location();
        }

        public void Update(int id, DO.Location entity)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
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
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.DB.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DO.Location> ReadAll(Func<DO.Location, bool>? func = null)
        {
            IQueryable<MyDb> query = _context.DB;
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.LocationConverter(m)));
            }
            return query.Select(m => m.LocationConverter(m)).ToList();
        }

        public DO.Location ReadObject(Func<DO.Location, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

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
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.LocationConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
