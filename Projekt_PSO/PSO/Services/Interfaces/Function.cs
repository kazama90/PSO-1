using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services.Interfaces
{
    public abstract class Function
    {
        protected Function(double[] x)
        {
            X = x;
        }

        public double[] X { get; protected set; }

        public int Dimension
        {
            get
            {
                if (X == null)
                    return 0;

                return X.Length;
            }

        }

        // Obliczenie wartosci danej funkcji
        public abstract double Evaluate();

        // Gorna i dolna granica domeny funkcji 
        public abstract double LowerBound { get; }
        public abstract double UpperBound { get; }

        
    }
}
