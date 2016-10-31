using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class AdaptadorAtacadoSaída : AdaptadorAtacado
    {
        public AdaptadorAtacadoSaída(ParserXmlAtacado parser) : base(parser)
        {
        }

        public override DocumentoFiscal Transformar()
        {
            DocumentoFiscal entidade = new SaídaFiscal((int) TipoDocumentoSistema.NFe,
                parser.LerDataEmissão(),
                parser.LerDataEntradaSaída(),
                parser.LerId(),
                parser.LerValorTotal(),
                parser.LerNNF(),
                parser.LerCNPJEmitente(),
                false,
                "",
                (uint) SetorSistema.Atacado,
                TransformarItens());

            return entidade;
        }

        protected override List<ItemFiscal> TransformarItens()
        {
            List<ItemFiscal> itens = new List<ItemFiscal>(parser.QuantidadeVendaItem);

            for (int x = 1; x <= parser.QuantidadeVendaItem; x++)
                itens.Add(new SaídaItemFiscal(parser.ObterReferência(x),
                    parser.ObterDescrição(x),
                    parser.ObterCFOP(x),
                    (int) parser.ObterTipoUnidade(x),
                    parser.ObterQuantidadeItens(x),
                    parser.ObterValorUnitario(x),
                    parser.ObterValor(x)
                    ));

            return itens;
        }
    }
}
