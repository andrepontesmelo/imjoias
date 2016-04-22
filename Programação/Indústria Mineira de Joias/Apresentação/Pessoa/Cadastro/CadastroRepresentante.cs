using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class CadastroRepresentante : Apresentação.Pessoa.Cadastro.CadastroPessoa
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
                bool nãoPrecisaCriarRepresentante = false;

                try
                {
                    nãoPrecisaCriarRepresentante = base.Pessoa is Entidades.Pessoa.Representante;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                if (nãoPrecisaCriarRepresentante)
                    return base.Pessoa;
                else
                    return new Entidades.Pessoa.Representante((PessoaFísica)base.Pessoa);
            }
            set
            {
                if (!(value is Entidades.Pessoa.Representante))
                    base.Pessoa = new Entidades.Pessoa.Representante((PessoaFísica)value);
                else
                    base.Pessoa = value;
            }
        }
    }
}

