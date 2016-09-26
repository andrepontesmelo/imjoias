using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public abstract class AdaptadorAtacado : ITransformavelDocumentoFiscal
    {
        protected ParserXmlAtacado parser;

        public AdaptadorAtacado(ParserXmlAtacado parser)
        {
            this.parser = parser;
        }

        public abstract DocumentoFiscal Transformar();

        protected abstract List<ItemFiscal> TransformarItens();
    }
}
