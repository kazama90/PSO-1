using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Interfaces
{
    public interface IRibbonTab
    {
        RibbonGroupVM GetOrCreateGroup(string header);
    }
}
