using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo para definir o nome da tabela
	/// no banco de dados.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DbTabela : Attribute
	{
		private string nome;

		public DbTabela(string nome)
		{
			this.nome = nome;
		}

		public string Tabela
		{
			get { return nome; }
		}
	}
}
