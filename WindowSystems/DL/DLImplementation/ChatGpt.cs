using WindowSystems.DL.DO;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.SQL;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.DLImplementation;

public class ChatGpt : IChatGpt
{

    ChatGptRepository chatGptRepository = new ChatGptRepository(new MyDbContext());
    WEBChatGpt webChatGpt = new WEBChatGpt();

    public int Create(DO.ChatGpt entity)
    {
        return chatGptRepository.Create(entity);
    }

    public void Delete(DO.ChatGpt entity)
    {
        chatGptRepository.Delete(chatGptRepository.ObjectToId(m => m.id == entity.id));
    }

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

    public IEnumerable<DO.ChatGpt> ReadAll(Func<DO.ChatGpt, bool>? func = null)
    {
        return new List<DO.ChatGpt>(chatGptRepository.ReadAll(func));
    }

    public DO.ChatGpt ReadObject(Func<DO.ChatGpt, bool>? func)
    {
        return chatGptRepository.ReadObject(func);   
    }

    public void Update(DO.ChatGpt entity)
    {
        int id = chatGptRepository.ObjectToId(m => m.id == entity.id);
        chatGptRepository.Update(entity);
    }
}
