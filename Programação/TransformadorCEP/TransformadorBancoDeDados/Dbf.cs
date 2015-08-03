using System.Collections;
using System;
using System.Data.Odbc;
using System.Data;

using System.Windows.Forms;
namespace TransformadorBancoDeDados
{
	public class Dbf
	{
		private	System.Data.Odbc.OdbcDataReader			leitor;
		private	OdbcConnection							conexão;
		private System.Data.Odbc.OdbcCommand			cmd;

	
		private System.Windows.Forms.ProgressBar		pb;
		private MySql novo;

		public DataSet ObterDataSet(string tabela)
		{
			DataSet dsVelho;
			dsVelho = new DataSet();
			new OdbcDataAdapter("select * from " + tabela, conexão).Fill(dsVelho, tabela);

			return dsVelho;
		}
		public void GravarDataSet(DataSet dsVelho, string tabela)
		{
			new OdbcDataAdapter("select * from " + tabela, conexão).Update(dsVelho, tabela);		}

		public Dbf(string NomeDoArquivo,MySql novoSql,ProgressBar meuPb)
		{

			pb = meuPb;
			string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + NomeDoArquivo + ";Extended Properties=DBASE IV;";
			conexão= new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=" + NomeDoArquivo);
			//conexão= new OleDbConnection(cmdConexão);
			conexão.Open();
			novo = novoSql;
			cmd = new OdbcCommand ("",conexão);
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
		public ArrayList ObterBairros()
		{
			ArrayList bairros = new ArrayList();

			Entidades.Bairro bairroAtual;
			int x = 0;
			pb.Value = 0;
			pb.Maximum =   ComandoInt("select count(*) from LOG_BAIRRO");
			cmd.CommandText = "select BAI_NU_SEQUENCIAL, BAI_NO from LOG_BAIRRO";
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				x++;
				bairroAtual = new Entidades.Bairro();
				
				bairroAtual.bairro = leitor.GetInt32(0);
				bairroAtual.nome = Dbf.corrigirAcentos(leitor.GetString(1).Trim());
				if ((x % 100) == 0)
				{
					pb.Value = x;
					pb.Refresh();
				}
				bairros.Add(bairroAtual);
			}
			
			leitor.Close();	
			return bairros;

		}
		public ArrayList ObterLogradouros()
		{
			bool pularEste;
			ArrayList logradouros = new ArrayList();

			int posAt = 0;
			Entidades.Logradouro logradouroAtual;
			pb.Value = 0;
			pb.Maximum =   ComandoInt("select count(*) from LOG_LOGRADOURO");
			cmd.CommandText = "select  LOC_NU_SEQUENCIAL, LOG_NOME, CEP, BAI_NU_SEQUENCIAL_INI, BAI_NU_SEQUENCIAL_FIM, LOG_COMPLEMENTO from LOG_LOGRADOURO";
			
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				posAt++;
				logradouroAtual = new Entidades.Logradouro();
				pularEste = false;

				logradouroAtual.localidade = leitor.GetInt32(0);
				logradouroAtual.logradouro = corrigirAcentos(leitor.GetString(1).Trim());
				logradouroAtual.cep = leitor.GetString(2);
				try
				{
					logradouroAtual.bairroInicial = leitor.GetInt32(3);
				} 
				catch (Exception e)
				{
					pularEste = true;
				}
				try
				{
					logradouroAtual.bairroFinal = leitor.GetInt32(4);
				} 
				catch(Exception e)
				{
					logradouroAtual.bairroFinal = 0;
				}

				try
				{
					logradouroAtual.complemento = leitor.GetString(5);
				} 
				catch( Exception e)
				{
					logradouroAtual.complemento  = "";
				}

				if (!pularEste) logradouros.Add(logradouroAtual);

				if ((posAt % 10000) == 0)
				{	
					pb.Value = posAt;
					pb.Refresh();

					novo.ColocarLogradouro(logradouros);
					logradouros = new ArrayList();
					GC.Collect();
				}

			}

			leitor.Close();	
			return logradouros;
		}
		public ArrayList ObterLocalidades()
		{
			ArrayList localidades = new ArrayList();

			Entidades.Localidade localidadeAtual;
			int x = 0;
			pb.Value = 0;
			pb.Maximum =   ComandoInt("select count(*) from LOG_LOCALIDADE");
			cmd.CommandText = "select LOC_NU_SEQUENCIAL, LOC_NO, UFE_SG from LOG_LOCALIDADE";
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				x++;
				localidadeAtual = new Entidades.Localidade();
				
				localidadeAtual.localidade = leitor.GetInt32(0);
				localidadeAtual.estado = GerenciamentoEstados.ObterNúmeroSequencialEstado(leitor.GetString(2));
				localidadeAtual.nome = corrigirAcentos(leitor.GetString(1));
				
				if ((x % 100) == 0)
				{
					pb.Value = x;
					pb.Refresh();
				}
				localidades.Add(localidadeAtual);
			}
			
			leitor.Close();	
			return localidades;

		}

		public static String corrigirAcentos(String origem)
		{
			origem = origem.Replace("-","Á");
			origem = origem.Replace("Ò","ã");
			origem = origem.Replace("Ú","é");
			origem = origem.Replace("Ô","â");
			origem = origem.Replace("Ý","í");
			origem = origem.Replace("þ","ç");
			origem = origem.Replace("¬","ª");
			origem = origem.Replace("¶","ô");
			origem = origem.Replace("¾","ó");
			origem = origem.Replace("ß","á");
			origem = origem.Replace("Û","ê");
			origem = origem.Replace("§","õ");
			origem = origem.Replace("·","ú");
			origem = origem.Replace("'","''");

			return origem;
		}

			
	}
		
}
        			
