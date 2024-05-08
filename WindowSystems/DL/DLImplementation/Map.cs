using WindowSystems.DL.DalApi;
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
            mapRepository.Delete(mapRepository.ObjectToId(m => m.id == entity.id));
        }

        public async Task<DO.Map> Read(DO.Map entity)
        {

            int id = mapRepository.ObjectToId(m => m.id == entity.id);
            if (id == -1)
            {
                entity = await webMap.Read(entity);
                this.Create(entity);
            }
            else
            { 
                entity =  mapRepository.Read(id);
            }
            return entity;
        }

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            return mapRepository.ReadAll(func);
        }

        public DO.Map ReadObject(Func<DO.Map, bool>? func)
        {
            return mapRepository.ReadObject(func);
        }

        public void Update(DO.Map entity)
        {
            mapRepository.Update(entity);
        }
    }
}
