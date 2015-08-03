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
		private IPAddress [] endereçosIP;
		protected Socket	 conexão;
		protected IPEndPoint ponto;

		// Evento disparado na recepção de dados
		public delegate void RecebimentoDelegate(byte [] dados, int bytesLidos);
		public event RecebimentoDelegate Recebimento;

		public delegate void FechadoDelegate();
		public event FechadoDelegate Fechado;

		/// <summary>
		/// Constrói o servidor a partir de um host
		/// </summary>
		/// <param name="host">Host do servidor</param>
		public Servidor(string host, int porta)
		{
			CacheDns dns;

			// Obter o ip
			dns = CacheDns.Instância;
			endereçosIP = dns.Resolver(host);
			
			// Conectar no servidor
			Conectar(porta);

			// Construir thread de leitura
			threadRecebimento = new Thread(new ThreadStart(Leitor));
			threadRecebimento.Start();
		}

		private Servidor() {}

		/// <summary>
		/// Destrói o servidor
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
			if (conexão != null && conexão.Connected)
			{
				conexão.Shutdown(SocketShutdown.Both);
				conexão.Close();
				conexão = null;
			}
			
			if (threadRecebimento != null)
			{
				threadRecebimento.Abort();
				threadRecebimento = null;
			}
		}

		/// <summary>
		/// Estabelece conexão com o servidor
		/// </summary>
		private void Conectar(int porta)
		{
			Exception exceção = null;
			int       iEndereço = 0;

			conexão = null;

			// Tenta conectar nos IPs disponíveis
			while (iEndereço < endereçosIP.Length && conexão == null)
			{
				try
				{
					IPAddress endereço = endereçosIP[iEndereço];

					// Cria o socket
					conexão = new Socket(endereço.AddressFamily,
						SocketType.Stream,
						ProtocolType.Tcp);

					// Cria o ponto de rede final
					ponto = new IPEndPoint(endereço, porta);		// Ponto final de rede

					// Conecta
					conexão.Connect(ponto);
				}
				catch (Exception e)
				{
					exceção = e;
					conexão = null;
				}
			}

			// Verificar se conexão está estabelecida
			if (conexão == null)
			{
				Dispose();

				if (exceção != null)
					throw exceção;
				
				throw new Exception("Não foi possível conectar no servidor");
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
				conexão.Send(buffer, quantidade, SocketFlags.None);
			}
			catch (Exception e)
			{
				Dispose();

				throw e;
			}
		}

		/// <summary>
		/// Envia uma requisição e aguarda a resposta
		/// </summary>
		/// <returns>Dados recebidos</returns>
		public abstract byte [] EnviarRequisição();

		/// <summary>
		/// Verifica se está conectado
		/// </summary>
		public bool Conectado
		{
			get { return conexão.Connected; }
		}

		/// <summary>
		/// Lê os dados do servidor
		/// </summary>
		private void Leitor()
		{
			try
			{
				byte [] buffer = new byte[bufferTamanho];
				int bytesLidos;

				do
				{
					// Lê dados da conexão
					bytesLidos = conexão.Receive(buffer, bufferTamanho, SocketFlags.None);

					// Dispara evento
					Recebimento(buffer, bytesLidos);
					DadosRecebidos(buffer, bytesLidos);
				} while (conexão.Connected && bytesLidos > 0);

				conexão.Shutdown(SocketShutdown.Both);
				conexão.Close();
				conexão = null;

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
		/// Ocorre quando bytes são lidos do servidor
		/// </summary>
		/// <param name="buffer">Buffer recebido</param>
		/// <param name="bytesLidos">Quantidade de bytes lidos</param>
		public abstract void DadosRecebidos(byte [] buffer, int bytesLidos);
	}
}
