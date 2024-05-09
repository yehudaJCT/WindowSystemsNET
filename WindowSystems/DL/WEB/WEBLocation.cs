using Newtonsoft.Json.Linq;
using WindowSystems.DL.DO;


namespace WindowSystems.DL.WEB;
public class WEBLocation 
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Location> Read(Location location)
    {
        string LocationIQ_api_key = "pk.dd2f67b1df55bf5c08d2e43cdd7419d9";
        string url = $"https://us1.locationiq.com/v1/search.php?key={LocationIQ_api_key}&q={Uri.EscapeDataString(location.Address)}&format=json";

        HttpResponseMessage response = await client.GetAsync(url);

        if(!response.IsSuccessStatusCode)
        {
            return new Location(-1,"null",1000,1000);
        }

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        JArray data = JArray.Parse(responseBody);

        return new Location(location.id, location.Address, double.Parse(data[0]["lat"].ToString()), double.Parse(data[0]["lon"].ToString()));

    }
}