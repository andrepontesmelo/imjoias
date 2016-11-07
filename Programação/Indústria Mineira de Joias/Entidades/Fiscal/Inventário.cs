using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Inventário : DbManipulaçãoSimples
    {
        private string referencia;
        private decimal quantidade;
        private string nome;
        private string classificacaofiscal;
        private int tipounidade;
        private double valor;
        private double valortotal;

        public Inventário()
        {
        }

        public string Referência => referencia;
        public decimal Quantidade => quantidade;
        public string Descrição => nome;
        public string ClassificaçãoFiscal => classificacaofiscal;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);
        public string ValorFormatado => valor.ToString("C");
        public string ValorTotalFormatado => valortotal.ToString("C");

        public static List<Inventário> Obter(DateTime? dataLimite)
        {
            return Mapear<Inventário>(string.Format("call inventario({0})", 
                dataLimite == null ? "NOW()" : DbTransformar(dataLimite.Value)));
        }
    }
}
