using System;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Chave de um item no cache.
	/// </summary>
	internal struct CacheDbChave
	{
		/// <summary>
		/// Tipo da entidade.
		/// </summary>
		private Type tipo;

		/// <summary>
		/// Par�metros para recupera��o no banco de dados.
		/// </summary>
		private object [] par�metros;

		/// <summary>
		/// Constr�i a chave de um item no cache.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <param name="par�metros">Par�metros para recupera��o da entidade.</param>
		public CacheDbChave(Type tipo, object [] par�metros)
		{
			this.tipo       = tipo;
			this.par�metros = par�metros;
		}

		/// <summary>
		/// Tipo da entidade.
		/// </summary>
		public Type Tipo
		{
			get { return tipo; }
		}

		/// <summary>
		/// Par�metros para recupera��o no banco de dados.
		/// </summary>
		public object [] Par�metros
		{
			get { return par�metros; }
		}

		/// <summary>
		/// Gera c�digo hash.
		/// </summary>
		/// <returns>C�digo hash.</returns>
		public override int GetHashCode()
		{
			int hash;

			hash = tipo.GetHashCode();

            foreach (object par�metro in par�metros)
                if (par�metro != null)
                    hash ^= par�metro.GetHashCode();
                else
                    hash = ~hash;

			return hash;
		}

		/// <summary>
		/// Verifica equival�ncia entre chaves.
		/// </summary>
		public override bool Equals(object obj)
		{
			if (!typeof(CacheDbChave).IsInstanceOfType(obj))
				return false;

			CacheDbChave item = (CacheDbChave) obj;
			bool equival�ncia = tipo.Equals(item.tipo) && par�metros.Length == item.par�metros.Length;
			int  cnt = 0;

			while (equival�ncia && cnt < par�metros.Length)
			{
                if (par�metros[cnt] == null || item.par�metros[cnt] == null)
                    equival�ncia &= par�metros[cnt] == item.par�metros[cnt];
                else
				    equival�ncia &= par�metros[cnt].Equals(item.par�metros[cnt]);

				cnt++;
			}

			return equival�ncia;
		}
	}
}
