using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Venda
{
    public partial class JanelaPer�odo : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public JanelaPer�odo()
        {
            InitializeComponent();
        }

        public DateTime DataIn�cio
        {
            get
            {
                if (optTotal.Checked)
                    return DateTime.MinValue;
                else
                    return dataIn�cio.Value;
            }
        }

        public DateTime DataFim
        {
            get
            {
                if (optTotal.Checked)
                    return DateTime.MaxValue;
                else
                    return dataFim.Value;
            }
        }

        private void optTotal_CheckedChanged(object sender, EventArgs e)
        {
            CorrigirEnabled();
        }

        private void optParcial_CheckedChanged(object sender, EventArgs e)
        {
            CorrigirEnabled();
        }

        private void CorrigirEnabled()
        {
            dataFim.Enabled = dataIn�cio.Enabled = optParcial.Checked;
        }

        public void Abrir(DateTime in�cio, DateTime fim)
        {
            bool vizualiza��oTotal =
                (in�cio == DateTime.MinValue) && (fim == DateTime.MaxValue);

            optTotal.Checked = vizualiza��oTotal;
            optParcial.Checked = !optTotal.Checked;

            if (!vizualiza��oTotal)
            {
                dataIn�cio.Value = in�cio;
                dataFim.Value = fim;
            }

            CorrigirEnabled();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}