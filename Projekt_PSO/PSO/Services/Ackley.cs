using PSO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Services
{
    public class Ackley : Function
    {
        // http://www.sfu.ca/~ssurjano/ackley.html
        public override double Evaluate(double[] x)
        {
            int dimension = x.Length;
            int a = 20;
            double b = 0.2;
            double c = 2 * Math.PI;
            double leftSum = 0;
            double rightSum = 0;
            for(int i = 0; i < dimension; i++)
            {
                leftSum += Math.Pow(x[i], 2);
                rightSum += Math.Cos(c*x[i]);
            }

            double leftBracket = (b * -1) * Math.Sqrt((1 / dimension) * leftSum);
            double rightBracket = (1 / dimension) * rightSum;

            return (a * -1) * Math.Exp(leftBracket) - (Math.Exp(rightBracket)) + a + Math.Exp(1); 

        }

        public override double LowerBound
        {
            get
            {
                return -32.768;
            }
        }

        public override double UpperBound
        {
            get
            {
                return 32.768;
            }
        }

        

    }
}
