using System;
using System.Collections;

namespace Negócio.Estoque
{
	/// <summary>
	/// Referência de mercadoria
	/// </summary>
	public abstract class Referência : IComparable
	{
		private ArrayList	grupos = new ArrayList();
		private string		descrição;

		public abstract override int GetHashCode();
		public abstract override string ToString();

		public virtual int CompareTo(object obj)
		{
			return GetHashCode() - obj.GetHashCode();
		}
		
		/// <summary>
		/// Constrói novo objeto da mercadoria
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
		/// Verifica se a referência está contida no grupo
		/// </summary>
		internal bool EstáContido(Grupo grupo)
		{
			return grupos.Contains(grupo);
		}

		/// <summary>
		/// Descrição da referência
		/// </summary>
		public string Descrição
		{
			get { return descrição; }
			set { descrição = value; }
		}
	}
}