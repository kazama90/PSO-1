using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Common
{
    public class MathFuncDescAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Atrybut określający opis oraz ściężkę do obrazu
        /// </summary>
        /// <param name="description">Opis wyliczenia</param>
        /// <param name="imageUri">Nazwa pliku graficznego</param>
        public MathFuncDescAttribute(string description, string imageUri)
            : base(description)
        {
            _imageUri = imageUri;
        }

        private string _imageUri;
        public string ImageUri
        {
            get { return _imageUri; }
        }
    }
}
