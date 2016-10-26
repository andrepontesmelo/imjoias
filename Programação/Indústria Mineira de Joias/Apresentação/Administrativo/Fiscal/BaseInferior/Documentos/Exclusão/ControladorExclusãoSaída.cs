using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Fiscal.BaseInferior.Documentos.Exclusão
{
    public class ControladorExclusãoSaída : ControladorExclusão
    {
        public ControladorExclusãoSaída(BaseDocumentos baseDocumentos) : base(baseDocumentos)
        {
        }

        protected override void ExcluirSemConfirmação(IEnumerable<string> idsSelecionados)
        {
            SaídaFiscal.Excluir(idsSelecionados);
        }
    }
}
