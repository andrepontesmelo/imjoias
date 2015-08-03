using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Importação.Intervenção
{
    public partial class BaseImportação : Form
    {
        protected Entidades.Pessoa.Pessoa pessoa;

        public BaseImportação()
        {
            InitializeComponent();
        }

        public BaseImportação(object objeto, Entidades.Pessoa.Pessoa novo)
        {
            InitializeComponent();

            propriedades.SelectedObject = objeto;

            if (novo == null)
                tabControl.Visible = false;
            else
            {
                if (novo.Observações != null)
                    txtObs.Text = novo.Observações;

                if (novo is PessoaFísica)
                    txtProfissão.Text = ((PessoaFísica)novo).Profissão;
                else
                    tabControl.TabPages.Remove(tabProfissão);
            }

            this.pessoa = novo;
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            string obs = txtObs.Text.Trim();

            if (obs.Length > 0)
                pessoa.Observações = obs;
            else
                pessoa.Observações = null;
        }

        private void txtProfissão_Validated(object sender, EventArgs e)
        {
            string str = txtProfissão.Text.Trim();

            if (str.Length > 1)
                ((PessoaFísica)pessoa).Profissão = str;
            else
                ((PessoaFísica)pessoa).Profissão = null;
        }
    }
}