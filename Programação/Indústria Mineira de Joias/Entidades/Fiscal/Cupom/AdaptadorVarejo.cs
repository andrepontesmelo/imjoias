using InterpretadorTDM.Registro;

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
            VendaFiscal entidade = new VendaFiscal(TipoVenda.Cupom, cupom.DataInicioEmissao);

            return entidade;
        }
    }
}
