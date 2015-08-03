using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Net;
using Proxy.Servidores;

namespace Proxy.Clientes
{
	/// <summary>
	/// Cliente do proxy, que acessa servidores, conforme autorização de um validador
	/// </summary>
	public abstract class Cliente : IDisposable
	{
		// Constante
		private const int	bufferTamanho = 4096;

		// Atributos
		private Perfil []			perfis;
		protected Socket			cliente;
		private Thread				thread;
		private Hashtable			tabelaProcessador;

		protected delegate void Processador(string linha, IList palavras, byte [] buffer, int bufferTamanho);

		/// <summary>
		/// Constrói um cliente
		/// </summary>
		public Cliente(Socket cliente)
		{
			this.cliente = cliente;

			// Adquire perfis
			perfis = GerentePerfis.Instância[(cliente.RemoteEndPoint as IPEndPoint).Address.GetAddressBytes()];

			// Constrói tabela de processamento
			tabelaProcessador = new Hashtable();
			ConstruirTabelaProcessamento();

			// Constrói thread de comunicação
			thread = new Thread(new ThreadStart(Comunicar));
			thread.Start();
		}

		/// <summary>
		/// Destrói o cliente
		/// </summary>
		~Cliente()
		{
			Dispose();
		}

		/// <summary>
		/// Libera recursos
		/// </summary>
		public virtual void Dispose()
		{
			if (cliente != null && cliente.Connected)
			{
				cliente.Shutdown(SocketShutdown.Both);
				cliente.Close();
				cliente = null;
			}
			
			if (thread != null)
			{
				thread.Abort();
				thread = null;
			}
		}

		/// <summary>
		/// Constrói tabela de processamento, vinculando comandos
		/// a funções específicas.
		/// </summary>
		protected abstract void ConstruirTabelaProcessamento();

		/// <summary>
		/// Insere comando de processamento
		/// </summary>
		/// <param name="comando">Comando a ser processado</param>
		/// <param name="processador">Processador para tratar o comando</param>
		protected void InserirProcessamento(string comando, Processador processador)
		{
			tabelaProcessador.Add(comando, processador);
		}

		/// <summary>
		/// Comunica-se com o cliente
		/// </summary>
		private void Comunicar()
		{
#if !DEBUG
			try
#endif
			{
				byte []			buffer = new byte[bufferTamanho];	// Buffer para leitura do socket
				int				quantidade;							// Quantidade de bytes lidos
				Processador		processador;						// Função para processar o comando
				ASCIIEncoding	ascii;

				ascii = new ASCIIEncoding();

				do
				{
					string [] linhas;

					// Lê os dados
					try
					{
						quantidade = cliente.Receive(buffer, 0, bufferTamanho, SocketFlags.None);
					}
					catch (SocketException)
					{
						Dispose();
						return;
					}

					linhas = ascii.GetString(buffer, 0, quantidade).Split('\n');

					// Processa a linha
					foreach (string linha in linhas)
					{
						string [] palavras;

						if (linha.Length < 1)
							continue;

						// Remover o \r
						if (linha.Substring(linha.Length - 1, 1) == "\r")
							linha.Remove(linha.Length - 1, 1);

						// Separar as palavras
						palavras = linha.Split(' ');

						// Processa a linha, se houver processador
						processador = (Processador) tabelaProcessador[palavras[0]];

						if (processador != null)
							processador(linha.ToString(), palavras, buffer, quantidade);
					}
				} while (cliente.Connected && quantidade > 0);
			}
#if !DEBUG
			catch
			{
			}
			finally
			{
				thread = null;
				Dispose();
			}
#else
			thread = null;
#endif
		}

		/// <summary>
		/// Verifica se o cliente está conectado
		/// </summary>
		public bool Conectado
		{
			get { return cliente.Connected; }
		}

		/// <summary>
		/// Obtém o endereço IP do cliente
		/// </summary>
		public string IP
		{
			get
			{
				byte [] endIp = ((IPEndPoint) this.cliente.RemoteEndPoint).Address.GetAddressBytes();

				return endIp[0].ToString() + "." + endIp[1].ToString() + "." + endIp[2].ToString() + "." + endIp[3].ToString();
			}
		}

		/// <summary>
		/// Valida uma URI
		/// </summary>
		/// <param name="uri">URI a ser validada</param>
		/// <returns>Autorização de acesso</returns>
		public bool Validar(Uri uri)
		{
			bool permissão = false;

			foreach (Perfil perfil in perfis)
				permissão |= perfil.Validar(uri);

			return permissão;
		}
	}

}
