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
    public partial class DadosTelefone : UserControl, Apresentação.Formulários.IEditorItem<Telefone>
    {
        private Telefone telefone;

        public DadosTelefone()
        {
            InitializeComponent();

            EventHandler aoFocarControle = new EventHandler(AoFocarControle);

            foreach (Control controle in Controls)
                controle.GotFocus += aoFocarControle;
        }

        public DadosTelefone(Telefone telefone)
            : this()
        {
            Item = telefone;
        }

        public Telefone Item
        {
            get { return telefone; }
            set
            {
                telefone = value;

                if (value.Descrição == null)
                {
                    cmbDescrição.Text = "< descrição (ex.: residencial) >";
                    cmbDescrição.SelectAll();
                }
                else
                    cmbDescrição.Text = value.Descrição;

                txtTelefone.Text = value.Número;
                txtObs.Text = value.Observações;
            }
        }

        private void cmbDescrição_Validated(object sender, EventArgs e)
        {
            telefone.Descrição = cmbDescrição.Text.Trim();
        }

        private void txtTelefone_Validated(object sender, EventArgs e)
        {
            telefone.Número = txtTelefone.Text.Trim();
        }

        private void cmbDescrição_Validating(object sender, CancelEventArgs e)
        {
            //string tel = cmbDescrição.Text.Trim();
            //bool ok = tel.Length > 0;

            //foreach (Telefone outro in telefone.Pessoa.Telefones)
            //    if (outro != telefone && string.Compare(tel, outro.Descrição, true) == 0)
            //    {
            //        MessageBox.Show(
            //            ParentForm,
            //            "A descrição do telefone não pode se repetir. Por favor, altere a descrição.",
            //            "Edição de telefone",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);

            //        ok = false;
            //        break;
            //    }

            //e.Cancel = !ok;
        }

        private void AoFocarControle(object sender, EventArgs e)
        {
            OnGotFocus(e);
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            if (txtObs.Text.Trim().Length > 0)
                telefone.Observações = txtObs.Text;
            else
                telefone.Observações = null;
        }
    }
}
