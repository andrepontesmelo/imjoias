using InterpretadorTDM;
using System;
using InterpretadorTDM.Registro;

namespace Entidades.Fiscal.Cupom
{
    public class AdaptadorVarejo : ITransformavelVendaFiscal
    {
        private CupomFiscal primeiroCupom;

        public AdaptadorVarejo(CupomFiscal primeiroCupom)
        {
            this.primeiroCupom = primeiroCupom;
        }

        public VendaFiscal Transformar()
        {
            throw new NotImplementedException();
        }
    }
}
