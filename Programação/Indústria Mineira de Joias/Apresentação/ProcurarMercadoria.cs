using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição
{
    /// <summary>
    /// Janela para entrada de referência de mercadoria,
    /// utilizada para procurar por fotos.
    /// </summary>
    public partial class ProcurarMercadoria : Apresentação.Formulários.JanelaExplicativa
    {
        public ProcurarMercadoria()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mercadoria procurada.
        /// </summary>
        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            get { return txtMercadoria.Mercadoria; }
        }

        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        public string Referência
        {
            get { return txtMercadoria.Referência; }
            set { txtMercadoria.Referência = value; }
        }

        private void txtMercadoria_ReferênciaConfirmada(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void txtMercadoria_ReferênciaAlterada(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
        }

        private void txtMercadoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

