using System;
using System.Collections.Generic;
using System.Collections;
using Acesso.Comum;
using System.Data;
using System.Text;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// Cole��o de ItemRelacionado
	/// Trata-se de um ArrayList personalizado.
	/// Um Entidades.Relacionado cont�m um objeto Cole��oItemRelacionado
	/// </summary>
	[Serializable]
	public abstract class Hist�ricoRelacionamento : DbManipula��oSimples, ICollection
	{
        /// <summary>
        /// Venda, Retorno ou Sa�da
        /// </summary>
        private Relacionamento entidadePai;

		protected List<Hist�ricoRelacionamentoItem> lista;

		/// <summary>
		/// Constr�i um ItemRelacionado de tipo espec�fico
		/// </summary>
        protected abstract Hist�ricoRelacionamentoItem ConstruirItemHist�rico(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice);

        protected virtual SaquinhoRelacionamento ConstuirItemAgrupado(Mercadoria.Mercadoria mercadoria, double quantidade, double indice)
        {
            return new SaquinhoRelacionamento(mercadoria, quantidade, indice);
        }

		public Hist�ricoRelacionamento(Relacionamento pai)
		{
            lista = new List<Hist�ricoRelacionamentoItem>();
            this.entidadePai = pai;
		}

		/// <summary>
		/// Adiciona novo item � cole��o. N�o grava no Bd
		/// </summary>
		/// <param name="item">Item a ser adicionado.</param>
		public virtual void Adicionar(Hist�ricoRelacionamentoItem item)
		{
			lista.Add(item);
		}


        public virtual List<Hist�ricoRelacionamentoItem> RelacionarV�rios(List<Hist�ricoRelacionamentoItem> itens)
        {
            List<Hist�ricoRelacionamentoItem> novosItens = new List<Hist�ricoRelacionamentoItem>();

            foreach (Hist�ricoRelacionamentoItem i in itens)
                novosItens.Add(Relacionar(i.Mercadoria, i.Quantidade, i.�ndice));

            return novosItens;
        }

        /// <summary>
        /// Adiciona um item de relacionamento, seja inser��o, seja remo��o.
        /// J� cadastra no banco de dados.
        /// </summary>
        public virtual Hist�ricoRelacionamentoItem Relacionar(Mercadoria.Mercadoria m, double quantidade, double �ndice)
        {
            Hist�ricoRelacionamentoItem novoItem;

            DateTime agora = Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual;

            novoItem = ConstruirItemHist�rico(m, quantidade, agora, Entidades.Pessoa.Funcion�rio.Funcion�rioAtual, �ndice);

            // Este evento pode disparar Opera��oCancelada.
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

            foreach (Hist�ricoRelacionamentoItem item in lista)
            {
                Saquinho novoSaquinho = ConstuirItemAgrupado(item.Mercadoria, item.Quantidade, item.�ndice);
                Saquinho saquinhoExistente;

                if (hashAgrupado.Contains(novoSaquinho.Identifica��oAgrup�vel()))
                {
                    // Saquinho j� existe.
                    saquinhoExistente = (Saquinho) hashAgrupado[novoSaquinho.Identifica��oAgrup�vel()];
                    saquinhoExistente.Quantidade += item.Quantidade;
                }
                else
                {
                    hashAgrupado.Add(novoSaquinho.Identifica��oAgrup�vel(), novoSaquinho);
                }
            }

            // Transforma a hash em uma lista
            ArrayList listaSaquinhos = new ArrayList(hashAgrupado.Count);
            foreach (SaquinhoRelacionamento s in hashAgrupado.Values)
            {
                // Os itens que entraram mas foram totalmente retirados n�o devem entrar:
                if (s.Quantidade != 0)
                    listaSaquinhos.Add(s);
                
                
                if (s.Quantidade < 0)
                    erroAlteracaoConcorrente = true;
            }

            return listaSaquinhos;
        }

        /// <summary>
        /// Calcula o pre�o total das mercadorias.
        /// </summary>
        /// <returns>Pre�o total.</returns>
        public double CalcularPre�o(double cota��o)
        {
            double total = 0;
            checked
            {
                foreach (Hist�ricoRelacionamentoItem item in lista)
                {
                    total += Math.Round(item.Mercadoria.CalcularPre�o(cota��o) * item.Quantidade, 2);
                }
            }

            return total;
        }


        private enum Ordem { ordemSa�da, ordemRefer�ncia, ordemPeso, ordemQuantidade, ordemData, ordemFuncion�rio, ordemC�digo, ordem�ndice }

        /// <summary>
        /// Recupera cole��o do banco de dados.
        /// </summary>
        /// <param name="cmd">Comando a ser utilizado.</param>
        public virtual void Recuperar(IDbCommand cmd)
        {
            IDataReader leitor = null;

            cmd.CommandText = "SELECT " + TabelaPai + ", referencia, peso, quantidade, data, funcionario, codigo, indice FROM " + Tabela + " WHERE " +
                TabelaPai + " = " + DbTransformar(entidadePai.C�digo)
                + " ORDER by data";


            lock (cmd.Connection)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(cmd.Connection);

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {

                        while (leitor.Read())
                        {
                            string refer�ncia = leitor.GetString((int)Ordem.ordemRefer�ncia);
                            double peso = leitor.GetDouble((int)Ordem.ordemPeso);
                            double quantidade = leitor.GetDouble((int)Ordem.ordemQuantidade);
                            double �ndice = leitor.GetDouble((int)Ordem.ordem�ndice);
                            DateTime data = leitor.GetDateTime((int)Ordem.ordemData);
                            int c�digo = leitor.GetInt32((int)Ordem.ordemC�digo);
                            int c�digoFuncion�rio = leitor.GetInt32((int)Ordem.ordemFuncion�rio);

                            // Ajusta o �ndice na mercadoria 
                            Entidades.Mercadoria.Mercadoria m = Mercadoria.Mercadoria.ObterMercadoria(refer�ncia, peso, entidadePai.TabelaPre�o);

                            m.�ndice = �ndice;

                            //if (m.DePeso)
                            //    m.Coeficiente = �ndice / peso;
                            //else
                            //    m.Coeficiente = �ndice;

                            Hist�ricoRelacionamentoItem item = ConstruirItemHist�rico(
                                m,
                                quantidade,
                                data,
                                c�digoFuncion�rio,
                                �ndice
                                );

                            item.C�digo = c�digo;

                            Adicionar(item);
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(cmd.Connection);
                }
            }
        }

        /// <summary>
        /// Nome da tabela. saidaitem, retornoitem ou vendaitem, 
        /// </summary>
        protected abstract string Tabela { get; }
        
        /// <summary>
        /// Venda, Retorno ou Sa�da
        /// </summary>
        protected abstract string TabelaPai { get; }
        
    }

    public class Altera��oConcorrente�Venda : Exception
    {
    }
}
