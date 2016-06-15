using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Relacionamento
{
    [Serializable, DbTransação]
	public abstract class Relacionamento : DbManipulaçãoAutomática
	{
        public event DbManipulaçãoHandler AoAlterarTabela;

        [DbRelacionamento("código", "tabela")]
        protected Tabela tabela;

		[DbAtributo(TipoAtributo.Ignorar)]
		private HistóricoRelacionamento	itens = null;

        [DbRelacionamento("codigo", "digitadopor")]
        protected Pessoa.Funcionário digitadopor;

		[DbChavePrimária(true)]
		protected long codigo;

        protected DateTime data;

        [DbColuna("observacoes")]
        protected string observações;
        
        public delegate void AntesDeCadastrarItemCallback(HistóricoRelacionamentoItem item, out bool cancelar);

        public event AntesDeCadastrarItemCallback AntesDeCadastrarItem;

        public string Observações
        {
            get { return observações; }
            set { observações = value; DefinirDesatualizado(); }
        }

        public Tabela TabelaPreço
        {
            get { return tabela; }
            set
            {
                if (!PermiteAlteraçãoTabela())
                    throw new Exception("Tabela de preços não pode ser alterada após inserção de itens.");

                tabela = value; DefinirDesatualizado();

                if (AoAlterarTabela != null)
                    AoAlterarTabela(this);
            }
        }

        public virtual bool PermiteAlteraçãoTabela()
        {
            return Itens.Count == 0;
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; DefinirDesatualizado(); }
        }

        public HistóricoRelacionamento Itens
        {
            get
            {
                if (itens == null)
                {
                    if (Cadastrado)
                    {
                        ArrayList listaComÚnicoElemento = new ArrayList();
                        listaComÚnicoElemento.Add(this);
                        RecuperarColeções(listaComÚnicoElemento);
                    }
                    else
                        itens = ConstruirItens();
                }

                return itens;
            }
        }

        protected abstract HistóricoRelacionamento ConstruirItens();

		public long Código
		{
			get { return codigo; }
			set
			{
                DefinirDesatualizado();
				codigo = value;
			}
		}

        public Pessoa.Funcionário DigitadoPor
        {
            get { return digitadopor; }
            set
            {
                DefinirDesatualizado();
                digitadopor = value;
            }
        }

		public Relacionamento()
		{
		}

        internal virtual void RecuperarColeção(IDbCommand  cmd)
        {
            Itens.Recuperar(cmd);
        }

        protected static void RecuperarColeções(IEnumerable entidades)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    try
                    {
                        foreach (Relacionamento r in entidades)
                        {
                            r.itens = r.ConstruirItens();
                            r.RecuperarColeção(cmd);
                        }
                    }
                    finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }
        }
        
        public static List<long> ObterCódigos(List<Relacionamento> lista)
        {
            List<long> códigos = new List<long>(lista.Count);

            foreach (Relacionamento r in lista)
                códigos.Add(r.Código);

            return códigos;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            data = DadosGlobais.Instância.HoraDataAtual;

            base.Cadastrar(cmd);
        }

        internal void DispararAntesDeCadastrarItem(HistóricoRelacionamentoItem novoItem)
        {
            if (AntesDeCadastrarItem != null)
            {
                bool cancelar;

                AntesDeCadastrarItem(novoItem, out cancelar);

                if (cancelar)
                    throw new Acesso.Comum.Exceções.OperaçãoCancelada(novoItem);
            }
        }

        public virtual void LiberarRecursos()
        {
            if (Cadastrado)
                itens = null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return obj.GetType() == this.GetType()
            && ((Relacionamento) obj).Código == this.Código;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
