using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Mercadoria
{
    public class Metal : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private string código;

        private string metal;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public string Nome { get { return metal; } set { metal = value; } }
        public string Código { get { return código; } }

        public static Metal[] ObterMetais()
        {
            return Mapear<Metal>("SELECT * FROM metal ORDER BY metal").ToArray();
        }

        public override string ToString()
        {
            return metal;
        }
    }
}
