using Entidades.Fiscal.Fabricação;
using Entidades.Fiscal.Registro;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Inventário : RegistroAbstrato
    {
        private decimal valor;
        private decimal  valortotal;
        private decimal quantidade;

        public Inventário()
        {
        }

        
        public decimal ValorUnitário => valor;
        public decimal ValorTotal => valortotal;
        public string ValorFormatado => FormatarMoeda(valor);
        public string ValorTotalFormatado => FormatarMoeda(valortotal);
        public decimal Quantidade => quantidade;

        public static List<Inventário> Obter(Fechamento fechamento)
        {
            fechamento.AtualizarMercadoriasSeAberto();

            var sql = string.Format("  select c.* from(select @d1:= {0} p) parm, ( " +
            " SELECT f.referencia, " +
            " SUM(IFNULL(`i`.`quantidade`, 0)) AS `quantidade`, " +
            " descricao, classificacaofiscal,tipounidade,f.valor, " +
            " (SUM(IFNULL(`i`.`quantidade`, 0)) * f.valor) AS `valortotal` " +
            " FROM " +
            " mercadoriafechamento f " +
            " LEFT JOIN `imjoias`.`inventario_interno_parcial` `i` ON((`i`.`referencia` = `f`.`referencia`)) " +
            " LEFT JOIN mercadoria m on f.referencia = m.referencia " +
            " where f.fechamento = {1} " +
            " GROUP BY `m`.`referencia`) c ",
            DbTransformar(fechamento.Fim.AddDays(1)),
            fechamento.Código);

            return Mapear<Inventário>(sql);
        }

        public ItemFabricaçãoFiscal ObterItemfabricação(int fechamento)
        {
            var hashReferênciaValor = MercadoriaFechamento.ObterHash(fechamento);
            return new ItemFabricaçãoFiscal(Referência, Math.Abs(Quantidade), hashReferênciaValor[Referência].Valor, 0);
        }
    }
}
