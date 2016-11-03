using Entidades.Comissão;
using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Comissões
{
    public partial class BaseComissão : Formulários.BaseInferior
    {
        public BaseComissão()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            quadro1.Visible = quadro2.Visible = quadro3.Visible = Comissão.UsuárioPodeManipularComissão;

            if (!Comissão.UsuárioPodeManipularComissão)
                títuloBaseInferior.Descrição = "Acesso somente leitura.";

            listaComissões.Carregar();
        }

        private void opçãoNova_Click(object sender, EventArgs e)
        {
            Comissão.AssegurarPermissãoManipulaçãoComissão();

            JanelaNovaComissão janela = new JanelaNovaComissão();
            janela.EventoComissãoAlterardaOuCadastrada += janela_EventoComissãoAlterardaOuCadastrada;
            janela.ShowDialog();
        }

        private void opçãoAlterarEstado_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            Comissão.AssegurarPermissãoManipulaçãoComissão();

            UseWaitCursor = true;
            Application.DoEvents();

            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;

            JanelaNovaComissão janela = new JanelaNovaComissão();
            janela.EventoComissãoAlterardaOuCadastrada += janela_EventoComissãoAlterardaOuCadastrada;
            janela.Comissão = selecionado;

            janela.Show();
            UseWaitCursor = false;
        }

        void janela_EventoComissãoAlterardaOuCadastrada(object sender, EventArgs e)
        {
            listaComissões.Carregar();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            Comissão.AssegurarPermissãoManipulaçãoComissão();

            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;

            DialogResult resposta = MessageBox.Show(this,
                "A informação de que alguma venda está vinculada a esta comissão será excluída, bem como estornos de comissão neste documento.\nDeseja prosseguir?",
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2);

            if (resposta != DialogResult.Yes)
                return;

            UseWaitCursor = true;

            selecionado.Descadastrar();

            UseWaitCursor = false;

            MessageBox.Show(this,
                "O documento foi excluído.",
                "Excluir comissão",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);

            listaComissões.Carregar();
        }

        private void opçãoAbrir_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void Entrar()
        {
            UseWaitCursor = true;
            Application.DoEvents();

            if (listaComissões.Selecionado == null)
                return;

            BaseEditarComissão novaBase = new BaseEditarComissão();
            novaBase.Abrir(listaComissões.Selecionado);
            SubstituirBase(novaBase);
            UseWaitCursor = false;
        }

        private void listaComissões_DuploClique(object sender, EventArgs e)
        {
            Entrar();
        }

        private void listaComissões_AoPressionar(Keys teclas)
        {
            if (!Comissão.UsuárioPodeManipularComissão)
                return;

            switch (teclas)
            {
                case Keys.F2:
                    Editar();
                    break;
                case Keys.Enter:
                    Entrar();
                    break;
                case Keys.Delete:
                    Excluir();
                    break;
            }
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            Comissão.AssegurarPermissãoManipulaçãoComissão();

            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;

            JanelaImpressãoComissão j = new JanelaImpressãoComissão(selecionado, null);
            j.InserirTodosRelatorios();
            j.Abrir(this);
        }

        private void opçãoVendasSemComissão_Click(object sender, EventArgs e)
        {
            Comissão.AssegurarPermissãoManipulaçãoComissão();
            SubstituirBase(new BaseVendaSemComissão());
        }
    }
}
