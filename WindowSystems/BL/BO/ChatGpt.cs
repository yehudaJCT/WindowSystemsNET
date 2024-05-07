namespace WindowSystems.BL.BO;
public class ChatGpt
{
    public string prompt { get; set; }
    public string responde { get; set; }

    public ChatGpt(string prompt, string responde)
    {
        this.prompt = prompt;
        this.responde = responde;
    }
}