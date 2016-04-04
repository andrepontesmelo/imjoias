using System;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Atributo que permite o armazenamento em cache
	/// de uma entidade.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class Cache�vel : Attribute
	{
		/// <summary>
		/// Nome dos m�todos para recupera��o
		/// da entidade no banco de dados.
		/// </summary>
		private string [] m�todos;

		/// <summary>
		/// Determina que uma classe pode ser armazenada
		/// em cache.
		/// </summary>
		/// <param name="m�todos">
		/// M�todos est�ticos para recupera��o da entidade
		/// no banco de dados.
		/// </param>
		public Cache�vel(params string [] m�todos)
		{
			this.m�todos = m�todos;
		}

		/// <summary>
		/// Nome dos m�todos para recupera��o da entidade
		/// no banco de dados.
		/// </summary>
		public string [] M�todos
		{
			get { return m�todos; }
		}
	}
}
