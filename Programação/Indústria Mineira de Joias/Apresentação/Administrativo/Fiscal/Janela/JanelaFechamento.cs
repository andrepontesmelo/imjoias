using System;
using Apresentação.Formulários;
using Entidades.Fiscal;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaFechamento : JanelaExplicativa
    {
        Fechamento entidade;

        public JanelaFechamento()
        {
            InitializeComponent();
        }

        public void Carregar(Fechamento entidade)
        {
            this.entidade = entidade;

            chkFechado.Checked = entidade.Fechado;
            dataInício.Value = entidade.Início;
            dataFim.Value = entidade.Fim;

            CorrigirMinimoDataFim();
            CorrigirMáximoDataInício();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            entidade.Fechado = chkFechado.Checked;
            entidade.Fim = dataFim.Value;
            entidade.Início = dataInício.Value;

            if (!entidade.Cadastrado)
                entidade.Cadastrar();
            else
                entidade.Atualizar();

            Close();
        }

        internal void Carregar()
        {
            Carregar(new Fechamento());
        }

        private void dataInício_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private bool DatasVálidas => dataInício.Value <= dataFim.Value;

        private void dataFim_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !DatasVálidas;
        }

        private void dataInício_Validated(object sender, EventArgs e)
        {
            CorrigirMinimoDataFim();
        }

        private void CorrigirMinimoDataFim()
        {
            dataFim.MinDate = dataInício.Value;
        }

        private void dataFim_Validated(object sender, EventArgs e)
        {
            CorrigirMáximoDataInício();
        }

        private void CorrigirMáximoDataInício()
        {
            dataInício.MaxDate = dataFim.Value;
        }
    }
}
