using System;
using Acesso.Comum;

namespace Acesso.Comum.Exceções
{
	/// <summary>
	/// Ocorre ao alterar uma chave primária
	/// </summary>
	[Serializable]
	public class AlteraçãoChavePrimária : ExceçãoEntidade
	{
		public AlteraçãoChavePrimária() : this(null)
		{}

		public AlteraçãoChavePrimária(DbManipulação entidade, string mensagem) : base(entidade, mensagem)
		{}

		public AlteraçãoChavePrimária(DbManipulação entidade) : base(entidade, "Não é possível alterar chave primária de uma entidade já cadastrada.")
		{}
	}
}
