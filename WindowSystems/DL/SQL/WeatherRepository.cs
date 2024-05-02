using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowSystems.DL.DOApi;

namespace WindowSystems.DL.SQL
{
    public class WeatherRepository
    {
        //private readonly WeatherDbContext _context;

        //public WeatherRepository()
        //{
        //    _context = new WeatherDbContext();
        //}

        //public int Create(BL.BO.Weather entity)
        //{
        //    try
        //    {
        //        _context.Weathers.Add(entity);
        //        return _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while creating weather data.", ex);
        //    }
        //}

        //public BL.BO.Weather Read(BL.BO.Weather entity)
        //{
        //    try
        //    {
        //        return _context.Weathers.Find(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while reading weather data.", ex);
        //    }
        //}

        //public void Update(BL.BO.Weather entity)
        //{
        //    try
        //    {
        //        _context.Entry(entity).State = EntityState.Modified;
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while updating weather data.", ex);
        //    }
        //}

        //public void Delete(BL.BO.Weather entity)
        //{
        //    try
        //    {
        //        _context.Weathers.Remove(entity);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while deleting weather data.", ex);
        //    }
        //}

        //public IEnumerable<BL.BO.Weather?> ReadAll(Func<BL.BO.Weather?, bool>? func = null)
        //{
        //    try
        //    {
        //        if (func != null)
        //            return _context.Weathers.Where(func).ToList();
        //        return _context.Weathers.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while reading all weather data.", ex);
        //    }
        //}

        //public BL.BO.Weather ReadObject(Func<BL.BO.Weather?, bool>? func)
        //{
        //    try
        //    {
        //        if (func != null)
        //            return _context.Weathers.FirstOrDefault(func);
        //        throw new ArgumentNullException(nameof(func));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while reading weather object.", ex);
        //    }
        //}
    }
}
