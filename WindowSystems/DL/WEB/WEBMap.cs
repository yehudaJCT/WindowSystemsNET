using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WindowSystems.DL.DO;

/// <summary>
/// Provides functionality to read map information from a web service.
/// </summary>
public class WEBMap
{
    private static readonly HttpClient client = new HttpClient();

    /// <summary>
    /// Reads map information asynchronously from a web service.
    /// </summary>
    /// <param name="entity">The map entity containing location and zoom details.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the read map entity.</returns>
    public async Task<Map> Read(Map entity)
    {
        try
        {
            string map_url = $"https://static-maps.yandex.ru/1.x/?l=map&ll={entity.Location.Longitude},{entity.Location.Latitude}&z={entity.zoom}&size=650,450&lang=en_US";

            HttpResponseMessage response = await client.GetAsync(map_url);

            if (response.IsSuccessStatusCode)
            {
                byte[] mapBytes = await response.Content.ReadAsByteArrayAsync();

                Map map = new Map(entity.Location, map_url, entity.zoom);
                return map;
            }
            else
            {
                Console.WriteLine("Error: Unable to retrieve map");
                return entity; // Return the original entity if there's an error
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
    }
}
