using System;
using System.Collections;
using Acesso.Comum;

namespace SuporteWeb
{
	/// <summary>
	/// Cole��o de usu�rios
	/// </summary>
	[Serializable]
	public class SuporteUsu�rios
	{
		/// <summary>
		/// Obt�m usu�rio atual.
		/// </summary>
		/// <param name="aplica��o">Aplica��o do usu�rio.</param>
		/// <param name="sess�o">Sess�o do usu�rio.</param>
		/// <returns>Usu�rio atual.</returns>
		public static Usu�rio ObterUsu�rioAtual(System.Web.HttpApplicationState aplica��o, System.Web.SessionState.HttpSessionState sess�o)
		{
			Usu�rios usrs = (Usu�rios) aplica��o["usu�rios"];

			return usrs[(Acesso.Comum.Chave) sess�o["chave"]];
		}

		/// <summary>
		/// Obt�m usu�rio atual
		/// </summary>
		/// <param name="p�gina">P�gina requerinte</param>
		/// <returns>Usu�rio atual</returns>
		public static Usu�rio ObterUsu�rioAtual(System.Web.UI.Page p�gina)
		{
			Usu�rios usrs = (Usu�rios) p�gina.Application["usu�rios"];
			Chave    chave = (Acesso.Comum.Chave) p�gina.Session["chave"];
			Usu�rio  usr  = usrs[chave];

			return usr;
		}

		/// <summary>
		/// Registra utiliza��o do usu�rio atual.
		/// </summary>
		/// <param name="aplica��o">Aplica��o utilizada.</param>
		/// <param name="par�metros">Par�metros utilizados.</param>
		/// <returns>Registro de utiliza��o.</returns>
		public static Entidades.Log RegistrarUtiliza��o(System.Web.UI.Page p�gina, Entidades.Log.Aplica��es aplica��o, string par�metros)
		{
			Entidades.Log registro;

			registro = Entidades.Log.Registrar(ObterUsu�rioAtual(p�gina).Nome, aplica��o, par�metros);

			return registro;
		}

		/// <summary>
		/// Registra utiliza��o do usu�rio atual.
		/// </summary>
		/// <param name="aplica��o">Aplica��o utilizada.</param>
		/// <param name="par�metros">Par�metros utilizados.</param>
		/// <returns>Registro de utiliza��o.</returns>
		public static Entidades.Log RegistrarUtiliza��o(System.Web.UI.Page p�gina, Entidades.Log.Aplica��es aplica��o)
		{
			Entidades.Log registro;
			Usu�rio       usr;

			usr      = ObterUsu�rioAtual(p�gina);
			registro = Entidades.Log.Registrar(usr.Nome, aplica��o);

			return registro;
		}

		/// <summary>
		/// Recupera usu�rio atual e atribui ao contexto da aplica��o.
		/// </summary>
		public static void RecuperarUsu�rio(System.Web.UI.Page p�gina)
		{
			System.AppDomain.CurrentDomain.SetData("usu�rio", ObterUsu�rioAtual(p�gina));
		}

		public static Usu�rios ConstruirUsu�rios()
		{
			Usu�rios usrs = new Acesso.MySQL.MySQLUsu�rios();
			string a;

			a = usrs.ToString();

			return usrs;
		}
	}
}
