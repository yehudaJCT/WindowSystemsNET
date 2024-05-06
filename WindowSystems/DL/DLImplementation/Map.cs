using WindowSystems.DL.DOApi;
using WindowSystems.DL.SQL;

namespace WindowSystems.DL.DLImplementation
{
    public class Map : IMap
    {
        MyRepository myRepository = new MyRepository(new MyDbContext());
        public int Create(DO.Map entity)
        {
            myRepository.Create(entity);
            throw new NotImplementedException();
        }

        public void Delete(DO.Map entity)
        {
            myRepository.Delete(entity);
            throw new NotImplementedException();
        }

        public Task<DO.Map> Read(DO.Map entity)
        {
            myRepository.Read(entity);
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Map> ReadAll(Func<DO.Map, bool>? func = null)
        {
            myRepository.ReadAll(func);
            throw new NotImplementedException();
        }

        public DO.Map ReadObject(Func<DO.Map, bool> func)
        {
            myRepository.ReadObject(func);
            throw new NotImplementedException();
        }

        public void Update(DO.Map entity)
        {
            myRepository.Update(entity);
            throw new NotImplementedException();
        }
    }
}
