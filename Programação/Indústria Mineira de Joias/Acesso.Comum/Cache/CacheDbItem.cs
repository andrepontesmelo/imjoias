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
		private DbManipula��o entidade;

		/// <summary>
		/// Data em que expira o item no cache.
		/// </summary>
		private DateTime validade;

        /// <summary>
        /// Determina se deve ser realizado c�pia da entidade.
        /// </summary>
        private bool copiar;

		/// <summary>
		/// Data de cria��o do item.
		/// </summary>
		private DateTime cria��o;

		/// <summary>
		/// N�mero de vezes que foi utilizado.
		/// </summary>
		private int usos;

		/// <summary>
		/// Chave do item no cache.
		/// </summary>
		private CacheDbChave chave;

		/// <summary>
		/// Constr�i um item do cache de banco de dados.
		/// </summary>
		/// <param name="entidade">Entidade do banco de dados.</param>
		/// <param name="validade">Validade do item no cache.</param>
		public CacheDbItem(DbManipula��o entidade, DateTime validade, CacheDbChave chave)
		{
			this.entidade = entidade;
			this.validade = validade;
			this.chave    = chave;
			this.cria��o  = DateTime.Now;
			this.usos     = 0;

            if (entidade == null)
                this.copiar = false;
            else
            {
                this.copiar = (entidade.GetType().GetCustomAttributes(typeof(N�oCopiarCache), true).Length == 0);

                if (copiar)
                    this.entidade.Alterado += new DbManipula��o.DbManipula��oHandler(AoAlterarEntidade);
            }
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			CacheDbItem outro = (CacheDbItem) obj;
			int compara��o;
			bool [] v�lido = new bool[2];

			v�lido[0] = this.validade >= DateTime.Now;
			v�lido[1] = outro.validade >= DateTime.Now;

			if (v�lido[0] && !v�lido[1])
				return 1;
			else if (!v�lido[0] && v�lido[1])
				return -1;

			compara��o = usos.CompareTo(outro.usos);

			if (compara��o == 0)
				compara��o = cria��o.CompareTo(outro.cria��o);

			if (compara��o == 0)
				compara��o = validade.CompareTo(outro.validade);

			return compara��o;
		}

		#endregion

		/// <summary>
		/// Entidade do banco de dados.
		/// </summary>
        public DbManipula��o Entidade
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
        /// Determina se deve realizar c�pia da entidade.
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
		/// Data de cria��o.
		/// </summary>
		public DateTime Cria��o
		{
			get { return cria��o; }
		}

		/// <summary>
		/// N�mero de usos do item.
		/// </summary>
		public int Usos
		{
			get { return usos; }
			set { usos = value; }
		}

		/// <summary>
		/// Verifica equival�ncia entre objetos.
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
		/// C�digo hash.
		/// </summary>
		public override int GetHashCode()
		{
            if (entidade != null)
                return chave.GetHashCode() ^ entidade.GetHashCode() ^ validade.GetHashCode();
            else
                return ~(chave.GetHashCode() ^ validade.GetHashCode());
		}

        /// <summary>
        /// Ocorre ao alterar a entidade. Uma mudan�a na entidade
        /// deve invalidar a entidade na cache.
        /// </summary>
        /// <param name="entidade">Entidade alterada.</param>
        /// <remarks>S� disparado se copiar == true.</remarks>
        internal void AoAlterarEntidade(DbManipula��o entidade)
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