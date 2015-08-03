using System;
using System.Collections;
using Entidades;
using Entidades.Mercadoria;

namespace Apresentação.Álbum.Edição
{
	/// <summary>
	/// Summary description for ColetorFornecedor.
	/// </summary>
	public class ColetorFornecedor : Apresentação.Formulários.Consultas.Coletor
	{
		// Constantes
		private const int limite = 10;

		// Atributos
		private ListViewFornecedor lst;
			
		/// <summary>
		/// Constrói o coletor de mercadorias
		/// </summary>
		public ColetorFornecedor(ListViewFornecedor lst)
		{
			this.lst = lst;
		}

		/// <summary>
		/// Recupera dados do banco de dados
		/// </summary>
		/// <param name="chave">Chave a ser procurada</param>
		protected override void Recuperar(string chave)
		{
			lock (lst)
			{
				IList fornecedores;
			
				// Obter mercadorias do controle
				fornecedores = Fornecedor.ObterFornecedores(chave, limite);

				lst.Mostrar(fornecedores);
			}
		}
		/// <summary>
		/// Recupera primeiro fornecedor somente
		/// </summary>
		/// <param name="chave">Chave de procura</param>
		/// <returns>Nome do fornecedor</returns>
		public string RecuperarPrimeiroSomente(string chave)
		{
            //if (Pesquisando || chave != Chave || lst.Items.Count == 0)
            //{
                Fornecedor fornecedor;

				Cancelar();

                fornecedor = Fornecedor.ObterFornecedorPróximo(chave);
				
				return fornecedor != null ? fornecedor.Nome : null;
            //}

            //// Se a pesquisa já tiver sido feita, recuperar da ListView
            //lock (lst)
            //{
            //    return lst.Items[0].Text;
            //}
		}


		/*
		/// <summary>
		/// Recupera primeira referência somente
		/// </summary>
		/// <param name="chave">Chave de procura</param>
		/// <returns>Referência</returns>
		public string RecuperarPrimeiroSomente(string chave)
		{
			if (Pesquisando || chave != Chave || lst.Items.Count == 0)
			{
				Cancelar();
				
				return Entidades.Álbum.Fornecedor.ObterReferênciaPróxima(chave);
			}

			// Se a pesquisa já tiver sido feita, recuperar da ListView
			lock (lst)
			{
				return lst.Items[0].Text;
			}
		}
		*/

	}
}
