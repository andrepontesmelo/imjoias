using System;
//using System.Data.Odbc;
using System.Data.OleDb;

using System.Windows.Forms;
namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Summary description for Dbf.
	/// </summary>
	public class Dbf
	{//"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\perchhold\\OnlineOnlineData\\SETDBFS;Extended Properties=DBASE IV;"; 
//		private	System.Data.Odbc.OdbcDataReader			leitor;
//		private	OdbcConnection							conexão;
//		private System.Data.Odbc.OdbcCommand			cmd;
		private	System.Data.OleDb.OleDbDataReader			leitor;
		private	OleDbConnection							conexão;
		private System.Data.OleDb.OleDbCommand			cmd;

		private float [,] vfaixa = new float[10, 10];
		
		private System.Windows.Forms.ProgressBar		pb;
		private MySql novo;
		//private Form1 meuForm;
		//private MySql banco;

		public Dbf(string NomeDoArquivo,MySql novoSql,ProgressBar meuPb)
		{
			//banco = meuBanco;
			//meuForm=formPrincipal;
			pb = meuPb;
			//string cmdConexão = "Driver={Microsoft dBase Driver (*.dbf)};Dbq=" + NomeDoArquivo + ";";
			string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + NomeDoArquivo + ";Extended Properties=DBASE IV;";
//			conexão= new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=" + NomeDoArquivo);
			conexão= new OleDbConnection(cmdConexão);
			conexão.Open();
			novo = novoSql;
			cmd = new OleDbCommand("",conexão);
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
		public void LerComponenteCusto() 
		{
			double dolarDouble=0;

			pb.Maximum =   ComandoInt("select count(*) from ccusto")  ;
			cmd.CommandText = "select CC_COD,CC_nome,CC_data,CC_valor,CC_dolar from ccusto";
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				
				
				try 
				{
					novo.InserirComponenteDeCusto(leitor.GetString(0),leitor.GetString(1));
					dolarDouble = leitor.GetDouble(4);

					//Se é dolar ou se o preço não está em dolar
					if ((leitor.GetString(0).Trim() == "10") || (dolarDouble ==0) )
						novo.InserirValorComponenteDeCusto(leitor.GetString(0),leitor.GetDateTime(2),leitor.GetDouble(3),"");
					else 
						//Caso do preço estar em dolar.
						novo.InserirValorComponenteDeCusto(leitor.GetString(0),leitor.GetDateTime(2),dolarDouble,"10");
					pb.Value+=1;

				} 
				catch(Exception e) 
				{
					if ( TestePerformace.modoTeste == false )  MessageBox.Show("ERRO:" +  e.Message);

				}

			}
			leitor.Close();
			
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
		public void LerValores() 
		{
			string engalobadaCC="";
			string cc="";
			string qtd="";
			string teor="";
			string peso="";
			string ccusto="";
			string codmer="";
			string linha;
			string grupo="";

			bool deuPau,deuPau1;
			pb.Value = 0;
			pb.Maximum =   ComandoInt("select count(*) from cadmer")  ;
			cmd.CommandText = "select CM_NOME,CM_TEOR,CM_PESO,cm_faixa,CM_digmer,CM_codmer,CM_ccusto,CM_LINHA, CM_GRUPO from cadmer";
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				pb.Value+=1;
				
			
			//	try 
				
					linha = leitor.GetString(7);
					if (linha == "S") 
					{
						linha = "1";
					} 
					else 
					{
						linha = "0";
					}
				 
				/*catch (Exception e) 
				{
					linha=true;
					foraDeLinha="0";
				}
			*/
				try 
				{
					teor = leitor.GetString(1);
				} 
				catch
				{
					teor ="";
				}
					
				try 
				{
					grupo = leitor.GetString(8);
				} 
				catch
				{
					grupo = "";
				}
					

				try 
				{
					ccusto = leitor.GetString(6).Trim();
				} 
				catch
				{
					ccusto="";
				}

				try 
				{
					peso = Convert.ToString(leitor.GetDouble(2)).Replace(",",".");
				} 
				catch (Exception e) 
				{
					peso="";
				}

				try 
				{
					codmer= leitor.GetString(5);
					codmer = codmer.Trim();
				} 
				catch (Exception e) 
				{
					codmer="";
				}


				if ( ccusto.Length != 0) 
				{
					try 
					{
						novo.InserirMercadoria(leitor.GetString(0),teor,peso,leitor.GetString(3),leitor.GetString(4),leitor.GetString(5),linha,grupo);
					
					}
					catch(Exception e) 
					{
						if ( TestePerformace.modoTeste == false ) MessageBox.Show(e.Message);
					}
						engalobadaCC = ccusto; //componente de custo string.
					engalobadaCC =  engalobadaCC.Trim();
					engalobadaCC = engalobadaCC.Replace(" ","0");
					if (( engalobadaCC.Length % 6 ) != 0 )   
						if ( TestePerformace.modoTeste == false )  MessageBox.Show ("Erro no DBF: '" + engalobadaCC + "' tem " + engalobadaCC.Length + " caracteres");
					//MessageBox.Show("Início: " + engalobadaCC);
					while (engalobadaCC.Length > 0) 
					{
						cc = engalobadaCC.Substring(0,2);
						qtd = engalobadaCC.Substring(2,4);

						if (cc[0] == '9')
						{
							string faixa = leitor.GetString(3);
							int ifaixa = char.ToLower(faixa[0]) - 'a';
							int isetor = '9' - cc[1];

							if (vfaixa[isetor, ifaixa] == 0)
								vfaixa[isetor, ifaixa] = float.Parse(qtd);
							else if (vfaixa[isetor, ifaixa] != float.Parse(qtd))
							{
								if ( TestePerformace.modoTeste == false ) MessageBox.Show("Erro ao importar banco de dados, referência " + codmer + ". Faixas inconsitentes: " + cc + " = " + vfaixa[isetor, ifaixa].ToString() + " != " + qtd);
								vfaixa[isetor, ifaixa] = float.Parse(qtd);
							}
						}
						else if ( (cc != "00") && (qtd != "0000")) 
						{
							//MessageBox.Show("Prefixo"+ cc);
							//MessageBox.Show("qtd:" + qtd);
							//MessageBox.Show( ((string)(((double)(Convert.ToDouble(qtd) / 100.0000)).ToString())).Trim());
							novo.InserirVinculoMercadoriaComponenteCusto(leitor.GetString(5),cc,((double)(Convert.ToDouble(qtd) / 100.0000)).ToString()  );
						}
						engalobadaCC = engalobadaCC.Substring(6, engalobadaCC.Length-6);
						//MessageBox.Show(" Resto:" + engalobadaCC);
					}

				}
				
			}
			leitor.Close();	
		}
			
	}
		
}
        			
