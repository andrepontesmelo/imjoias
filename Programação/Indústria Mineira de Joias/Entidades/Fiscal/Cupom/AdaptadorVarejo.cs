using InterpretadorTDM.Registro;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Cupom
{
    public class AdaptadorVarejo : ITransformavelVendaFiscal
    {
        private CupomFiscal cupom;

        public AdaptadorVarejo(CupomFiscal cupom)
        {
            this.cupom = cupom;
        }

        public SaidaFiscal Transformar()
        {
            SaidaFiscal entidade = new SaidaFiscal(TipoSaída.Cupom, 
                cupom.DataInicioEmissao, 
                AdaptarId(cupom.DataInicioEmissao, 
                cupom.NumeroContadorDocumentoEmitido, 
                cupom.COO),
                cupom.ValorTotalLiquido,
                null,
                cupom.COO,
                cupom.NumeroContadorDocumentoEmitido,
                null,
                AdaptarItens(cupom.Detalhes));
            
            return entidade;
        }

        private List<SaidaItemFiscal> AdaptarItens(List<DetalheCupomFiscal> detalhes)
        {
            List<SaidaItemFiscal> itens = new List<SaidaItemFiscal>();

            foreach (DetalheCupomFiscal detalhe in detalhes)
                itens.Add(AdaptarItem(detalhe));

            return itens;
        }

        private SaidaItemFiscal AdaptarItem(DetalheCupomFiscal detalhe)
        {
            return new SaidaItemFiscal(AdaptarReferência(detalhe),
                                detalhe.Descricao.Trim(),
                                null,
                                TipoUnidadeInterpretação.Interpretar(detalhe.Unidade),
                                detalhe.Quantidade,
                                detalhe.ValorUnitario,
                                detalhe.ValorTotalLiquido);
        }

        private string AdaptarReferência(DetalheCupomFiscal detalhe)
        {
            return detalhe.CodigoProdutoOuServico.Trim().Substring(1, 11);
        }

        private string AdaptarId(DateTime dataInicioEmissao, int numeroContadorDocumentoEmitido, int coo)
        {
            return string.Format("{0}#{1}#{2}", dataInicioEmissao.ToString("yyyy-MM-dd"),
                numeroContadorDocumentoEmitido, coo);
        }
    }
}
