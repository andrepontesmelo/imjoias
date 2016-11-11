using Entidades.Fiscal.Produção;
using Entidades.Fiscal.Registro;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Inventário : RegistroAbstrato
    {
        private double valor;
        private double valortotal;
        private decimal quantidade;

        public Inventário()
        {
        }

        
        public double ValorUnitário => valor;
        public double ValorTotal => valortotal;
        public string ValorFormatado => FormatarMoeda(valor);
        public string ValorTotalFormatado => FormatarMoeda(valortotal);
        public decimal Quantidade => quantidade;

        public static List<Inventário> Obter(DateTime? dataLimite)
        {
            return Mapear<Inventário>(string.Format("call inventario({0})", 
                dataLimite == null ? "NOW()" : DbTransformar(dataLimite.Value)));
        }

        public ItemProduçãoFiscal ObterItemProdução()
        {
            return new ItemProduçãoFiscal(Referência, Math.Abs(Quantidade));
        }
    }
}
