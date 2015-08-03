using System;
using System.Data;
using System.Data.SqlClient;
using ByteFX.Data;
using System.Windows.Forms;
using System.Collections;
namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Acesso ao MySQl
	/// </summary>
	public class MySql
	{
		ByteFX.Data.MySqlClient.MySqlConnection conexão;
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
		
			
		
		//Recuperação de dados 
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

		public void CriarFaixas(string setor, string faixa,string valor) 
		{
//			MessageBox.Show("INSERT INTO `faixa`  (`faixa`, `data`, `setor`, `valor`) VALUES ('" + faixa + "','" + DateTime.Now.ToString("yyyy-mm-dd") + "','" + setor + "'," + valor.Trim() + ")" );
			try 
			{
				ComandoString("INSERT INTO `faixa`  (`faixa`, `data`, `setor`, `valor`) VALUES ('" + faixa + "','" + DateTime.Now.ToString("yyyy-mm-dd") + "','" + setor + "'," + valor.Trim() + ")" );
			}
			catch (Exception e) 
			{
				if ( TestePerformace.modoTeste == false ) MessageBox.Show("erro:" + e.Message);
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
		public void PreencheListView(ListView lista,int numSubs,string comando)
		{
			int x;
			ListViewItem item;
			lista.Items.Clear();
			cmd.CommandText = comando;
			leitor = cmd.ExecuteReader();
			while ( leitor.Read() ) 
			{
				//Engalobação: ver se esse new nao prejudica memória ram.
				item = new ListViewItem(leitor.GetString(0),0);
				for ( x=1 ; x<=numSubs ;x++ ) 
				{
					item.SubItems.Add(leitor.GetString(x));
				}
				lista.Items.Add(item);
			}

			leitor.Close();
			
		}

		public void InserirComponenteDeCusto(string codigo,string nome) 
		{
			ComandoString("INSERT INTO `componentecusto`  (`nome`, `codigo`) VALUES ('" + nome.Trim() + "','" + codigo.Trim() + "')");
		}

		
		public void InserirValorComponenteDeCusto(string codigo, DateTime data, double valor,string multiplicarComponenteCusto ) 
		{
			if ( multiplicarComponenteCusto == "" ) 
			{
				ComandoString("INSERT INTO `valorcomponentecusto` (`multiplicarcomponentecusto`, `data`,`valor`,`componentecusto`) VALUES (NULL,'" + data.ToString("yyyy/MM/dd hh:mm:ss") + "','" + valor.ToString("0000.00").Replace(",",".") + "','"  + codigo + "')");
			}
			else
			{
				ComandoString("INSERT INTO `valorcomponentecusto` (`multiplicarcomponentecusto`, `data`,`valor`,`componentecusto`) VALUES ("+ multiplicarComponenteCusto  +   ",'" + data.ToString("yyyy/MM/dd hh:mm:ss") + "','" + valor.ToString("0000.00").Replace(",",".") + "','"  + codigo + "')");
			}
		}


		public void InserirMercadoria(string nome, string teor, string peso, string faixa, string digito, string referencia,string Linha,string grupo)
		{
			//MessageBox.Show("INSERT INTO `mercadoria` (`nome`, `teor`, `peso`, `faixa`, `digito`, `referencia`) 		VALUES ('" + nome.Trim() + "','" + teor + "','" + peso + "','" + faixa.Trim() + "','" + digito.Trim() + "','" + referencia.Trim() + "')" );
			ComandoString(@"INSERT INTO `mercadoria` (`nome`, `teor`, `peso`, `faixa`, `digito`, `referencia`,`linha`,`grupo`) 		VALUES ('" + nome.Trim() + "','" + teor + "','" + peso + "','" + faixa.Trim() + "','" + digito.Trim() + "','" + referencia.Trim() + "','" + Linha + "','" + grupo + "')" );
		}
		public void InserirVinculoMercadoriaComponenteCusto(string referenciaMercadoria,string componenteCusto,string quantidade) 
		{
			//Se existir mais componentes De custo iguais para cada mercadoria, a quantidade é somada.
				double quantidadeJáExistente=0;
				double novaQuantidade=0;
			//Verificação de mercadoriaDuplicada
			//if (referenciaMercadoria.Trim() == "10816101100") MessageBox.Show("a");
			
			quantidadeJáExistente = ComandoDouble("select quantidade from vinculomercadoriacomponentecusto where componentecusto='" + componenteCusto + "' AND mercadoria='" + referenciaMercadoria + "'");
			if (quantidadeJáExistente!=0) 
			{
				novaQuantidade=quantidadeJáExistente+Convert.ToDouble(quantidade);
				ComandoInt(@"UPDATE `vinculomercadoriacomponentecusto` SET `quantidade`=" + novaQuantidade.ToString().Replace(",",".")  +  " WHERE `mercadoria`='" + referenciaMercadoria.Trim() +"' AND `componentecusto`='" + componenteCusto + "'");
			} else
            //novo componente de custo.
				//MessageBox.Show("INSERT INTO `vinculomercadoriacomponentedecusto`   (`mercadoria`, `componentedecusto`, `quantidade`) VALUES ('" + referenciaMercadoria.Trim() + "','" + componenteCusto.Trim() + "','" +  quantidade.Replace(",",".") + "')");
				try
				{
					ComandoString(@"INSERT INTO `vinculomercadoriacomponentecusto`   (`mercadoria`, `componentecusto`, `quantidade`) VALUES ('" + referenciaMercadoria.Trim() + "','" + componenteCusto.Trim() + "','" +  quantidade.Replace(",",".")  + "')");
				}
				catch (Exception e)
				{
					if ( TestePerformace.modoTeste == false )  MessageBox.Show("Não foi possível vincular mercadoria " + referenciaMercadoria + " com o componente de custo " + componenteCusto + ".");
				}
		}
		public void ApagarTudo() 
		{			
			ComandoString("DELETE FROM valorCOMPONENTECUSTO");
			ComandoString("DELETE FROM vinculomercadoriacomponentecusto");
			ComandoString("DELETE FROM COMPONENTECUSTO");
			ComandoString("DELETE FROM tabelaindices");
			ComandoString("DELETE FROM mercadoria");
			ComandoString("DELETE FROM faixa");
		}

	}
}

