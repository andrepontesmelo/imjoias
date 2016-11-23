using Entidades.Fiscal.Fabricação;
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
            var sql = string.Format("select i.* from (select @d1 := {0} p) parm, inventario_parcial i ",
                dataLimite == null ? "NOW()" : DbTransformar(dataLimite.Value.AddDays(1)));

            return Mapear<Inventário>(sql);
        }

        public ItemFabricaçãoFiscal ObterItemfabricação()
        {
            return new ItemFabricaçãoFiscal(Referência, Math.Abs(Quantidade));
        }
    }
}
