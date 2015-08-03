using System;
using System.Data;
using System.Data.SqlClient;
using ByteFX.Data;
using System.Windows.Forms;
using System.Collections;
using ByteFX.Data.MySqlClient;
namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Acesso ao MySQl
	/// </summary>
	public class MySql
	{
		MySqlConnection conexão;
		MySqlCommand cmd;
		MySqlDataReader leitor = null;
		private System.Windows.Forms.ProgressBar		pb;
		Form1 form;	

		public MySqlConnection Conexão
		{
			get
			{
				return conexão;
			}
		}
		public MySql(Form1 form1, ProgressBar meuPb)
		{
			form = form1;
			pb = meuPb;
			GerenciamentoEstados.DeterminarMySql(this);
			//
			// TODO: Add constructor logic here
			//
		}

		public void Conectar(string database,string host,string login, string password) 
		{
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
			
		}
		
		public void apagarTudo()
		{
			ComandoString("delete from bairros");
			ComandoString("delete from logradouros");
			ComandoString("delete from localidades");
			ComandoString("delete from estados");
		}
		
		//Recuperação de dados 
		public String ComandoString(string ComandoSql) 
		{
			lock (this) 
			{ 
				using (cmd = new ByteFX.Data.MySqlClient.MySqlCommand(ComandoSql,conexão)) 
				{
					try
					{
						leitor = cmd.ExecuteReader();
					} 
					catch(Exception e)
					{
						//MessageBox.Show("Erro: " + ComandoSql);
						form.Loga(ComandoSql + '\n');
						leitor.Close();
						return null;
					}

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

		public double ComandoDouble(string ComandoSql) 
		{
			lock (this) 
			{
				cmd.CommandText = ComandoSql;
				leitor = cmd.ExecuteReader();
				double retornarei=0;
				while ( leitor.Read() ) 
				{
					retornarei = leitor.GetDouble(0);
				}
				leitor.Close();
				return retornarei;
			}
		}

		public ArrayList LerArrayList(string comando)
		{
			lock (this) 
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
		}

		public void ColocarBairro(Entidades.Bairro bairro)
		{
			ComandoString(@"INSERT INTO `bairros` (`bairro`, `nome`) VALUES (" + bairro.bairro + ", '" + bairro.nome + "' )");
		}
		public void ColocarBairro(ArrayList bairros)
		{
			Entidades.Bairro bairro;
			pb.Value = 0;
			pb.Maximum = bairros.Count;
			for (int x = 0; x < bairros.Count; x++)
			{
				bairro = (Entidades.Bairro) bairros[x];
				ColocarBairro(bairro);
				if ((x % 1000) == 0)
				{
					pb.Value = x;
					pb.Refresh();
					form.Refresh();
					form.Focus();
				}
			}
			
			pb.Value = 0;
		}

		public void ColocarLogradouro(Entidades.Logradouro logradouro)
		{
					ComandoString(@"INSERT INTO `logradouros` (`logradouro`, `cep`, `localidade`, `bairroInicial`, `bairroFinal`, `complemento` ) VALUES ('" + logradouro.logradouro + "' , '" + logradouro.cep + "', " + logradouro.localidade + "," + logradouro.bairroInicial + "," + ColocaNull(logradouro.bairroFinal) + ", " + ColocaNull(logradouro.complemento) + ")");
		}
		public void ColocarLogradouro(ArrayList logradouros)
		{
			Entidades.Logradouro logradouro;
			//pb.Value = 0;
			//pb.Maximum = logradouros.Count;
			for (int x = 0; x < logradouros.Count; x++)
			{
				logradouro = (Entidades.Logradouro) logradouros[x];
					ComandoString(@"INSERT INTO `logradouros` (`logradouro`, `cep`, `localidade`, `bairroInicial`, `bairroFinal`, `complemento` ) VALUES ('" + logradouro.logradouro + "' , '" + logradouro.cep + "', " + logradouro.localidade + "," + logradouro.bairroInicial + "," + ColocaNull(logradouro.bairroFinal) + ", " + ColocaNull(logradouro.complemento) + ")");

				/*if ((x % 10000) == 0)
				{
					//MessageBox.Show("Logradouro: " + logradouro.logradouro);
					pb.Value = x;
					pb.Refresh();
				}
				*/
			}

			
		}

		public void ColocarLocalidades(ArrayList localidades)
		{
			Entidades.Localidade localidade;
			pb.Value = 0;
			pb.Maximum = localidades.Count;
			for (int x = 0; x < localidades.Count; x++)
			{
				localidade = (Entidades.Localidade) localidades[x];
				ComandoString("INSERT INTO `localidades` (`localidade`, `estado`, `nome`) VALUES (" + localidade.localidade + "," + localidade.estado + ",'" + localidade.nome + "')");
				if ((x % 10000) == 0)
				{
					pb.Value = x;
					pb.Refresh();
				}
			}


			
			pb.Value = 0;
		}

		private String ColocaNull(String a)
		{	
			a = a.Trim();
			if (a.Length == 0) 
			{
				return "NULL";
			} 
			else
			{
				return "'" + a + "'";
			}
		}
		private String ColocaNull(int a)
		{	
			if (a == 0) 
			{
				return "NULL";
			} 
			else
			{
				return a.ToString();
			}
		}


	}
}

