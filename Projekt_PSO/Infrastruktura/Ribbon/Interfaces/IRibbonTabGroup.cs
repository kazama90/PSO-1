using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Interfaces
{
    public interface IRibbonTabGroup
    {
        /// <summary>
        /// Nagłówek grupy zakładek
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Określa, czy dana zakładka jest widoczna
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Dodaje zakładkę, o ile nie istniała już w kolekcji
        /// </summary>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt dodanej lub istniejącej zakładki</returns>
        IRibbonTab GetOrCreateTab(string header);
    }
}
