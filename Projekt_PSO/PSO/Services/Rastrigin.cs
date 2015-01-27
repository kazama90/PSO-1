using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services.Interfaces
{
    public class Rastrigin : Function
    {
        // http://www.sfu.ca/~ssurjano/rastr.html
        public override double Evaluate(double[] x)
        {
            int dimension = x.Length;
            double sum = 0;
            for(int i = 0; i < dimension; i++)
            {
                sum += Math.Pow(x[i], 2) - 10 * Math.Cos(2 * Math.PI * x[i]); 
            }

            return 10 * dimension + sum;
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
