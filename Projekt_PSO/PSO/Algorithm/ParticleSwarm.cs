using PSO.Algorithm;
using PSO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    public class ParticleSwarm
    {
        static Random rnd = new Random();

        public bool UseTightness { get; private set; }
        public double COneValue { get; private set; }
        public double CTwoValue { get; private set; }
        public double? Tightness { get; private set; }
        public double Inertia { get; private set; }
        public double BestFitness { get; private set; }
        public double[] BestPosition { get; private set; }
        public List<Particle> Particles { get; private set; }
        public Function OptimizationFunction { get; private set; }
        public int SwarmSize { get; private set; }
        public int IterationCount { get; private set; }
        public int Dimension { get; private set; }
        public double Vmax { get; private set; }

        public ParticleSwarm(int swarmSize, int iterationCount, Function function, double inertia, double cOneValue, double cTwoValue, double vmax, bool useTightness, double? tigthness = null)
        {
            SwarmSize = swarmSize;
            IterationCount = iterationCount;
            Inertia = inertia;
            COneValue = cOneValue;
            CTwoValue = cTwoValue;
            Vmax = vmax;
            OptimizationFunction = function;
            UseTightness = useTightness;
            Tightness = tigthness;

            Dimension = 3;
            BestFitness = double.MaxValue;
            BestPosition = new double[Dimension];

            InitializeParticles();

        }

        private void InitializeParticles()
        {
            Particles = new List<Particle>();

            for (int i = 0; i < SwarmSize; i++)
            {
                double[] randomParticlePosition = new double[Dimension];
                for(int j = 0; j < Dimension; j++)
                {
                    randomParticlePosition[j] = NextDouble(OptimizationFunction.LowerBound, OptimizationFunction.UpperBound);
                }

                double[] randomParticleVelocity = new double[Dimension];

                for(int k = 0; k < Dimension; k++)
                {
                    if (UseTightness)
                    {
                        randomParticleVelocity[k] = 0;
                        continue;
                    }

                    double minVelocity = (-1 * Vmax) / 3;
                    double maxVelocity = Vmax / 3;

                    randomParticleVelocity[k] = NextDouble(minVelocity, maxVelocity);
                }

                Particles.Add(new Particle(randomParticlePosition, randomParticleVelocity, OptimizationFunction.Evaluate(randomParticlePosition)));
                
            }
        }

        double NextDouble(double min, double max)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException();
            return rnd.NextDouble() * (Math.Abs(max - min)) + min;
        }

        public void Iteration()
        {
            foreach (Particle p in Particles)
            {
                UpdateGlobalBestPosition(p);
                UpdateParticleBestPosition(p);
            }

            foreach (Particle p in Particles)
            {
                double[] newVelocity = new double[Dimension];
                double[] newPosition = new double[Dimension];

                for(int i = 0; i < Dimension; i++)
                {
                    double firstRnd = NextDouble(0, 1);
                    double secondRnd = NextDouble(0, 1);

                    // Scisk

                    if (UseTightness)
                    {
                        double cognitiveWeight = COneValue * firstRnd * (p.BestPosition[i] - p.Position[i]);
                        double socialWeight = CTwoValue * secondRnd * (this.BestPosition[i] - p.Position[i]);

                        newVelocity[i] = (double)Tightness * (p.Velocity[i] + cognitiveWeight + socialWeight);
                    }

                    // Bez scisku - inercja + vmax
                    else
                    {
                        double cognitiveWeight = COneValue * firstRnd * (p.BestPosition[i] - p.Position[i]);
                        double socialWeight = CTwoValue * secondRnd * (this.BestPosition[i] - p.Position[i]);

                        newVelocity[i] = Inertia * p.Velocity[i] + cognitiveWeight + socialWeight;

                        // ograniczenie predkosci do Vmax

                        newVelocity[i] = CorrectVelocityToVmax(newVelocity[i]);
                    }

                    newPosition[i] = p.Position[i] + newVelocity[i];

                    // ograniczenie pozycji do zakresu domeny

                    newPosition[i] = CorrectPositionToDomain(newPosition[i]);
                }

                p.UpdateVelocity(newVelocity);
                p.UpdatePosition(newPosition);

            }
        }



        private double CorrectVelocityToVmax(double velocity)
        {
             if (velocity < -1 * Vmax)
             {
                 return -1 * Vmax;
             }
             else if (velocity > Vmax)
             {
                 return Vmax;
             }
             else
             {
                 return velocity;
             }
        }

        private double CorrectPositionToDomain(double x)
        {
            if (x < OptimizationFunction.LowerBound)
            {
                return OptimizationFunction.LowerBound;
            }
            else if (x > OptimizationFunction.UpperBound)
            {
                return OptimizationFunction.UpperBound;
            }
            else
            {
                return x;
            }
        }

        private void UpdateParticleBestPosition(Particle p)
        {
            double particleFitness = OptimizationFunction.Evaluate(p.Position);
            p.UpdateFitness(particleFitness);
            p.UpdateBestPosition();
        }

        private void UpdateGlobalBestPosition(Particle p)
        {
            if (p.BestFitness < this.BestFitness)
            {
                this.BestFitness = p.BestFitness;
                p.Position.CopyTo(this.BestPosition, 0);
            }
        }
    }
}
