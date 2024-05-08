namespace WindowSystems.DL.DO;

public struct ChatGpt
{
    public int id { get; }
    public string prompt { get; }
    public string responde { get; }

    public ChatGpt(int id, string prompt, string responde)
    {
        this.id = id;
        this.prompt = prompt;
        this.responde = responde;
    }

    public ChatGpt(int id, string prompt)
    {
        this.id = id;
        this.prompt = prompt;
    }
}
