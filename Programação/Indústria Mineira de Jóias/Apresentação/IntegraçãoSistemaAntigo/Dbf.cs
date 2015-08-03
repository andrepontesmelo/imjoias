using System;
using System.Data.OleDb;
using System.Data;

using System.Windows.Forms;
namespace Apresentação.IntegraçãoSistemaAntigo
{
	public class Dbf
	{
		public	System.Data.OleDb.OleDbDataReader		leitor;
		public	OleDbConnection							conexão;
		public	System.Data.OleDb.OleDbCommand			cmd;

		public Dbf(string pastaArquivo)
		{
			string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pastaArquivo + ";Extended Properties=DBASE IV;";
            //string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\;Extended Properties=DBASE IV;";
			conexão= new OleDbConnection(cmdConexão);
			conexão.Open();
			cmd = new OleDbCommand("",conexão);
		}

		public void Gravar(DataSet ds, string tabela)
		{
			OleDbCommandBuilder cmdBuilder;
			OleDbDataAdapter adaptador;

			adaptador = new OleDbDataAdapter("select * from " + tabela, conexão);
			cmdBuilder = new OleDbCommandBuilder(adaptador);

			adaptador.Update(ds, tabela);
		}

		public void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
		{
			OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tabela, conexão);
			da.Fill(ds, tabela);
		}

		public DataSet ObterDataSetMercadoria()
		{
			DataSet ds = new DataSet();

			AdicionarTabelaAoDataSet(ds, "cadmer");
			AdicionarTabelaAoDataSet(ds, "gramas");
			AdicionarTabelaAoDataSet(ds, "ccusto");
            AdicionarTabelaAoDataSet(ds, "gesano");

			return ds;
		}

		public String ComandoString(string ComandoSql) 
		{
            string retornarei = "";

			cmd.CommandText = ComandoSql;
            try
            {
                using (leitor = cmd.ExecuteReader())
                {

                    while (leitor.Read())
                    {
                        retornarei += leitor.GetString(0);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

			return retornarei;
		}
	}
}
