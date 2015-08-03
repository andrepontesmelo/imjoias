using System;

namespace Estat�stica.Db
{
	/// <summary>
	/// Summary description for Exce��oDefini��oIncorreta.
	/// </summary>
	public class Exce��oDefini��oIncorreta : Exception
	{
		private string mensagem;

		/// <summary>
		/// Constr�i o erro
		/// </summary>
		/// <param name="mensagem">Mensagem do erro</param>
		public Exce��oDefini��oIncorreta(string mensagem)
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
