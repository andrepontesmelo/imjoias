using System;
using System.Data.OleDb;
using System.Data;

using System.Windows.Forms;
namespace Transformador2.Acesso
{
	public class Dbf
	{
		public	System.Data.OleDb.OleDbDataReader		leitor;
		public	OleDbConnection							conexão;
		public	System.Data.OleDb.OleDbCommand			cmd;

		public DataSet									ds = null;
		
		public Dbf(string pastaArquivo)
		{
			string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pastaArquivo + ";Extended Properties=DBASE IV;";
			conexão= new OleDbConnection(cmdConexão);
			conexão.Open();
			cmd = new OleDbCommand("",conexão);
		}

		public void AdicionarTabelaAoObterDataSet(string tabela)
		{
			if (ds == null)
				ds = new DataSet();
            		
			OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tabela, conexão);
			da.Fill(ds, tabela);
		}

	}
}
