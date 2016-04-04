using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// F�brica para cria��o de objetos CampoPar�metro.
	/// </summary>
	internal sealed class F�bricaCampoPar�metro
	{
		private F�bricaCampoPar�metro()
		{
		}

		/// <summary>
		/// Constr�i um mapeamento de um campo de um objeto-entidade
		/// para um par�metro de banco de dados.
		/// </summary>
		/// <param name="campo">Campo a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <returns>Mapeamento de um campo para um par�metro.</returns>
		public static CampoPar�metroBase [] MapearCampoPar�metro(FieldInfo campo, IDbCommand cmd)
		{
			return MapearCampoPar�metro(campo, cmd, "");
		}

		/// <summary>
		/// Constr�i um mapeamento de um campo de um objeto-entidade
		/// para um par�metro de banco de dados.
		/// </summary>
		/// <param name="campo">Campo a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <returns>Mapeamento de um campo para um par�metro.</returns>
		public static CampoPar�metroBase [] MapearCampoPar�metro(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			DbAtributo atributo;
			DbAtributo [] atributos;

			atributos = (DbAtributo []) campo.GetCustomAttributes(typeof(DbAtributo), false);
			atributo  = (DbAtributo) atributos;

			/* Relacionamentos necessitam de um mapeamento
			 * mais complexo, permitindo m�ltiplos campos
			 * a partir de um �nico objeto.
			 */
			if (atributo.Relacionamento)
			{
                List<CampoObjetoPar�metro> campos = new List<CampoObjetoPar�metro>();

				foreach (DbRelacionamento relacionamento in campo.GetCustomAttributes(typeof(DbRelacionamento), false))
					campos.Add(new CampoObjetoPar�metro(campo, relacionamento.Campo, relacionamento.Coluna, cmd, prefixo));

				return campos.ToArray();
			}


			/* DbFoto deve ser transformado para vetor de bytes
			 * antes da atribui��o no par�metro.
			 */
			if (campo.FieldType == typeof(DbFoto) || campo.FieldType.IsSubclassOf(typeof(DbFoto)))
				return new CampoPar�metroBase [] { new DbFotoPar�metro(campo, cmd, prefixo) };


			/* DateTime pode ser nulo no banco de dados, caso
			 * no programa seu valor seja DateTime.MinValue ou
			 * DateTime.MaxValue.
			 */
			if (campo.FieldType == typeof(DateTime))
				return new CampoPar�metroBase [] { new DateTimePar�metro(campo, cmd, prefixo) };

			if (campo.FieldType.IsDefined(typeof(DbConvers�o), true))
                return new CampoPar�metroBase [] { new CampoPar�metroConvertendo(campo, cmd, prefixo) };

			// Mapeamento padr�o.
			return new CampoPar�metroBase [] { new CampoPar�metroSimples(campo, cmd, prefixo) };
		}
	}
}
