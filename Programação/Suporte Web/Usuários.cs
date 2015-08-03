using System;
using System.Collections;
using Acesso.Comum;

namespace SuporteWeb
{
	/// <summary>
	/// Coleção de usuários
	/// </summary>
	[Serializable]
	public class SuporteUsuários
	{
		/// <summary>
		/// Obtém usuário atual.
		/// </summary>
		/// <param name="aplicação">Aplicação do usuário.</param>
		/// <param name="sessão">Sessão do usuário.</param>
		/// <returns>Usuário atual.</returns>
		public static Usuário ObterUsuárioAtual(System.Web.HttpApplicationState aplicação, System.Web.SessionState.HttpSessionState sessão)
		{
			Usuários usrs = (Usuários) aplicação["usuários"];

			return usrs[(Acesso.Comum.Chave) sessão["chave"]];
		}

		/// <summary>
		/// Obtém usuário atual
		/// </summary>
		/// <param name="página">Página requerinte</param>
		/// <returns>Usuário atual</returns>
		public static Usuário ObterUsuárioAtual(System.Web.UI.Page página)
		{
			Usuários usrs = (Usuários) página.Application["usuários"];
			Chave    chave = (Acesso.Comum.Chave) página.Session["chave"];
			Usuário  usr  = usrs[chave];

			return usr;
		}

		/// <summary>
		/// Registra utilização do usuário atual.
		/// </summary>
		/// <param name="aplicação">Aplicação utilizada.</param>
		/// <param name="parâmetros">Parâmetros utilizados.</param>
		/// <returns>Registro de utilização.</returns>
		public static Entidades.Log RegistrarUtilização(System.Web.UI.Page página, Entidades.Log.Aplicações aplicação, string parâmetros)
		{
			Entidades.Log registro;

			registro = Entidades.Log.Registrar(ObterUsuárioAtual(página).Nome, aplicação, parâmetros);

			return registro;
		}

		/// <summary>
		/// Registra utilização do usuário atual.
		/// </summary>
		/// <param name="aplicação">Aplicação utilizada.</param>
		/// <param name="parâmetros">Parâmetros utilizados.</param>
		/// <returns>Registro de utilização.</returns>
		public static Entidades.Log RegistrarUtilização(System.Web.UI.Page página, Entidades.Log.Aplicações aplicação)
		{
			Entidades.Log registro;
			Usuário       usr;

			usr      = ObterUsuárioAtual(página);
			registro = Entidades.Log.Registrar(usr.Nome, aplicação);

			return registro;
		}

		/// <summary>
		/// Recupera usuário atual e atribui ao contexto da aplicação.
		/// </summary>
		public static void RecuperarUsuário(System.Web.UI.Page página)
		{
			System.AppDomain.CurrentDomain.SetData("usuário", ObterUsuárioAtual(página));
		}

		public static Usuários ConstruirUsuários()
		{
			Usuários usrs = new Acesso.MySQL.MySQLUsuários();
			string a;

			a = usrs.ToString();

			return usrs;
		}
	}
}
