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

        /// <summary>
        /// Nagłówek grupy kontekstowych zakładek, o ile przynależy do takiej
        /// </summary>
        string ContextualTabGroupHeader { get; set; }

        /// <summary>
        /// Zwraca lub dodaje nową grupę
        /// </summary>
        /// <param name="name">Nazwa identyfikująca grupę</param>
        /// <param name="header">Nagłówek grupy</param>
        /// <returns>Obiekt grupy</returns>
        IRibbonGroup GetOrCreateGroup(string name, string header);

        /// <summary>
        /// Pobiera grupę o wskazanej nazwie
        /// </summary>
        /// <param name="name">Nazwa identyfikująca grupę</param>
        /// <returns>Jeśli odnaleziono grupę, to jej obiekt lub null w przeciwnym przypadku</returns>
        IRibbonGroup GetOrCreateGroup(string name);
    }
}
