using WindowSystems.BL.BLApi;
using OpenAI_ChatGPT;

namespace WindowSystems.BL.BlImplementation
{
    public class Bl : IBl
    {
        private readonly IChatCompletionService _chatCompletionService;

        public Bl(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
        }

        public IData data => new Data(_chatCompletionService);
    }
}
