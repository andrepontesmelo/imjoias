using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Mapeamento direto de um campo para um par�metro.
	/// </summary>
	internal class CampoPar�metroSimples : CampoPar�metroBase
	{
		/// <summary>
		/// Par�metro do banco de dados.
		/// </summary>
		protected IDbDataParameter par�metro;

		/// <summary>
		/// Campo da entidade.
		/// </summary>
		protected FieldInfo campo;

		/// <summary>
		/// Nome da coluna.
		/// </summary>
		private string coluna;

		/// <summary>
		/// Constr�i mapeamento de campo para par�metro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public CampoPar�metroSimples(FieldInfo campo, IDbCommand cmd)
		{
			par�metro = CriarPar�metro(campo, cmd, "");
			coluna    = ExtrairNomeColuna(campo);
			this.campo = campo;
		}

		/// <summary>
		/// Constr�i mapeamento de campo para par�metro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do par�metro.</param>
		public CampoPar�metroSimples(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			par�metro = CriarPar�metro(campo, cmd, prefixo);
			coluna    = ExtrairNomeColuna(campo);
			this.campo = campo;
		}

		/// <summary>
		/// Define o par�metro a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">Entidade que cont�m o valor.</param>
		public override void DefinirPar�metro(object entidade)
		{
			if (entidade != null)
				par�metro.Value = campo.GetValue(entidade);
			else
				par�metro.Value = null;
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
		/// Nome do par�metro.
		/// </summary>
		public override string Par�metro
		{
			get
			{
				return par�metro.ParameterName;
			}
		}
	}
}
