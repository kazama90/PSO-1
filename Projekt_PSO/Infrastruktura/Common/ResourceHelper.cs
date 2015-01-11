using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Infrastruktura.Common
{
    public static class ResourceHelper
    {
        /// <summary>
        /// Zwraca obiekt bitmapy z obrazem o podanej nazwie
        /// </summary>
        /// <param name="projNamespace">Przestrzeń nazw projektu</param>
        /// <param name="imgName">Nazwa obrazu</param>
        /// <returns>Obiekt zawierający obraz</returns>
        public static BitmapImage GetImage(string projNamespace, string imgName)
        {
            string uri = string.Format("pack://application:,,,/{0};component/Resources/Images/{1}", projNamespace.Substring(0, projNamespace.IndexOf(".")), imgName);

            return new BitmapImage(new Uri(uri));
        }
    }
}
