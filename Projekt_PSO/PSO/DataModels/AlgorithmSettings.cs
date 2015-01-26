using Infrastruktura.Common;
using PSO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.DataModels
{
    public class AlgorithmSettings : PropertyChangedImplementation
    {
        public MathFunctions MathFunction { get; set; }

        int _particleCount;
        public int ParticleCount
        {
            get { return _particleCount; }
            set
            {
                if (_particleCount == value)
                    return;

                _particleCount = value;
                RaisePropertyChanged();
            }
        }

        int _iterationCount;
        public int IterationCount
        {
            get { return _iterationCount; }
            set
            {
                if (_iterationCount == value)
                    return;

                _iterationCount = value;
                RaisePropertyChanged();
            }
        }

        decimal _inertia;
        public decimal Inertia
        {
            get { return _inertia; }
            set
            {
                if (_inertia == value)
                    return;

                _inertia = value;
                RaisePropertyChanged();
            }
        }

        decimal _cOneValue;
        public decimal COneValue
        {
            get { return _cOneValue; }
            set
            {
                if (_cOneValue == value)
                    return;

                _cOneValue = value;
                RaisePropertyChanged();
            }
        }

        decimal _cTwoValue;
        public decimal CTwoValue
        {
            get { return _cTwoValue; }
            set
            {
                if (_cTwoValue == value)
                    return;

                _cTwoValue = value;
                RaisePropertyChanged();
            }
        }

        bool _tightness;
        public bool Tightness
        {
            get { return _tightness; }
            set
            {
                if (_tightness == value)
                    return;

                _tightness = value;
                RaisePropertyChanged();
            }
        }
    }
}
