using Infrastruktura.Interfaces;
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
            this.GlobalEventAggregator = eventAggregator;
            this.Container = container;
            this.Ribbon = container.Resolve<IRibbon>();

            Initialize();
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

        protected IUnityContainer Container { get; set; }

        protected IEventAggregator GlobalEventAggregator { get; set; }

        protected IEventAggregator EventAggregator { get; set; }

        protected IRibbon Ribbon { get; set; }

        #endregion Properties

        #region Methods

        protected virtual void Initialize() { }

        #endregion Methods
    }
}
