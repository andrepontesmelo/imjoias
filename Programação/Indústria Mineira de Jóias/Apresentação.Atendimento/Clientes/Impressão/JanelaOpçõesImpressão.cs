using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Atendimento.Clientes.Impressão
{
    public partial class JanelaOpçõesImpressão : JanelaExplicativa
    {
        public JanelaOpçõesImpressão()
        {
            InitializeComponent();
        }

        public Região Região
        {
            get { return cmbRegião.Região; }
        }

        public Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão Ordem
        {
            get
            {
                if (optNome.Checked)
                    return Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão.Nome;
                else if (optEndereco.Checked)
                    return Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão.Endereço;
                else
                    throw new NotImplementedException();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cmbRegião.Região == null)
            {
                MessageBox.Show("Favor selecionar uma região", "Falta escolher a região", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbRegião.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}