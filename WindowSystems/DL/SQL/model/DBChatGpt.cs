using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model;

public class DBChatGpt
{
    [Key]
    public int id { get; set; }


    [StringLength(255)]
    public string prompt { get; set; }


    [StringLength(255)]
    public string responde { get; set; }

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
