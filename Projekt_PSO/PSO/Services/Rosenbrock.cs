using PSO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services
{
    public class Rosenbrock : Function
    {
        public Rosenbrock(double[] x) : base(x) { }

        // http://www.sfu.ca/~ssurjano/rosen.html
        public override double Evaluate()
        {
            double sum = 0;
            double leftBracket = 0;
            double rightBracket = 0;

            for(int i=0; i < Dimension - 1; i++)
            {
                leftBracket = Math.Pow(X[i + 1] - Math.Pow(X[i], 2), 2);
                rightBracket = Math.Pow(X[i] - 1, 2);
                sum += (100 * leftBracket) + rightBracket;
            }

            return sum;

        }

        public override double LowerBound
        {
            get { return -5; }
        }

        public override double UpperBound
        {
            get { return 10; }
        }
    }
}
