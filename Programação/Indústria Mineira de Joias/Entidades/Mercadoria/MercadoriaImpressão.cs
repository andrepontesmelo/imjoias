using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Mercadoria
{
    public class MercadoriaImpressão : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbColuna("referencia")]
        private string referência;
        private double peso;
        private double coeficiente;
        private bool depeso;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public string Referência { get { return referência; } }
        public double Peso { get { return peso; } }
        public double Índice {
            get
            {
                if (DePeso)
                    return Coeficiente * Peso;
                else
                    return Coeficiente;
            }
        }

        public double Coeficiente { get { return coeficiente; } }
        public bool DePeso { get { return depeso; } }

        public static List<MercadoriaImpressão> ObterMercadorias(Tabela tabela)
        {
            string cmd = "select referencia, peso, depeso, coeficiente from mercadoria, "
            + " tabelamercadoria where mercadoria.referencia=tabelamercadoria.mercadoria "
            + " and tabela= " + DbTransformar(tabela.Código);

            return Mapear<MercadoriaImpressão>(cmd);
        }
    }
}
