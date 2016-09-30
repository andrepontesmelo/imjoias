using InterpretadorTDM.Registro;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Cupom
{
    public class AdaptadorVarejo : ITransformavelDocumentoFiscal
    {
        private CupomFiscal cupom;

        public AdaptadorVarejo(CupomFiscal cupom)
        {
            this.cupom = cupom;
        }

        public DocumentoFiscal Transformar()
        {
            DocumentoFiscal entidade = new SaídaFiscal(TipoSaída.Cupom, 
                cupom.DataInicioEmissao, 
                AdaptarId(cupom.DataInicioEmissao, 
                cupom.NumeroContadorDocumentoEmitido, 
                cupom.COO),
                cupom.ValorTotalLiquido,
                null,
                cupom.COO,
                cupom.NumeroContadorDocumentoEmitido,
                null,
                false,
                AdaptarItens(cupom.Detalhes));
            
            return entidade;
        }

        private List<ItemFiscal> AdaptarItens(List<DetalheCupomFiscal> detalhes)
        {
            List<ItemFiscal> itens = new List<ItemFiscal>();

            foreach (DetalheCupomFiscal detalhe in detalhes)
                itens.Add(AdaptarItem(detalhe));

            return itens;
        }

        private ItemFiscal AdaptarItem(DetalheCupomFiscal detalhe)
        {
            return new SaídaItemFiscal(AdaptarReferência(detalhe),
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
