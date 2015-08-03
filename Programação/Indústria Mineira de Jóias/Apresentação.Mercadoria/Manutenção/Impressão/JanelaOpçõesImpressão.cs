using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Mercadoria.Manutenção.Impressão
{
    public partial class JanelaOpçõesImpressão : JanelaExplicativa
    {
        public JanelaOpçõesImpressão()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}