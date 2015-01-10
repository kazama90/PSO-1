using Infrastruktura.Common.BaseClasses;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.ViewModels
{
    public class PlotVM : BaseVM
    {
        public PlotVM(IUnityContainer container, IEventAggregator eventAggregator)
            : base(container, eventAggregator)
        {
            this.EventAggregator = container.Resolve<IEventAggregator>("PSO");
        }
    }
}
