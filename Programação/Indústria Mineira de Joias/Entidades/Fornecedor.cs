using System;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Acesso.Comum.Cache;
using System.Collections.Generic;

namespace Entidades
{
	/// <summary>
	/// Fornecedor de mercadorias.
	/// </summary>
	[Cacheável("ObterFornecedor", "ObterFornecedorPróximo", "ObterFornecedores")]	
	public class Fornecedor : DbManipulaçãoAutomática
	{
		// Atributos
		[DbChavePrimária(true), DbColuna("codigo")]
		private long código;

		private string nome;

        [DbColuna("comentarios")]
        private string comentários;

		// Propriedades
		public long Código
		{
			get { return código; }
		}

		public string Nome
		{
			get { return nome;	}
			set { 
				nome = value; 
			}
		}

        public string Comentários
        {
            get { return comentários; }
            set { comentários = value; }
        }

		public Fornecedor()
		{
		}

		public Fornecedor(int código, string nome)
		{
			this.código = código;
			this.nome = nome;
		}

        public static Dictionary<long, Fornecedor> hashFornecedor = new Dictionary<long, Fornecedor>();

        /// <summary>
        /// Obtém fornecedor por meio de seu código.
        /// Caso não tenha encontre o fornecedor, baixa todo o banco de dados para a hash.
        /// </summary>
        /// <param name="código">Código do fornecedor.</param>
        /// <returns>Entidade do fornecedor.</returns>
        public static Fornecedor ObterFornecedor(long código)
        {
            List<Fornecedor> lstFornecedor;

            Fornecedor f = null;

            if (!hashFornecedor.TryGetValue(código, out f))
            {
                lstFornecedor = Mapear<Fornecedor>("SELECT * FROM fornecedor");
                foreach (Fornecedor fornecedor in lstFornecedor)
                {
                    hashFornecedor[fornecedor.Código] = fornecedor;
                }
            }

            hashFornecedor.TryGetValue(código, out f);

            return f;
        }

        /// <summary>
        /// Obtém fornecedor por meio de seu nome.
        /// </summary>
        /// <param name="nome">Nome do fornecedor.</param>
        /// <returns>Entidade do fornecedor.</returns>
        public static Fornecedor ObterFornecedorPorNome(string nome)
        {
            return MapearÚnicaLinha<Fornecedor>("SELECT * FROM fornecedor WHERE nome = " + DbTransformar(nome));
        }

		/// <summary>
		/// Obtém lista de fornecedores
		/// SELECT * FROM `fornecedor` where nome like '%nome%'
		/// </summary>
		/// <param name="nome">palavra chave da busca</param>
		/// <param name="limite">quantidade máxima de fornecedores retornados</param>
		public static Fornecedor[] ObterFornecedores(string nome, int limite)
		{
            return Mapear<Fornecedor>("SELECT * "
            + "FROM fornecedor where nome = '" + nome + "' UNION select * from fornecedor where nome like '%" + nome + "%' LIMIT " + limite.ToString()).ToArray();
		}

        public static List<Fornecedor> ObterFornecedores()
        {
            return Mapear<Fornecedor>("SELECT * FROM fornecedor order by nome ");
        }
		
		/// <summary>
		/// Recupera o primeiro fornecedor com nome próximo
		/// </summary>
		/// <param name="chave">Chave a ser recuperada</param>
		/// <returns>nome do fornecedor</returns>
		public static Fornecedor ObterFornecedorPróximo(string chave)
		{
			Fornecedor[] lista = ObterFornecedores(chave, 1);
			
            if (lista.Length == 0) 
				return null;

            if (lista[0].Nome.Trim().ToLower().CompareTo(chave.Trim().ToLower()) == 0)
                return lista[0];
            else
                return null;
		}

        public override string ToString()
        {
            return nome;
        }
	}
}
