using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Infrastruktura.Interfaces
{
    interface IRibbonGroup
    {
        ContentControl AddControl(ContentControl control);
    }
}
