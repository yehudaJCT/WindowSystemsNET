using WindowSystems.DL.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowSystems.BL.BLApi;

public interface IBl
{
    IData data { get; }
}