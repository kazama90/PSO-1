using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Constants;
using PSO.Views;
using Infrastruktura.Interfaces;
using System.Windows.Controls.Ribbon;

namespace PSO.ModuleDefinitions
{
    public class Module : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public Module(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.LeftPanelContent, typeof(SettingsView));
            _regionManager.RegisterViewWithRegion(RegionNames.RightPanelContent, typeof(PlotView));

            // inicjalizacja przycisków na ribbonie
            var ribbonViewModel = _container.Resolve<IRibbon>();
            var tab = ribbonViewModel.GetOrCreateTab("taka tam zakładka");
            var group = tab.GetOrCreateGroup("taka tam grupa");
            group.AddControl(new RibbonButton
            {
                Label = "taki tam button"
            });
        }
    }
}
