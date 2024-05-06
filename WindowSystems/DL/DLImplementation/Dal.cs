using WindowSystems.DL.DalApi;

namespace WindowSystems.DL.DLImplementation
{
    public class Dal : IDal
    {
        public IMap map => new Map();

        public IWeather weather => new Weather();

        public IChatGpt chatGpt => new ChatGpt();

        public ILocation location => new Location();
    }
}
