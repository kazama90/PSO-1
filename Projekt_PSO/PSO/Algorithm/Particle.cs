using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Algorithm
{
    public class Particle
    {
        #region Fields
        static Random rnd = new Random(); 
        #endregion

        #region Properties
        public double[] Position { get; private set; }
        public double Fitness { get; private set; }
        public double[] BestPosition { get; private set; }
        public double BestFitness { get; private set; }
        public double[] Velocity { get; private set; } 
        #endregion

        #region Ctor
        public Particle(double[] position, double[] velocity, double fitness)
        {
            Position = position;
            Velocity = velocity;
            Fitness = fitness;
            BestFitness = double.MaxValue;
            BestPosition = new double[Position.Length];
            UpdateBestPosition();
        }
        #endregion

        #region Methods
        public void UpdateBestPosition()
        {
            if (Fitness < BestFitness)
            {
                BestFitness = Fitness;
                Position.CopyTo(BestPosition, 0);
            }
        }

        public void UpdateFitness(double fitness)
        {
            Fitness = fitness;
        }

        public void UpdateVelocity(double[] velocity)
        {
            velocity.CopyTo(Velocity, 0);
        }

        public void UpdatePosition(double[] position)
        {
            position.CopyTo(Position, 0);
        }

        #endregion
    }
}
