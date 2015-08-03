using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento direto de um DbFoto para um par�metro
	/// do banco de dados.
	/// </summary>
	internal class DbFotoPar�metro : CampoPar�metroSimples
	{
		/// <summary>
		/// Constr�i mapeamento de campo para par�metro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do par�metro.</param>
		public DbFotoPar�metro(FieldInfo campo, IDbCommand cmd, string prefixo) : base(campo, cmd, prefixo)
		{
		}
			
		/// <summary>
		/// Define o par�metro a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">Entidade que cont�m o valor.</param>
		public override void DefinirPar�metro(object entidade)
		{
			par�metro.Value = (byte []) ((DbFoto) campo.GetValue(entidade));
		}
	}
}
