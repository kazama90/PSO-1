using Infrastruktura.Common.BaseClasses;
using Infrastruktura.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Ribbon
{
    public class RibbonTabGroupVM : BaseVM, IRibbonTabGroup
    {
        #region Ctor

        public RibbonTabGroupVM(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.GlobalEventAggregator = eventAggregator;
            this.Container = container;
        }

        #endregion Ctor

        #region Properties

        bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible == value)
                    return;
                _isVisible = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<IRibbonTab> _tabs;
        public ObservableCollection<IRibbonTab> Tabs
        {
            get { return _tabs ?? (_tabs = new ObservableCollection<IRibbonTab>()); }
        }

        #endregion Properties

        #region Methods

        public IRibbonTab GetOrCreateTab(string header)
        {
            if (header == null)
                throw new ArgumentNullException("Nie można dodać zakładki do ribbona bez określania jej nagłówka");

            // sprawdzenie, czy zakładka już istnieje
            var tab = Tabs.FirstOrDefault(x => x.ContextualTabGroupHeader == header);
            if (tab != null)
                return tab;

            // stworzenie obiektu zakładki i dodanie do kolekcji
            tab = this.Container.Resolve<IRibbonTab>();
            tab.ContextualTabGroupHeader = header;
            tab.Header = header;
            //tab = new RibbonTabVM(this.Container, this.EventAggregator) { Header = header };
            _tabs.Add(tab);

            // zwrócenie dodanego obiektu
            return tab;
        }

        #endregion Methods
    }
}