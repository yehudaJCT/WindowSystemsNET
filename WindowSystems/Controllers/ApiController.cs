using System;
using System.Net.Http;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public ApiController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet("weather")]
    public async Task<IActionResult> GetWeather(string location)
    {
        var LocationIQ_api_key = "pk.dd2f67b1df55bf5c08d2e43cdd7419d9";
        var openweathermap_api_key = "df21d91a75fffd8fdbac469d792d0e69";

        var client = _clientFactory.CreateClient();

        // Get latitude and longitude from LocationIQ API
        var locationResponse = await client.GetStringAsync($"https://us1.locationiq.com/v1/search.php?key={LocationIQ_api_key}&q={location}&format=json");
        var locationData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(locationResponse);
        var lat = locationData[0]["lat"];
        var lon = locationData[0]["lon"];

        // Get weather data from OpenWeatherMap API
        var weatherResponse = await client.GetStringAsync($"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={openweathermap_api_key}");

        if (!string.IsNullOrEmpty(weatherResponse))
        {
            return Ok(weatherResponse);
        }

        return BadRequest();
    }

    [HttpGet("map")]
    public async Task<IActionResult> GetMap(string location)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://api.mapbox.com/styles/v1/mapbox/streets-v11/static/{location}?access_token=YOUR_MAPBOX_ACCESS_TOKEN");

        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var bytes = await response.Content.ReadAsByteArrayAsync();
            System.IO.File.WriteAllBytes("map.png", bytes);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("sendToBard")]
    public async Task<IActionResult> SendToBard(string text, string weather, string mapPath)
    {
        // Implement the logic to send the text, weather, and map to Bard (Gemini)
        // This will depend on the specific API provided by Bard (Gemini)

        return Ok();
    }
}