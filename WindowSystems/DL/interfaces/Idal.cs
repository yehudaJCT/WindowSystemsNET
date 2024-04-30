using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowSystems.DL.interfaces;

public interface IDal
{
    IMap map { get; }

    IWeather weather { get; }
}
