namespace WindowSystems.DL.DO;

public struct ChatGpt
{
    public string prompt { get; }
    public string responde { get; }

    public ChatGpt(string prompt, string responde)
    {
        this.prompt = prompt;
        this.responde = responde;
    }

    public ChatGpt(int id, string prompt)
    {
        this.prompt = prompt;
    }
}
