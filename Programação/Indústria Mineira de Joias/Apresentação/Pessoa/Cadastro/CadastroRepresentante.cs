using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Cadastro
{
    public partial class CadastroRepresentante : Apresenta��o.Pessoa.Cadastro.CadastroPessoa
    {
        public CadastroRepresentante()
        {
            InitializeComponent();
        }

        public CadastroRepresentante(Representante representante)
            : base(representante)
        {
            InitializeComponent();
        }

        public override Entidades.Pessoa.Pessoa Pessoa
        {
            get
            {
                bool n�oPrecisaCriarRepresentante = false;

                try
                {
                    n�oPrecisaCriarRepresentante = base.Pessoa is Entidades.Pessoa.Representante;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                if (n�oPrecisaCriarRepresentante)
                    return base.Pessoa;
                else
                    return new Entidades.Pessoa.Representante((PessoaF�sica)base.Pessoa);
            }
            set
            {
                if (!(value is Entidades.Pessoa.Representante))
                    base.Pessoa = new Entidades.Pessoa.Representante((PessoaF�sica)value);
                else
                    base.Pessoa = value;
            }
        }
    }
}

