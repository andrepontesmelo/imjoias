using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Proxy.Servidores
{
	/// <summary>
	/// Servidor HTTP
	/// </summary>
	public abstract class Servidor : IDisposable
	{
		// Constantes
		private const int	bufferTamanho = 4096;

		// Atributos
		private Thread		threadRecebimento;		// Recebe os dados
		private IPAddress [] endere�osIP;
		protected Socket	 conex�o;
		protected IPEndPoint ponto;

		// Evento disparado na recep��o de dados
		public delegate void RecebimentoDelegate(byte [] dados, int bytesLidos);
		public event RecebimentoDelegate Recebimento;

		public delegate void FechadoDelegate();
		public event FechadoDelegate Fechado;

		/// <summary>
		/// Constr�i o servidor a partir de um host
		/// </summary>
		/// <param name="host">Host do servidor</param>
		public Servidor(string host, int porta)
		{
			CacheDns dns;

			// Obter o ip
			dns = CacheDns.Inst�ncia;
			endere�osIP = dns.Resolver(host);
			
			// Conectar no servidor
			Conectar(porta);

			// Construir thread de leitura
			threadRecebimento = new Thread(new ThreadStart(Leitor));
			threadRecebimento.Start();
		}

		private Servidor() {}

		/// <summary>
		/// Destr�i o servidor
		/// </summary>
		~Servidor()
		{
			Dispose();
		}

		/// <summary>
		/// Libera os recursos do objeto
		/// </summary>
		public virtual void Dispose()
		{
			if (conex�o != null && conex�o.Connected)
			{
				conex�o.Shutdown(SocketShutdown.Both);
				conex�o.Close();
				conex�o = null;
			}
			
			if (threadRecebimento != null)
			{
				threadRecebimento.Abort();
				threadRecebimento = null;
			}
		}

		/// <summary>
		/// Estabelece conex�o com o servidor
		/// </summary>
		private void Conectar(int porta)
		{
			Exception exce��o = null;
			int       iEndere�o = 0;

			conex�o = null;

			// Tenta conectar nos IPs dispon�veis
			while (iEndere�o < endere�osIP.Length && conex�o == null)
			{
				try
				{
					IPAddress endere�o = endere�osIP[iEndere�o];

					// Cria o socket
					conex�o = new Socket(endere�o.AddressFamily,
						SocketType.Stream,
						ProtocolType.Tcp);

					// Cria o ponto de rede final
					ponto = new IPEndPoint(endere�o, porta);		// Ponto final de rede

					// Conecta
					conex�o.Connect(ponto);
				}
				catch (Exception e)
				{
					exce��o = e;
					conex�o = null;
				}
			}

			// Verificar se conex�o est� estabelecida
			if (conex�o == null)
			{
				Dispose();

				if (exce��o != null)
					throw exce��o;
				
				throw new Exception("N�o foi poss�vel conectar no servidor");
			}
		}

		/// <summary>
		/// Envia um buffer para o servidor
		/// </summary>
		/// <param name="buffer">Buffer a ser enviado</param>
		/// <param name="quantidade">Quantidade de bytes a serem enviados</param>
		public void Enviar(byte [] buffer, int quantidade)
		{
			try
			{
				conex�o.Send(buffer, quantidade, SocketFlags.None);
			}
			catch (Exception e)
			{
				Dispose();

				throw e;
			}
		}

		/// <summary>
		/// Envia uma requisi��o e aguarda a resposta
		/// </summary>
		/// <returns>Dados recebidos</returns>
		public abstract byte [] EnviarRequisi��o();

		/// <summary>
		/// Verifica se est� conectado
		/// </summary>
		public bool Conectado
		{
			get { return conex�o.Connected; }
		}

		/// <summary>
		/// L� os dados do servidor
		/// </summary>
		private void Leitor()
		{
			try
			{
				byte [] buffer = new byte[bufferTamanho];
				int bytesLidos;

				do
				{
					// L� dados da conex�o
					bytesLidos = conex�o.Receive(buffer, bufferTamanho, SocketFlags.None);

					// Dispara evento
					Recebimento(buffer, bytesLidos);
					DadosRecebidos(buffer, bytesLidos);
				} while (conex�o.Connected && bytesLidos > 0);

				conex�o.Shutdown(SocketShutdown.Both);
				conex�o.Close();
				conex�o = null;

				// Disparar evento
				if (Fechado != null)
					Fechado();
			}
			finally
			{
				threadRecebimento = null;
				Dispose();
			}
		}

		/// <summary>
		/// Ocorre quando bytes s�o lidos do servidor
		/// </summary>
		/// <param name="buffer">Buffer recebido</param>
		/// <param name="bytesLidos">Quantidade de bytes lidos</param>
		public abstract void DadosRecebidos(byte [] buffer, int bytesLidos);
	}
}
