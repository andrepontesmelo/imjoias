using Acesso.Comum.Exceções;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Realiza mapeamento de tipos para banco de dados.
	/// </summary>
	internal class MapeamentoTipo
	{
		private Dictionary<Type, DbType> hashTipos;

		private MapeamentoTipo()
		{
            hashTipos = new Dictionary<Type, DbType>();

			hashTipos.Add(typeof(char []), DbType.AnsiString);
			hashTipos.Add(typeof(byte []), DbType.Binary);
			hashTipos.Add(typeof(bool), DbType.Boolean);
			hashTipos.Add(typeof(byte), DbType.Byte);
			hashTipos.Add(typeof(DateTime), DbType.DateTime);
			hashTipos.Add(typeof(decimal), DbType.Decimal);
			hashTipos.Add(typeof(double), DbType.Double);
			hashTipos.Add(typeof(short), DbType.Int16);
			hashTipos.Add(typeof(int), DbType.Int32);
			hashTipos.Add(typeof(long), DbType.Int64);
			hashTipos.Add(typeof(sbyte), DbType.SByte);
			hashTipos.Add(typeof(float), DbType.Single);
			hashTipos.Add(typeof(string), DbType.String);
			hashTipos.Add(typeof(ushort), DbType.UInt16);
			hashTipos.Add(typeof(uint), DbType.UInt32);
			hashTipos.Add(typeof(ulong), DbType.UInt64);
			hashTipos.Add(typeof(DayOfWeek), DbType.UInt16);
			hashTipos.Add(typeof(Enum), DbType.Int32);
            hashTipos.Add(typeof(long?), DbType.Int64);
            hashTipos.Add(typeof(ulong?), DbType.UInt64);
            hashTipos.Add(typeof(int?), DbType.Int32);
            hashTipos.Add(typeof(uint?), DbType.UInt32);
            hashTipos.Add(typeof(DateTime?), DbType.DateTime);
            hashTipos.Add(typeof(double?), DbType.Double);

			// Objetos
			hashTipos.Add(typeof(DbFoto), DbType.Binary);
		}

		private static MapeamentoTipo instância = new MapeamentoTipo();
		public static MapeamentoTipo Instância
		{
			get { return instância; }
		}

		public DbType this[Type tipoFinal]
		{
			get
			{
				Type tipo = tipoFinal;

				while (tipo != null && !hashTipos.ContainsKey(tipo))
				{
					tipo = tipo.BaseType;
				}

				if (tipo == null)
					throw new ExcessãoMapeamentoTipo("Tipo " + tipoFinal.FullName + " desconhecido no MapeamentoTipo!", tipoFinal);

				return hashTipos[tipo];
			}
		}
	}
}
