using Infrastruktura.Common;
using Infrastruktura.Common.BaseClasses;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using OxyPlot;
using OxyPlot.Series;
using PSO.Constants;
using PSO.Events;
using PSO.Events.Payloads;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PSO.ViewModels
{
    public class PlotVM : BaseVM
    {
        #region Ctor

        public PlotVM(IUnityContainer container, IEventAggregator eventAggregator)
            : base(container, eventAggregator)
        {
        }

        #endregion Ctor

        #region Properties

        PlotModel _convergencePlot;
        public PlotModel ConvergencePlot
        {
            get { return _convergencePlot; }
            set
            {
                _convergencePlot = value;
                RaisePropertyChanged();
                RefreshView();
            }
        }

        #endregion Properties

        #region Event handlers

        private void GeneratePlotEventHandler(GeneratePlotPayload obj)
        {
            if (obj == null)
                ConvergencePlot = null;
            else
                GeneratePlot(obj.Title, obj.LineSeries);
        }

        #endregion Event handlers

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            this.EventAggregator.GetEvent<GeneratePlotEvent>().Subscribe(GeneratePlotEventHandler);

            var tab = this.Ribbon.GetOrCreateTab(RibbonNames.ControlTab, "Sterowanie PSO");
            var group = tab.GetOrCreateGroup(RibbonNames.PlotsGroup, "Wykresy");
            group.AddControl(new RibbonButton
            {
                Name = RibbonNames.PlotButton,
                Label = "Wyczyść",
                LargeImageSource = ResourceHelper.GetImage(this.GetType().Namespace, "delete.png"),
                Command = ClearPlotCommand
            });
        }

        public override void RefreshView()
        {
            base.RefreshView();

            ClearPlotCommand.RaiseCanExecuteChanged();
        }

        private void GeneratePlot(string title, List<LineSeries> lineSeries)
        {
            if (ConvergencePlot == null)
            {
                ConvergencePlot = new PlotModel();
                ConvergencePlot.Title = title;
            }

            foreach (var serie in lineSeries)
            {
                if (ConvergencePlot.Series.FirstOrDefault(x => x.Title == serie.Title) == null)
                {
                    this.ConvergencePlot.Series.Add(serie);
                }
                else
                {
                    var lineSeriesItemsSource = (this.ConvergencePlot.Series.First(x => x.Title == serie.Title) as LineSeries).ItemsSource;

                    (lineSeriesItemsSource as List<DataPoint>).AddRange(serie.ItemsSource as List<DataPoint>);
                }

                this.ConvergencePlot.InvalidatePlot(true);
            }
        }

        #endregion Methods

        #region Commands


        DelegateCommand _clearPlotCommand;
        public DelegateCommand ClearPlotCommand
        {
            get
            {
                return _clearPlotCommand
                    ?? (_clearPlotCommand = new DelegateCommand(ClearPlotCommandExecute, ClearPlotCommandCanExecute));
            }
        }
        void ClearPlotCommandExecute()
        {
            ConvergencePlot = null;
        }
        bool ClearPlotCommandCanExecute()
        {
            return ConvergencePlot != null && !IsBusy;
        }

        #endregion Commands
    }
}