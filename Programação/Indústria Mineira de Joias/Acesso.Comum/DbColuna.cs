using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo para definir o nome da coluna
	/// no banco de dados.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class DbColuna : Attribute
	{
		private string nome;

		public DbColuna(string nome)
		{
			this.nome = nome;
		}

		public string Coluna
		{
			get { return nome; }
		}
	}
}
