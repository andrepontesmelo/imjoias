using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class CadastroCliente : Apresentação.Pessoa.Cadastro.CadastroPessoa
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        public CadastroCliente(Entidades.Pessoa.Pessoa pessoa)
            : this()
        {
            Pessoa = pessoa;
        }

        public override Entidades.Pessoa.Pessoa Pessoa
        {
            get
            {
                return base.Pessoa;
            }
            set
            {
                base.Pessoa = value;

                cliente.Pessoa = value;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {

        }
    }
}

