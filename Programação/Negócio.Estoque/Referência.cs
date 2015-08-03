using System;
using System.Collections;

namespace Neg�cio.Estoque
{
	/// <summary>
	/// Refer�ncia de mercadoria
	/// </summary>
	public abstract class Refer�ncia : IComparable
	{
		private ArrayList	grupos = new ArrayList();
		private string		descri��o;

		public abstract override int GetHashCode();
		public abstract override string ToString();

		public virtual int CompareTo(object obj)
		{
			return GetHashCode() - obj.GetHashCode();
		}
		
		/// <summary>
		/// Constr�i novo objeto da mercadoria
		/// </summary>
		/// <returns>Novo objeto da mercadoria</returns>
		public abstract Mercadoria ConstruirMercadoria();

		/// <summary>
		/// Grupos aos quais a mercadoria pertence
		/// </summary>
		public Grupo [] Grupos
		{
			get
			{
				Grupo [] vetor = new Grupo[grupos.Count];

				grupos.CopyTo(vetor);

				return vetor;
			}
		}

		/// <summary>
		/// Adiciona um grupo a qual a mercadoria pertence
		/// </summary>
		internal void AdicionarGrupo(Grupo grupo)
		{
			lock (grupos.SyncRoot)
			{
				grupos.Add(grupo);
			}
		}

		/// <summary>
		/// Remove um grupo da mercadoria
		/// </summary>
		/// <param name="grupo"></param>
		internal void RemoverGrupo(Grupo grupo)
		{
			lock (grupos.SyncRoot)
			{
				grupos.Remove(grupo);
			}
		}

		/// <summary>
		/// Verifica se a refer�ncia est� contida no grupo
		/// </summary>
		internal bool Est�Contido(Grupo grupo)
		{
			return grupos.Contains(grupo);
		}

		/// <summary>
		/// Descri��o da refer�ncia
		/// </summary>
		public string Descri��o
		{
			get { return descri��o; }
			set { descri��o = value; }
		}
	}
}