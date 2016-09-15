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

        public VendaFiscal Transformar()
        {
            VendaFiscal entidade = new VendaFiscal(TipoVenda.Cupom, 
                cupom.DataInicioEmissao, 
                AdaptarId(cupom.DataInicioEmissao, cupom.NumeroContadorDocumentoEmitido, cupom.COO),
                0,
                AdaptarItens(cupom.Detalhes));
            
            return entidade;
        }

        private List<VendaItemFiscal> AdaptarItens(List<DetalheCupomFiscal> detalhes)
        {
            List<VendaItemFiscal> itens = new List<VendaItemFiscal>();

            foreach (DetalheCupomFiscal detalhe in detalhes)
                itens.Add(new VendaItemFiscal(AdaptarReferência(detalhe),
                    detalhe.Descricao.Trim(),
                    null,
                    TipoUnidadeInterpretação.Interpretar(detalhe.Unidade),
                    detalhe.Quantidade,
                    detalhe.ValorUnitario,
                    0));

            return itens;
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
