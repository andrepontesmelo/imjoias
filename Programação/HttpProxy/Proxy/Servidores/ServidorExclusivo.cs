using System;
using System.Net.Sockets;

namespace Proxy.Servidores
{
	/// <summary>
	/// Servidor Exclusivo implementa uma conexão exclusiva de um
	/// cliente para um servidor. Todo dado enviado é repassado
	/// sem qualquer filtro e todo dado recebido é enviado ao cliente.
	/// </summary>
	/// <remarks>
	/// Utiliza-se uma thread separada para recebimento de dados
	/// </remarks>
	public class ServidorExclusivo : Servidor
	{
		/// <summary>
		/// Constrói um servidor exclusivo
		/// </summary>
		public ServidorExclusivo(string host,int porta) : base(host, porta)
		{
		}

		/// <summary>
		/// Envia uma requisição ao servidor e espera por uma repsosta
		/// </summary>
		public override byte[] EnviarRequisição()
		{
			throw new NotSupportedException("O servidor exclusivo não suporta enviar requisição");
		}

		/// <summary>
		/// Ocorre quando bytes são lidos do servidor
		/// </summary>
		/// <param name="buffer">Buffer recebido</param>
		/// <param name="bytesLidos">Quantidade de bytes lidos</param>
		public override void DadosRecebidos(byte[] buffer, int bytesLidos)
		{
			// Faça nada
		}

	}
}
