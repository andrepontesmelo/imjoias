﻿namespace Entidades.Fiscal.NotaFiscalEletronica
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
                parser.LerCancelamento());

            return entidade;
        }
    }
}
