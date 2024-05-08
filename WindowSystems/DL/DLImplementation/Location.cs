using global::WindowSystems.DL.DalApi;
using global::WindowSystems.DL.SQL;
using global::WindowSystems.DL.WEB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowSystems.DL.DLImplementation;

public class Location : ILocation
{
    LocationRepository locationRepository = new LocationRepository(new MyDbContext());
    WEBLocation webLocation = new WEBLocation();

    public int Create(DO.Location entity)
    {
        return locationRepository.Create(entity);
    }

    public void Delete(DO.Location entity)
    {
        locationRepository.Delete(locationRepository.ObjectToId(m => m.id == entity.id));
    }

    public async Task<DO.Location> Read(DO.Location entity)
    {
        int id = locationRepository.ObjectToId(m => m.id == entity.id);
        if (id == -1)
        {
            entity = await webLocation.Read(entity);
            this.Create(entity);
        }
        else
        {
            entity = locationRepository.Read(id);
        }
        return entity;
    }

    public IEnumerable<DO.Location> ReadAll(Func<DO.Location, bool>? func = null)
    {
        return locationRepository.ReadAll(func);
    }

    public DO.Location ReadObject(Func<DO.Location, bool>? func)
    {
        return locationRepository.ReadObject(func);
    }

    public void Update(DO.Location entity)
    {
        int id = locationRepository.ObjectToId(m => m.id == entity.id);
        locationRepository.Update(entity);
    }
}
