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
		/// Parâmetros para recuperação no banco de dados.
		/// </summary>
		private object [] parâmetros;

		/// <summary>
		/// Constrói a chave de um item no cache.
		/// </summary>
		/// <param name="tipo">Tipo da entidade.</param>
		/// <param name="parâmetros">Parâmetros para recuperação da entidade.</param>
		public CacheDbChave(Type tipo, object [] parâmetros)
		{
			this.tipo       = tipo;
			this.parâmetros = parâmetros;
		}

		/// <summary>
		/// Tipo da entidade.
		/// </summary>
		public Type Tipo
		{
			get { return tipo; }
		}

		/// <summary>
		/// Parâmetros para recuperação no banco de dados.
		/// </summary>
		public object [] Parâmetros
		{
			get { return parâmetros; }
		}

		/// <summary>
		/// Gera código hash.
		/// </summary>
		/// <returns>Código hash.</returns>
		public override int GetHashCode()
		{
			int hash;

			hash = tipo.GetHashCode();

            foreach (object parâmetro in parâmetros)
                if (parâmetro != null)
                    hash ^= parâmetro.GetHashCode();
                else
                    hash = ~hash;

			return hash;
		}

		/// <summary>
		/// Verifica equivalência entre chaves.
		/// </summary>
		public override bool Equals(object obj)
		{
			if (!typeof(CacheDbChave).IsInstanceOfType(obj))
				return false;

			CacheDbChave item = (CacheDbChave) obj;
			bool equivalência = tipo.Equals(item.tipo) && parâmetros.Length == item.parâmetros.Length;
			int  cnt = 0;

			while (equivalência && cnt < parâmetros.Length)
			{
                if (parâmetros[cnt] == null || item.parâmetros[cnt] == null)
                    equivalência &= parâmetros[cnt] == item.parâmetros[cnt];
                else
				    equivalência &= parâmetros[cnt].Equals(item.parâmetros[cnt]);

				cnt++;
			}

			return equivalência;
		}
	}
}
