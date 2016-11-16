using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.�lbum.Edi��o
{
    /// <summary>
    /// Janela para entrada de refer�ncia de mercadoria,
    /// utilizada para procurar por fotos.
    /// </summary>
    public partial class ProcurarMercadoria : Apresenta��o.Formul�rios.JanelaExplicativa
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
        /// Refer�ncia da mercadoria.
        /// </summary>
        public string Refer�ncia
        {
            get { return txtMercadoria.Refer�ncia; }
            set { txtMercadoria.Refer�ncia = value; }
        }

        private void txtMercadoria_Refer�nciaConfirmada(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void txtMercadoria_Refer�nciaAlterada(object sender, EventArgs e)
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

