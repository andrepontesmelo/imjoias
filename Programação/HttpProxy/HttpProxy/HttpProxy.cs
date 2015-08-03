using System;
using System.Threading;
using System.Net.Sockets;
using HttpProxy.Clientes;
using System.Xml;

namespace HttpProxy
{
	/// <summary>
	/// Summary description for HttpProxy.
	/// </summary>
	public class HttpProxy : IDisposable
	{
		private Thread		servidor;		// Escuta as conexoes
		private TcpListener	escuta;

		/// <summary>
		/// Constrói o proxy http
		/// </summary>
		public HttpProxy(int porta)
		{
			// Carrega os perfis
			CarregarPerfis();

			// Escuta a porta
			escuta = new TcpListener(porta);
			escuta.Start();
		
			// Prepara a thread para escutar o servidor
			servidor = new Thread(new ThreadStart(Escutar));
			servidor.Start();
		}
	
		/// <summary>
		/// Escuta a porta para recebimento de conexões
		/// </summary>
		private void Escutar()
		{
			while (true)
			{
				Socket cliente = escuta.AcceptSocket();
				
				/* TODO: Controlar existência de clientes, armazenando-os
				 * em uma lista.
				 */
				
				new Cliente(cliente);
			}
		}

		#region IDisposable Members

		/// <summary>
		/// Libera recursos, parando o servidor
		/// </summary>
		public void Dispose()
		{
			servidor.Abort();
			escuta.Stop();
		}

		#endregion

		/// <summary>
		/// Carrega os perfis
		/// </summary>
		private void CarregarPerfis()
		{
			System.IO.FileStream arq = System.IO.File.OpenWrite(@"C:\InetPub\wwwroot\httpproxy.txt");
			Proxy.Clientes.GerentePerfis perfis;
			XmlDocument doc;
			string s = "";
			
			doc = new XmlDocument();
			perfis = Proxy.Clientes.GerentePerfis.Instância;
			
			try
			{
				doc.Load("HttpProxy.xml");

				CarregarPerfil(doc);

				s = "Carregado com sucesso!\n\n";
			}
			catch (Exception e)
			{
				s = e.ToString();
				
				Validador padrão = new Validador();
				
				padrão.AdicionarHost("imjoias.com.br");
				padrão.AdicionarHost("192.168.1.10");

				perfis.AdicionarPerfil(
					new Proxy.Clientes.Perfil(
					new byte [] { 0, 0, 0, 0 },
					new byte [] { 0, 0, 0, 0 },
					padrão));
			}
			finally
			{
				System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
				arq.Write(ascii.GetBytes(s), 0, ascii.GetByteCount(s));
				arq.Close();
			}
		}

		private void CarregarPerfil(XmlDocument doc)
		{
			Validador validador = null;
			Proxy.Clientes.GerentePerfis gerente;

			gerente = Proxy.Clientes.GerentePerfis.Instância;

			foreach (XmlNode nodo in doc.DocumentElement)
			{
				// Carrega o validador
				if (string.Compare(nodo.Name, "validador", true) == 0)
				{
					validador = new Validador();

					foreach (XmlNode filho in nodo.ChildNodes)
					{
						if (string.Compare(filho.Name, "permitir", true) == 0)
							validador.AdicionarHost(filho.Attributes["host"].Value);
						else
							throw new ArgumentException("Nodo não reconhecido " + filho.ToString());
					}
				}
				else if (string.Compare(nodo.Name, "perfil", true) == 0)
				{
					if (validador != null)
					{
						Proxy.Clientes.Perfil perfil;

						perfil = new Proxy.Clientes.Perfil(
							nodo.Attributes["ip"].Value,
							nodo.Attributes["máscara"].Value,
							validador);

						gerente.AdicionarPerfil(perfil);
					}
					else
						throw new ArgumentException("Necessário a configuração de um validador antes de criar um perfil!");
				}
			}
		}
	}
}
