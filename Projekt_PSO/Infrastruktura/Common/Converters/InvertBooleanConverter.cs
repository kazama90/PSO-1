using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Infrastruktura.Common.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(bool) || targetType == typeof(bool?))
                return !(bool)value;

            throw new InvalidOperationException("Typ do którego konwerujemy może być tylko typu boolean");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(bool) || targetType == typeof(bool?))
                return !(bool)value;

            throw new InvalidOperationException("Typ do którego konwerujemy może być tylko typu boolean");
        }
    }
}
