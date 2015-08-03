using System;

namespace Acesso.Comum.Exce��es
{
	/// <summary>
	/// Exce��o que ocorre em uma entidade.
	/// </summary>
	[Serializable]
	public class Exce��oEntidade : Exception
	{
		private Acesso.Comum.DbManipula��o entidade;

		public Exce��oEntidade() : this(null)
		{}

		/// <summary>
		/// Constr�i a exce��o.
		/// </summary>
		/// <param name="entidade">Entidade que gerou exce��o.</param>
		public Exce��oEntidade(Acesso.Comum.DbManipula��o entidade)
		{
			this.entidade = entidade;
		}

		/// <summary>
		/// Constr�i a exce��o com uma mensagem personalizada.
		/// </summary>
		/// <param name="entidade">Entidade que gerou exce��o.</param>
		/// <param name="mensagem">Mensagem personalizada.</param>
		public Exce��oEntidade(Acesso.Comum.DbManipula��o entidade, string mensagem) : base(mensagem)
		{
			this.entidade = entidade;
		}

		/// <summary>
		/// Entidade que gerou exce��o.
		/// </summary>
		public Acesso.Comum.DbManipula��o Entidade
		{
			get { return entidade; }
		}
	}
}
