using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Estoque.Entrada
{
    public partial class BaseEditarEntrada : Apresentação.Financeiro.BaseEditarRelacionamento
    {
        public BaseEditarEntrada()
        {
            InitializeComponent();
        }

        public override void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            base.Abrir(relacionamento);

            DefinirTítulo(relacionamento);

            relacionamento.DepoisDeCadastrar += relacionamento_DepoisDeCadastrar;
        }

        private void DefinirTítulo(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            título.Descrição = "";
            
            if (relacionamento.Cadastrado)
                título.Título = "Relacionar entrada nr. " + relacionamento.Código.ToString();
            else
                título.Título = "Novo documento de entrada";
        }

        void relacionamento_DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            DefinirTítulo(entidade as Entidades.Relacionamento.Relacionamento);
        }

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get { return Apresentação.Impressão.TipoDocumento.Entrada; }
        }
    }
}
