using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Acesso.Comum
{
	/// <summary>
	/// Cache para mapeamento
	/// </summary>
	internal class CacheMapeamento
	{
		private Dictionary<string, FieldInfo[]> mapeamentoAtributos;

		/// <summary>
		/// Constrói a cache
		/// </summary>
		public CacheMapeamento()
		{
            mapeamentoAtributos = new Dictionary<string, FieldInfo[]>();
		}

		/// <summary>
		/// Cache de atributos
		/// </summary>
		public System.Reflection.FieldInfo [] this[Type tipo, string consulta]
		{
			get
			{
				FieldInfo [] obj;
				string chave;

				chave = ObterChave(tipo, consulta);
				mapeamentoAtributos.TryGetValue(chave, out obj);

				return obj;
			}
			set
			{
				string chave;

                if (!consulta.Contains(" UNION "))
                {
                    chave = ObterChave(tipo, consulta);

                    mapeamentoAtributos[chave] = value;
                }
			}
		}

		/// <summary>
		/// Obtém chave da consulta, que corresponde a
		/// parte da consulta que contém as cláusulas
		/// SELECT e FROM
		/// </summary>
		/// <param name="consulta">Consulta SQL</param>
		/// <returns>Chave do cache</returns>
		private static string ObterChave(Type tipo, string consulta)
		{
			int    i;

			i = consulta.IndexOf(" WHERE");

			return tipo.FullName + (i > 0 ? consulta.Substring(0, i + 1) : consulta);
		}
	}
}
