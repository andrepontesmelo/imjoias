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
    public partial class EscolherEstado : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public EscolherEstado()
        {
            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                cmbPa�s.Items.AddRange(Pa�s.ObterPa�ses());
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

        private void cmbPa�s_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();

            lblEstado.Enabled = cmbEstado.Enabled = false;

            if (cmbPa�s.SelectedItem != null)
            {
                AguardeDB.Mostrar();

                try
                {
                    cmbEstado.Items.AddRange(Estado.ObterEstados((Pa�s)cmbPa�s.SelectedItem));

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

