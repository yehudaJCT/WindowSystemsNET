using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.DO;

namespace WindowSystems.SQL.model;

public class DBChatGpt
{
    [Key]
    public int id { get; set; }
    public string prompt { get; set; }
    public string responde { get; set; }



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
