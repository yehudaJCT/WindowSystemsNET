namespace WindowSystems.DL.DalApi;

using System;
using System.Collections.Generic;
using WindowSystems.DL.API;
using WindowSystems.DL.interfaces;

public class dalWeather : IWeather
{
    public int Create(Weather entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Weather entity)
    {
        throw new NotImplementedException();
    }

    public Weather Read(Weather entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Weather?> ReadAll(Func<Weather?, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public Weather ReadObject(Func<Weather?, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(Weather entity)
    {
        throw new NotImplementedException();
    }
}
