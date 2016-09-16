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

        public VendaFiscal Transformar()
        {
            VendaFiscal entidade = new VendaFiscal(TipoVenda.NFe,
                parser.LerDataEmissão(),
                parser.LerId(),
                parser.LerValorTotal(),
                0,
                TransformarItens());

            return entidade;
        }

        private List<VendaItemFiscal> TransformarItens()
        {
            List<VendaItemFiscal> itens = new List<VendaItemFiscal>(parser.QuantidadeVendaItem);

            for (int x = 1; x <= parser.QuantidadeVendaItem; x++)
                itens.Add(new VendaItemFiscal(parser.ObterReferência(x), 
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
