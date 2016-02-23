using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Estoque.Entrada;

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

        protected override void InserirDocumento(JanelaImpressão j)
        {
            RelatorioEntrada relatório = new Apresentação.Impressão.Relatórios.Estoque.Entrada.RelatorioEntrada();

            new Impressão.Relatórios.Entrada.ControleImpressãoEntrada().PrepararImpressão(relatório,
                (Entidades.Estoque.Entrada) Relacionamento);

            j.Título = "Impressão de entrada";
            j.Descrição = "";
            j.InserirDocumento(relatório, "Entrada");
        }

        protected override bool ValidarPermissãoDestravar()
        {
            throw new NotImplementedException();
        }
    }
}
