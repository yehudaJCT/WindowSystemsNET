using System.Drawing;

namespace WindowSystems.BL.BO;


public struct Data
{
    public string URL { get; set; }

    public BO.Weather Weather { get; set; }

    public BO.ChatGpt ChatGpt { get; set; }

    public BO.Location location  { get; set; }

    
};
