namespace WindowSystems.BL.BO;
public struct ChatGpt
{
    public string responde;

    public ChatGpt(string prompt, string responde)
    {
        this.responde = responde;
    }
}