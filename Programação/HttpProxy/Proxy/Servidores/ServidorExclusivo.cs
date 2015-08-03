using System;
using System.Net.Sockets;

namespace Proxy.Servidores
{
	/// <summary>
	/// Servidor Exclusivo implementa uma conex�o exclusiva de um
	/// cliente para um servidor. Todo dado enviado � repassado
	/// sem qualquer filtro e todo dado recebido � enviado ao cliente.
	/// </summary>
	/// <remarks>
	/// Utiliza-se uma thread separada para recebimento de dados
	/// </remarks>
	public class ServidorExclusivo : Servidor
	{
		/// <summary>
		/// Constr�i um servidor exclusivo
		/// </summary>
		public ServidorExclusivo(string host,int porta) : base(host, porta)
		{
		}

		/// <summary>
		/// Envia uma requisi��o ao servidor e espera por uma repsosta
		/// </summary>
		public override byte[] EnviarRequisi��o()
		{
			throw new NotSupportedException("O servidor exclusivo n�o suporta enviar requisi��o");
		}

		/// <summary>
		/// Ocorre quando bytes s�o lidos do servidor
		/// </summary>
		/// <param name="buffer">Buffer recebido</param>
		/// <param name="bytesLidos">Quantidade de bytes lidos</param>
		public override void DadosRecebidos(byte[] buffer, int bytesLidos)
		{
			// Fa�a nada
		}

	}
}
