using Infrastruktura.Common.BaseClasses;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;

namespace PSO.ViewModels
{
    public class SettingsVM : BaseVM
    {
        public SettingsVM(IUnityContainer container, IEventAggregator eventAggregator)
            : base(container, eventAggregator)
        {
            this.EventAggregator = container.Resolve<IEventAggregator>("PSO");
        }

        protected override void Initialize()
        {
            var tab = this.Ribbon.GetOrCreateTab("settingsTab");
            var group = tab.GetOrCreateGroup("settingsGroup");
            group.AddControl(new RibbonButton
            {
                Label = "xyz",
                Command = StartStopCommand
            });

            //var contextualTab = this.Ribbon.GetOrCreateContextualTabGroup("contextualSettingsTabGroup");
            //var tab2 = this.Ribbon.GetOrCreateTab("contextualSettingsTab");
            //tab2.ContextualTabGroupHeader = "contextualSettingsTabGroup";
            //var group2 = tab2.GetOrCreateGroup("contextualSettingsGroup");
            //group2.AddControl(new RibbonButton
            //{
            //    Label = "contextualXyz2",
            //    Command = StartStopCommand
            //});
            //contextualTab.IsVisible = true;
        }

        #region Commands

        ICommand _startStopCommand;
        public ICommand StartStopCommand
        {
            get
            {
                return _startStopCommand
                    ?? (_startStopCommand = new DelegateCommand(StartStopCommandExecute, StartStopCommandCanExecute));
            }
        }
        void StartStopCommandExecute()
        {
            System.Windows.MessageBox.Show("button zadziałał");
        }
        bool StartStopCommandCanExecute()
        {
            return true;
        }

        #endregion Commands
    }
}
