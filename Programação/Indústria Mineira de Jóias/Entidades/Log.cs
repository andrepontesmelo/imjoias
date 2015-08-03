using System;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	/// <summary>
	/// Manipula��o de hist�rico
	/// </summary>
	[DbTabela("utilizacao")]
	public class Log : Acesso.Comum.DbManipula��oAutom�tica
	{
		/// <summary>
		/// C�digo de aplica��es
		/// </summary>
		public enum Aplica��es
		{
			/* Os valores n�o devem ser alterados,
			 * pois afetar� o hist�rico j� armazenado.
			 */
			Relat�rio						= 0,		/* ASPX: Relatorio/menu.aspx */
			Relat�rioRecep��o				= 1,		/* ASPX: Relatorio/Recepcao */
			Relat�rioConstrutorGr�ficos		= 2,		/* ASPX: Relatorio/Graficos */
			StatusRecep��o					= 3, 		/* ASPX: Relatorio/Recepcao/Status.aspx*/
			Telefonemas						= 4, 		/* ASPX: Relatorio/Recepcao/telefonemas.aspx*/
		}

		/// <summary>
		/// C�digo do log.
		/// </summary>
		[DbChavePrim�ria(true), DbColuna("codigo")]
		private long c�digo;

		/// <summary>
		/// Usu�rio que efetuou a��o.
		/// </summary>
		[DbColuna("usuario")]
		private string usu�rio;

		/// <summary>
		/// Momento da ocorr�ncia.
		/// </summary>
        //private DateTime quando;

		/// <summary>
		/// Aplica��o utilizada.
		/// </summary>
		[DbColuna("aplicacao")]
		private Aplica��es aplica��o;

		/// <summary>
		/// Par�metros utilizados.
		/// </summary>
		[DbColuna("parametros")]
		private string par�metros;


		#region Propriedades

		/// <summary>
		/// C�digo do registro.
		/// </summary>
		public long C�digo
		{
			get { return c�digo; }
		}

		/// <summary>
		/// Usu�rio que executou a��o.
		/// </summary>
		public string Usu�rio
		{
			get { return usu�rio; }
			set { usu�rio = value; }
		}

		/// <summary>
		/// Aplica��o utilizada.
		/// </summary>
		public Aplica��es Aplica��o
		{
			get { return aplica��o; }
			set { aplica��o = value; }
		}

		/// <summary>
		/// Par�metros da aplica��o.
		/// </summary>
		public string Par�metros
		{
			get { return par�metros; }
			set { par�metros = value; }
		}

		#endregion


		/// <summary>
		/// Constr�i uma entrada de registro.
		/// </summary>
		public Log()
		{
			this.c�digo = -1;
            //this.quando = DateTime.Now;
		}

		/// <summary>
		/// Constr�i uma entrada de registro.
		/// </summary>
		/// <param name="usu�rio">Usu�rio que realizou a��o.</param>
		/// <param name="aplica��o">Aplica��o utilizada.</param>
		/// <param name="par�metros">Par�metros utilizados.</param>
		public Log(string usu�rio, Aplica��es aplica��o, string par�metros) : this()
		{
			this.usu�rio    = usu�rio;
			this.aplica��o  = aplica��o;
			this.par�metros = par�metros;
		}

		/// <summary>
		/// Constr�i uma entrada de registro.
		/// </summary>
		/// <param name="usu�rio">Usu�rio que realizou a��o.</param>
		/// <param name="aplica��o">Aplica��o utilizada.</param>
		public Log(string usu�rio, Aplica��es aplica��o) : this(usu�rio, aplica��o, null)
		{
		}

		/// <summary>
		/// Registra a utiliza��o de uma aplica��o por determinado usu�rio
		/// </summary>
		/// <param name="usu�rio">Usu�rio</param>
		/// <param name="aplica��o">Aplica��o utilizada</param>
		/// <param name="par�metros">Par�metros utilizados</param>
		public static Log Registrar(string usu�rio, Aplica��es aplica��o, string par�metros)
		{
			Log entrada = new Log(usu�rio, aplica��o, par�metros);

			entrada.Cadastrar();

			return entrada;
		}

		/// <summary>
		/// Registra a utiliza��o de uma aplica��o por determinado usu�rio.
		/// </summary>
		/// <param name="usu�rio">Usu�rio.</param>
		/// <param name="aplica��o">Aplica��o utilizada.</param>
		public static Log Registrar(string usu�rio, Aplica��es aplica��o)
		{
			Log entrada = new Log(usu�rio, aplica��o);

			entrada.Cadastrar();

			return entrada;
		}
	}
}
