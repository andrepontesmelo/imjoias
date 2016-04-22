using System;

namespace Acesso.Comum.Exceções
{
	/// <summary>
	/// Exceção de entidade já existente
	/// </summary>
	[Serializable]
	public class EntidadeJáExistente : ExceçãoEntidade
	{
		public EntidadeJáExistente() : this(null)
		{}

		public EntidadeJáExistente(Acesso.Comum.DbManipulação entidade) : base(entidade, "Entidade já existe no banco de dados.")
		{
		}

		public EntidadeJáExistente(Acesso.Comum.DbManipulação entidade, string mensagem) : base(entidade, mensagem)
		{
		}
	}
}
