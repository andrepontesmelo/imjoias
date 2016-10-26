using Entidades.Fiscal;
using System.Collections.Generic;

namespace Apresentação.Fiscal.BaseInferior.Documentos.Exclusão
{
    class ControladorExclusãoEntrada : ControladorExclusão
    {
        public ControladorExclusãoEntrada(BaseDocumentos baseDocumentos) : base(baseDocumentos)
        {
        }

        protected override void ExcluirSemConfirmação(IEnumerable<string> idsSelecionados)
        {
            EntradaFiscal.Excluir(idsSelecionados);
        }
    }
}
