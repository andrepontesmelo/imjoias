using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Timers;

namespace Proxy.Servidores
{
	/// <summary>
	/// Cache de resolução de nomes
	/// </summary>
	/// <example>
	/// CacheDns  dns;
	/// IPAddress endereçoIp;
	/// 
	/// dns        = CacheDns.Instância;
	/// endereçoIp = dns.Resolver("www.imjoias.com.br");
	/// </example>
	public sealed class CacheDns
	{
		// Constantes
		private const int	tempoExpiração = 8 * 60; // Tempo para expirar a cache

		// Atributos
		private Hashtable	tabela;				// Tabela de endereços
		private Timer		timerLimpaCache;	// Timer para limpar a cache

		#region Singleton

		/// <summary>
		/// Deixar a construtora privada para que ninguém possa instânciá-la,
		/// se não a própria classe.
		/// </summary>
		private CacheDns()
		{
			tabela = new Hashtable();
			
			// Prepara o timer
			timerLimpaCache				= new Timer();
			timerLimpaCache.AutoReset	= true;
			timerLimpaCache.Interval	= tempoExpiração * 60 * 1000;
			timerLimpaCache.Elapsed    += new ElapsedEventHandler(timerLimpaCache_Elapsed);
			timerLimpaCache.Start();
		}

		/// <summary>
		/// Instância única (singleton) da classe CacheDns
		/// </summary>
		public static CacheDns instância = new CacheDns();

		/// <summary>
		/// Acesso à instância única da classe CacheDns
		/// </summary>
		public static CacheDns Instância
		{
			get { return instância; }
		}

		#endregion

		/// <summary>
		/// Resolve o nome de um endereço
		/// </summary>
		/// <param name="endereço"></param>
		/// <returns></returns>
		public IPAddress[] Resolver(string endereço) 
		{
			// verifica se existe na cache
			if (tabela.Contains(endereço))
				return (IPAddress[]) tabela[endereço];
			else 
			{	// Resolve o nome
				IPHostEntry resposta = Dns.Resolve(endereço);
			
				tabela[resposta.HostName] = resposta.AddressList;

				foreach (string alias in resposta.Aliases)
					tabela[alias] = resposta.AddressList;

				return resposta.AddressList;
			}
		}

		/// <summary>
		/// Ocorre quando avança o tempo de expiração
		/// </summary>
		private void timerLimpaCache_Elapsed(object sender, ElapsedEventArgs e)
		{
			tabela.Clear();
		}
	}
}
