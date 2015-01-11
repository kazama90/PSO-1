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
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace Infrastruktura.Ribbon
{
    public class RibbonGroupVM : BaseVM, IRibbonGroup
    {
        #region Ctor

        public RibbonGroupVM(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this.GlobalEventAggregator = eventAggregator;
            this.Container = container;
        }

        #endregion Ctor

        #region Properties

        ObservableCollection<ContentControl> _controls;
        public ObservableCollection<ContentControl> Controls
        {
            get { return _controls ?? (_controls = new ObservableCollection<ContentControl>()); }
        }

        public string Name { get; set; }

        #endregion Properties

        #region Methods

        public ContentControl AddControl(ContentControl control)
        {
            var newControl = Controls.FirstOrDefault(x => x == control);
            if (newControl != null)
                return newControl;

            _controls.Add(control);
            return control;
        }

        #endregion Methods
    }
}
