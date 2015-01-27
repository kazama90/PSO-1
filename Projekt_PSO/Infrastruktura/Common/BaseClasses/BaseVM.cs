using Infrastruktura.Events;
using Infrastruktura.Events.Payloads;
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

            var stringNamespace = this.GetType().Namespace;
            var topNamespace = stringNamespace.Substring(0, stringNamespace.IndexOf("."));

            if (container != null)
            {
                this.Ribbon = container.Resolve<IRibbon>();
                this.EventAggregator = container.Resolve<IEventAggregator>(topNamespace);
            }
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

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        protected IUnityContainer Container { get; set; }

        protected IEventAggregator GlobalEventAggregator { get; set; }

        protected IEventAggregator EventAggregator { get; set; }

        protected IRibbon Ribbon { get; set; }

        #endregion Properties

        #region Methods

        public virtual void Initialize()
        {
            this.EventAggregator.GetEvent<AsyncOperationEvent>().Subscribe(OnAsyncOperationEventHandler, ThreadOption.PublisherThread);
        }

        public virtual void ClosingView()
        {
            this.EventAggregator.GetEvent<AsyncOperationEvent>().Unsubscribe(OnAsyncOperationEventHandler);
        }

        public virtual void RefreshView() { }

        private void OnAsyncOperationEventHandler(AsyncOperationPayload payload)
        {
            if (payload.OperationState == AsyncOperationState.Started)
                IsBusy = true;
            else
                IsBusy = false;

            this.RefreshView();
        }

        #endregion Methods
    }
}
