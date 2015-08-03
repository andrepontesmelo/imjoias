using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Histórico
{
    public partial class EditarHistórico : Apresentação.Formulários.JanelaExplicativa
    {
        /// <summary>
        /// Pessoa cujo histórico será incrementado.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Entidade do histórico.
        /// </summary>
        private Entidades.Pessoa.Histórico histórico;

        /// <summary>
        /// Constrói uma nova janela de edição de histórico.
        /// </summary>
        /// <param name="pessoa">Pessoa cujo histórico será incrementado.</param>
        public EditarHistórico(Entidades.Pessoa.Pessoa pessoa)
        {
            InitializeComponent();

            this.pessoa = pessoa;

            txtPessoa.Text = pessoa.Nome;
            txtDigitadoPor.Text = Entidades.Pessoa.Funcionário.FuncionárioAtual.Nome;

            histórico = new Entidades.Pessoa.Histórico();
            histórico.Pessoa = pessoa;
            histórico.DigitadoPor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
        }

        /// <summary>
        /// Ocorre ao carregar a janela de edição.
        /// </summary>
        private void EditarHistórico_Load(object sender, EventArgs e)
        {
            txtTexto.Focus();
        }

        /// <summary>
        /// Entidade do histórico.
        /// </summary>
        public Entidades.Pessoa.Histórico Histórico
        {
            get { return histórico; } 
        }

        /// <summary>
        /// Ocorre ao validar o texto.
        /// </summary>
        private void txtTexto_Validated(object sender, EventArgs e)
        {
            histórico.Texto = txtTexto.Text.Trim();
        }

        private void chkAlertarVenda_CheckedChanged(object sender, EventArgs e)
        {
            histórico.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void chkAlertarSaída_CheckedChanged(object sender, EventArgs e)
        {
            histórico.AlertarSaída = chkAlertarSaída.Checked;
        }

        private void chkAlertarCorreio_CheckedChanged(object sender, EventArgs e)
        {
            histórico.AlertarCorreio = chkAlertarCorreio.Checked;
        }

        private void chkAlertarConserto_CheckedChanged(object sender, EventArgs e)
        {
            histórico.AlertarPedido = chkAlertarConserto.Checked;
        }
    }
}

