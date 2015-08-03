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
            get 
            { 
                return (optTodosClientes.Checked ? null : cmbRegião.Região); 
            }
        }

        public Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão Ordem
        {
            get
            {
                if (optOrdemAlfabetica.Checked)
                    return Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão.Alfabética;
                else if (optOrdemEndereço.Checked)
                    return Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão.Endereço;
                else if (optOrdemCódigoCliente.Checked)
                    return Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão.CódCliente;
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
            //if (cmbRegião.Região == null)
            //{
            //    MessageBox.Show("Favor selecionar uma região", "Falta escolher a região", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            //    cmbRegião.Focus();
            //    return;
            //}

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void optRegiao_CheckedChanged(object sender, EventArgs e)
        {
            cmbRegião.Enabled = optRegiao.Checked;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}