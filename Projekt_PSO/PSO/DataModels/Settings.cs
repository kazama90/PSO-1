using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.DataModels
{
    public class Settings
    {
        public FunctionType Function { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public int NumberOfParticles { get; set; }
        public int Iterations { get; set; }
    }
}
