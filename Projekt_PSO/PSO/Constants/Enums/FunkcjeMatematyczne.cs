using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Enums
{
    public enum MathFunctions
    {
        [DescriptionAttribute("Rastrigin")]
        Rastrigin,
        [DescriptionAttribute("Ackley")]
        Ackley,
        [DescriptionAttribute("Rosenbrock")]
        Rosenbrock
    }
}
