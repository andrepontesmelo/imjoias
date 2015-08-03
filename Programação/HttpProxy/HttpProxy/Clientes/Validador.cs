using System;
using System.Collections;

#region BACKUP DA VERSÃO DO ANDRÉ
/*
using HttpProxy.Configuração;
using ByteFX.Data.MySqlClient;
using System.Data;

namespace HttpProxy.Clientes
{
	/// <summary>
	/// Valida um site
	/// </summary>
	public class Validador : Proxy.Clientes.Validador, IDisposable
	{
		private MySql		banco;
		private Hashtable	usrs = new Hashtable();
		private UsrSql		usrAtual;	

		private static Validador instância = null;

		/// <summary>
		/// Torna a classe singleton
		/// </summary>
		public static Validador Instância
		{
			get
			{
				if (instância == null)
					instância = new Validador();

				new System.Threading.Timer(new System.Threading.TimerCallback(instância.Timeout), null, 1000 * 60 * 60 * 4, System.Threading.Timeout.Infinite);

				return instância;
			}
		}

		/// <summary>
		/// Expiração do tempo de vida deste objeto
		/// </summary>
		private void Timeout(object obj)
		{
			instância = null;
			Dispose();
		}
		
		/// <summary>
		/// Construtora privada, sem acesso externo
		/// </summary>
		private Validador()
		{
			banco = new MySql();

			banco.Conectar("proxy", "192.168.1.10", "proxy", "imj");
			AtualizaSql();
		}

		public void Dispose()
		{
			banco.Dispose();
		}

		/// <summary>
		/// Constrói a hashtable de IPs
		/// </summary>
		public void AtualizaSql() 
		{
			banco.ConstruirHashTableIps(usrs);
		}

		/// <summary>
		/// Obtém permissão de acesso
		/// </summary>
		/// <param name="uri">URI de acesso</param>
		/// <param name="usuárioIp">IP do usuário</param>
		/// <returns>Permissão</returns>
		public override bool ObterPermissão(Uri uri, string usuárioIp)
		{	
			bool permissão = false;

			if (usrs.ContainsKey(usuárioIp)) 
			{
				usrAtual = ((UsrSql) usrs[usuárioIp]);

				if (usrAtual.TipoAcesso == 0) 
				{
					// O usuário é peão, pode acessar só os permitidos.
					permissão = usrAtual.EstáNaLista(uri.Host);
				} 
				else 
				{ 
					// O Usuário é admin, é restrito só os listados.
					permissão = !usrAtual.EstáNaLista(uri.Host);
				}			
			}

			if (!permissão)
				try
				{
					banco.LogaAcesso(usrAtual.Id, uri.Host, 0);
				}
				catch {}

			return permissão;
		}		
	}
}
*/
#endregion

namespace HttpProxy.Clientes
{
	/// <summary>
	/// Valida um site, autorizando aqueles que estiverem contidos
	/// na lida de hosts válidos.
	/// </summary>
	public class Validador : Proxy.Clientes.Validador
	{
		private ArrayList hosts;

		/// <summary>
		/// Constrói o validador
		/// </summary>
		public Validador()
		{
			hosts = new ArrayList();
		}

		/// <summary>
		/// Valida uma URI
		/// </summary>
		/// <param name="uri">URI a ser validada</param>
		/// <returns>Autorização para acesso</returns>
		public override bool Validar(Uri uri)
		{
			string host = uri.Host;
			int    iHost, iString = 0;

			do
			{
				host = host.Substring(iString);
				iHost = hosts.BinarySearch(host);
			} while (iHost < 0 && (iString = host.IndexOf('.') + 1) > 0);

			return iHost >= 0;
		}

		/// <summary>
		/// Adiciona um host à list
		/// </summary>
		/// <param name="host">Host cujo acesso é permitido</param>
		public void AdicionarHost(string host)
		{
			hosts.Add(host);
			hosts.Sort();
		}
	}
}