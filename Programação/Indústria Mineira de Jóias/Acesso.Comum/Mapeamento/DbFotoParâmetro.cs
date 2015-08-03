using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento direto de um DbFoto para um parâmetro
	/// do banco de dados.
	/// </summary>
	internal class DbFotoParâmetro : CampoParâmetroSimples
	{
		/// <summary>
		/// Constrói mapeamento de campo para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do parâmetro.</param>
		public DbFotoParâmetro(FieldInfo campo, IDbCommand cmd, string prefixo) : base(campo, cmd, prefixo)
		{
		}
			
		/// <summary>
		/// Define o parâmetro a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">Entidade que contém o valor.</param>
		public override void DefinirParâmetro(object entidade)
		{
			parâmetro.Value = (byte []) ((DbFoto) campo.GetValue(entidade));
		}
	}
}
