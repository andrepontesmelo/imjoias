using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;
using Apresentação.Formulários;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// Janela para edição dos dados de um estado.
    /// </summary>
    /// <remarks>
    /// Não permite edição de região.
    /// </remarks>
    public partial class EditarEstado : Apresentação.Formulários.JanelaExplicativa
    {
        private Estado estado;

        /// <summary>
        /// Constrói uma janela para edição de um novo estado.
        /// </summary>
        public EditarEstado()
        {
            InitializeComponent();

            estado = new Estado();
        }

        /// <summary>
        /// Constrói uma janela para edição de um estado já existente.
        /// </summary>
        public EditarEstado(Estado estado)
        {
            InitializeComponent();

            Estado = estado;
        }

        public EditarEstado(País país) : this()
        {
            if (país != null)
            {
                estado.País = país;
                cmbPaís.SelectedItem = estado.País;
            }
        }

        /// <summary>
        /// Estado em edição.
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

                cmbPaís.SelectedItem = estado.País;

                if (estado.Região == null)
                    cmbRegião.SelectedItem = null;
                else
                    cmbRegião.SelectedItem = value;
            }
        }

        private void CarregarListas()
        {
            AguardeDB.Mostrar();

            try
            {
                País[] países = País.ObterPaíses();
                Região[] regiões = Região.ObterRegiões();

                cmbPaís.Items.AddRange(países);
                cmbRegião.Items.AddRange(regiões);
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

        private void cmbPaís_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado.País = cmbPaís.SelectedItem as País;
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtNome.Text.Trim().Length == 0;
        }

        private void EditarEstado_Load(object sender, EventArgs e)
        {
            CarregarListas();
        }

        private void cmbRegião_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado.Região = cmbRegião.SelectedItem as Região;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (estado.País == null)
                MessageBox.Show(
                    this,
                    "Por favor, preencha o campo \"País\".",
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

