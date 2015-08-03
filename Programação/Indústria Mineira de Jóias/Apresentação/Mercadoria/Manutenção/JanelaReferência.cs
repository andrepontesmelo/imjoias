using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class JanelaReferência : Apresentação.Formulários.JanelaExplicativa
    {
        public JanelaReferência()
        {
            InitializeComponent();
        }

        public string Referência
        {
            get
            {
                return txtMercadoria.Referência;
            }
        }

        private void JanelaReferência_Load(object sender, EventArgs e)
        {
            txtMercadoria.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string erro = "";

            if (!Entidades.Mercadoria.Mercadoria.ValidarReferênciaNumérica(txtMercadoria.ReferênciaNumérica))
                erro += "\n\tReferência inválida";

            if (Entidades.Mercadoria.Mercadoria.VerificarExistência(txtMercadoria.ReferênciaNumérica))
                erro += "\n\tReferência já cadastrada";

            if (!String.IsNullOrEmpty(erro))
            {
                MessageBox.Show("Erro", erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}