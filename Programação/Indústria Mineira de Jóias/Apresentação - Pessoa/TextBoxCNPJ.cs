using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa
{
    public partial class TextBoxCNPJ : UserControl
    {
        public TextBoxCNPJ()
        {
            InitializeComponent();
        }

        private void txtCNPJ_Resize(object sender, EventArgs e)
        {
            Height = txtCNPJ.Height;
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            if (txtCNPJ.Text.Length == 0 || Entidades.Pessoa.PessoaJurídica.ValidarCNPJ(txtCNPJ.Text))
            {
                txtCNPJ.ForeColor = SystemColors.ControlText;
                txtCNPJ.Refresh();
                e.Cancel = false;
            }
            else
            {
                txtCNPJ.ForeColor = Color.Red;
                txtCNPJ.Refresh();
                e.Cancel = true;

                Apresentação.Útil.Beepador.Erro();
            }
        }

        public override string Text
        {
            get
            {
                return txtCNPJ.Text;
            }
            set
            {
                txtCNPJ.Text = value;
            }
        }

        public override bool Focused
        {
            get
            {
                return base.Focused || txtCNPJ.Focused;
            }
        }
    }
}
