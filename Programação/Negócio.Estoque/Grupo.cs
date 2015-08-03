using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Grupo de mercadorias
	/// </summary>
	public class Grupo : IEnumerable, ISujeitoImposto
	{
		protected string	nome;
		private Hashtable	referências;
		private Hashtable	impostos;

		/// <summary>
		/// Constrói um grupo de referências
		/// </summary>
		public Grupo()
		{
			referências = new Hashtable();
			impostos    = new Hashtable();
		}

		#region IEnumerable

		public IEnumerator GetEnumerator()
		{
			return referências.GetEnumerator();
		}

		#endregion

		#region Adição/Remoção/Consulta de impostos

		/// <summary>
		/// Adiciona imposto à mercadoria
		/// </summary>
		/// <param name="imposto">Imposto a ser adicionado</param>
		public void AdicionarImposto(Imposto imposto)
		{
			lock (impostos.SyncRoot)
			{
				impostos.Add(imposto.Nome, imposto);
			}
		}

		/// <summary>
		/// Remove imposto da mercadoria
		/// </summary>
		/// <param name="imposto">Imposto a ser removido</param>
		public void RemoverImposto(Imposto imposto)
		{
			lock (impostos.SyncRoot)
			{
				impostos.Remove(imposto.Nome);
			}
		}

		/// <summary>
		/// Obtém lista de impostos
		/// </summary>
		public virtual Imposto[] Impostos
		{
			get
			{
				Imposto[] vetor = new Imposto[impostos.Count];
				int i = 0;

				foreach (Imposto imposto in impostos)
					vetor[i] = imposto;

				return vetor;
			}
		}

		#endregion

		/// <summary>
		/// Adiciona uma referência ao grupo
		/// </summary>
		/// <param name="referência">Referência a ser adicionada</param>
		public void AdicionarReferência(Referência referência)
		{
			if (!ValidarReferência(referência))
				throw new Exception("Referência inválida para este grupo.");

			referências.Add(referência, referência);
			referência.AdicionarGrupo(this);
		}

		/// <summary>
		/// Remove referência do grupo
		/// </summary>
		/// <param name="referência">Referência a ser removida</param>
		public void RemoverReferência(Referência referência)
		{
			/* Teoricamente, não deveria ocorrer a remoção
			 * de uma referência a partir de um objeto que
			 * não esteja na tabela hash. Porém utilizaremos
			 * a técnica de programação defensiva.
			 */
			Referência local;

			local = (Referência) referências[referência];

			referências.Remove(referência);

			if (local != referência)
				local.RemoverGrupo(this);

			referência.RemoverGrupo(this);
		}

		/// <summary>
		/// Nome do grupo
		/// </summary>
		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		/// <summary>
		/// Verifica se uma referência é válida para pertencer
		/// ao grupo.
		/// </summary>
		/// <param name="referência">Referência a ser validada</param>
		/// <returns>Verdadeiro se a referência for válida</returns>
		/// <remarks>Esta função é chamada por AdicionarReferência</remarks>
		protected virtual bool ValidarReferência(Referência referência)
		{
			/* Esta função pode ser sobreposta.
			 * Padrão = verdadeiro
			 */
			return true;
		}
	}
}
