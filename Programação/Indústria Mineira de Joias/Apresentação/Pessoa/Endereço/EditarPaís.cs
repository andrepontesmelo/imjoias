using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// Edita os dados cadastrais de um país.
    /// </summary>
    public partial class EditarPaís : Apresentação.Formulários.JanelaExplicativa
    {
        public País país;

        public EditarPaís()
        {
            InitializeComponent();

            país = new País();
        }

        public EditarPaís(País país)
        {
            InitializeComponent();

            País = país;
        }

        public País País
        {
            get { return país; }
            set
            {
                país = value;

                txtNome.Text = país.Nome;
                txtSigla.Text = país.Sigla != null ? país.Sigla : "";

                if (país.DDI.HasValue)
                    txtDDI.Int = (int)país.DDI;
                else
                    txtDDI.Text = "";
            }
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            país.Nome = txtNome.Text.Trim();
        }

        private void txtSigla_Validated(object sender, EventArgs e)
        {
            string sigla = txtSigla.Text.Trim();

            if (sigla.Length > 0)
                país.Sigla = txtSigla.Text;
            else
                país.Sigla = null;
        }

        private void txtDDI_Validated(object sender, EventArgs e)
        {
            if (txtDDI.Int > 0)
                país.DDI = (uint)txtDDI.Int;
            else
                país.DDI = null;
        }
    }
}

