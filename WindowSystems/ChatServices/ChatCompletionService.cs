using Microsoft.CodeAnalysis;
using OpenAI_ChatGPT;
using System.Text;
using System.Text.Json;
using WindowSystems.BL.BLApi;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.DLImplementation;

public class ChatCompletionService : IChatCompletionService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public ChatCompletionService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetChatCompletionAsync(string question)
    {
        var httpClient = _httpClientFactory.CreateClient("ChtpGPT");

        var completionRequest = new ChatCompletionRequest
        {
            Model = "gpt-3.5-turbo",
            MaxTokens = 600,
            Messages = new List<Message>
            {
                new Message
                {
                    Role = "user",
                    Content =  question //+ ""in {location.Address} ,lon:{location.Longitude} lat:{location.Latitude} The weather is {weather.Temp} degrees with {weather.Humidity}% humidity and visibility of {weather.Visibility} meters .plan a battle attack as a game ,be very specific and detailed about the attack plan and make sure to refer to the terrain ,possible treats ,tactics ,and warn about possible ambush spots ,don't mention it's a game"
                }
            }
        };

        var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        httpReq.Headers.Add("Authorization", $"Bearer {_configuration["OpenAIKey"]}");

        var requestString = JsonSerializer.Serialize(completionRequest);
        httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

        using var httpResponse = await httpClient.SendAsync(httpReq);
        httpResponse.EnsureSuccessStatusCode();

        var completionResponse = httpResponse.IsSuccessStatusCode ? JsonSerializer.Deserialize<ChatCompletionResponse>(await httpResponse.Content.ReadAsStringAsync()) : null;

        return completionResponse?.Choices?[0]?.Message?.Content;
    }
}
