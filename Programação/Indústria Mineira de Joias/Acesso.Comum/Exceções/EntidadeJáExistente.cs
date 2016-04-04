using System;

namespace Acesso.Comum.Exce��es
{
	/// <summary>
	/// Exce��o de entidade j� existente
	/// </summary>
	[Serializable]
	public class EntidadeJ�Existente : Exce��oEntidade
	{
		public EntidadeJ�Existente() : this(null)
		{}

		public EntidadeJ�Existente(Acesso.Comum.DbManipula��o entidade) : base(entidade, "Entidade j� existe no banco de dados.")
		{
		}

		public EntidadeJ�Existente(Acesso.Comum.DbManipula��o entidade, string mensagem) : base(entidade, mensagem)
		{
		}
	}
}
