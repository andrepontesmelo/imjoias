using System;

namespace Acesso.Comum
{
	/// <summary>
	/// Atributo de uma entidade. Este atributo caracteriza
	/// os campos de uma entidade, de forma a realizar o mapeamento
	/// da mesma com o banco de dados, por meio da especialização
	/// da classe <see cref="DbManipulaçãoAutomática"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class DbAtributo : Attribute
	{
		protected TipoAtributo tipo;

		/// <summary>
		/// Constrói um atributo normal de banco de dados.
		/// </summary>
		public DbAtributo()
		{
			tipo = TipoAtributo.Normal;
		}

		/// <summary>
		/// Constrói um atributo específico de banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo de atributo.</param>
		public DbAtributo(TipoAtributo tipo)
		{
			this.tipo = tipo;
		}

		/// <summary>
		/// Tipo do atributo.
		/// </summary>
		public TipoAtributo Tipo
		{
			get { return tipo; }
		}

		/// <summary>
		/// Determina se o campo deve ser ignorado.
		/// </summary>
		public bool Ignorar
		{
			get { return (tipo & TipoAtributo.Ignorar) > 0; }
		}

		/// <summary>
		/// Determina se o campo é chave-primária da tabela.
		/// </summary>
		public bool ChavePrimária
		{
			get { return (tipo & TipoAtributo.ChavePrimária) > 0; }
		}

		/// <summary>
		/// Determina se o campo é auto-incrementado.
		/// </summary>
		public bool AutoIncremento
		{
			get { return (tipo & TipoAtributo.AutoIncremento) > 0; }
		}

		/// <summary>
		/// Determina se o campo é um relacionamento com outra tabela.
		/// </summary>
		public bool Relacionamento
		{
			get { return (tipo & TipoAtributo.Relacionamento) > 0; }
		}

		/// <summary>
		/// Converte um conjunto de atributos para um único atributo.
		/// </summary>
		/// <param name="atributos">Conjunto de atributos.</param>
		/// <returns>Atributos unidos.</returns>
		public static explicit operator DbAtributo(DbAtributo [] atributos)
		{
			if (atributos.Length == 0)
				return new DbAtributo();

            // DbAtributo atributo = new DbAtributo((TipoAtributo) ~0);
			DbAtributo atributo = new DbAtributo();

			foreach (DbAtributo outro in atributos)
                // atributo.tipo &= outro.tipo;
				atributo.tipo |= outro.tipo;

			return atributo;
		}
	}

	public class DbChavePrimária : DbAtributo
	{
		public DbChavePrimária() : base(TipoAtributo.ChavePrimária)
		{}

		public DbChavePrimária(bool autoIncremento) : base(TipoAtributo.ChavePrimária)
		{
			if (autoIncremento)
				tipo |= TipoAtributo.AutoIncremento;
		}
	}
}
