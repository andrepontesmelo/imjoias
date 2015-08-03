using System;
using System.Collections;

namespace Acesso.Comum
{
	/// <summary>
	/// Cache para mapeamento
	/// </summary>
	internal class CacheMapeamento
	{
		private Hashtable mapeamentoAtributos;

		/// <summary>
		/// Constrói a cache
		/// </summary>
		public CacheMapeamento()
		{
			mapeamentoAtributos = new Hashtable();
		}

		/// <summary>
		/// Cache de atributos
		/// </summary>
		public System.Reflection.FieldInfo [] this[Type tipo, string consulta]
		{
			get
			{
				object obj;
				string chave;

				chave = ObterChave(tipo, consulta);
				obj   = mapeamentoAtributos[chave];

				return (System.Reflection.FieldInfo []) obj;
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
