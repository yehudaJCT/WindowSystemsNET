using Microsoft.EntityFrameworkCore;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL
{
    public class MapRepository
    {
        private readonly MapDbContext _context;

        public MapRepository()
        {
            _context = new MapDbContext();
        }

        public int Create(DO.Map entity)
        {
            SMap sMap = new SMap(entity);
            _context.Maps.Add(sMap);
            return _context.SaveChanges();
        }

        //public DO.Map Read(DO.Map entity)
        //{
        //    SMap sMap = new SMap(entity);
        //    return _context.Maps.Find(sMap);
        //}

        //public void Update(DO.Map entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        public void Delete(DO.Map entity)
        {
            SMap sMap = new SMap(entity);
            _context.Maps.Remove(sMap);
            _context.SaveChanges();
        }

        //public IEnumerable<DO.Map?> ReadAll()
        //{
        //    _context.Maps.p
        //    return _context.Maps.Where(func).ToList();
        //    return _context.Maps.ToList();
        //}

        //public DO.Map ReadObject(Func<DO.Map?, bool>? func)
        //{
        //    if (func != null)
        //        return _context.Maps.FirstOrDefault(func);
        //    throw new ArgumentNullException(nameof(func));
        //}


    }
}
