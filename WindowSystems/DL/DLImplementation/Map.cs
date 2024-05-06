using WindowSystems.DL.DOApi;
using WindowSystems.DL.SQL;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.DLImplementation
{
    public class Map : IMap
    {
        MapRepository mapRepository = new MapRepository(new MyDbContext());
        WEBMap webMap = new WEBMap();

        public int Create(DO.Map entity)
        {
            return mapRepository.Create(entity);
        }

        public void Delete(DO.Map entity)
        {
            mapRepository.Delete(mapRepository.ObjectToId(m => m.URL == entity.URL));
            throw new NotImplementedException();
        }

        public Task<DO.Map> Read(DO.Map entity)
        {

            int id = mapRepository.ObjectToId(m => m.URL == entity.URL);
            if (id == -1)
            {
                webMap.Read(entity);
            }
            else
            { 
                mapRepository.Read(id);
            }

            throw new NotImplementedException();
        }

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            mapRepository.ReadAll(func);
            throw new NotImplementedException();
        }

        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            mapRepository.ReadObject(func);
            throw new NotImplementedException();
        }

        public void Update(DO.Map entity)
        {
            mapRepository.Update(mapRepository.ObjectToId(m => m.URL == entity.URL),entity);
            throw new NotImplementedException();
        }
    }
}
