using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.DataModels
{
    public class Particle
    {
        public double[] Position { get; set; }
        public double Fitness { get; set; }
        public double[] Velocity { get; set; }

        public double[] BestPosition { get; set; }
        public double BestFitness { get; set; }
    }
}
