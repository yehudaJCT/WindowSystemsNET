using OpenAI_ChatGPT;
using System.Text.Json;
using System.Threading.Tasks;
using WindowSystems.DL.DO;

/// <summary>
/// Provides functionality to interact with OpenAI ChatGPT service over the web.
/// </summary>
public class WEBChatGpt
{
    private readonly IChatCompletionService _chatCompletionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="WEBChatGpt"/> class.
    /// </summary>
    /// <param name="chatCompletionService">The service for completing chat prompts.</param>
    public WEBChatGpt(IChatCompletionService chatCompletionService)
    {
        _chatCompletionService = chatCompletionService;
    }

    /// <summary>
    /// Reads a ChatGpt instance asynchronously.
    /// </summary>
    /// <param name="chatGpt">The ChatGpt instance to read.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the read ChatGpt instance.</returns>
    public async Task<ChatGpt> Read(ChatGpt chatGpt)
    {
        var response = await _chatCompletionService.GetChatCompletionAsync(chatGpt.prompt);
        return new ChatGpt(chatGpt.id, chatGpt.prompt, response);
    }
}
