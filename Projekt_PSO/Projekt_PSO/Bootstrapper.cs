using Infrastruktura.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Regions;
using Infrastruktura;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Infrastruktura.Views;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using PSO.ViewModels;

namespace Projekt_PSO
{
    public class Bootstrapper : BaseBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterInstance<IEventAggregator>("PSO", new EventAggregator());
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            IRegionManager regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(Infrastruktura.Constants.RegionNames.MainRegion, typeof(TwoPanelRegion));

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Title = "Implementacja algorytmu PSO";
            App.Current.MainWindow.Show();
        }

    }
}
