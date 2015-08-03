using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class EditarRamal : Apresentação.Formulários.JanelaExplicativa
    {
        private Entidades.Pessoa.Funcionário funcionário;

        public EditarRamal(Entidades.Pessoa.Funcionário funcionário)
        {
            InitializeComponent();

            this.funcionário = funcionário;

            txtFuncionário.Text = funcionário.Nome;
            txtRamal.Int = funcionário.Ramal;
        }

        private void EditarRamal_Load(object sender, EventArgs e)
        {
            txtRamal.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            funcionário.AtualizarRamal(txtRamal.Int);
        }
    }
}

