using Infrastruktura.Common;
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
    public class RibbonVM : BaseVM, IRibbon
    {
        #region Ctor

        public RibbonVM(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.GlobalEventAggregator = eventAggregator;
            this.Container = container;
        }

        #endregion Ctor

        #region Properties

        ObservableCollection<RibbonTabVM> _tabs;
        public ObservableCollection<RibbonTabVM> Tabs
        {
            get { return _tabs ?? (_tabs = new ObservableCollection<RibbonTabVM>()); }
        }

        ObservableCollection<RibbonTabGroupVM> _contextualTabGroups;
        public ObservableCollection<RibbonTabGroupVM> ContextualTabGroups
        {
            get { return _contextualTabGroups ?? (_contextualTabGroups = new ObservableCollection<RibbonTabGroupVM>()); }
        }

        #endregion Properties

        #region Methods

        public IRibbonTab GetOrCreateTab(string header)
        {
            if (header == null)
                throw new ArgumentNullException("Nie można dodać zakładki do ribbona bez określania jej nagłówka");

            // sprawdzenie, czy zakładka już istnieje
            var tab = Tabs.FirstOrDefault(x => x.Header == header);
            if (tab != null)
                return tab;

            // stworzenie obiektu zakładki i dodanie do kolekcji
            tab = this.Container.Resolve<RibbonTabVM>();
            tab.Header = header;
            //tab = new RibbonTabVM(this.Container, this.EventAggregator) { Header = header };
            Tabs.Add(tab);

            // zwrócenie dodanego obiektu
            return tab;
        }

        [Obsolete("Jak na razie nie działa...", true)]
        public IRibbonTabGroup GetOrCreateContextualTabGroup(string header)
        {
            if (header == null)
                throw new ArgumentNullException("Nie można dodać zakładki do ribbona bez określania jej nagłówka");


            // sprawdzenie, czy zakładka już istnieje
            var tabGroup = ContextualTabGroups.FirstOrDefault(x => x.Header == header);
            if (tabGroup != null)
                return tabGroup;

            // stworzenie obiektu zakładki i dodanie do kolekcji
            tabGroup = this.Container.Resolve<RibbonTabGroupVM>();
            tabGroup.Header = header;
            //tab = new RibbonTabVM() { Header = header };
            ContextualTabGroups.Add(tabGroup);

            // zwrócenie dodanego obiektu
            return tabGroup;
        }

        #endregion Methods
    }
}
