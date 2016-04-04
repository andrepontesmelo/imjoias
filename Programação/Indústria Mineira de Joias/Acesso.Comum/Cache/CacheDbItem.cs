using System;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Item de armazenamento no cache.
	/// </summary>
	internal class CacheDbItem : IComparable
	{
		/// <summary>
		/// Entidade a ser armazenada no cache.
		/// </summary>
		private DbManipulação entidade;

		/// <summary>
		/// Data em que expira o item no cache.
		/// </summary>
		private DateTime validade;

        /// <summary>
        /// Determina se deve ser realizado cópia da entidade.
        /// </summary>
        private bool copiar;

		/// <summary>
		/// Data de criação do item.
		/// </summary>
		private DateTime criação;

		/// <summary>
		/// Número de vezes que foi utilizado.
		/// </summary>
		private int usos;

		/// <summary>
		/// Chave do item no cache.
		/// </summary>
		private CacheDbChave chave;

		/// <summary>
		/// Constrói um item do cache de banco de dados.
		/// </summary>
		/// <param name="entidade">Entidade do banco de dados.</param>
		/// <param name="validade">Validade do item no cache.</param>
		public CacheDbItem(DbManipulação entidade, DateTime validade, CacheDbChave chave)
		{
			this.entidade = entidade;
			this.validade = validade;
			this.chave    = chave;
			this.criação  = DateTime.Now;
			this.usos     = 0;

            if (entidade == null)
                this.copiar = false;
            else
            {
                this.copiar = (entidade.GetType().GetCustomAttributes(typeof(NãoCopiarCache), true).Length == 0);

                if (copiar)
                    this.entidade.Alterado += new DbManipulação.DbManipulaçãoHandler(AoAlterarEntidade);
            }
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			CacheDbItem outro = (CacheDbItem) obj;
			int comparação;
			bool [] válido = new bool[2];

			válido[0] = this.validade >= DateTime.Now;
			válido[1] = outro.validade >= DateTime.Now;

			if (válido[0] && !válido[1])
				return 1;
			else if (!válido[0] && válido[1])
				return -1;

			comparação = usos.CompareTo(outro.usos);

			if (comparação == 0)
				comparação = criação.CompareTo(outro.criação);

			if (comparação == 0)
				comparação = validade.CompareTo(outro.validade);

			return comparação;
		}

		#endregion

		/// <summary>
		/// Entidade do banco de dados.
		/// </summary>
        public DbManipulação Entidade
		{
			get { return entidade; }
		}

		/// <summary>
		/// Data em que os dados se expiram.
		/// </summary>
		public DateTime Validade
		{
			get
            {
                if (entidade != null && !entidade.Cadastrado)
                    return DateTime.MaxValue;
                if (entidade != null && !entidade.Atualizado)
                    return DateTime.MinValue;
                else
                    return validade;
            }
		}

        /// <summary>
        /// Determina se deve realizar cópia da entidade.
        /// </summary>
        public bool Copiar
        {
            get { return copiar; }
        }

		/// <summary>
		/// Chave para armazenar item no cache.
		/// </summary>
		public CacheDbChave Chave
		{
			get { return chave; }
		}

		/// <summary>
		/// Data de criação.
		/// </summary>
		public DateTime Criação
		{
			get { return criação; }
		}

		/// <summary>
		/// Número de usos do item.
		/// </summary>
		public int Usos
		{
			get { return usos; }
			set { usos = value; }
		}

		/// <summary>
		/// Verifica equivalência entre objetos.
		/// </summary>
		public override bool Equals(object obj)
		{
            if (!typeof(CacheDbItem).IsInstanceOfType(obj))
                return false;

            CacheDbItem outro = (CacheDbItem)obj;

            if (entidade == null)
            {
                if (outro.entidade == null)
                    return true;
                else
                    return false;
            }
            else
            {
                bool entidadesIguais = entidade.Equals(outro.entidade);
                bool chavesIguais = chave.Equals(outro.chave);

                return entidadesIguais && chavesIguais;
            }
        }

		/// <summary>
		/// Código hash.
		/// </summary>
		public override int GetHashCode()
		{
            if (entidade != null)
                return chave.GetHashCode() ^ entidade.GetHashCode() ^ validade.GetHashCode();
            else
                return ~(chave.GetHashCode() ^ validade.GetHashCode());
		}

        /// <summary>
        /// Ocorre ao alterar a entidade. Uma mudança na entidade
        /// deve invalidar a entidade na cache.
        /// </summary>
        /// <param name="entidade">Entidade alterada.</param>
        /// <remarks>Só disparado se copiar == true.</remarks>
        internal void AoAlterarEntidade(DbManipulação entidade)
        {
#if DEBUG
            Console.WriteLine("Item na cache alterado. Vencendo validade de " + entidade.ToString());
#endif
            validade = DateTime.MinValue;
        }

        public override string ToString()
        {
            return "{CacheDbItem} " + (entidade == null ? "null" : entidade.ToString());
        }
    }
}