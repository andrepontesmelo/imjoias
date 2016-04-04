using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Fábrica para criação de objetos CampoParâmetro.
	/// </summary>
	internal sealed class FábricaCampoParâmetro
	{
		private FábricaCampoParâmetro()
		{
		}

		/// <summary>
		/// Constrói um mapeamento de um campo de um objeto-entidade
		/// para um parâmetro de banco de dados.
		/// </summary>
		/// <param name="campo">Campo a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <returns>Mapeamento de um campo para um parâmetro.</returns>
		public static CampoParâmetroBase [] MapearCampoParâmetro(FieldInfo campo, IDbCommand cmd)
		{
			return MapearCampoParâmetro(campo, cmd, "");
		}

		/// <summary>
		/// Constrói um mapeamento de um campo de um objeto-entidade
		/// para um parâmetro de banco de dados.
		/// </summary>
		/// <param name="campo">Campo a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		/// <returns>Mapeamento de um campo para um parâmetro.</returns>
		public static CampoParâmetroBase [] MapearCampoParâmetro(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			DbAtributo atributo;
			DbAtributo [] atributos;

			atributos = (DbAtributo []) campo.GetCustomAttributes(typeof(DbAtributo), false);
			atributo  = (DbAtributo) atributos;

			/* Relacionamentos necessitam de um mapeamento
			 * mais complexo, permitindo múltiplos campos
			 * a partir de um único objeto.
			 */
			if (atributo.Relacionamento)
			{
                List<CampoObjetoParâmetro> campos = new List<CampoObjetoParâmetro>();

				foreach (DbRelacionamento relacionamento in campo.GetCustomAttributes(typeof(DbRelacionamento), false))
					campos.Add(new CampoObjetoParâmetro(campo, relacionamento.Campo, relacionamento.Coluna, cmd, prefixo));

				return campos.ToArray();
			}


			/* DbFoto deve ser transformado para vetor de bytes
			 * antes da atribuição no parâmetro.
			 */
			if (campo.FieldType == typeof(DbFoto) || campo.FieldType.IsSubclassOf(typeof(DbFoto)))
				return new CampoParâmetroBase [] { new DbFotoParâmetro(campo, cmd, prefixo) };


			/* DateTime pode ser nulo no banco de dados, caso
			 * no programa seu valor seja DateTime.MinValue ou
			 * DateTime.MaxValue.
			 */
			if (campo.FieldType == typeof(DateTime))
				return new CampoParâmetroBase [] { new DateTimeParâmetro(campo, cmd, prefixo) };

			if (campo.FieldType.IsDefined(typeof(DbConversão), true))
                return new CampoParâmetroBase [] { new CampoParâmetroConvertendo(campo, cmd, prefixo) };

			// Mapeamento padrão.
			return new CampoParâmetroBase [] { new CampoParâmetroSimples(campo, cmd, prefixo) };
		}
	}
}
