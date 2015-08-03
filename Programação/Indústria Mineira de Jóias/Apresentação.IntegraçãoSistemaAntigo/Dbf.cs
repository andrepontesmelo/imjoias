using System;
using System.Data.OleDb;
using System.Data;

using System.Windows.Forms;
namespace Apresenta��o.Integra��oSistemaAntigo
{
	public class Dbf
	{
		public	System.Data.OleDb.OleDbDataReader		leitor;
		public	OleDbConnection							conex�o;
		public	System.Data.OleDb.OleDbCommand			cmd;

		public Dbf(string pastaArquivo)
		{
			string cmdConex�o = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pastaArquivo + ";Extended Properties=DBASE IV;";
            //string cmdConex�o = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\;Extended Properties=DBASE IV;";
			conex�o= new OleDbConnection(cmdConex�o);
			conex�o.Open();
			cmd = new OleDbCommand("",conex�o);
		}

		public void Gravar(DataSet ds, string tabela)
		{
			OleDbCommandBuilder cmdBuilder;
			OleDbDataAdapter adaptador;

			adaptador = new OleDbDataAdapter("select * from " + tabela, conex�o);
			cmdBuilder = new OleDbCommandBuilder(adaptador);

			adaptador.Update(ds, tabela);
		}

		public void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
		{
			OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tabela, conex�o);
			da.Fill(ds, tabela);
		}

		public DataSet ObterDataSetMercadoria()
		{
			DataSet ds = new DataSet();

			AdicionarTabelaAoDataSet(ds, "cadmer");
			AdicionarTabelaAoDataSet(ds, "gramas");
			AdicionarTabelaAoDataSet(ds, "ccusto");

			return ds;
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
	}
}
