using WindowSystems.DL.DO;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.SQL;
using OpenAI_ChatGPT;
using WindowSystems.DL.SQL.model;

namespace WindowSystems.DL.DLImplementation
{
    /// <summary>
    /// Implementation of the chat GPT data access layer.
    /// </summary>
    public class ChatGpt : IChatGpt
    {
        ChatGptRepository chatGptRepository = new ChatGptRepository(new MyDbContext());

        private readonly IChatCompletionService _chatCompletionService;
        private readonly WEBChatGpt webChatGpt;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatGpt"/> class.
        /// </summary>
        /// <param name="chatCompletionService">The chat completion service.</param>
        public ChatGpt(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
            webChatGpt = new WEBChatGpt(chatCompletionService);
        }

        /// <summary>
        /// Creates a new chat GPT entity.
        /// </summary>
        /// <param name="entity">The chat GPT entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public int Create(DO.ChatGpt entity)
        {
            return chatGptRepository.Create(entity);
        }

        /// <summary>
        /// Deletes a chat GPT entity.
        /// </summary>
        /// <param name="entity">The chat GPT entity to delete.</param>
        public void Delete(DO.ChatGpt entity)
        {
            chatGptRepository.Delete(chatGptRepository.ObjectToId(m => m.id == entity.id));
        }

        /// <summary>
        /// Reads a chat GPT entity.
        /// </summary>
        /// <param name="entity">The chat GPT entity to read.</param>
        /// <returns>The read chat GPT entity.</returns>
        public async Task<DO.ChatGpt> Read(DO.ChatGpt entity)
        {
            int id = chatGptRepository.ObjectToId(m => m.id == entity.id);
            if (id == -1)
            {
                entity = await webChatGpt.Read(entity);
                this.Create(entity);
            }
            else
            {
                entity = chatGptRepository.Read(id);
            }
            return entity;
        }

        /// <summary>
        /// Reads all chat GPT entities.
        /// </summary>
        /// <param name="func">Optional function to filter entities.</param>
        /// <returns>An enumerable collection of chat GPT entities.</returns>
        public IEnumerable<DO.ChatGpt> ReadAll(Func<DO.ChatGpt, bool>? func = null)
        {
            return chatGptRepository.ReadAll(func);
        }

        /// <summary>
        /// Reads a single chat GPT entity based on a predicate function.
        /// </summary>
        /// <param name="func">The predicate function to apply for reading.</param>
        /// <returns>The read chat GPT entity.</returns>
        public DO.ChatGpt ReadObject(Func<DO.ChatGpt, bool>? func)
        {
            return chatGptRepository.ReadObject(func);
        }

        /// <summary>
        /// Updates a chat GPT entity.
        /// </summary>
        /// <param name="entity">The chat GPT entity to update.</param>
        public void Update(DO.ChatGpt entity)
        {
            int id = chatGptRepository.ObjectToId(m => m.id == entity.id);
            chatGptRepository.Update(entity);
        }
    }
}
