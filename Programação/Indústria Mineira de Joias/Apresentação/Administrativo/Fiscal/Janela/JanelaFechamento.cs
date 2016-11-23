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
    }
}
