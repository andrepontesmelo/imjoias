using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Pessoa.Endereço
{
    partial class ProcurarLocalidade : Apresentação.Formulários.JanelaExplicativa
    {
        public País País { get { return (País)cmbPaís.SelectedItem; } }
        public Estado Estado { get { return (Estado)cmbEstado.SelectedItem; } }
        public Região Região { get { return (Região)cmbRegião.SelectedItem; } }

        public ProcurarLocalidade()
        {
            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                cmbPaís.Items.AddRange(País.ObterPaíses().ToArray());
                cmbRegião.Items.AddRange(Região.ObterRegiões());
            }
            finally
            {
                AguardeDB.Fechar();
            }
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
                    cmbEstado.Items.AddRange(Estado.ObterEstados(País));

                    lblEstado.Enabled = cmbEstado.Enabled = true;
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        public static Localidade Procurar(IWin32Window owner)
        {
            País país;
            Estado estado;
            Região região;
            Localidade[] localidades = null;

            repetir:
            using (ProcurarLocalidade dlg = new ProcurarLocalidade())
            {
                if (dlg.ShowDialog(owner) != DialogResult.OK)
                    return null;

                país = dlg.País;
                estado = dlg.Estado;
                região = dlg.Região;
            }

            AguardeDB.Mostrar();

            try
            {
                if (país != null && estado != null && região != null)
                    localidades = Localidade.ObterLocalidades(estado, região);

                else if (país != null && estado != null)
                    localidades = Localidade.ObterLocalidades(estado);

                else if (país != null)
                    localidades = Localidade.ObterLocalidades(país);

                else if (região != null)
                    localidades = Localidade.ObterLocalidades(região);

                else
                    localidades = Localidade.ObterLocalidades();
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (localidades.Length == 0)
            {
                if (MessageBox.Show(owner,
                    "Nenhuma localidade foi encontrada com os parâmetros entrados.",
                    "Procurar por localidade",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                {
                    goto repetir;
                }
            }
            else
            {
                using (ListarLocalidades dlg = new ListarLocalidades(localidades))
                {
                    if (dlg.ShowDialog(owner) == DialogResult.OK)
                        return dlg.Seleção;
                }
            }

            return null;
        }
    }
}

