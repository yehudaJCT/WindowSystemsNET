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

        void IData.Delete(string URL)
        {
            DL.DO.Map map = dal.map.ReadObject(m => m.URL == URL);
            dal.map.Delete(map);
        }

        BO.Data IData.GetData(double lon, double lat, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        BO.ChatGpt IData.GetResponde(string URL, string Prompt)
        {
            throw new NotImplementedException();
        }
    }
}
