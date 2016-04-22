using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Estoque.Entrada;
using Entidades.Relacionamento;
using System;

namespace Apresentação.Estoque.Entrada
{
    public partial class BaseEditarEntrada : Financeiro.BaseEditarRelacionamento
    {
        public BaseEditarEntrada()
        {
            InitializeComponent();
        }

        public override void Abrir(Relacionamento relacionamento)
        {
            base.Abrir(relacionamento);

            DefinirTítulo(relacionamento);

            relacionamento.DepoisDeCadastrar += relacionamento_DepoisDeCadastrar;
        }

        private void DefinirTítulo(Relacionamento relacionamento)
        {
            título.Descrição = "";
            
            if (relacionamento.Cadastrado)
                título.Título = "Relacionar entrada nr. " + relacionamento.Código.ToString();
            else
                título.Título = "Novo documento de entrada";
        }

        public override Relacionamento ReobterRelacionamento()
        {
            return Entidades.Estoque.Entrada.Obter((ulong) Relacionamento.Código);
        }

        void relacionamento_DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            DefinirTítulo(entidade as Relacionamento);
        }

        protected override Impressão.TipoDocumento TipoDocumento
        {
            get { return Impressão.TipoDocumento.Entrada; }
        }

        protected override void InserirDocumento(JanelaImpressão j)
        {
            RelatorioEntrada relatório = new RelatorioEntrada();

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
