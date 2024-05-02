using WindowSystems.DL.DOApi;

namespace WindowSystems.DL.DLImplementation
{
    public class Weather : IWeather
    {
        public int Create(DO.Weather entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DO.Weather entity)
        {
            throw new NotImplementedException();
        }

        public Task<DO.Weather> Read(DO.Weather entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Weather> ReadAll(Func<DO.Weather, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public DO.Weather ReadObject(Func<DO.Weather, bool>? func)
        {
            throw new NotImplementedException();
        }

        public void Update(DO.Weather entity)
        {
            throw new NotImplementedException();
        }
    }
}
