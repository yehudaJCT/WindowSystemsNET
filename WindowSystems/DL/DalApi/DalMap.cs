using WindowSystems.DL.API;
using WindowSystems.DL.interfaces;

namespace WindowSystems.DL.DalApi;

public class DalMap : IMap
{
    public int Create(Map entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Map entity)
    {
        throw new NotImplementedException();
    }

    public Map Read(Map entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Map?> ReadAll(Func<Map?, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public Map ReadObject(Func<Map?, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(Map entity)
    {
        throw new NotImplementedException();
    }
}
