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
            List<VendaItemFiscal> itens = new List<VendaItemFiscal>();

            VendaFiscal entidade = new VendaFiscal(TipoVenda.NFe, 
                parser.LerDataEmissão(), 
                parser.LerId(),
                itens);

            return entidade;
        }
    }
}
