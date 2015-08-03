using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Hist�rico
{
    public partial class EditarHist�rico : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        /// <summary>
        /// Pessoa cujo hist�rico ser� incrementado.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Entidade do hist�rico.
        /// </summary>
        private Entidades.Pessoa.Hist�rico hist�rico;

        /// <summary>
        /// Constr�i uma nova janela de edi��o de hist�rico.
        /// </summary>
        /// <param name="pessoa">Pessoa cujo hist�rico ser� incrementado.</param>
        public EditarHist�rico(Entidades.Pessoa.Pessoa pessoa)
        {
            InitializeComponent();

            this.pessoa = pessoa;

            txtPessoa.Text = pessoa.Nome;
            txtDigitadoPor.Text = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual.Nome;

            hist�rico = new Entidades.Pessoa.Hist�rico();
            hist�rico.Pessoa = pessoa;
            hist�rico.DigitadoPor = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;
        }

        /// <summary>
        /// Ocorre ao carregar a janela de edi��o.
        /// </summary>
        private void EditarHist�rico_Load(object sender, EventArgs e)
        {
            txtTexto.Focus();
        }

        /// <summary>
        /// Entidade do hist�rico.
        /// </summary>
        public Entidades.Pessoa.Hist�rico Hist�rico
        {
            get { return hist�rico; } 
        }

        /// <summary>
        /// Ocorre ao validar o texto.
        /// </summary>
        private void txtTexto_Validated(object sender, EventArgs e)
        {
            hist�rico.Texto = txtTexto.Text.Trim();
        }

        private void chkAlertarVenda_CheckedChanged(object sender, EventArgs e)
        {
            hist�rico.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void chkAlertarSa�da_CheckedChanged(object sender, EventArgs e)
        {
            hist�rico.AlertarSa�da = chkAlertarSa�da.Checked;
        }

        private void chkAlertarCorreio_CheckedChanged(object sender, EventArgs e)
        {
            hist�rico.AlertarCorreio = chkAlertarCorreio.Checked;
        }

        private void chkAlertarConserto_CheckedChanged(object sender, EventArgs e)
        {
            hist�rico.AlertarPedido = chkAlertarConserto.Checked;
        }
    }
}

