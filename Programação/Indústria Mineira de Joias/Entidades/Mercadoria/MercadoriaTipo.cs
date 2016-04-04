using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Mercadoria
{
    public class MercadoriaTipo : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private string código;

        private string tipo;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public string Tipo { get { return tipo; } set { tipo = value; } }
        public string Código { get { return código; } }

        public static MercadoriaTipo[] ObterTipos()
        {
            return Mapear<MercadoriaTipo>("SELECT * FROM mercadoriatipo ORDER BY tipo").ToArray();
        }

        public override string ToString()
        {
            return tipo;
        }
    }
}
