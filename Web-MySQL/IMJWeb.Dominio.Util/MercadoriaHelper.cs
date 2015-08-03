using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio.Util
{
    public static class MercadoriaHelper
    {
        public static string FormatarIndice(decimal? indice)
        {
            return indice.HasValue ? string.Format("{0:0.00}", indice.Value) : "indisponível";
        }

        public static string FormatarPeso(decimal? peso)
        {
            if (!peso.HasValue)
                return null;

            else if (peso.Value > 1000)
            {
                peso /= 1000;
                return peso.Value.ToString("0") + " kg e " + peso.Value.ToString("0.00") + " g";
            }
            else
                return peso.Value.ToString("0.00") + " g";
        }
    }
}
