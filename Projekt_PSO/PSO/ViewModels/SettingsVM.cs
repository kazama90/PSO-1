using Infrastruktura.Common;
using Infrastruktura.Common.BaseClasses;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using OxyPlot;
using OxyPlot.Series;
using PSO.Constants;
using PSO.DataModels;
using PSO.Enums;
using PSO.Events;
using PSO.Events.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PSO.ViewModels
{
    public class SettingsVM : BaseVM
    {
        #region Ctor

        public SettingsVM(IUnityContainer container, IEventAggregator eventAggregator)
            : base(container, eventAggregator)
        {
        }

        #endregion Ctor

        #region Properties

        object _backgroundImg;
        public object BackgroundImg
        {
            get
            {
                try
                {
                    return ResourceHelper.GetImage(this.GetType().Namespace, EnumHelper.GetImageUri(MathFunction));
                }
                catch(ArgumentException e)
                {
                    MessageBox.Show("Ładowanie tła zakończone niepowodzeniem", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }

        MathFunctions _mathFunction;
        public MathFunctions MathFunction
        {
            get { return _mathFunction; }
            set
            {
                if (_mathFunction == value)
                    return;

                _mathFunction = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => BackgroundImg);
            }
        }

        public IEnumerable<ValueDescription> MathFunctionsList
        {
            get
            {
                return EnumHelper.GetAllValuesAndDescriptions<MathFunctions>();
            }
        }

        AlgorithmSettings Settings { get; set; }

        #endregion Properties

        #region Event handlers



        #endregion Event handlers

        #region Methods

        public override void Initialize()
        {
            var tab = this.Ribbon.GetOrCreateTab(RibbonNames.ControlTab, "Sterowanie PSO");
            var group = tab.GetOrCreateGroup(RibbonNames.StartStopGroup, "Sterowanie");
            group.AddControl(new RibbonButton
            {
                Name = RibbonNames.StartButton,
                Label = "Uruchom",
                LargeImageSource = ResourceHelper.GetImage(this.GetType().Namespace, "start.png"),
                Command = StartStopCommand
            });
        }

        #endregion Methods

        #region Commands

        DelegateCommand _startStopCommand;
        public DelegateCommand StartStopCommand
        {
            get
            {
                return _startStopCommand
                    ?? (_startStopCommand = new DelegateCommand(StartStopCommandExecute, StartStopCommandCanExecute));
            }
        }
        void StartStopCommandExecute()
        {
            this.EventAggregator.GetEvent<GeneratePlotEvent>().Publish(
                new GeneratePlotPayload
                {
                    Title = "Wykres zbieżności",
                    LineSeries = new List<LineSeries>
                    {
                        new LineSeries
                        {
                            ItemsSource = new List<DataPoint>
                            {
                                new DataPoint(1,1),
                                new DataPoint(2,2),
                                new DataPoint(3,5),
                                new DataPoint(4,9),
                                new DataPoint(5,14)
                            },
                            Title = "funkcja 1"
                        },
                        new LineSeries
                        {
                            ItemsSource = new List<DataPoint>
                            {
                                new DataPoint(0,1),
                                new DataPoint(1,3),
                                new DataPoint(1,5),
                                new DataPoint(2,7),
                                new DataPoint(2,9)
                            },
                            Title = "funkcja 2"
                        }
                    }
                });

            //System.Windows.MessageBox.Show("button zadziałał");
        }
        bool StartStopCommandCanExecute()
        {
            return true;
        }

        DelegateCommand _tloCommand;
        public DelegateCommand TloCommand
        {
             get
             {
                 return _tloCommand ?? (_tloCommand = new DelegateCommand(() =>
                 {
                     //if (BackgroundImg == null)
                     //    BackgroundImg = ResourceHelper.GetImage(this.GetType().Namespace, "rastrigin.png");
                     //else
                     //    BackgroundImg = null;
                 }));
             }
        }

        #endregion Commands
    }
}
