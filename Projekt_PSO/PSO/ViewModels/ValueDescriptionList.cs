using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSO.Interfaces;

namespace PSO.ViewModels
{
    public class ValueDescriptionList<T> : List<ValueDescription<T>>, IValueDescriptionList<T> where T : struct
    {

    }
}
