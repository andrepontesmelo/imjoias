using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão;
using Apresentação.Impressão.Servidor;
using System.ServiceProcess;

namespace Programa.ServidorImpressão
{
    public partial class ConfigurarImpressora : Form
    {
        private ConfiguraçãoImpressora cfg;
        private Serviço serviço;
        private ServiceController serviçoWindows;

        public ConfigurarImpressora(ConfiguraçãoImpressora cfg, Serviço serviço, ServiceController serviçoWindows)
        {
            InitializeComponent();

            this.cfg = cfg;

            txtNome.Text = cfg.Nome;
            chkCompartilhar.Checked = cfg.Compartilhar.Valor;

            foreach (TipoDocumento tipo in Enum.GetValues(typeof(TipoDocumento)))
            {
                if (tipo != TipoDocumento.Desconhecido)
                    chkDocumentos.Items.Add(tipo, cfg.Suporta(tipo).Valor);
            }

            this.serviço = serviço;
            this.serviçoWindows = serviçoWindows;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();

            cfg.Compartilhar.Valor = chkCompartilhar.Checked;

            foreach (TipoDocumento tipo in chkDocumentos.Items)
                cfg.Suporta(tipo).Valor = chkDocumentos.GetItemChecked(chkDocumentos.Items.IndexOf(tipo));

            if (serviço != null)
                serviço.RecarregarImpressoras();

            if (serviçoWindows != null)
            {
                serviçoWindows.Stop();
                serviçoWindows.Start();
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}