using System;
using System.Collections.Generic;
using System.Collections;
using Acesso.Comum;
using System.Data;
using System.Text;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Coleção de ItemRelacionado
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Relacionado contém um objeto ColeçãoItemRelacionado
	/// </summary>
	[Serializable]
	public abstract class HistóricoRelacionamento : DbManipulaçãoSimples, ICollection
	{
        /// <summary>
        /// Venda, Retorno ou Saída
        /// </summary>
        private Relacionamento entidadePai;

		protected List<HistóricoRelacionamentoItem> lista;

		/// <summary>
		/// Constrói um ItemRelacionado de tipo específico
		/// </summary>
        protected abstract HistóricoRelacionamentoItem ConstruirItemHistórico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice);

        protected virtual SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria.Mercadoria mercadoria, double quantidade, double indice)
        {
            return new SaquinhoRelacionamento(mercadoria, quantidade, indice);
        }

		public HistóricoRelacionamento(Relacionamento pai)
		{
            lista = new List<HistóricoRelacionamentoItem>();
            this.entidadePai = pai;
		}

		/// <summary>
		/// Adiciona novo item à coleção. Não grava no Bd
		/// </summary>
		/// <param name="item">Item a ser adicionado.</param>
		public virtual void Adicionar(HistóricoRelacionamentoItem item)
		{
			lista.Add(item);
		}


        public virtual List<HistóricoRelacionamentoItem> RelacionarVários(List<HistóricoRelacionamentoItem> itens)
        {
            List<HistóricoRelacionamentoItem> novosItens = new List<HistóricoRelacionamentoItem>();

            foreach (HistóricoRelacionamentoItem i in itens)
                novosItens.Add(Relacionar(i.Mercadoria, i.Quantidade, i.Índice));

            return novosItens;
        }

        /// <summary>
        /// Adiciona um item de relacionamento, seja inserção, seja remoção.
        /// Já cadastra no banco de dados.
        /// </summary>
        public virtual HistóricoRelacionamentoItem Relacionar(Mercadoria.Mercadoria m, double quantidade, double índice)
        {
            HistóricoRelacionamentoItem novoItem;

            DateTime agora = Configuração.DadosGlobais.Instância.HoraDataAtual;

            novoItem = ConstruirItemHistórico(m, quantidade, agora, Entidades.Pessoa.Funcionário.FuncionárioAtual, índice);

            // Este evento pode disparar OperaçãoCancelada.
            entidadePai.DispararAntesDeCadastrarItem(novoItem);

            if (!entidadePai.Cadastrado)
                entidadePai.Cadastrar();
            
            novoItem.Cadastrar();

            Adicionar(novoItem);

            return novoItem;
        }

		#region ICollection Members
		public int Count
		{
			get
			{
                return lista.Count;
			}
		}

		
		public bool IsSynchronized
		{
			get
			{
				return true;
			}
		}

		public object SyncRoot
		{
			get
			{
				return entidadePai;
			}
		}

		public void CopyTo(Array array, int index)
		{
			//hashMercadoriaItemRelacionado.CopyTo(array, index);
            throw new NotImplementedException("CopyTo() do ColecaoItemRelacionado");
        }

        #endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return lista.GetEnumerator();
		}

		#endregion

        public ArrayList ObterSaquinhosAgrupadosOrdenados(out bool erroAlteracaoConcorrente)
        {
            ArrayList listaOrdenada = ObterSaquinhosAgrupados(out erroAlteracaoConcorrente);

            listaOrdenada.Sort();

            return listaOrdenada;
        }

        public ArrayList ObterSaquinhosAgrupados(out bool erroAlteracaoConcorrente)
        {
            erroAlteracaoConcorrente = false;
            Hashtable hashAgrupado = new Hashtable(lista.Count);

            foreach (HistóricoRelacionamentoItem item in lista)
            {
                Saquinho novoSaquinho = ConstuirItemAgrupado(item.Mercadoria, item.Quantidade, item.Índice);
                Saquinho saquinhoExistente;

                if (hashAgrupado.Contains(novoSaquinho.IdentificaçãoAgrupável()))
                {
                    // Saquinho já existe.
                    saquinhoExistente = (Saquinho) hashAgrupado[novoSaquinho.IdentificaçãoAgrupável()];
                    saquinhoExistente.Quantidade += item.Quantidade;
                }
                else
                {
                    hashAgrupado.Add(novoSaquinho.IdentificaçãoAgrupável(), novoSaquinho);
                }
            }

            // Transforma a hash em uma lista
            ArrayList listaSaquinhos = new ArrayList(hashAgrupado.Count);
            foreach (SaquinhoRelacionamento s in hashAgrupado.Values)
            {
                // Os itens que entraram mas foram totalmente retirados não devem entrar:
                if (s.Quantidade != 0)
                    listaSaquinhos.Add(s);
                
                
                if (s.Quantidade < 0)
                    erroAlteracaoConcorrente = true;
            }

            return listaSaquinhos;
        }

        /// <summary>
        /// Calcula o preço total das mercadorias.
        /// </summary>
        /// <returns>Preço total.</returns>
        public double CalcularPreço(double cotação)
        {
            double total = 0;
            checked
            {
                foreach (HistóricoRelacionamentoItem item in lista)
                {
                    total += Math.Round(item.Mercadoria.CalcularPreço(cotação) * item.Quantidade, 2);
                }
            }

            return total;
        }


        private enum Ordem { ordemSaída, ordemReferência, ordemPeso, ordemQuantidade, ordemData, ordemFuncionário, ordemCódigo, ordemÍndice }

        /// <summary>
        /// Recupera coleção do banco de dados.
        /// </summary>
        /// <param name="cmd">Comando a ser utilizado.</param>
        public virtual void Recuperar(IDbCommand cmd)
        {
            IDataReader leitor = null;

            cmd.CommandText = "SELECT " + TabelaPai + ", referencia, peso, quantidade, data, funcionario, codigo, indice FROM " + Tabela + " WHERE " +
                TabelaPai + " = " + DbTransformar(entidadePai.Código)
                + " ORDER by data";


            lock (cmd.Connection)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(cmd.Connection);

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {

                        while (leitor.Read())
                        {
                            string referência = leitor.GetString((int)Ordem.ordemReferência);
                            double peso = leitor.GetDouble((int)Ordem.ordemPeso);
                            double quantidade = leitor.GetDouble((int)Ordem.ordemQuantidade);
                            double índice = leitor.GetDouble((int)Ordem.ordemÍndice);
                            DateTime data = leitor.GetDateTime((int)Ordem.ordemData);
                            int código = leitor.GetInt32((int)Ordem.ordemCódigo);
                            int códigoFuncionário = leitor.GetInt32((int)Ordem.ordemFuncionário);

                            // Ajusta o índice na mercadoria 
                            Entidades.Mercadoria.Mercadoria m = Mercadoria.Mercadoria.ObterMercadoria(referência, peso, entidadePai.TabelaPreço);

                            m.Índice = índice;

                            //if (m.DePeso)
                            //    m.Coeficiente = índice / peso;
                            //else
                            //    m.Coeficiente = índice;

                            HistóricoRelacionamentoItem item = ConstruirItemHistórico(
                                m,
                                quantidade,
                                data,
                                códigoFuncionário,
                                índice
                                );

                            item.Código = código;

                            Adicionar(item);
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(cmd.Connection);
                }
            }
        }

        /// <summary>
        /// Nome da tabela. saidaitem, retornoitem ou vendaitem, 
        /// </summary>
        protected abstract string Tabela { get; }
        
        /// <summary>
        /// Venda, Retorno ou Saída
        /// </summary>
        protected abstract string TabelaPai { get; }
        
    }

    public class AlteraçãoConcorrenteÀVenda : Exception
    {
    }
}
