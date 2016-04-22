using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.ComissãoCálculo;

namespace Apresentação.Financeiro.Comissões
{
    public partial class JanelaNovaComissão : JanelaExplicativa
    {

        public event EventHandler EventoComissãoAlterardaOuCadastrada;

        private Comissão comissão = null;

        public Comissão Comissão
        {
            get
            {
                if (comissão == null)
                    return new Comissão(txtDescrição.Text, 
                    dataMês.Value,
                    chkComissãoPaga.Checked);

                return comissão;
            }
            set
            {
                comissão = value;

                txtDescrição.Text = comissão.Descrição;
                chkComissãoPaga.Checked = comissão.Pago;
                dataMês.Value = comissão.MêsReferência;

                lblTítulo.Text = "Editar comissão";
                lblDescrição.Text = "cód #" + comissão.Código.ToString();
            }
        }

        public JanelaNovaComissão()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtDescrição.Text.Trim().Length == 0)
            {
                MessageBox.Show(this,
                    "Entre com alguma descrição",
                    "Sem descrição",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (comissão == null)
                Comissão.Cadastrar();
            else
            {
                if (dataMês.Value != comissão.MêsReferência)
                    comissão.MêsReferência = dataMês.Value;

                if (txtDescrição.Text != comissão.Descrição)
                    comissão.Descrição = txtDescrição.Text;

                if (chkComissãoPaga.Checked != comissão.Pago)
                    comissão.Pago = chkComissãoPaga.Checked;

                Comissão.Atualizar();
            }
                
            if (EventoComissãoAlterardaOuCadastrada != null)
                EventoComissãoAlterardaOuCadastrada(null, null);

            Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
