using Apresentação.Fiscal.Lista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apresentação.Fiscal.BaseInferior
{
    public partial class BaseDocumentos : Formulários.BaseInferior
    {
        private const string EXCLUSÃO_TÍTULO = "Exclusão";

        public BaseDocumentos()
        {
            InitializeComponent();
        }

        private void opçãoExcluir_Click(object sender, System.EventArgs e)
        {
            ListaDocumentoFiscal lista = ObterListaAtiva();

            var idsSelecionados = lista.ObterCódigosSelecionados();
            int qtd = Enumerable.Count(idsSelecionados);
            if (qtd == 0)
            {
                MessageBox.Show(this, "Nenhum documento selecionado", EXCLUSÃO_TÍTULO,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string idsAgrupados = string.Join(Environment.NewLine, idsSelecionados);
            string mensagem = string.Format("Confirma exclusão da{1} segunte{1} {0} nota{1} ? {2}", 
                qtd, qtd > 1 ? "s" : "", Environment.NewLine) + idsAgrupados;

            if (MessageBox.Show(this,
                mensagem,
                EXCLUSÃO_TÍTULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
        }

        protected virtual ListaDocumentoFiscal ObterListaAtiva()
        {
            throw new System.Exception("abstrato");
        }
    }
}
