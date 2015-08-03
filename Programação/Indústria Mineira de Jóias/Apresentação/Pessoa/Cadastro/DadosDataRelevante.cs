using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class DadosDataRelevante : UserControl, Apresentação.Formulários.IEditorItem<DataRelevante>
    {
        private DataRelevante item;

        public DadosDataRelevante()
        {
            InitializeComponent();
        }

        public DataRelevante Item
        {
            get { return item; }
            set
            {
                item = value;

                if (item.Data >= dtData.MinDate)
                    dtData.Value = item.Data;

                txtDescrição.Text = item.Descrição;
                chkAlerta.Checked = item.Alertar;

                dtData.Enabled = !item.Cadastrado;
            }
        }

        private void dtData_Validated(object sender, EventArgs e)
        {
            item.Data = dtData.Value.Date;
        }

        private void txtDescrição_Validated(object sender, EventArgs e)
        {
            item.Descrição = txtDescrição.Text.Trim();
        }

        private void txtDescrição_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtDescrição.Text.Trim().Length == 0;
        }

        private void chkAlerta_CheckedChanged(object sender, EventArgs e)
        {
            item.Alertar = chkAlerta.Checked;
        }

        private void AoFocarControle(object sender, EventArgs e)
        {
            OnGotFocus(e);
        }
    }
}
