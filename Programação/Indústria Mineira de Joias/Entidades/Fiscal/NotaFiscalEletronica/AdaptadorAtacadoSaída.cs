using Entidades.Fiscal.NotaFiscalEletronica.Parser;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class AdaptadorAtacadoSaída : AdaptadorAtacado
    {
        private Dictionary<uint, long> hashNfeVenda;

        public AdaptadorAtacadoSaída(ParserXmlAtacado parser) : this(parser, null)
        {
        }

        public AdaptadorAtacadoSaída(ParserXmlAtacado parser, Dictionary<uint, long> hashNfeVenda) : base(parser)
        {
            this.hashNfeVenda = hashNfeVenda;
        }

        public override DocumentoFiscal Transformar()
        {
            DocumentoFiscal entidade = new SaídaFiscal((int) TipoDocumentoSistema.NFe,
                parser.LerDataEmissão(),
                parser.LerDataEntradaSaída(),
                parser.LerId(),
                parser.LerValorTotal(),
                parser.LerValorDesconto(),
                parser.LerValorTotal(),
                parser.LerNNF(),
                parser.LerCNPJEmitente(),
                parser.LerCPFEmissor(),
                parser.LerCNPJEmissor(),
                false,
                "",
                (uint) SetorSistema.Atacado,
                null,
                ObterCódigoVenda((uint) parser.LerNNF()),
                TransformarItens());

            return entidade;
        }

        private int? ObterCódigoVenda(uint nfe)
        {
            long venda;
            if (hashNfeVenda == null || !hashNfeVenda.TryGetValue(nfe, out venda))
                return null;

            return (int) venda;
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

