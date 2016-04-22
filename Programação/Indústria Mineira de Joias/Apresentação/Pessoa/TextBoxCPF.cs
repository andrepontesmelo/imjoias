using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa
{
    public partial class TextBoxCPF : UserControl
    {
        public TextBoxCPF()
        {
            InitializeComponent();
        }

        private void txtCPF_Resize(object sender, EventArgs e)
        {
            Height = txtCPF.Height;
        }

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {
            if (txtCPF.Text.Length == 0 || Entidades.Pessoa.PessoaFísica.ValidarCPF(txtCPF.Text))
            {
                txtCPF.ForeColor = SystemColors.ControlText;
                txtCPF.Refresh();
                e.Cancel = false;
            }
            else
            {
                txtCPF.ForeColor = Color.Red;
                txtCPF.Refresh();
                e.Cancel = true;

                Negócio.Beepador.Erro();
            }
        }

        public override string Text
        {
            get
            {
                return txtCPF.Text;
            }
            set
            {
                txtCPF.Text = value;
            }
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        public override bool Focused
        {
            get
            {
                return base.Focused || txtCPF.Focused;
            }
        }
    }
}
