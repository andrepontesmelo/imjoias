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
            List<VendaItemFiscal> itens = new List<VendaItemFiscal>();

            VendaFiscal entidade = new VendaFiscal(TipoVenda.Cupom, 
                cupom.DataInicioEmissao, 
                AdaptarId(cupom.DataInicioEmissao, cupom.NumeroContadorDocumentoEmitido, cupom.COO),
                0,
                itens);
            
            return entidade;
        }

        private string AdaptarId(DateTime dataInicioEmissao, int numeroContadorDocumentoEmitido, int coo)
        {
            return string.Format("{0}#{1}#{2}", dataInicioEmissao.ToString("yyyy-MM-dd"),
                numeroContadorDocumentoEmitido, coo);
        }
    }
}
