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

        bool _isLiczbaIteracji;
        public bool IsLiczbaIteracji
        {
            get { return _isLiczbaIteracji; }
            set
            {
                if (_isLiczbaIteracji == value)
                    return;

                _isLiczbaIteracji = value;
                RaisePropertyChanged();
            }
        }

        int _particleCount = 1;
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

        int _iterationCount = 1;
        public int IterationCount
        {
            get { return _iterationCount; }
            set
            {
                if (_iterationCount == value)
                    return;

                _iterationCount = value;
                _isLiczbaIteracji = true;
                RaisePropertyChanged();
                RaisePropertyChanged(() => IsLiczbaIteracji);
            }
        }

        int _timeInSeconds = 1;
        public int TimeInSeconds
        {
            get { return _timeInSeconds; }
            set
            {
                if (_timeInSeconds == value)
                    return;

                _timeInSeconds = value;
                _isLiczbaIteracji = false;
                RaisePropertyChanged();
                RaisePropertyChanged(() => IsLiczbaIteracji);
            }
        }

        double _cOneValue = 2;
        public double COneValue
        {
            get { return _cOneValue; }
            set
            {
                if (_cOneValue == value)
                    return;

                _cOneValue = value;
                _cTwoValue = 4 - value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => CTwoValue);
            }
        }

        double _cTwoValue = 2;
        public double CTwoValue
        {
            get { return _cTwoValue; }
            set
            {
                if (_cTwoValue == value)
                    return;

                _cTwoValue = value;
                _cOneValue = 4 - value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => COneValue);
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

        int _maxSpeed;
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            set
            {
                if (_maxSpeed == value)
                    return;

                _maxSpeed = value;
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
