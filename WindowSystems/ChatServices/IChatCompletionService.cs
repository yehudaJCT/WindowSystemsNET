namespace OpenAI_ChatGPT;
using WindowSystems.DL.DO;

public interface IChatCompletionService
{
    Task<string> GetChatCompletionAsync(string question);
}