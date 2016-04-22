using System;

namespace Acesso.Comum.Exceções
{
	/// <summary>
	/// Ocorre quando a entidade não foi ainda cadastrada.
	/// </summary>
	[Serializable]
	public class EntidadeNãoCadastrada : ExceçãoEntidade
	{
		public EntidadeNãoCadastrada() : this(null)
		{}

		public EntidadeNãoCadastrada(Acesso.Comum.DbManipulação entidade) : base(entidade, "Entidade ainda não cadastrada.")
		{
		}
	}
}
