using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.ViewModels
{
    public class ValueDescription<T> where T : struct
    {
        public ValueDescription()
        {
        }

        public ValueDescription(T value, string description)
        {
            Value = value;
            Description = description;
        }
        public T Value { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
}
