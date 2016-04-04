using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace Acesso.Comum.Mapeamento
{
    class CampoParâmetroConvertendo : CampoParâmetroBase
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
        /// Conversor do valor.
        /// </summary>
        private DbConversor conversor;

		/// <summary>
		/// Constrói mapeamento de campo para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public CampoParâmetroConvertendo(FieldInfo campo, IDbCommand cmd) : this(campo, cmd, "")
		{
		}

		/// <summary>
		/// Constrói mapeamento de campo para parâmetro.
		/// </summary>
		/// <param name="campo">Campo da entidade.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <param name="prefixo">Prefixo do parâmetro.</param>
        public CampoParâmetroConvertendo(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
            DbConversão[] conversores;

			parâmetro  = CriarParâmetro(campo, cmd, prefixo);
			coluna     = ExtrairNomeColuna(campo);
			this.campo = campo;

            conversores = (DbConversão[])campo.FieldType.GetCustomAttributes(typeof(DbConversão), true);
            conversor   = conversores[0].Conversor;
		}

		/// <summary>
		/// Define o parâmetro a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">Entidade que contém o valor.</param>
		public override void DefinirParâmetro(object entidade)
		{
			if (entidade != null)
				parâmetro.Value = conversor.ConverterParaDB(campo.GetValue(entidade));
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
