using Apresentação.Fiscal.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior.Documentos.Exclusão
{
    public abstract class ControladorExclusão
    {
        private const string EXCLUSÃO_TÍTULO = "Exclusão";

        private BaseDocumentos baseDocumentos;

        public ControladorExclusão(BaseDocumentos baseDocumentos)
        {
            this.baseDocumentos = baseDocumentos;
        }

        internal bool Excluir()
        {
            ListaDocumentoFiscal lista = baseDocumentos.ObterListaAtiva();

            var idsSelecionados = lista.ObterCódigosSelecionados();

            if (MostrarMensagemExclusãoSemSeleçãoSeNecessário(idsSelecionados))
                return false;

            ExcluirComComfirmação(idsSelecionados);
            return true;
        }

        private bool MostrarMensagemExclusãoSemSeleçãoSeNecessário(IEnumerable<string> idsSelecionados)
        {
            if (Enumerable.Count(idsSelecionados) == 0)
            {
                MessageBox.Show(baseDocumentos, "Nenhum documento selecionado", EXCLUSÃO_TÍTULO,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        private void ExcluirComComfirmação(IEnumerable<string> idsSelecionados)
        {
            int qtd = Enumerable.Count(idsSelecionados);
            string idsAgrupados = string.Join(Environment.NewLine, idsSelecionados);
            string mensagem = string.Format("Confirma exclusão de {0} nota{1} segunte{1} ? {2}",
                qtd, qtd > 1 ? "s" : "", Environment.NewLine) + idsAgrupados;

            if (MessageBox.Show(baseDocumentos,
                mensagem,
                EXCLUSÃO_TÍTULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ExcluirSemConfirmação(idsSelecionados);
        }

        protected abstract void ExcluirSemConfirmação(IEnumerable<string> idsSelecionados);
    }
}
