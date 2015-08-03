using System;
using System.Data.OleDb;
using System.Data;

using System.Windows.Forms;
namespace Transformador2.Acesso
{
	public class Dbf
	{
		public	System.Data.OleDb.OleDbDataReader		leitor;
		public	OleDbConnection							conex�o;
		public	System.Data.OleDb.OleDbCommand			cmd;

		public DataSet									ds = null;
		
		public Dbf(string pastaArquivo)
		{
			string cmdConex�o = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pastaArquivo + ";Extended Properties=DBASE IV;";
			conex�o= new OleDbConnection(cmdConex�o);
			conex�o.Open();
			cmd = new OleDbCommand("",conex�o);
		}

		public void AdicionarTabelaAoObterDataSet(string tabela)
		{
			if (ds == null)
				ds = new DataSet();
            		
			OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tabela, conex�o);
			da.Fill(ds, tabela);
		}

	}
}
