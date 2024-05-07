using WindowSystems.BL.BLApi;
using WindowSystems.BL.BO;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.DLImplementation;
using WindowSystems.DL.DO;

namespace WindowSystems.BL.BlImplementation
{
    public class Data : IData
    {
        IDal dal = new Dal();

        public bool IsALocation(string address)
        {
            var location = dal.location.Read(new DL.DO.Location(address));
            //??
            if (location == null )
                return false;
            return true;
        }

        void IData.Delete(string URL)
        {
            DL.DO.Map map = dal.map.ReadObject(m => m.URL == URL);
            dal.map.Delete(map);
        }

        BO.Data IData.GetData(string address, DateTime dateTime)
        {
            var location = dal.location.Read(new DL.DO.Location(address));
            //var weather = dal.weather.Read()
            throw new NotImplementedException();
        }

        BO.ChatGpt IData.GetResponde(string URL, string Prompt)
        {
            throw new NotImplementedException();
        }
    }
}
