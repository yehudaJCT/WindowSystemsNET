using WindowSystems.BL.BLApi;

namespace WindowSystems.BL.BlImplementation
{
    public class Bl : IBl
    {
        public IData data => new Data();
    }
}
