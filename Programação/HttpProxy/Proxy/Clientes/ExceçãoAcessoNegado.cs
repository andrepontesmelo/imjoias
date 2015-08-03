using System;

namespace Proxy.Clientes
{
	/// <summary>
	/// Exce��o disparada quando o acesso a um site foi negado
	/// </summary>
	public class Exce��oAcessoNegado : Exception
	{
		private const string mensagem = "O cliente n�o possui permiss�o de acesso � URL solicitada.";
		private string url;

		/// <summary>
		/// Constr�i uma exce��o de acesso negado a uma URL
		/// </summary>
		/// <param name="url">URL cujo acesso foi negado</param>
		public Exce��oAcessoNegado(string url)
		{
			this.url = url;
		}

		/// <summary>
		/// URL cujo acesso foi negado
		/// </summary>
		public string URL
		{
			get { return url; }
		}

		/// <summary>
		/// Mensagem de erro
		/// </summary>
		public override string Message
		{
			get { return mensagem; }
		}

		public override string ToString()
		{
			return mensagem + "\r\n" + "URL: " + url;
		}
	}
}
