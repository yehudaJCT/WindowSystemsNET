using WindowSystems.BL.BO;

namespace WindowSystems.BL.BLApi
{
    public interface IData
    {
        public Data GetData(double lon, double lat, DateTime dateTime);


        public ChatGpt GetResponde(string URL, string Prompt);

        public void Delete(string URL);

    }
}
