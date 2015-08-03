using System;
using System.Collections;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Tabela de refer�ncias
	/// </summary>
	public class TabelaRefer�ncias : IEnumerable, ICollection
	{
		private ArrayList refer�ncias = new ArrayList();

		#region Singleton

		private static TabelaRefer�ncias inst�ncia = null;

		private TabelaRefer�ncias() {}

		public static TabelaRefer�ncias Inst�ncia
		{
			get
			{
				if (inst�ncia == null)
					inst�ncia = new TabelaRefer�ncias();

				return inst�ncia;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return refer�ncias.GetEnumerator();
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get { return true; }
		}

		public int Count
		{
			get { return refer�ncias.Count; }
		}

		public void CopyTo(Array array, int index)
		{
			refer�ncias.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get { return refer�ncias.SyncRoot; }
		}

		#endregion

		/// <summary>
		/// Adiciona uma refer�ncia � tabela
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser adicionada</param>
		public void AdicionarRefer�ncia(Refer�ncia refer�ncia)
		{
			lock (refer�ncias.SyncRoot)
			{
				// Verificar exist�ncia da refer�ncia
				if (refer�ncias.BinarySearch(refer�ncia) >= 0)
					throw new Exception("Refer�ncia n�o � �nica!");

				refer�ncias.Add(refer�ncia);
				refer�ncias.Sort();
			}
		}

		/// <summary>
		/// Remove uam refer�ncia da tabela
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser removida</param>
		public void RemoverRefer�ncia(Refer�ncia refer�ncia)
		{
			lock (refer�ncias.SyncRoot)
			{
				int i = refer�ncias.BinarySearch(refer�ncia);

				if (i < 0)
					throw new Exception("Elemento n�o encontrado!");

				refer�ncias.RemoveAt(i);
			}
		}

		/// <summary>
		/// Refer�ncia na posi��o i
		/// </summary>
		public Refer�ncia this [int i]
		{
			get
			{
				return (Refer�ncia) refer�ncias[i];
			}
		}

		/// <summary>
		/// Refer�ncia baseada em objeto (utilizando IComparable)
		/// </summary>
		public Refer�ncia this [object obj]
		{
			get
			{
				// Encontrar a refer�ncia
				lock (refer�ncias.SyncRoot)
				{
					int i = refer�ncias.BinarySearch(obj);

					if (i < 0)
						return null;

					return (Refer�ncia) refer�ncias[i];
				}
			}
		}
	}
}
