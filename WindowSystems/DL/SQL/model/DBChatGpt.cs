using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model;

public class DBChatGpt
{
    [Key]
    public int id { get; set; }
    public string prompt;
    public string responde;

    DBChatGpt()
    {

    }

    public DBChatGpt(ChatGpt chatGpt)
    {
        this.id = chatGpt.id;
        this.prompt = chatGpt.prompt;
        this.responde = chatGpt.responde;

    }

    public ChatGpt ChatGptConverter(DBChatGpt ChatGpt)
    {
        ChatGpt chatGpt = new ChatGpt(ChatGpt.id, ChatGpt.prompt, ChatGpt.responde);
        return chatGpt;
    }


}
