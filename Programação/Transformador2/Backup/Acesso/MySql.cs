using System;
using System.Data;
using System.Data.SqlClient;
using ByteFX.Data;
using ByteFX.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace Transformador2.Acesso
{
	public class MySql
	{
		ByteFX.Data.MySqlClient.MySqlConnection		conexão;
		ByteFX.Data.MySqlClient.MySqlCommand		cmd;
		ByteFX.Data.MySqlClient.MySqlDataReader		leitor = null;
		
		public DataSet								ds = null;
		
		public MySql()
		{
			Conectar("imjoias", "127.0.0.1", "imjoias", "imj");
		}

		public void AdicionarTabelaAoDataSet(string tabela)
		{
			if (ds == null)
				ds = new DataSet();
			
			MySqlDataAdapter  da = new  ByteFX.Data.MySqlClient.MySqlDataAdapter("select * from " + tabela, conexão);
			da.Fill(ds, tabela);
		}
		public void GravarDataSet(string tabela)
		{
			ByteFX.Data.MySqlClient.MySqlDataAdapter  da = new  ByteFX.Data.MySqlClient.MySqlDataAdapter("select * from " + tabela, conexão);
			MySqlCommandBuilder cmdBuilder;
			cmdBuilder = new MySqlCommandBuilder(da);
			try
			{
				da.Update(ds, tabela);
			} 
			catch (Exception e)
			{
				MessageBox.Show("Erro ao atualizar no mysql a tabela " + tabela + ". Mensagem: " + e.Message);
			}
		}


		private void Conectar(string database,string host,string login, string password) 
		{
			if (conexão != null) conexão.Close();
			conexão = new ByteFX.Data.MySqlClient.MySqlConnection(
				"Database=" + database +
				";Data Source=" + host +
				";User Id=" + login +
				";Password=" + password);
			conexão.Open();
			try 
			{
				cmd = new ByteFX.Data.MySqlClient.MySqlCommand("",conexão);
			} 
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		
			
		public String ComandoString(string ComandoSql) 
		{
			lock (this) 
			{ 
				using (cmd = new ByteFX.Data.MySqlClient.MySqlCommand(ComandoSql,conexão)) 
				{
					leitor = cmd.ExecuteReader();
					string retornarei= "";
					while ( leitor.Read() ) 
					{
						retornarei += leitor.GetString(0);
					}
					leitor.Close();
					return retornarei;
				}
			}
		}
		public int ComandoInt(string ComandoSql) 
		{
			lock (this) 
			{
				cmd.CommandText = ComandoSql;
				leitor = cmd.ExecuteReader();
				int retornarei=0;
				while ( leitor.Read() ) 
				{
					retornarei = leitor.GetInt32(0);
				}
				leitor.Close();
				return retornarei;
			}
		}

	}
}