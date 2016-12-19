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

            var sql = string.Format(" select f.referencia, sum(i.quantidade) as quantidade, descricao, classificacaofiscal, tipounidade, " +
                " f.valor, (SUM(i.quantidade) * f.valor) AS valortotal from mercadoriafechamento f " +
                " left join extratoinventario i on i.referencia = f.referencia and f.fechamento = {0} " +
                " left join mercadoria m on f.referencia = m.referencia " +
                " where i.data < {1} " + 
                " group by f.referencia having quantidade != 0 ",
                fechamento.Código,
                DbTransformar(fechamento.Fim.AddDays(1)));

            return Mapear<Inventário>(sql);
        }

        public SaídaFabricaçãoFiscal ObterItemfabricação(int fechamento)
        {
            var hashReferênciaMercadoriaFechamento = MercadoriaFechamento.ObterHash(fechamento);
            var mercadoriaFechamento = hashReferênciaMercadoriaFechamento[Referência];
            return new SaídaFabricaçãoFiscal(Referência, Math.Abs(Quantidade), mercadoriaFechamento.Valor, 0, mercadoriaFechamento.Peso);
        }
    }
}
