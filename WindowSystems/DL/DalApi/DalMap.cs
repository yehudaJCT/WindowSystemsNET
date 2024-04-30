using Humanizer;
using WindowSystems.DL.API;
using WindowSystems.DL.interfaces;

namespace WindowSystems.DL.DalApi;

public class DalMap : IMap
{
    private static readonly HttpClient client = new HttpClient();

    public int Create(Map entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Map entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Map> Read(Map entity)
    {
        string map_url = $"https://static-maps.yandex.ru/1.x/?l=map&ll={entity.lon},{entity.lon}&z={entity.zoom}&size=650,450&lang=en_US";

        HttpResponseMessage response = await client.GetAsync(map_url);

        if (response.IsSuccessStatusCode)
        {
            byte[] mapBytes = await response.Content.ReadAsByteArrayAsync();

            // Save the map image
            await File.WriteAllBytesAsync("..\\WindowSystems\\map.png", mapBytes);

            Map map = new Map
            {
                URL = map_url,
                lan = entity.lan,
                lon = entity.lon,
                zoom = entity.zoom
            };

            return map;

        }
        else
        {
            Console.WriteLine("Error: Unable to retrieve map");
            return entity;
        }
    }

    public IEnumerable<Map?> ReadAll(Func<Map?, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public Map ReadObject(Func<Map?, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(Map entity)
    {
        throw new NotImplementedException();
    }
}
