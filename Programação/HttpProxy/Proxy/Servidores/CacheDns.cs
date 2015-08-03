using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Timers;

namespace Proxy.Servidores
{
	/// <summary>
	/// Cache de resolu��o de nomes
	/// </summary>
	/// <example>
	/// CacheDns  dns;
	/// IPAddress endere�oIp;
	/// 
	/// dns        = CacheDns.Inst�ncia;
	/// endere�oIp = dns.Resolver("www.imjoias.com.br");
	/// </example>
	public sealed class CacheDns
	{
		// Constantes
		private const int	tempoExpira��o = 8 * 60; // Tempo para expirar a cache

		// Atributos
		private Hashtable	tabela;				// Tabela de endere�os
		private Timer		timerLimpaCache;	// Timer para limpar a cache

		#region Singleton

		/// <summary>
		/// Deixar a construtora privada para que ningu�m possa inst�nci�-la,
		/// se n�o a pr�pria classe.
		/// </summary>
		private CacheDns()
		{
			tabela = new Hashtable();
			
			// Prepara o timer
			timerLimpaCache				= new Timer();
			timerLimpaCache.AutoReset	= true;
			timerLimpaCache.Interval	= tempoExpira��o * 60 * 1000;
			timerLimpaCache.Elapsed    += new ElapsedEventHandler(timerLimpaCache_Elapsed);
			timerLimpaCache.Start();
		}

		/// <summary>
		/// Inst�ncia �nica (singleton) da classe CacheDns
		/// </summary>
		public static CacheDns inst�ncia = new CacheDns();

		/// <summary>
		/// Acesso � inst�ncia �nica da classe CacheDns
		/// </summary>
		public static CacheDns Inst�ncia
		{
			get { return inst�ncia; }
		}

		#endregion

		/// <summary>
		/// Resolve o nome de um endere�o
		/// </summary>
		/// <param name="endere�o"></param>
		/// <returns></returns>
		public IPAddress[] Resolver(string endere�o) 
		{
			// verifica se existe na cache
			if (tabela.Contains(endere�o))
				return (IPAddress[]) tabela[endere�o];
			else 
			{	// Resolve o nome
				IPHostEntry resposta = Dns.Resolve(endere�o);
			
				tabela[resposta.HostName] = resposta.AddressList;

				foreach (string alias in resposta.Aliases)
					tabela[alias] = resposta.AddressList;

				return resposta.AddressList;
			}
		}

		/// <summary>
		/// Ocorre quando avan�a o tempo de expira��o
		/// </summary>
		private void timerLimpaCache_Elapsed(object sender, ElapsedEventArgs e)
		{
			tabela.Clear();
		}
	}
}
