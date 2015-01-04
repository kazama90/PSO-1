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

        public RibbonTabVM()
            : base(null, null)
        {

        }

        #endregion Ctor

        #region Properties

        ObservableCollection<RibbonGroupVM> _groups;
        public ObservableCollection<RibbonGroupVM> Groups
        {
            get { return _groups ?? (_groups = new ObservableCollection<RibbonGroupVM>()); }
        }

        #endregion Properties

        #region Methods

        public RibbonGroupVM GetOrCreateGroup(string header)
        {
            var group = Groups.FirstOrDefault(x => x.Header == header);
            if (group != null)
                return group;

            group = new RibbonGroupVM { Header = header };
            _groups.Add(group);

            return group;
        }

        #endregion Methods
    }
}
