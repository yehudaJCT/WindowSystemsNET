﻿namespace WindowSystems.DL.DO;

public struct ChatGpt
{
    public string prompt;
    public string responde;

    public ChatGpt(string prompt, string responde)
    {
        this.prompt = prompt;
        this.responde = responde;
    }
}
