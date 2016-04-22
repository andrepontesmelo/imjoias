using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento de DateTime para par�metro de banco de dados.
	/// Quando o valor do DateTime for DateTime.MinValue ou
	/// DateTime.MaxValue, o valor atribu�do ao banco de dados � nulo.
	/// </summary>
	internal class DateTimePar�metro : CampoPar�metroSimples
	{
		/// <summary>
		/// Constr�i mapeamento de DateTime para par�metro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do par�metro.</param>
		public DateTimePar�metro(FieldInfo campo, IDbCommand cmd, string prefixo) : base(campo, cmd, prefixo)
		{
		}

		/// <summary>
		/// Define valor do par�metro a partir da entidade.
		/// </summary>
		/// <param name="entidade">Entidade que possui o valor.</param>
		public override void DefinirPar�metro(object entidade)
		{
			DateTime valor = (DateTime) campo.GetValue(entidade);

			if (valor == DateTime.MinValue || valor == DateTime.MaxValue)
				par�metro.Value = null;
			else
				par�metro.Value = valor;
		}
	}
}
