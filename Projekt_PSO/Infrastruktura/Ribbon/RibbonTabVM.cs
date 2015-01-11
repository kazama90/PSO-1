using Infrastruktura.Common.BaseClasses;
using Infrastruktura.Interfaces;
using Infrastruktura.Ribbon;
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
    public class RibbonTabVM : BaseVM, IRibbonTab
    {
        #region Ctor

        public RibbonTabVM(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.GlobalEventAggregator = eventAggregator;
            this.Container = container;
        }

        #endregion Ctor

        #region Properties

        string _contextualTabGroupHeader;
        public string ContextualTabGroupHeader
        {
            get { return _contextualTabGroupHeader; }
            set
            {
                _contextualTabGroupHeader = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<RibbonGroupVM> _groups;
        public ObservableCollection<RibbonGroupVM> Groups
        {
            get { return _groups ?? (_groups = new ObservableCollection<RibbonGroupVM>()); }
        }

        public string Name { get; set; }

        #endregion Properties

        #region Methods

        public IRibbonGroup GetOrCreateGroup(string name, string header)
        {
            return GetOrCreateGroup(name, header, false);
        }

        private IRibbonGroup GetOrCreateGroup(string name, string header, bool findOnly)
        {
            var group = Groups.FirstOrDefault(x => x.Name == name);
            if (group != null)
                return group;

            if (findOnly)
                return null;

            group = this.Container.Resolve<RibbonGroupVM>();
            group.Header = header;
            group.Name = name;
            _groups.Add(group);

            return group;
        }

        public IRibbonGroup GetOrCreateGroup(string name)
        {
            return this.GetOrCreateGroup(name, null, true);
        }

        #endregion Methods
    }
}
