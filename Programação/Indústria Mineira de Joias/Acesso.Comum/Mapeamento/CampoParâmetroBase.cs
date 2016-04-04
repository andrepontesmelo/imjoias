using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Base para mapeamento de campo em parâmetro.
	/// </summary>
	internal abstract class CampoParâmetroBase
	{
		/// <summary>
		/// Prepara o parâmetro para mapeamento, conforme
		/// tipo do campo.
		/// </summary>
		/// <param name="campo">Campo da entdiade a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public IDbDataParameter CriarParâmetro(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			return CriarParâmetro(campo, campo.FieldType, cmd, prefixo);
		}

		/// <summary>
		/// Prepara o parâmetro para mapeamento, conforme
		/// tipo do campo.
		/// </summary>
		/// <param name="campo">Campo da entidade a ser mapeado.</param>
		/// <param name="tipo">Tipo do objeto a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public static IDbDataParameter CriarParâmetro(FieldInfo campo, Type tipo, IDbCommand cmd, string prefixo)
		{
			MapeamentoTipo   mapeamento = MapeamentoTipo.Instância;
			IDbDataParameter parâmetro;

			parâmetro               = cmd.CreateParameter();
			parâmetro.DbType        = mapeamento[tipo];
			parâmetro.ParameterName = "?" + prefixo + ExtrairNomeColuna(campo);
			parâmetro.Direction     = ParameterDirection.Output;

			cmd.Parameters.Add(parâmetro);

			return parâmetro;
		}

		/// <summary>
		/// Extrai o nome da coluna.
		/// </summary>
		/// <param name="campo">Campo do objeto.</param>
		/// <returns>Nome da coluna.</returns>
		protected static string ExtrairNomeColuna(FieldInfo campo)
		{
			DbColuna [] atributos;

			atributos = (DbColuna []) campo.GetCustomAttributes(typeof(DbColuna), false);

			if (atributos.Length == 0)
				return campo.Name;
			
			else if (atributos.Length == 1)
				return atributos[0].Coluna;

			else
				throw new Exception("Um campo não pode possuir mais de um atributo \"DbColuna\".");
		}

		/// <summary>
		/// Define o parâmetro mapeado a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">
		/// Entidade de onde serão extraídos os valores.
		/// </param>
		public abstract void DefinirParâmetro(object entidade);

		/// <summary>
		/// Nome das coluna.
		/// </summary>
		public abstract string Coluna
		{
			get;
		}

		/// <summary>
		/// Nome dos parâmetro.
		/// </summary>
		public abstract string Parâmetro
		{
			get;
		}
	}
}
