using Microsoft.EntityFrameworkCore;
using WindowSystems.DL.DOApi;

namespace WindowSystems.DL.SQL
{
    public class MapRepository
    {
        //private readonly MapDbContext _context;

        //public MapRepository()
        //{
        //    _context = new MapDbContext();
        //}

        //public int Create(DO.Map entity)
        //{
        //    _context.Maps.Add(entity);
        //    return _context.SaveChanges();
        //}

        //public DO.Map Read(DO.Map entity)
        //{
        //    return _context.Maps.Find(entity);
        //}

        //public void Update(DO.Map entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //public void Delete(DO.Map entity)
        //{
        //    _context.Maps.Remove(entity);
        //    _context.SaveChanges();
        //}

        //public IEnumerable<DO.Map?> ReadAll(Func<DO.Map?, bool>? func = null)
        //{
        //    if (func != null)
        //        return _context.Maps.Where(func).ToList();
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
