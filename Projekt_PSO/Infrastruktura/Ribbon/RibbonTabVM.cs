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

        #endregion Properties

        #region Methods

        public IRibbonGroup GetOrCreateGroup(string header)
        {
            var group = Groups.FirstOrDefault(x => x.Header == header);
            if (group != null)
                return group;

            group = this.Container.Resolve<RibbonGroupVM>();
            group.Header = header;
            //group = new RibbonGroupVM { Header = header };
            _groups.Add(group);

            return group;
        }

        #endregion Methods
    }
}
