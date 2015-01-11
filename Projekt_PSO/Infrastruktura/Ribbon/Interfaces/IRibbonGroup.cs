using Infrastruktura.Ribbon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Infrastruktura.Interfaces
{
    public interface IRibbonGroup
    {
        /// <summary>
        /// Nagłówek grupy
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Dodaje kontrolkę do grupy
        /// </summary>
        /// <param name="control">Kontrolka dodawana do grupy</param>
        /// <returns>Dodaną kontrolkę</returns>
        ContentControl AddControl(ContentControl control);
    }
}
