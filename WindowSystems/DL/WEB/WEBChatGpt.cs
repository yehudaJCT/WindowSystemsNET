using Microsoft.CodeAnalysis;
using OpenAI_ChatGPT;
using System.Text;
using System.Text.Json;
using WindowSystems.DL.DO;

public class WEBChatGpt
{
    private readonly IChatCompletionService _chatCompletionService;

    public async Task<WindowSystems.DL.DO.ChatGpt> Read(string prompt)
    {
        var response = await _chatCompletionService.GetChatCompletionAsync(prompt);
        return new WindowSystems.DL.DO.ChatGpt
        {
            prompt = prompt,
            responde = response
        };
    }
}

