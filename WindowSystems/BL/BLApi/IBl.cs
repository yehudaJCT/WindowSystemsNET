using WindowSystems.DL.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IBl
{
    public ILocation Location { get; }

    public IMap Map { get; }

    public IWeather Weather { get; }

    public IChatGpt ChatGpt { get; } 
}