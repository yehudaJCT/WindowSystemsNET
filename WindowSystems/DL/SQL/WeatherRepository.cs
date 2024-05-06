using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.SQL
{
    public class WeatherRepository
    {
        private readonly MyDbContext _context;

        public WeatherRepository(MyDbContext context)
        {
            _context = context;
        }

        public int Create(DO.Weather entity)
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


        public DO.Weather Read(int id)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                return dbMap.WeatherConverter(dbMap);
            }
            return new DO.Weather();
        }

        public void Update(DO.Weather entity)
        {
            var dbMap = _context.DB.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.Latitude = entity.Location.Latitude;
                dbMap.Longitude = entity.Location.Longitude;
                dbMap.Address = entity.Location.Address;
                dbMap.Date = entity.Date;
                dbMap.Temp = entity.Temp;   
                dbMap.Humidity = entity.Humidity;   
                dbMap.Visibility = entity.Visibility;
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

        public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
        {
            IQueryable<MyDb> query = _context.DB;
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.WeatherConverter(m)));
            }
            return query.Select(m => m.WeatherConverter(m)).ToList();
        }

        public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.WeatherConverter(dbMap);
                }
            }
            return new DO.Weather();
        }

        public int ObjectToId(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.DB.ToList();

                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m)));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
