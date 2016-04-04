using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Acesso.Comum;
using Entidades.Pessoa;
using Entidades;

namespace Apresentação.Usuário.Funcionários
{
    /// <summary>
    /// Formulário para guiar os primeiros passos do usuário novato.
    /// </summary>
    public partial class GuiaNovato : Apresentação.Formulários.JanelaExplicativa
    {
        public GuiaNovato()
        {
            InitializeComponent();

            foreach (Botão botão in barraBotões1.Botões)
                botão.Controlador = new ControladorInútil();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
                lblNome.Text = Funcionário.FuncionárioAtual.Nome;
        }

        #region Painel: Cadastro de senha

        private void painelSenha_Exibido(object sender, EventArgs e)
        {
            txtNovaSenha.Focus();
        }

        private void painelSenha_ValidandoTransição(object sender, CancelEventArgs e)
        {
            if (txtNovaSenha.Text != txtConfirmação.Text)
            {
                MessageBox.Show(
                    this,
                    "A nova senha não confere com a confirmação de senha.",
                    "Cadastro de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                e.Cancel = true;
            }

            if (txtNovaSenha.Text.Length < 4)
            {
                MessageBox.Show(
                    this,
                    "A senha digitada é muito pequena.",
                    "Cadastro de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                e.Cancel = true;
            }
        }

        #endregion

        #region Painel: Ramal

        private void painelRamal_Exibido(object sender, EventArgs e)
        {
            txtRamal.Int = Funcionário.FuncionárioAtual.Ramal;
            txtRamal.Focus();
        }

        private void painelRamal_ValidandoTransição(object sender, CancelEventArgs e)
        {
            Funcionário.FuncionárioAtual.Ramal = txtRamal.Int;
        }

        #endregion

        #region Painel: Pessoa-Física

        private void painelDadosPF_Exibido(object sender, EventArgs e)
        {
            dadosPessoaFísica.Pessoa = Funcionário.FuncionárioAtual;
        }

        #endregion

        #region Painel: Endereço

        private void painelDadosEndereço_Exibido(object sender, EventArgs e)
        {
            editorEndereços.Pessoa = Funcionário.FuncionárioAtual;
        }

        #endregion

        #region Painel: Funcionário

        private void painelFuncionário_Exibido(object sender, EventArgs e)
        {
            dadosFuncionário.Pessoa = Funcionário.FuncionárioAtual;
        }

        #endregion

        /// <summary>
        /// Ocorre ao finalizar o assistente.
        /// </summary>
        private void assistenteControle_Terminado(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            Funcionário.FuncionárioAtual.AlterarSenha("", txtNovaSenha.Text);
            Funcionário.FuncionárioAtual.AtualizarRamal(txtRamal.Int);

            Funcionário.FuncionárioAtual.Atualizar();

            AguardeDB.Fechar();

            Close();
        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            if (assistenteControle.Itens[assistenteControle.PainelAtual] == painelWindows)
                MessageBox.Show("Você pressionou o botão de exemplo!");
        }

        private void painelTxtMercadoria_Exibido(object sender, EventArgs e)
        {
            txtMercadoriaExemplo.Tabela = Entidades.Tabela.TabelaPadrão;
            txtMercadoriaExemplo.Referência = Entidades.Mercadoria.Mercadoria.ObterReferênciaPróxima("101");
        }

        private void quadroMercadoriaExemplo_EventoAdicionou(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade)
        {
            bandejaExemplo.Adicionar(new Saquinho(mercadoria, quantidade));
        }

        private void quadroMercadoriaExemplo_EventoAlterou(ISaquinho saquinhoOriginal, double novaQtd, double novoPeso)
        {
            bandejaExemplo.Remover(saquinhoOriginal);
            saquinhoOriginal.Mercadoria.Peso = novoPeso;
            bandejaExemplo.Adicionar(new Saquinho(saquinhoOriginal.Mercadoria, novaQtd));
        }

        private void painelQuadroMercadoria_Exibido(object sender, EventArgs e)
        {
            quadroMercadoriaExemplo.Tabela = Tabela.TabelaPadrão;
            bandejaExemplo.Tabela = Tabela.TabelaPadrão;
            bandejaExemplo.MostrarSeleçãoTabela = false;
        }

        private void painelWindows_ValidandoTransição(object sender, CancelEventArgs e)
        {
            AcceptButton = null;
        }

        private void painelWindows_Exibido(object sender, EventArgs e)
        {
            AcceptButton = btnExemplo;
        }
    }
}

