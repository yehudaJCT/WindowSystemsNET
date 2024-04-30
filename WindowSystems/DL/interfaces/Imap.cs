using WindowSystems.model.DbData;

namespace WindowSystems.DL.interfaces
{
    public interface IMap
    {
        // Create operation
        void CreateMap(Map map);

        // Read operation
        Map GetMap(double latitude, double longitude);

        // Read all operation
        List<Map> GetAllMap();

        // Update operation
        void UpdateMap(Map map);

        // Delete operation
        void DeleteMap(double latitude, double longitude);
    }
}
