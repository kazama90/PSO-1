using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Infrastruktura.Common.BaseClasses
{
    public class BaseView : UserControl
    {
        public BaseView(BaseVM viewModel)
        {
            Loaded += (s, e) =>
            {
                this.DataContext = viewModel;
            };
            Loaded += InitialLoad;
        }

        void InitialLoad(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as BaseVM;

            if (viewModel != null)
                viewModel.Initialize();

            Loaded -= InitialLoad;
        }
    }   
}
