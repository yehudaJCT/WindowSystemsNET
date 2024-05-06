namespace WindowSystems.DL.DO;

public struct ChatGpt
{
    public int id { get; set; }
    public string prompt { get; set; }
    public string responde { get; set; }

    public ChatGpt(int id, string prompt, string responde)
    {
        this.id = id;
        this.prompt = prompt;
        this.responde = responde;
    }
}
