using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services.Interfaces
{
    public class Rastrigin : Function
    {
        public Rastrigin(double[] x) : base(x) { }

        // http://www.sfu.ca/~ssurjano/rastr.html
        public override double Evaluate()
        {
            double sum = 0;
            for(int i = 0; i < Dimension; i++)
            {
                sum += Math.Pow(X[i], 2) - 10 * Math.Cos(2 * Math.PI * X[i]); 
            }

            return 10 * Dimension + sum;
        }

        public override double LowerBound
        {
            get
            {
                return -5.12;
            }
        }

        public override double UpperBound
        {
            get
            {
                return 5.12;
            }
        }

    }
}
