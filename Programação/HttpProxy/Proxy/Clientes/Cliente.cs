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
	/// Cliente do proxy, que acessa servidores, conforme autoriza��o de um validador
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
		/// Constr�i um cliente
		/// </summary>
		public Cliente(Socket cliente)
		{
			this.cliente = cliente;

			// Adquire perfis
			perfis = GerentePerfis.Inst�ncia[(cliente.RemoteEndPoint as IPEndPoint).Address.GetAddressBytes()];

			// Constr�i tabela de processamento
			tabelaProcessador = new Hashtable();
			ConstruirTabelaProcessamento();

			// Constr�i thread de comunica��o
			thread = new Thread(new ThreadStart(Comunicar));
			thread.Start();
		}

		/// <summary>
		/// Destr�i o cliente
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
		/// Constr�i tabela de processamento, vinculando comandos
		/// a fun��es espec�ficas.
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
				Processador		processador;						// Fun��o para processar o comando
				ASCIIEncoding	ascii;

				ascii = new ASCIIEncoding();

				do
				{
					string [] linhas;

					// L� os dados
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
		/// Verifica se o cliente est� conectado
		/// </summary>
		public bool Conectado
		{
			get { return cliente.Connected; }
		}

		/// <summary>
		/// Obt�m o endere�o IP do cliente
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
		/// <returns>Autoriza��o de acesso</returns>
		public bool Validar(Uri uri)
		{
			bool permiss�o = false;

			foreach (Perfil perfil in perfis)
				permiss�o |= perfil.Validar(uri);

			return permiss�o;
		}
	}

}
