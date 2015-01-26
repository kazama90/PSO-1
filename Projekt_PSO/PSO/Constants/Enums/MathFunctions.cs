using Infrastruktura.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Enums
{
    public enum MathFunctions
    {
        [MathFuncDescAttribute("Rastrigin", "rastrigin.png")]
        Rastrigin,
        [MathFuncDescAttribute("Ackley", "ackley.png")]
        Ackley,
        [MathFuncDescAttribute("Rosenbrock", "rosenbrock.png")]
        Rosenbrock
    }
}
