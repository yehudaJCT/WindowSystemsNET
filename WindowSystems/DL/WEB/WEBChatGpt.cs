using Microsoft.CodeAnalysis;
using OpenAI_ChatGPT;
using System.Text;
using System.Text.Json;
using WindowSystems.DL.DO;

public class WEBChatGpt
{
    private readonly IChatCompletionService _chatCompletionService;

    public async Task<WindowSystems.DL.DO.ChatGpt> Read(ChatGpt chatGpt)
    {
        var response = await _chatCompletionService.GetChatCompletionAsync(chatGpt.prompt);
        return new WindowSystems.DL.DO.ChatGpt(chatGpt.id, chatGpt.prompt, response);

    }
}

