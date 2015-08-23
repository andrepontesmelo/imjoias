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
	[Cache�vel("ObterFornecedor", "ObterFornecedorPr�ximo", "ObterFornecedores")]	
	public class Fornecedor : DbManipula��oAutom�tica
	{
		// Atributos
		[DbChavePrim�ria(true), DbColuna("codigo")]
		private long c�digo;

		private string nome;

        [DbColuna("comentarios")]
        private string coment�rios;

		// Propriedades
		public long C�digo
		{
			get { return c�digo; }
		}

		public string Nome
		{
			get { return nome;	}
			set { 
				nome = value; 
			}
		}

        public string Coment�rios
        {
            get { return coment�rios; }
            set { coment�rios = value; }
        }

		public Fornecedor()
		{
		}

		public Fornecedor(int c�digo, string nome)
		{
			this.c�digo = c�digo;
			this.nome = nome;
		}

        public static Dictionary<long, Fornecedor> hashFornecedor = new Dictionary<long, Fornecedor>();

        /// <summary>
        /// Obt�m fornecedor por meio de seu c�digo.
        /// Caso n�o tenha encontre o fornecedor, baixa todo o banco de dados para a hash.
        /// </summary>
        /// <param name="c�digo">C�digo do fornecedor.</param>
        /// <returns>Entidade do fornecedor.</returns>
        public static Fornecedor ObterFornecedor(long c�digo)
        {
            List<Fornecedor> lstFornecedor;

            Fornecedor f = null;

            if (!hashFornecedor.TryGetValue(c�digo, out f))
            {
                lstFornecedor = Mapear<Fornecedor>("SELECT * FROM fornecedor");
                foreach (Fornecedor fornecedor in lstFornecedor)
                {
                    hashFornecedor[fornecedor.C�digo] = fornecedor;
                }
            }

            hashFornecedor.TryGetValue(c�digo, out f);

            return f;
        }

        /// <summary>
        /// Obt�m fornecedor por meio de seu nome.
        /// </summary>
        /// <param name="nome">Nome do fornecedor.</param>
        /// <returns>Entidade do fornecedor.</returns>
        public static Fornecedor ObterFornecedorPorNome(string nome)
        {
            return Mapear�nicaLinha<Fornecedor>("SELECT * FROM fornecedor WHERE nome = " + DbTransformar(nome));
        }

		/// <summary>
		/// Obt�m lista de fornecedores
		/// SELECT * FROM `fornecedor` where nome like '%nome%'
		/// </summary>
		/// <param name="nome">palavra chave da busca</param>
		/// <param name="limite">quantidade m�xima de fornecedores retornados</param>
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
		/// Recupera o primeiro fornecedor com nome pr�ximo
		/// </summary>
		/// <param name="chave">Chave a ser recuperada</param>
		/// <returns>nome do fornecedor</returns>
		public static Fornecedor ObterFornecedorPr�ximo(string chave)
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
