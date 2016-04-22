using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento de DateTime para parâmetro de banco de dados.
	/// Quando o valor do DateTime for DateTime.MinValue ou
	/// DateTime.MaxValue, o valor atribuído ao banco de dados é nulo.
	/// </summary>
	internal class DateTimeParâmetro : CampoParâmetroSimples
	{
		/// <summary>
		/// Constrói mapeamento de DateTime para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do parâmetro.</param>
		public DateTimeParâmetro(FieldInfo campo, IDbCommand cmd, string prefixo) : base(campo, cmd, prefixo)
		{
		}

		/// <summary>
		/// Define valor do parâmetro a partir da entidade.
		/// </summary>
		/// <param name="entidade">Entidade que possui o valor.</param>
		public override void DefinirParâmetro(object entidade)
		{
			DateTime valor = (DateTime) campo.GetValue(entidade);

			if (valor == DateTime.MinValue || valor == DateTime.MaxValue)
				parâmetro.Value = null;
			else
				parâmetro.Value = valor;
		}
	}
}
