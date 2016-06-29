using System;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class CadastroCliente : CadastroPessoa
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

