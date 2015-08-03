using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo que garante uso de transa��o segura nos
	/// m�todos "Cadastrar", "Atualizar" e "Descadastrar"
	/// das classes que implementam DbManipula��o.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DbTransa��o : Attribute
	{
	}
}
