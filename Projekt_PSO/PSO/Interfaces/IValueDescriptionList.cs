using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSO.ViewModels;

namespace PSO.Interfaces
{
    public interface IValueDescriptionList<T> : IList<ValueDescription<T>> where T : struct
    {

    }
}
