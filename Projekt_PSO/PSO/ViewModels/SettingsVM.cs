using Infrastruktura.Common;
using Infrastruktura.Common.BaseClasses;
using Infrastruktura.Events;
using Infrastruktura.Events.Payloads;
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
using PSO.Services;
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

        AlgorithmSettings _settings;
        public AlgorithmSettings Settings
        {
            get { return _settings ?? (_settings = new AlgorithmSettings()); }
        }

        #endregion Properties

        #region Event handlers



        #endregion Event handlers

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

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

        public override void RefreshView()
        {
            StartStopCommand.RaiseCanExecuteChanged();
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
            EventAggregator.GetEvent<GeneratePlotEvent>().Publish(null);

            PSOService psoService = new PSOService();
            psoService.RunAsync(new AsyncPsoPayload(this.Settings,
                (List<DataPoint> param) =>
                {
                    EventAggregator.GetEvent<GeneratePlotEvent>().Publish(
                        new GeneratePlotPayload
                        {
                            Title = "Wykres zbieżności",
                            LineSeries = new List<LineSeries>
                            {
                                new LineSeries
                                {
                                    Title = EnumHelper.Description(MathFunction),
                                    ItemsSource = param
                                }
                            }
                        });
                },
                () =>
                {
                    EventAggregator.GetEvent<AsyncOperationEvent>().Publish(new AsyncOperationPayload { OperationState = AsyncOperationState.Stopped });
                }));

            EventAggregator.GetEvent<AsyncOperationEvent>().Publish(new AsyncOperationPayload { OperationState = AsyncOperationState.Started });
        }
        bool StartStopCommandCanExecute()
        {
            return !IsBusy;
        }

        #endregion Commands
    }
}
