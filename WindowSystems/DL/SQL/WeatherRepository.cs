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
            var existingMap = _context.Weather.FirstOrDefault(m => m.id == entity.id);

            if (existingMap == null)
            {
                // If no map exists at the specified ID, create a new one
                var dbMap = new DBWeather(entity);
                _context.Weather.Add(dbMap);
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
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                LocationRepository locationRepository = new LocationRepository(_context);//?
                DO.Location location = locationRepository.Read(id);
                return dbMap.WeatherConverter(dbMap, location);
            }
            return new DO.Weather();
        }

        public void Update(DO.Weather entity)
        {
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == entity.id);
            if (dbMap != null)
            {
                dbMap.Date = entity.Date;
                dbMap.Temp = entity.Temp;   
                dbMap.Humidity = entity.Humidity;   
                dbMap.Visibility = entity.Visibility;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dbMap = _context.Weather.FirstOrDefault(m => m.id == id);
            if (dbMap != null)
            {
                _context.Weather.Remove(dbMap);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
        {
            IQueryable<DBWeather> query = _context.Weather;
            LocationRepository locationRepository = new LocationRepository(_context);//?
            if (func != null)
            {
                query = query.Where(m => func.Invoke(m.WeatherConverter(m, locationRepository.Read(m.id))));
            }
            return query.Select(m => m.WeatherConverter(m, locationRepository.Read(m.id))).ToList();
        }

        public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Weather.ToList();
                LocationRepository locationRepository = new LocationRepository(_context);//?
                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.WeatherConverter(dbMap, locationRepository.Read(dbMap.id));
                }
            }
            return new DO.Weather();
        }

        public int ObjectToId(Func<DO.Weather, bool>? func)
        {
            if (func != null)
            {
                var allMaps = _context.Weather.ToList();
                LocationRepository locationRepository = new LocationRepository(_context);//?
                var dbMap = allMaps.FirstOrDefault(m => func(m.WeatherConverter(m, locationRepository.Read(m.id))));
                if (dbMap != null)
                {
                    return dbMap.id;
                }
            }
            return -1;
        }
    }
}
