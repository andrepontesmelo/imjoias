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
    public partial class EscolherEstado : Apresentação.Formulários.JanelaExplicativa
    {
        public EscolherEstado()
        {
            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                cmbPaís.Items.AddRange(País.ObterPaíses());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        public Estado Estado
        {
            get { return (Estado)cmbEstado.SelectedItem; }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProcurar.Enabled = cmbEstado.SelectedItem != null;
        }

        private void cmbPaís_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();

            lblEstado.Enabled = cmbEstado.Enabled = false;

            if (cmbPaís.SelectedItem != null)
            {
                AguardeDB.Mostrar();

                try
                {
                    cmbEstado.Items.AddRange(Estado.ObterEstados((País)cmbPaís.SelectedItem));

                    lblEstado.Enabled = cmbEstado.Enabled = true;
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }
    }
}

