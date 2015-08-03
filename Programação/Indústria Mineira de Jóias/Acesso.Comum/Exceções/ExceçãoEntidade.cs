using System;

namespace Acesso.Comum.Exceções
{
	/// <summary>
	/// Exceção que ocorre em uma entidade.
	/// </summary>
	[Serializable]
	public class ExceçãoEntidade : Exception
	{
		private Acesso.Comum.DbManipulação entidade;

		public ExceçãoEntidade() : this(null)
		{}

		/// <summary>
		/// Constrói a exceção.
		/// </summary>
		/// <param name="entidade">Entidade que gerou exceção.</param>
		public ExceçãoEntidade(Acesso.Comum.DbManipulação entidade)
		{
			this.entidade = entidade;
		}

		/// <summary>
		/// Constrói a exceção com uma mensagem personalizada.
		/// </summary>
		/// <param name="entidade">Entidade que gerou exceção.</param>
		/// <param name="mensagem">Mensagem personalizada.</param>
		public ExceçãoEntidade(Acesso.Comum.DbManipulação entidade, string mensagem) : base(mensagem)
		{
			this.entidade = entidade;
		}

		/// <summary>
		/// Entidade que gerou exceção.
		/// </summary>
		public Acesso.Comum.DbManipulação Entidade
		{
			get { return entidade; }
		}
	}
}
