/*
using System;
using System.Data;
using System.Data.SqlClient;
using ByteFX.Data;
using System.Windows.Forms;
using System.Collections;

namespace HttpProxy.Configuração
{
	/// <summary>
	/// Acesso ao MySQl
	/// </summary>
	public class MySql : IDisposable
	{
		ByteFX.Data.MySqlClient.MySqlConnection conexão;
		ByteFX.Data.MySqlClient.MySqlCommand cmd;
		ByteFX.Data.MySqlClient.MySqlDataReader leitor = null;
		Hashtable linksCache=null;

		public MySql()
		{
			
			//
			// TODO: Add constructor logic here
			//
		}

		public void Conectar(string database,string host,string login, string password) 
		{
			//System.Windows.Forms.MessageBox.Show("conectando no mysql...");
			if (conexão != null) conexão.Close();
			conexão = new ByteFX.Data.MySqlClient.MySqlConnection(
				"Database=" + database +
				";Data Source=" + host +
				";User Id=" + login +
				";Password=" + password);
			conexão.Open();
			//TODO: como faz o try ?
			try 
			{
				cmd = new ByteFX.Data.MySqlClient.MySqlCommand("",conexão);
			} 
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

			}
			//System.Windows.Forms.MessageBox.Show("sucesso na conexão.");
		}
		
			
		//Recuperação de dados 
		public String ComandoString(string ComandoSql) 
		{
			cmd.CommandText = ComandoSql;
			leitor = cmd.ExecuteReader();
			string retornarei= "";
			while ( leitor.Read() ) 
			{
				retornarei += leitor.GetString(0);
			}
			leitor.Close();
			return retornarei;
		}
		public int ComandoInt(string ComandoSql) 
		{
			cmd.CommandText = ComandoSql;
			leitor = cmd.ExecuteReader();
			int retornarei=0;
			while ( leitor.Read() ) 
			{
				retornarei = leitor.GetInt32(retornarei);
			}
			leitor.Close();
			return retornarei;
		}

		public ArrayList LerArrayList(string comando)
		{
			ArrayList retornarei= new ArrayList();
			cmd.CommandText = comando;
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				retornarei.Add(leitor.GetString(0));
			}
			leitor.Close();
			return retornarei;
		}
		public void ConstruirHashTableIps(Hashtable tabela)
		{
			tabela.Clear();
			cmd.CommandText = "select enderecoIp,tipoAcesso, id from ips,usuarios WHERE usuarios.id = ips.usuarioId";
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				tabela.Add(leitor.GetString(0),new UsrSql( leitor.GetString(0) , leitor.GetInt32(1),leitor.GetInt32(2),this));
				//leitor.GetString(0
			}
			leitor.Close();
		}
		private int ConsultaOuIncluiLink(string nomeSite) 
		{
			
			int retornarei;
			if ( linksCache == null ) linksCache = new Hashtable();
			if ( linksCache.ContainsKey(nomeSite) ) 
			{
				return ((int) linksCache[nomeSite]);
			}
			else 
			{
				if( ComandoString("select id from links where host like '" + nomeSite  + "'").Length == 0 ) 
					//O site a ser criado nao existe, criando então.
					ComandoString("INSERT INTO `links` (`id`, `host`) VALUES (NULL, '" + nomeSite + "')");
					retornarei = ComandoInt("select id from links where host like '" + nomeSite  + "'");   
					linksCache.Add(nomeSite,retornarei);
			}
			return retornarei;			
		}
		public void LogaAcesso(int usuárioId,string host,int permitiu) 
		{
			ComandoString("INSERT INTO `log`  (`usuarioId`, `data`, `linkId`, `ID`, `permitido`) VALUES (" + 
			usuárioId.ToString() + ",'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "'," + ConsultaOuIncluiLink(host) + ",NULL," + permitiu.ToString() + ")");
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (conexão.State != ConnectionState.Closed)
				conexão.Close();
		}

		#endregion
	}
}
*/