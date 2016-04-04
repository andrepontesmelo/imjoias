using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// Janela para edi��o dos dados de um estado.
    /// </summary>
    /// <remarks>
    /// N�o permite edi��o de regi�o.
    /// </remarks>
    public partial class EditarEstado : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Estado estado;

        /// <summary>
        /// Constr�i uma janela para edi��o de um novo estado.
        /// </summary>
        public EditarEstado()
        {
            InitializeComponent();

            estado = new Estado();
        }

        /// <summary>
        /// Constr�i uma janela para edi��o de um estado j� existente.
        /// </summary>
        public EditarEstado(Estado estado)
        {
            InitializeComponent();

            Estado = estado;
        }

        public EditarEstado(Pa�s pa�s) : this()
        {
            if (pa�s != null)
            {
                estado.Pa�s = pa�s;
                cmbPa�s.SelectedItem = estado.Pa�s;
            }
        }

        /// <summary>
        /// Estado em edi��o.
        /// </summary>
        public Estado Estado
        {
            get { return estado; }
            set
            {
                estado = value;

                txtNome.Text = estado.Nome;

                if (estado.Sigla == null)
                    txtSigla.Text = "";
                else
                    txtSigla.Text = estado.Sigla;

                cmbPa�s.SelectedItem = estado.Pa�s;

                if (estado.Regi�o == null)
                    cmbRegi�o.SelectedItem = null;
                else
                    cmbRegi�o.SelectedItem = value;
            }
        }

        private void CarregarListas()
        {
            AguardeDB.Mostrar();

            try
            {
                Pa�s[] pa�ses = Pa�s.ObterPa�ses();
                Regi�o[] regi�es = Regi�o.ObterRegi�es();

                cmbPa�s.Items.AddRange(pa�ses);
                cmbRegi�o.Items.AddRange(regi�es);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            estado.Nome = txtNome.Text.Trim();
        }

        private void txtSigla_Validated(object sender, EventArgs e)
        {
            string sigla = txtSigla.Text.Trim();

            if (sigla.Length > 0)
                estado.Sigla = sigla;
            else
                estado.Sigla = null;
        }

        private void cmbPa�s_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado.Pa�s = cmbPa�s.SelectedItem as Pa�s;
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtNome.Text.Trim().Length == 0;
        }

        private void EditarEstado_Load(object sender, EventArgs e)
        {
            CarregarListas();
        }

        private void cmbRegi�o_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado.Regi�o = cmbRegi�o.SelectedItem as Regi�o;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (estado.Pa�s == null)
                MessageBox.Show(
                    this,
                    "Por favor, preencha o campo \"Pa�s\".",
                    "Editar estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

