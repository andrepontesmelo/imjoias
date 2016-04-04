using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// Edita os dados cadastrais de um pa�s.
    /// </summary>
    public partial class EditarPa�s : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public Pa�s pa�s;

        public EditarPa�s()
        {
            InitializeComponent();

            pa�s = new Pa�s();
        }

        public EditarPa�s(Pa�s pa�s)
        {
            InitializeComponent();

            Pa�s = pa�s;
        }

        public Pa�s Pa�s
        {
            get { return pa�s; }
            set
            {
                pa�s = value;

                txtNome.Text = pa�s.Nome;
                txtSigla.Text = pa�s.Sigla != null ? pa�s.Sigla : "";

                if (pa�s.DDI.HasValue)
                    txtDDI.Int = (int)pa�s.DDI;
                else
                    txtDDI.Text = "";
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            pa�s.Nome = txtNome.Text.Trim();
        }

        private void txtSigla_Validated(object sender, EventArgs e)
        {
            string sigla = txtSigla.Text.Trim();

            if (sigla.Length > 0)
                pa�s.Sigla = txtSigla.Text;
            else
                pa�s.Sigla = null;
        }

        private void txtDDI_Validated(object sender, EventArgs e)
        {
            if (txtDDI.Int > 0)
                pa�s.DDI = (uint)txtDDI.Int;
            else
                pa�s.DDI = null;
        }
    }
}

