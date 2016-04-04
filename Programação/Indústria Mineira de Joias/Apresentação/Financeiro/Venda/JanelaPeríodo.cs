using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda
{
    public partial class JanelaPeríodo : Apresentação.Formulários.JanelaExplicativa
    {
        public JanelaPeríodo()
        {
            InitializeComponent();
        }

        public DateTime DataInício
        {
            get
            {
                if (optTotal.Checked)
                    return DateTime.MinValue;
                else
                    return dataInício.Value;
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
            dataFim.Enabled = dataInício.Enabled = optParcial.Checked;
        }

        public void Abrir(DateTime início, DateTime fim)
        {
            bool vizualizaçãoTotal =
                (início == DateTime.MinValue) && (fim == DateTime.MaxValue);

            optTotal.Checked = vizualizaçãoTotal;
            optParcial.Checked = !optTotal.Checked;

            if (!vizualizaçãoTotal)
            {
                dataInício.Value = início;
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