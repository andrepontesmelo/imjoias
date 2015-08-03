using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo que garante uso de transação segura nos
	/// métodos "Cadastrar", "Atualizar" e "Descadastrar"
	/// das classes que implementam DbManipulação.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DbTransação : Attribute
	{
	}
}
