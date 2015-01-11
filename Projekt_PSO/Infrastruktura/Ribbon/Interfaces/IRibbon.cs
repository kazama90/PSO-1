using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace Infrastruktura.Interfaces
{
    public interface IRibbon
    {
        /// <summary>
        /// Zwraca lub dodaje nową zakładkę
        /// </summary>
        /// <param name="name">Nazwa identyfikująca zakładkę</param>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt zakładki</returns>
        IRibbonTab GetOrCreateTab(string name, string header);

        /// <summary>
        /// Pobiera zakładkę o wskazanej nazwie
        /// </summary>
        /// <param name="name">Nazwa identyfikująca zakładkę</param>
        /// <returns>Jeśli odnaleziono zakładkę, to jej obiekt lub null w przeciwnym przypadku</returns>
        IRibbonTab GetOrCreateTab(string name);

        /// <summary>
        /// Zwraca lub dodaje kontekstową zakładkę
        /// </summary>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt zakładki kontekstowej</returns>
        [Obsolete("Jak na razie nie działa...", true)]
        IRibbonTabGroup GetOrCreateContextualTabGroup(string header);

        /// <summary>
        /// Szuka elementu (buttona, itp.) o wskazanej nazwie
        /// </summary>
        /// <param name="name">Nazwa elementu</param>
        /// <returns>Jeśli odnaleziono element, to jego obiekt lub null w przeciwnym przypadku</returns>
        ContentControl GetElement(string name);
    }
}
