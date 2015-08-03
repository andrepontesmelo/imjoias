using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria.Manuten��o
{
    public partial class JanelaRefer�ncia : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public JanelaRefer�ncia()
        {
            InitializeComponent();
        }

        public string Refer�ncia
        {
            get
            {
                return txtMercadoria.Refer�ncia;
            }
        }

        private void JanelaRefer�ncia_Load(object sender, EventArgs e)
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

            if (!Entidades.Mercadoria.Mercadoria.ValidarRefer�nciaNum�rica(txtMercadoria.Refer�nciaNum�rica))
                erro += "\n\tRefer�ncia inv�lida";

            if (Entidades.Mercadoria.Mercadoria.VerificarExist�ncia(txtMercadoria.Refer�nciaNum�rica))
                erro += "\n\tRefer�ncia j� cadastrada";

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