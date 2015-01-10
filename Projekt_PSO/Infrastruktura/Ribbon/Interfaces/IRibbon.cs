using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;

namespace Infrastruktura.Interfaces
{
    public interface IRibbon
    {
        /// <summary>
        /// Zwraca lub dodaje nową zakładkę
        /// </summary>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt dodanej lub istniejącej zakładki</returns>
        IRibbonTab GetOrCreateTab(string header);

        /// <summary>
        /// Zwraca lub dodaje kontekstową zakładkę
        /// </summary>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt dodanej lub istniejącej zakładki kontekstowej</returns>
        [Obsolete("Jak na razie nie działa...", true)]
        IRibbonTabGroup GetOrCreateContextualTabGroup(string header);
    }
}
