using Infrastruktura.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Infrastruktura.Regions
{
    /// <summary>
    /// Interaction logic for RibbonRegion.xaml
    /// </summary>
    public partial class RibbonRegion : UserControl
    {
        public RibbonRegion(IUnityContainer container)
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.DataContext = container.Resolve<IRibbon>();
                int i = 0;
                i++;
            };
        }
    }
}
