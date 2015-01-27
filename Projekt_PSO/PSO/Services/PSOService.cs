using PSO.DataModels;
using PSO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSO.Services
{
    public class PSOService
    {
        #region Fields
        System.Timers.Timer _timer;
        #endregion Fields
        private void Run(object payload)
        {
            var castedPayload = payload as AsyncPsoPayload;

            if (castedPayload == null)
                throw new Exception("Niepoprawny typ parametru");

            var settings = castedPayload.Settings;

            Function mathFunction;
            switch(settings.MathFunction)
            {
                case Enums.MathFunctions.Ackley:
                    mathFunction = new Ackley();
                    break;
                case Enums.MathFunctions.Rastrigin:
                    mathFunction = new Rastrigin();
                    break;
                case Enums.MathFunctions.Rosenbrock:
                    mathFunction = new Rosenbrock();
                    break;
                default:
                    throw new ArgumentException("Wskazana funkcja nie została zaimplementowana");
            }

            ParticleSwarm p = new ParticleSwarm(settings.ParticleCount,
                                                mathFunction,
                                                settings.Inertia,
                                                settings.COneValue,
                                                settings.CTwoValue,
                                                settings.MaxSpeed,
                                                settings.Tightness,
                                                settings.TightnessLevel);

            if (settings.IsLiczbaIteracji)
            {
                List<double> bestPos = new List<double>();
                for (int i = 0; i < settings.IterationCount; i++)
                {
                    bestPos.Add(p.BestFitness);
                    p.Iteration();
                }
                castedPayload.UpdatePlotFunction(bestPos.ToArray());
            }
            else
            {
                var isRunning = true;
                _timer = new System.Timers.Timer(settings.TimeInSeconds * 1000);
                _timer.Elapsed += (s, e) => { isRunning = false; };
                _timer.Start();

                List<double> bestPos = new List<double>();
                while (isRunning)
                {
                    bestPos.Add(p.BestFitness);
                    p.Iteration();
                }

                castedPayload.UpdatePlotFunction(bestPos.ToArray());
            }
        }

        public void RunAsync(AsyncPsoPayload settings)
        {
            Thread thdPso = new Thread(new ParameterizedThreadStart(Run));
            thdPso.Start(settings);
        }
    }

    public class AsyncPsoPayload
    {
        public AsyncPsoPayload(AlgorithmSettings settings, Action<double[]> updatePlotFunc)
        {
            this.Settings = settings;
            this.UpdatePlotFunction = updatePlotFunc;
        }

        public AlgorithmSettings Settings { get; set; }
        public Action<double[]> UpdatePlotFunction { get; set; }
    }
}
