using Infrastruktura.Common;
using Infrastruktura.Common.BaseClasses;
using Infrastruktura.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Ribbon
{
    public class RibbonVM : BaseVM, IRibbon
    {
        ObservableCollection<RibbonTabVM> _tabs;
        public ObservableCollection<RibbonTabVM> Tabs
        {
            get { return _tabs ?? (_tabs = new ObservableCollection<RibbonTabVM>()); }
        }

        public RibbonVM()
            : base(null, null)
        {
        }

        public RibbonTabVM GetOrCreateTab(string header)
        {
            if (header == null)
                throw new ArgumentNullException("Nie można dodać zakładki do ribbona bez określania jej nagłówka");

            // sprawdzenie, czy zakładka już istnieje
            var tab = Tabs.FirstOrDefault(x => x.Header == header);
            if (tab != null)
                return tab;

            // stworzenie obiektu zakładki i dodanie do kolekcji
            tab = new RibbonTabVM() { Header = header };
            Tabs.Add(tab);

            // zwrócenie dodanego obiektu
            return tab;
        }

        public void AddButton(System.Windows.Controls.Ribbon.RibbonButton button)
        {
            throw new NotImplementedException();
        }
    }
}
