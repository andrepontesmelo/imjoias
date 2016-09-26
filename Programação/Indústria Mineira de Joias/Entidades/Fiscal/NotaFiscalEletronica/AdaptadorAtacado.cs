using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class AdaptadorAtacado : ITransformavelVendaFiscal
    {
        ParserXmlAtacado parser;

        public AdaptadorAtacado(ParserXmlAtacado parser)
        {
            this.parser = parser;
        }

        public SaidaFiscal Transformar()
        {
            SaidaFiscal entidade = new SaidaFiscal(TipoSaída.NFe,
                parser.LerDataEmissão(),
                parser.LerId(),
                parser.LerValorTotal(),
                parser.LerNNF(),
                null,
                null,
                parser.LerCNPJEmitente(),
                TransformarItens());

            return entidade;
        }

        private List<SaidaItemFiscal> TransformarItens()
        {
            List<SaidaItemFiscal> itens = new List<SaidaItemFiscal>(parser.QuantidadeVendaItem);

            for (int x = 1; x <= parser.QuantidadeVendaItem; x++)
                itens.Add(new SaidaItemFiscal(parser.ObterReferência(x), 
                    parser.ObterDescrição(x),
                    parser.ObterCFOP(x),
                    parser.ObterTipoUnidade(x),
                    parser.ObterQuantidadeItens(x),
                    parser.ObterValorUnitario(x),
                    parser.ObterValor(x)
                    ));

            return itens;
        }
    }
}
