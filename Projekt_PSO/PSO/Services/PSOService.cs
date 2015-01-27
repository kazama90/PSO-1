using OxyPlot;
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
                List<DataPoint> bestPos = new List<DataPoint>();
                for (int i = 0; i < settings.IterationCount; i++)
                {
                    if (bestPos.Count == settings.IterationCount / 10 && settings.IsLivePlot)
                    {
                        castedPayload.UpdatePlotFunction(bestPos);
                        bestPos = new List<DataPoint>();
                    }

                    bestPos.Add(new DataPoint(i, p.BestFitness));
                    p.Iteration();
                }

                if (bestPos.Count > 0)
                    castedPayload.UpdatePlotFunction(bestPos);
            }
            else
            {
                var isRunning = true;
                _timer = new System.Timers.Timer(settings.TimeInSeconds * 1000);
                _timer.Elapsed += (s, e) => { isRunning = false; };
                _timer.Start();

                List<DataPoint> bestPos = new List<DataPoint>();
                int i = 0;
                while (isRunning)
                {
                    bestPos.Add(new DataPoint(i++, p.BestFitness));
                    p.Iteration();

                    if (bestPos.Count == 10000 && settings.IsLivePlot)
                    {
                        castedPayload.UpdatePlotFunction(bestPos);
                        bestPos = new List<DataPoint>();
                    }
                }

                if (bestPos.Count > 0)
                    castedPayload.UpdatePlotFunction(bestPos);
            }

            castedPayload.CalculationFinished();
        }

        public void RunAsync(AsyncPsoPayload settings)
        {
            Thread thdPso = new Thread(new ParameterizedThreadStart(Run));
            var temp = thdPso.ThreadState;
            thdPso.Start(settings);
        }
    }

    public class AsyncPsoPayload
    {
        public AsyncPsoPayload(AlgorithmSettings settings, Action<List<DataPoint>> updatePlotFunc, Action calculationFinished)
        {
            this.Settings = settings;
            this.UpdatePlotFunction = updatePlotFunc;
            this.CalculationFinished = calculationFinished;
        }

        public AlgorithmSettings Settings { get; set; }
        public Action<List<DataPoint>> UpdatePlotFunction { get; set; }
        public Action CalculationFinished { get; set; }
    }
}
