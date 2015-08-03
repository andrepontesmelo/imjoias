using System;
using System.Data;
using System.Data.SqlClient;
using ByteFX.Data;
using System.Windows.Forms;
using System.Collections;
namespace ConfiguraProxy
{
	/// <summary>
	/// Acesso ao MySQl
	/// </summary>
	public class MySql
	{
		ByteFX.Data.MySqlClient.MySqlConnection conex�o;
		ByteFX.Data.MySqlClient.MySqlCommand cmd;
		ByteFX.Data.MySqlClient.MySqlDataReader leitor = null;
		
		public MySql()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Conectar(string database,string host,string login, string password) 
		{
			if (conex�o != null) conex�o.Close();
			conex�o = new ByteFX.Data.MySqlClient.MySqlConnection(
				"Database=" + database +
				";Data Source=" + host +
				";User Id=" + login +
				";Password=" + password);
			conex�o.Open();
			//TODO: como faz o try ?
			try 
			{
				cmd = new ByteFX.Data.MySqlClient.MySqlCommand("",conex�o);
			} 
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

			}
			
		}
		
			
		//Recupera��o de dados 
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
		public void PreencheListView(ListView lista,int numSubs,string comando)
		{
			int x;
			ListViewItem item;
			lista.Items.Clear();
			cmd.CommandText = comando;
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				//Engaloba��o: ver se esse new nao prejudica mem�ria ram.
				item = new ListViewItem(leitor.GetString(0),0);
				for ( x=1 ; x<=numSubs ;x++ ) 
				{
					item.SubItems.Add(leitor.GetString(x));
				}
				lista.Items.Add(item);
			}

			leitor.Close();
			
		}

	}
}
