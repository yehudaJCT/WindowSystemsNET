using WindowSystems.BL.BO;

namespace WindowSystems.BL.BLApi
{
    public interface IData
    {
        public bool IsALocation(string address);

        public Data GetData(string address, DateTime dateTime);

        public ChatGpt GetResponde(string URL, string Prompt);

        public void Delete(string URL);

    }
}
