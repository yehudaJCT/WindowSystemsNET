using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowSystems.DL.interfaces;
using WindowSystems.DL.sql.Context;

namespace WindowSystems.DL.sql.Implementation
{
    public class WeatherRepository : IWeather
    {
        private readonly WeatherDbContext _context;

        public WeatherRepository()
        {
            _context = new WeatherDbContext();
        }

        public int Create(DO.Weather entity)
        {
            try
            {
                _context.Weathers.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating weather data.", ex);
            }
        }

        public DO.Weather Read(DO.Weather entity)
        {
            try
            {
                return _context.Weathers.Find(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while reading weather data.", ex);
            }
        }

        public void Update(DO.Weather entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating weather data.", ex);
            }
        }

        public void Delete(DO.Weather entity)
        {
            try
            {
                _context.Weathers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting weather data.", ex);
            }
        }

        public IEnumerable<DO.Weather?> ReadAll(Func<DO.Weather?, bool>? func = null)
        {
            try
            {
                if (func != null)
                    return _context.Weathers.Where(func).ToList();
                return _context.Weathers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while reading all weather data.", ex);
            }
        }

        public DO.Weather ReadObject(Func<DO.Weather?, bool>? func)
        {
            try
            {
                if (func != null)
                    return _context.Weathers.FirstOrDefault(func);
                throw new ArgumentNullException(nameof(func));
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while reading weather object.", ex);
            }
        }
    }
}
