using System;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Atributo que permite o armazenamento em cache
	/// de uma entidade.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class Cacheável : Attribute
	{
		/// <summary>
		/// Nome dos métodos para recuperação
		/// da entidade no banco de dados.
		/// </summary>
		private string [] métodos;

		/// <summary>
		/// Determina que uma classe pode ser armazenada
		/// em cache.
		/// </summary>
		/// <param name="métodos">
		/// Métodos estáticos para recuperação da entidade
		/// no banco de dados.
		/// </param>
		public Cacheável(params string [] métodos)
		{
			this.métodos = métodos;
		}

		/// <summary>
		/// Nome dos métodos para recuperação da entidade
		/// no banco de dados.
		/// </summary>
		public string [] Métodos
		{
			get { return métodos; }
		}
	}
}
