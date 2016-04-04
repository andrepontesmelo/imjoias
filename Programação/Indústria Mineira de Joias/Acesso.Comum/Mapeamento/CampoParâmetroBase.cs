using System;
using System.Data;
using System.Reflection;

namespace Acesso.Comum.Mapeamento
{
	/// <summary>
	/// Base para mapeamento de campo em par�metro.
	/// </summary>
	internal abstract class CampoPar�metroBase
	{
		/// <summary>
		/// Prepara o par�metro para mapeamento, conforme
		/// tipo do campo.
		/// </summary>
		/// <param name="campo">Campo da entdiade a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public IDbDataParameter CriarPar�metro(FieldInfo campo, IDbCommand cmd, string prefixo)
		{
			return CriarPar�metro(campo, campo.FieldType, cmd, prefixo);
		}

		/// <summary>
		/// Prepara o par�metro para mapeamento, conforme
		/// tipo do campo.
		/// </summary>
		/// <param name="campo">Campo da entidade a ser mapeado.</param>
		/// <param name="tipo">Tipo do objeto a ser mapeado.</param>
		/// <param name="cmd">Comando do banco de dados.</param>
		public static IDbDataParameter CriarPar�metro(FieldInfo campo, Type tipo, IDbCommand cmd, string prefixo)
		{
			MapeamentoTipo   mapeamento = MapeamentoTipo.Inst�ncia;
			IDbDataParameter par�metro;

			par�metro               = cmd.CreateParameter();
			par�metro.DbType        = mapeamento[tipo];
			par�metro.ParameterName = "?" + prefixo + ExtrairNomeColuna(campo);
			par�metro.Direction     = ParameterDirection.Output;

			cmd.Parameters.Add(par�metro);

			return par�metro;
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
				throw new Exception("Um campo n�o pode possuir mais de um atributo \"DbColuna\".");
		}

		/// <summary>
		/// Define o par�metro mapeado a partir de uma entidade.
		/// </summary>
		/// <param name="entidade">
		/// Entidade de onde ser�o extra�dos os valores.
		/// </param>
		public abstract void DefinirPar�metro(object entidade);

		/// <summary>
		/// Nome das coluna.
		/// </summary>
		public abstract string Coluna
		{
			get;
		}

		/// <summary>
		/// Nome dos par�metro.
		/// </summary>
		public abstract string Par�metro
		{
			get;
		}
	}
}
