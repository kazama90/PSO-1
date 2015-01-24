using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Infrastruktura.Common
{
    // http://stackoverflow.com/questions/6145888/how-to-bind-an-enum-to-a-combobox-control-in-wpf
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description of a specific enum value.
        /// </summary>
        public static string Description(this Enum value)
        {
            var nAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (!nAttributes.Any())
            {
                // If no description is found, best guess is to generate it by replacing underscores with spaces
                // and title case it. You can change this to however you want to handle enums with no descriptions.
                TextInfo oTI = CultureInfo.CurrentCulture.TextInfo;
                return oTI.ToTitleCase(oTI.ToLower(value.ToString().Replace("_", " ")));
            }

            return (nAttributes.First() as DescriptionAttribute).Description;
        }

        public static string GetImageUri(this Enum value)
        {
            var nAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(MathFuncDescAttribute), false);

            if (!nAttributes.Any())
            {
                throw new ArgumentException("Enumeracja, dla której ma zostać pobrany URI obrazu musi być opisana atrybutem MathFuncDescAttribute");
            }

            return (nAttributes.First(x=>x.GetType() == typeof(MathFuncDescAttribute)) as MathFuncDescAttribute).ImageUri;
        }

        /// <summary>
        /// Returns an enumerable collection of all values and descriptions for an enum type.
        /// </summary>
        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
        }
    }
}
