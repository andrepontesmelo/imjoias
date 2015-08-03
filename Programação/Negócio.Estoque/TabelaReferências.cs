using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Tabela de referências
	/// </summary>
	public class TabelaReferências : IEnumerable, ICollection
	{
		private ArrayList referências = new ArrayList();

		#region Singleton

		private static TabelaReferências instância = null;

		private TabelaReferências() {}

		public static TabelaReferências Instância
		{
			get
			{
				if (instância == null)
					instância = new TabelaReferências();

				return instância;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return referências.GetEnumerator();
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get { return true; }
		}

		public int Count
		{
			get { return referências.Count; }
		}

		public void CopyTo(Array array, int index)
		{
			referências.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get { return referências.SyncRoot; }
		}

		#endregion

		/// <summary>
		/// Adiciona uma referência à tabela
		/// </summary>
		/// <param name="referência">Referência a ser adicionada</param>
		public void AdicionarReferência(Referência referência)
		{
			lock (referências.SyncRoot)
			{
				// Verificar existência da referência
				if (referências.BinarySearch(referência) >= 0)
					throw new Exception("Referência não é única!");

				referências.Add(referência);
				referências.Sort();
			}
		}

		/// <summary>
		/// Remove uam referência da tabela
		/// </summary>
		/// <param name="referência">Referência a ser removida</param>
		public void RemoverReferência(Referência referência)
		{
			lock (referências.SyncRoot)
			{
				int i = referências.BinarySearch(referência);

				if (i < 0)
					throw new Exception("Elemento não encontrado!");

				referências.RemoveAt(i);
			}
		}

		/// <summary>
		/// Referência na posição i
		/// </summary>
		public Referência this [int i]
		{
			get
			{
				return (Referência) referências[i];
			}
		}

		/// <summary>
		/// Referência baseada em objeto (utilizando IComparable)
		/// </summary>
		public Referência this [object obj]
		{
			get
			{
				// Encontrar a referência
				lock (referências.SyncRoot)
				{
					int i = referências.BinarySearch(obj);

					if (i < 0)
						return null;

					return (Referência) referências[i];
				}
			}
		}
	}
}
