using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services.Interfaces
{
    public abstract class Function
    {
        // Obliczenie wartosci danej funkcji
        public abstract double Evaluate(double[] x);

        // Gorna i dolna granica domeny funkcji 
        public abstract double LowerBound { get; }
        public abstract double UpperBound { get; } 
    }
}
