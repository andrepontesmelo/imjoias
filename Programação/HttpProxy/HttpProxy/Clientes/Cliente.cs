using System;
using System.Collections;
using System.Net.Sockets;
using Proxy.Servidores;
using System.Threading;

namespace HttpProxy.Clientes
{
	/// <summary>
	/// Summary description for Cliente.
	/// </summary>
	public class Cliente : Proxy.Clientes.Cliente
	{
		// Constantes
		private const string uriAcessoNegado = "http://192.168.1.10/acessoNegado.html";

		public Cliente(Socket cliente) : base(cliente)
		{
		}

		/// <summary>
		/// Constrói tabela de processamento, vinculando comandos
		/// a funções específicas.
		/// </summary>
		protected override void ConstruirTabelaProcessamento()
		{
			InserirProcessamento("GET", new Processador(ProcessarGet));
		}

		/// <summary>
		/// Processa uma linha de comando do tipo GET
		/// </summary>
		/// <param name="linha">Linha de comando</param>
		/// <param name="palavras">Lista de palavras (string)</param>
		/// <param name="buffer">Todo o buffer recebido</param>
		private void ProcessarGet(string linha, IList palavras, byte [] buffer, int bufferTamanho)
		{
			Servidor  servidor;
			Uri		  uri;
			
			// Verifica versão do protocolo
			if ((string) palavras[2] == "HTTP/1.1")
				throw new NotImplementedException("O protocolo HTTP 1.1 ainda não foi implementado e não é compatível!");

			// Processa a URI
			uri = new Uri((string) palavras[1]);

			// Ver permissão para acesso
			if (uri.AbsoluteUri != uriAcessoNegado && !Validar(uri))
			{
				Redirecionar(uriAcessoNegado);
#if !DEBUG
				throw new Proxy.Clientes.ExceçãoAcessoNegado((string) palavras[1]);
#else
				Dispose();
				return;
#endif
			}

			// Obter conexão
			/* Futuramente, mudar para Servidores["host"] e tratar
			 * como um objeto Servidor.
			 */
			servidor = GerenteServidores.Instância[uri.Host, uri.IsDefaultPort ? 80 : uri.Port];
			servidor.Recebimento += new ServidorExclusivo.RecebimentoDelegate(servidor_Recebimento);
			servidor.Fechado += new Proxy.Servidores.Servidor.FechadoDelegate(servidor_Fechado);
			servidor.Enviar(buffer, bufferTamanho);
		}

		/// <summary>
		/// Ocorre quando o servidor recebe dados
		/// </summary>
		[Obsolete("Deverá ser removido depois de construir as classes ServidorHTTP10 e ServidorHTTP11")]
		private void servidor_Recebimento(byte[] dados, int bytesLidos)
		{
			try
			{
				//mandouAlgo = true;
				cliente.Send(dados, bytesLidos,SocketFlags.None);
			}
			catch
			{}
		}

		/// <summary>
		/// Ocorre quando o servidor fecha a conexão
		/// </summary>
		private void servidor_Fechado()
		{
			Dispose();
		}

		/// <summary>
		/// Redireciona para outro endereço
		/// </summary>
		/// <param name="uri">URI destino</param>
		private void Redirecionar(string uri)
		{
			byte [] buffer;
			
			buffer = System.Text.Encoding.ASCII.GetBytes("HTTP/1.0 307 Temporary Redirect\r\n"
				+ "Location: " + uri + "\r\n\r\nRedirecionado temporariamente para <a href='"
				+ uri + "'>" + uri + "</a>");

			cliente.Send(buffer);
		}
	}
}
