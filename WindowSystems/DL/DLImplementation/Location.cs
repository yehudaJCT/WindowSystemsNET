namespace WindowSystems.DL.DLImplementation;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WindowSystems.DL.DOApi;

public class Location : ILocation
{
    public int Create(DO.Location entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(DO.Location entity)
    {
        throw new NotImplementedException();
    }

    public Task<DO.Location> Read(DO.Location entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DO.Location> ReadAll(Func<DO.Location, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public DO.Location ReadObject(Func<DO.Location, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(DO.Location entity)
    {
        throw new NotImplementedException();
    }
}
