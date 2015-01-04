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
        /// Zwraca zakładkę, dodając ją, jeśli nie istniała.
        /// </summary>
        /// <param name="header">Nagłówek zakładki</param>
        /// <returns>Obiekt dodanej lub istniejącej zakładki</returns>
        RibbonTabVM GetOrCreateTab(string header);
    }
}
