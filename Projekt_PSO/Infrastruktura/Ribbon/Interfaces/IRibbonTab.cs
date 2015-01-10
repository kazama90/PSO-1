using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Interfaces
{
    public interface IRibbonTab
    {
        /// <summary>
        /// Nagłówek zakładki
        /// </summary>
        string Header { get; set; }
        string ContextualTabGroupHeader { get; set; }
        /// <summary>
        /// Zwraca lub dodaje nową grupę
        /// </summary>
        /// <param name="header">Nagłówek grupy</param>
        /// <returns>Obiekt dodanej lub istniejącej grupy</returns>
        IRibbonGroup GetOrCreateGroup(string header);
    }
}
