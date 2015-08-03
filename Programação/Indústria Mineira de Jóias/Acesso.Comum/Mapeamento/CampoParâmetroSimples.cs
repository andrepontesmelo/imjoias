using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento direto de um campo para um parâmetro.
	/// </summary>
	internal class CampoParâmetroSimples : CampoParâmetroBase
	{
		/// <summary>
		/// Parâmetro do banco de dados.
		/// </summary>
		protected IDbDataParameter parâmetro;

		/// <summary>
		/// Campo da entidade.
		/// </summary>
		protected FieldInfo campo;

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		private string coluna;

		/// <summary>
		/// Constrói mapeamento de campo para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public CampoParâmetroSimples(FieldInfo campo, IDbCommand cmd)
		{
			parâmetro = CriarParâmetro(campo, cmd, "");
			coluna    = ExtrairNomeColuna(campo);
			this.campo = campo;
		}

		/// <summary>
		/// Constrói mapeamento de campo para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do parâmetro.</param>
		public CampoParâmetroSimples(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			parâmetro = CriarParâmetro(campo, cmd, prefixo);
			coluna    = ExtrairNomeColuna(campo);
			this.campo = campo;
		}

		/// <summary>
		/// Define o parâmetro a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">Entidade que contém o valor.</param>
		public override void DefinirParâmetro(object entidade)
		{
			if (entidade != null)
				parâmetro.Value = campo.GetValue(entidade);
			else
				parâmetro.Value = null;
		}

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		public override string Coluna
		{
			get
			{
				return this.coluna;
			}
		}

		/// <summary>
		/// Nome do parâmetro.
		/// </summary>
		public override string Parâmetro
		{
			get
			{
				return parâmetro.ParameterName;
			}
		}
	}
}
