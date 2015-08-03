using System;

namespace Proxy.Clientes
{
	/// <summary>
	/// Exceção disparada quando o acesso a um site foi negado
	/// </summary>
	public class ExceçãoAcessoNegado : Exception
	{
		private const string mensagem = "O cliente não possui permissão de acesso à URL solicitada.";
		private string url;

		/// <summary>
		/// Constrói uma exceção de acesso negado a uma URL
		/// </summary>
		/// <param name="url">URL cujo acesso foi negado</param>
		public ExceçãoAcessoNegado(string url)
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
