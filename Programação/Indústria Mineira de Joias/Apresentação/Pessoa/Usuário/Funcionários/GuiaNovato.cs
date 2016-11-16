using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Acesso.Comum;
using Entidades.Pessoa;
using Entidades;

namespace Apresenta��o.Usu�rio.Funcion�rios
{
    /// <summary>
    /// Formul�rio para guiar os primeiros passos do usu�rio novato.
    /// </summary>
    public partial class GuiaNovato : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public GuiaNovato()
        {
            InitializeComponent();

            foreach (Bot�o bot�o in barraBot�es1.Bot�es)
                bot�o.Controlador = new ControladorIn�til();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
                lblNome.Text = Funcion�rio.Funcion�rioAtual.Nome;
        }

        #region Painel: Cadastro de senha

        private void painelSenha_Exibido(object sender, EventArgs e)
        {
            txtNovaSenha.Focus();
        }

        private void painelSenha_ValidandoTransi��o(object sender, CancelEventArgs e)
        {
            if (txtNovaSenha.Text != txtConfirma��o.Text)
            {
                MessageBox.Show(
                    this,
                    "A nova senha n�o confere com a confirma��o de senha.",
                    "Cadastro de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                e.Cancel = true;
            }

            if (txtNovaSenha.Text.Length < 4)
            {
                MessageBox.Show(
                    this,
                    "A senha digitada � muito pequena.",
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
            txtRamal.Int = Funcion�rio.Funcion�rioAtual.Ramal;
            txtRamal.Focus();
        }

        private void painelRamal_ValidandoTransi��o(object sender, CancelEventArgs e)
        {
            Funcion�rio.Funcion�rioAtual.Ramal = txtRamal.Int;
        }

        #endregion

        #region Painel: Pessoa-F�sica

        private void painelDadosPF_Exibido(object sender, EventArgs e)
        {
            dadosPessoaF�sica.Pessoa = Funcion�rio.Funcion�rioAtual;
        }

        #endregion

        #region Painel: Endere�o

        private void painelDadosEndere�o_Exibido(object sender, EventArgs e)
        {
            editorEndere�os.Pessoa = Funcion�rio.Funcion�rioAtual;
        }

        #endregion

        #region Painel: Funcion�rio

        private void painelFuncion�rio_Exibido(object sender, EventArgs e)
        {
            dadosFuncion�rio.Pessoa = Funcion�rio.Funcion�rioAtual;
        }

        #endregion

        /// <summary>
        /// Ocorre ao finalizar o assistente.
        /// </summary>
        private void assistenteControle_Terminado(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            Funcion�rio.Funcion�rioAtual.AlterarSenha("", txtNovaSenha.Text);
            Funcion�rio.Funcion�rioAtual.AtualizarRamal(txtRamal.Int);

            Funcion�rio.Funcion�rioAtual.Atualizar();

            AguardeDB.Fechar();

            Close();
        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            if (assistenteControle.Itens[assistenteControle.PainelAtual] == painelWindows)
                MessageBox.Show("Voc� pressionou o bot�o de exemplo!");
        }

        private void painelTxtMercadoria_Exibido(object sender, EventArgs e)
        {
            txtMercadoriaExemplo.Tabela = Entidades.Tabela.TabelaPadr�o;
            txtMercadoriaExemplo.Refer�ncia = Entidades.Mercadoria.Mercadoria.ObterRefer�nciaPr�xima("101");
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
            quadroMercadoriaExemplo.Tabela = Tabela.TabelaPadr�o;
            bandejaExemplo.Tabela = Tabela.TabelaPadr�o;
            bandejaExemplo.MostrarSele��oTabela = false;
        }

        private void painelWindows_ValidandoTransi��o(object sender, CancelEventArgs e)
        {
            AcceptButton = null;
        }

        private void painelWindows_Exibido(object sender, EventArgs e)
        {
            AcceptButton = btnExemplo;
        }
    }
}

