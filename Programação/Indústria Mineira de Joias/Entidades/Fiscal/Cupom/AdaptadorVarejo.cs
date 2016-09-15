using InterpretadorTDM.Registro;
using System.Collections.Generic;

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
                "id",
                itens);
            
            return entidade;
        }
    }
}
