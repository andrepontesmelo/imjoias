using System;

namespace Estatística.Db
{
	/// <summary>
	/// Summary description for ExceçãoDefiniçãoIncorreta.
	/// </summary>
	public class ExceçãoDefiniçãoIncorreta : Exception
	{
		private string mensagem;

		/// <summary>
		/// Constrói o erro
		/// </summary>
		/// <param name="mensagem">Mensagem do erro</param>
		public ExceçãoDefiniçãoIncorreta(string mensagem)
		{
			this.mensagem = mensagem;
		}

		/// <summary>
		/// Mensagem de erro
		/// </summary>
		public override string Message
		{
			get { return mensagem; }
		}
	}
}
