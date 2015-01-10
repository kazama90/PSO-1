using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Views;
using Infrastruktura;
using Microsoft.Practices.Prism.Regions;
using Infrastruktura.Regions;
using Infrastruktura.Interfaces;
using Infrastruktura.Ribbon;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;

namespace Infrastruktura.Common.BaseClasses
{
    public class BaseBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            IRegionManager regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(Constants.RegionNames.RibbonRegion, typeof(RibbonRegion));
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.RegisterType<IRibbon, RibbonVM>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IRibbonTabGroup, RibbonTabGroupVM>();
            this.Container.RegisterType<IRibbonTab, RibbonTabVM>();
            this.Container.RegisterType<IRibbonGroup, RibbonGroupVM>();
        }
    }
}
