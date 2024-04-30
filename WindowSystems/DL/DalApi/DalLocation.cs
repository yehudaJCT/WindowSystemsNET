using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WindowSystems.DL.API;
using WindowSystems.DL.interfaces;



public class DalLocation : ILocation
{
    private static readonly HttpClient client = new HttpClient();

    public int Create(Location entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Location entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Location> Read(Location location)
    {
        string LocationIQ_api_key = "pk.dd2f67b1df55bf5c08d2e43cdd7419d9";
        string url = $"https://us1.locationiq.com/v1/search.php?key={LocationIQ_api_key}&q={Uri.EscapeDataString(location.Address)}&format=json";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        JArray data = JArray.Parse(responseBody);



        return new Location
        {
            Latitude =  double.Parse(data[0]["lat"].ToString()),
            Longitude = double.Parse(data[0]["lon"].ToString()),
            Address = location.Address
        };

    }

    public IEnumerable<Location?> ReadAll(Func<Location?, bool>? func = null)
    {
        throw new NotImplementedException();
    }

    public Location ReadObject(Func<Location?, bool>? func)
    {
        throw new NotImplementedException();
    }

    public void Update(Location entity)
    {
        throw new NotImplementedException();
    }
}