using System;

namespace Acesso.Comum.Exce��es
{
	/// <summary>
	/// Ocorre quando a entidade n�o foi ainda cadastrada.
	/// </summary>
	[Serializable]
	public class EntidadeN�oCadastrada : Exce��oEntidade
	{
		public EntidadeN�oCadastrada() : this(null)
		{}

		public EntidadeN�oCadastrada(Acesso.Comum.DbManipula��o entidade) : base(entidade, "Entidade ainda n�o cadastrada.")
		{
		}
	}
}
