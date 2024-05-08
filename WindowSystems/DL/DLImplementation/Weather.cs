﻿using WindowSystems.DL.DalApi;
using WindowSystems.DL.SQL;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.DLImplementation;


public class Weather : IWeather
{
    WeatherRepository weatherRepository = new WeatherRepository(new MyDbContext());
    WEBWeather webWeather = new WEBWeather();

    public int Create(DO.Weather entity)
    {
        return weatherRepository.Create(entity);
    }

    public void Delete(DO.Weather entity)
    {
        weatherRepository.Delete(weatherRepository.ObjectToId(m => m.id == entity.id));
    }

    public async Task<DO.Weather> Read(DO.Weather entity)
    {
        int id = weatherRepository.ObjectToId(m => m.id == entity.id);
        if (id == -1)
        {
            entity = await webWeather.Read(entity);
            this.Create(entity);
        }
        else
        {
            entity = weatherRepository.Read(id);
        }
        return entity;
    }

    public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
    {
        return weatherRepository.ReadAll(func);
    }

    public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
    {
        return weatherRepository.ReadObject(func);
    }

    public void Update(DO.Weather entity)
    {
        weatherRepository.Update(entity);
    }
}