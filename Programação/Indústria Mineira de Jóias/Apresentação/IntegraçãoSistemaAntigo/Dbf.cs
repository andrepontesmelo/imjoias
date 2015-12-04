using System;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace Apresentação.IntegraçãoSistemaAntigo
{
	public class Dbf
	{
		public System.Data.OleDb.OleDbDataReader		leitor;
        public System.Data.OleDb.OleDbCommand cmd;
        public OleDbConnection							conexão;

		public Dbf(string pastaArquivo)
		{
			string cmdConexão = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pastaArquivo + ";Extended Properties=DBASE IV;";
			conexão = new OleDbConnection(cmdConexão);
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

		public String ExecutaComando(string comandoSql) 
		{
            StringBuilder lido = new StringBuilder();

			cmd.CommandText = comandoSql;
            try
            {
                using (leitor = cmd.ExecuteReader())
                {

                    while (leitor.Read())
                    {
                        lido.Append(leitor.GetString(0));
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

			return lido.ToString();
		}
	}
}
