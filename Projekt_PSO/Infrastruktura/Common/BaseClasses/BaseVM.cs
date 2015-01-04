using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Common.BaseClasses
{
    public class BaseVM : PropertyChangedImplementation
    {
        #region Ctor

        public BaseVM(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
            this.Container = container;
        }

        public BaseVM()
        {
        }

        #endregion Ctor

        #region Properties

        string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                if (_header == value)
                    return;

                _header = value;
                RaisePropertyChanged();
            }
        }

        protected IEventAggregator EventAggregator { get; set; }

        protected IUnityContainer Container { get; set; }

        #endregion Properties
    }
}
