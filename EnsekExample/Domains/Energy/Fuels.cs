using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekExample.Domains.Energy
{
    // Used an enum as I hardcoded the fuel ids in the orders tests. 
    // Ideally it would api (cached) response too as these ids could very per environment.
    internal enum Fuel
    {
        gas = 1,
        nuclear = 2,
        electric = 3,
        oil = 4
    }
}
