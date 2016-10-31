using Apresenta��o.Formul�rios;
using Entidades.Pessoa.Endere�o;
using System;

namespace Apresenta��o.Pessoa.Endere�o
{
    public partial class EscolherEstado : JanelaExplicativa
    {
        public EscolherEstado()
        {
            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                cmbPa�s.Items.AddRange(Pa�s.ObterPa�ses().ToArray());
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

