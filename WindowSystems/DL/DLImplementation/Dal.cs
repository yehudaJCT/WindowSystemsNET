using OpenAI_ChatGPT;
using WindowSystems.DL.DalApi;

namespace WindowSystems.DL.DLImplementation
{
    public class Dal : IDal
    {
        private readonly IChatCompletionService _chatCompletionService;

        public Dal(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
        }

        public IMap map => new Map();
        public IWeather weather => new Weather();
        public IChatGpt chatGpt => new ChatGpt(_chatCompletionService);
        public ILocation location => new Location();
    }
}
