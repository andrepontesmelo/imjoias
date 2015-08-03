using System;
using System.Collections;

#region BACKUP DA VERS�O DO ANDR�
/*
using HttpProxy.Configura��o;
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

		private static Validador inst�ncia = null;

		/// <summary>
		/// Torna a classe singleton
		/// </summary>
		public static Validador Inst�ncia
		{
			get
			{
				if (inst�ncia == null)
					inst�ncia = new Validador();

				new System.Threading.Timer(new System.Threading.TimerCallback(inst�ncia.Timeout), null, 1000 * 60 * 60 * 4, System.Threading.Timeout.Infinite);

				return inst�ncia;
			}
		}

		/// <summary>
		/// Expira��o do tempo de vida deste objeto
		/// </summary>
		private void Timeout(object obj)
		{
			inst�ncia = null;
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
		/// Constr�i a hashtable de IPs
		/// </summary>
		public void AtualizaSql() 
		{
			banco.ConstruirHashTableIps(usrs);
		}

		/// <summary>
		/// Obt�m permiss�o de acesso
		/// </summary>
		/// <param name="uri">URI de acesso</param>
		/// <param name="usu�rioIp">IP do usu�rio</param>
		/// <returns>Permiss�o</returns>
		public override bool ObterPermiss�o(Uri uri, string usu�rioIp)
		{	
			bool permiss�o = false;

			if (usrs.ContainsKey(usu�rioIp)) 
			{
				usrAtual = ((UsrSql) usrs[usu�rioIp]);

				if (usrAtual.TipoAcesso == 0) 
				{
					// O usu�rio � pe�o, pode acessar s� os permitidos.
					permiss�o = usrAtual.Est�NaLista(uri.Host);
				} 
				else 
				{ 
					// O Usu�rio � admin, � restrito s� os listados.
					permiss�o = !usrAtual.Est�NaLista(uri.Host);
				}			
			}

			if (!permiss�o)
				try
				{
					banco.LogaAcesso(usrAtual.Id, uri.Host, 0);
				}
				catch {}

			return permiss�o;
		}		
	}
}
*/
#endregion

namespace HttpProxy.Clientes
{
	/// <summary>
	/// Valida um site, autorizando aqueles que estiverem contidos
	/// na lida de hosts v�lidos.
	/// </summary>
	public class Validador : Proxy.Clientes.Validador
	{
		private ArrayList hosts;

		/// <summary>
		/// Constr�i o validador
		/// </summary>
		public Validador()
		{
			hosts = new ArrayList();
		}

		/// <summary>
		/// Valida uma URI
		/// </summary>
		/// <param name="uri">URI a ser validada</param>
		/// <returns>Autoriza��o para acesso</returns>
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
		/// Adiciona um host � list
		/// </summary>
		/// <param name="host">Host cujo acesso � permitido</param>
		public void AdicionarHost(string host)
		{
			hosts.Add(host);
			hosts.Sort();
		}
	}
}