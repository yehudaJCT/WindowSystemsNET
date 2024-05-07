using Newtonsoft.Json.Linq;
using WindowSystems.DL.DO;


namespace WindowSystems.DL.WEB;
public class WEBLocation 
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Location> Read(string address)
    {
        string LocationIQ_api_key = "pk.dd2f67b1df55bf5c08d2e43cdd7419d9";
        string url = $"https://us1.locationiq.com/v1/search.php?key={LocationIQ_api_key}&q={Uri.EscapeDataString(address)}&format=json";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        JArray data = JArray.Parse(responseBody);

        return new Location
        {
            Latitude = double.Parse(data[0]["lat"].ToString()),
            Longitude = double.Parse(data[0]["lon"].ToString()),
            Address = address
        };
    }
}