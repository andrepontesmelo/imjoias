using System;
using Acesso.Comum;
using System.Collections.Generic;
using System.Data;
using Entidades.Acerto;
using System.Collections;
using Entidades.Configuração;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Não chama Consignado porque é genérico para saída, retorno e venda também!
	/// </summary>
    [Serializable, DbTransação]
	public abstract class Relacionamento : Acesso.Comum.DbManipulaçãoAutomática
	{
        public event DbManipulação.DbManipulaçãoHandler AoAlterarTabela;

        [DbRelacionamento("código", "tabela")]
        protected Tabela tabela;

		// Atributos
		[DbAtributo(TipoAtributo.Ignorar)]
		private HistóricoRelacionamento	itens = null;

        [DbRelacionamento("codigo", "digitadopor")]
        protected Pessoa.Funcionário digitadopor;

		[DbChavePrimária(true)]
		protected long                      codigo;

        protected DateTime                  data;

        [DbColuna("observacoes")]
        protected string observações;

        
        public delegate void AntesDeCadastrarItemCallback(HistóricoRelacionamentoItem item, out bool cancelar);

        /// <summary>
        /// Disparado antes de cadastrar um item.
        /// </summary>
        public event AntesDeCadastrarItemCallback AntesDeCadastrarItem;

        #region Propriedades

        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }




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

        /// <summary>
        /// Verifica se é possível alterar a tabela de preços.
        /// </summary>
        /// <returns>Se é permitido a alteração da tabela de preços.</returns>
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


        #endregion

        //// Delegações
        //public delegate Entidades.Relacionamento.Relacionamento ObterRelacionamento(long código);

		public Relacionamento()
		{
            /* Deve-se tomar cuidado em atribuições na construtoras básicas de entidade.
             * Neste comentado abaixo, o Mapear, ao gerar um objeto recem obtido do BD
             * estava mudando a data. Este não era o problema, porque a data original seria carregada
             * por cima depois. Porém a atrição abaixo torna a entidade recem obtida do bd Desatualizada.
             */
            //this.Data = DateTime.Now;

            /* André, descordo do seu comentário acima. O mapear atribui "Cadastrado"
             * e "Atualizado" ao término do mapear. Estes valores são inicialmente
             * sempre falsos, sendo estabelecidos somente após construir o objeto.
             * -- Júlio, 12/07/2006
             */
		}

        /// <summary>
        /// Deve ser chamado pelo RecuperarColeções()
        /// </summary>
        internal virtual void RecuperarColeção(IDbCommand  cmd)
        {
            Itens.Recuperar(cmd);
        }

        /// <summary>
        /// Recupera coleções de um conjunto de relacionamentos.
        /// </summary>
        protected static void RecuperarColeções(IEnumerable entidades)
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    /* As coleções requerem acessar outras tabelas, tais como
                     * Mercadoria e Pessoa. Se uma dessas entidades utilizarem a
                     * mesma conexão, por estarem na mesma Thread, elas não terão
                     * acesso ao DataReader.
                     */
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    try
                    {
                        foreach (Entidades.Relacionamento.Relacionamento r in entidades)
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
        
        public static List<long> ObterCódigos(List<Entidades.Relacionamento.Relacionamento> lista)
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

        /// <summary>
        /// Dispara evento antes de cadastrar um item.
        /// </summary>
        /// <param name="novoItem">Item a ser cadastrado.</param>
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

        /// <summary>
        /// Libera recursos computacionais que podem ser recuperados
        /// posteriormente.
        /// </summary>
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
