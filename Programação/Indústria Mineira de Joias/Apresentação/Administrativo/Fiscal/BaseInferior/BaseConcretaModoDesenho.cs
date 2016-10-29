using Apresentação.Fiscal.BaseInferior;
using Entidades.Fiscal.Pdf;
using System;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.BaseInferior
{
    public class BaseConcretaModoDesenho : BaseDocumento
    {
        protected override void CadastrarPdf(string arquivo)
        {
            throw new NotImplementedException();
        }

        protected override void Excluir()
        {
            throw new NotImplementedException();
        }

        protected override List<string> ObterIds()
        {
            throw new NotImplementedException();
        }

        protected override FiscalPdf ObterPdf()
        {
            throw new NotImplementedException();
        }
    }
}
