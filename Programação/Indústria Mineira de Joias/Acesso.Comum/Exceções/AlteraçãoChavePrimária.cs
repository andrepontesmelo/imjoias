using System;
using Acesso.Comum;

namespace Acesso.Comum.Exce��es
{
	/// <summary>
	/// Ocorre ao alterar uma chave prim�ria
	/// </summary>
	[Serializable]
	public class Altera��oChavePrim�ria : Exce��oEntidade
	{
		public Altera��oChavePrim�ria() : this(null)
		{}

		public Altera��oChavePrim�ria(DbManipula��o entidade, string mensagem) : base(entidade, mensagem)
		{}

		public Altera��oChavePrim�ria(DbManipula��o entidade) : base(entidade, "N�o � poss�vel alterar chave prim�ria de uma entidade j� cadastrada.")
		{}
	}
}
