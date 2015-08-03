using System;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	/// <summary>
	/// Manipulação de histórico
	/// </summary>
	[DbTabela("utilizacao")]
	public class Log : Acesso.Comum.DbManipulaçãoAutomática
	{
		/// <summary>
		/// Código de aplicações
		/// </summary>
		public enum Aplicações
		{
			/* Os valores não devem ser alterados,
			 * pois afetará o histórico já armazenado.
			 */
			Relatório						= 0,		/* ASPX: Relatorio/menu.aspx */
			RelatórioRecepção				= 1,		/* ASPX: Relatorio/Recepcao */
			RelatórioConstrutorGráficos		= 2,		/* ASPX: Relatorio/Graficos */
			StatusRecepção					= 3, 		/* ASPX: Relatorio/Recepcao/Status.aspx*/
			Telefonemas						= 4, 		/* ASPX: Relatorio/Recepcao/telefonemas.aspx*/
		}

		/// <summary>
		/// Código do log.
		/// </summary>
		[DbChavePrimária(true), DbColuna("codigo")]
		private long código;

		/// <summary>
		/// Usuário que efetuou ação.
		/// </summary>
		[DbColuna("usuario")]
		private string usuário;

		/// <summary>
		/// Momento da ocorrência.
		/// </summary>
        //private DateTime quando;

		/// <summary>
		/// Aplicação utilizada.
		/// </summary>
		[DbColuna("aplicacao")]
		private Aplicações aplicação;

		/// <summary>
		/// Parâmetros utilizados.
		/// </summary>
		[DbColuna("parametros")]
		private string parâmetros;


		#region Propriedades

		/// <summary>
		/// Código do registro.
		/// </summary>
		public long Código
		{
			get { return código; }
		}

		/// <summary>
		/// Usuário que executou ação.
		/// </summary>
		public string Usuário
		{
			get { return usuário; }
			set { usuário = value; }
		}

		/// <summary>
		/// Aplicação utilizada.
		/// </summary>
		public Aplicações Aplicação
		{
			get { return aplicação; }
			set { aplicação = value; }
		}

		/// <summary>
		/// Parâmetros da aplicação.
		/// </summary>
		public string Parâmetros
		{
			get { return parâmetros; }
			set { parâmetros = value; }
		}

		#endregion


		/// <summary>
		/// Constrói uma entrada de registro.
		/// </summary>
		public Log()
		{
			this.código = -1;
            //this.quando = DateTime.Now;
		}

		/// <summary>
		/// Constrói uma entrada de registro.
		/// </summary>
		/// <param name="usuário">Usuário que realizou ação.</param>
		/// <param name="aplicação">Aplicação utilizada.</param>
		/// <param name="parâmetros">Parâmetros utilizados.</param>
		public Log(string usuário, Aplicações aplicação, string parâmetros) : this()
		{
			this.usuário    = usuário;
			this.aplicação  = aplicação;
			this.parâmetros = parâmetros;
		}

		/// <summary>
		/// Constrói uma entrada de registro.
		/// </summary>
		/// <param name="usuário">Usuário que realizou ação.</param>
		/// <param name="aplicação">Aplicação utilizada.</param>
		public Log(string usuário, Aplicações aplicação) : this(usuário, aplicação, null)
		{
		}

		/// <summary>
		/// Registra a utilização de uma aplicação por determinado usuário
		/// </summary>
		/// <param name="usuário">Usuário</param>
		/// <param name="aplicação">Aplicação utilizada</param>
		/// <param name="parâmetros">Parâmetros utilizados</param>
		public static Log Registrar(string usuário, Aplicações aplicação, string parâmetros)
		{
			Log entrada = new Log(usuário, aplicação, parâmetros);

			entrada.Cadastrar();

			return entrada;
		}

		/// <summary>
		/// Registra a utilização de uma aplicação por determinado usuário.
		/// </summary>
		/// <param name="usuário">Usuário.</param>
		/// <param name="aplicação">Aplicação utilizada.</param>
		public static Log Registrar(string usuário, Aplicações aplicação)
		{
			Log entrada = new Log(usuário, aplicação);

			entrada.Cadastrar();

			return entrada;
		}
	}
}
