using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Cadastro
{
    public partial class EditarRamal : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Entidades.Pessoa.Funcion�rio funcion�rio;

        public EditarRamal(Entidades.Pessoa.Funcion�rio funcion�rio)
        {
            InitializeComponent();

            this.funcion�rio = funcion�rio;

            txtFuncion�rio.Text = funcion�rio.Nome;
            txtRamal.Int = funcion�rio.Ramal;
        }

        private void EditarRamal_Load(object sender, EventArgs e)
        {
            txtRamal.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            funcion�rio.AtualizarRamal(txtRamal.Int);
        }
    }
}

