using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Entidades.Pessoa.Endere�o;

namespace Apresenta��o.Pessoa.Endere�o
{
    partial class ProcurarLocalidade : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public Pa�s Pa�s { get { return (Pa�s)cmbPa�s.SelectedItem; } }
        public Estado Estado { get { return (Estado)cmbEstado.SelectedItem; } }
        public Regi�o Regi�o { get { return (Regi�o)cmbRegi�o.SelectedItem; } }

        public ProcurarLocalidade()
        {
            AguardeDB.Mostrar();

            try
            {
                InitializeComponent();

                cmbPa�s.Items.AddRange(Pa�s.ObterPa�ses().ToArray());
                cmbRegi�o.Items.AddRange(Regi�o.ObterRegi�es());
            }
            finally
            {
                AguardeDB.Fechar();
            }
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
                    cmbEstado.Items.AddRange(Estado.ObterEstados(Pa�s));

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
            Pa�s pa�s;
            Estado estado;
            Regi�o regi�o;
            Localidade[] localidades = null;

            repetir:
            using (ProcurarLocalidade dlg = new ProcurarLocalidade())
            {
                if (dlg.ShowDialog(owner) != DialogResult.OK)
                    return null;

                pa�s = dlg.Pa�s;
                estado = dlg.Estado;
                regi�o = dlg.Regi�o;
            }

            AguardeDB.Mostrar();

            try
            {
                if (pa�s != null && estado != null && regi�o != null)
                    localidades = Localidade.ObterLocalidades(estado, regi�o);

                else if (pa�s != null && estado != null)
                    localidades = Localidade.ObterLocalidades(estado);

                else if (pa�s != null)
                    localidades = Localidade.ObterLocalidades(pa�s);

                else if (regi�o != null)
                    localidades = Localidade.ObterLocalidades(regi�o);

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
                    "Nenhuma localidade foi encontrada com os par�metros entrados.",
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
                        return dlg.Sele��o;
                }
            }

            return null;
        }
    }
}

