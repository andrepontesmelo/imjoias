using InterpretadorTDM.Registro;
using System.Collections.Generic;
using System;
using Entidades.Fiscal.Tipo;

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
            DocumentoFiscal entidade = new SaídaFiscal((int)TipoDocumentoSistema.Cupom,
                cupom.DataInicioEmissao,
                cupom.DataInicioEmissao,
                AdaptarId(cupom),
                cupom.ValorTotalLiquido,
                cupom.ReducaoZ.CRZ,
                null,
                cupom.IndicadorCancelamento,
                "",
                (uint) SetorSistema.Varejo,
                ObterCódigoMáquina(cupom),
                AdaptarItens(cupom.Detalhes));

            return entidade;
        }

        private int? ObterCódigoMáquina(CupomFiscal cupom)
        {
            return Máquina.ObterCódigoMáquinaInserindo(cupom.ModeloECF, cupom.NumeroFabricacao);
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
                                (int) TipoUnidadeInterpretação.Interpretar(detalhe.Unidade),
                                detalhe.Quantidade,
                                detalhe.ValorUnitario,
                                detalhe.ValorTotalLiquido);
        }

        private string AdaptarReferência(DetalheCupomFiscal detalhe)
        {
            return detalhe.CodigoProdutoOuServico.Trim().Substring(1, 11);
        }

        private string AdaptarId(CupomFiscal cupom)
        {
            return string.Format("{0}@{1}", cupom.COO, ObterCódigoMáquina(cupom));
        }
    }
}