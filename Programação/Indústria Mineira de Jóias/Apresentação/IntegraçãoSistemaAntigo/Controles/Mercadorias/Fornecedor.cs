using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
	public class Fornecedor
	{
        // Dado a refer�ncia, se tiver na hash � pq existe cadastrado.
        private Dictionary<string, bool> hashExisteRefer�ncia = new Dictionary<string, bool>();

        // Dado o nome do fornecedor, retorna ele (codigo)
        private Dictionary<string, int> hashFornecedoresCadastrados = new Dictionary<string, int>();

        // Dado o "nome" do fornecedor.
        private Dictionary<string, bool> hashFornecedoresParaCadastrar = new Dictionary<string, bool>();

//        private List<string> nomesDeFornecedoresParaCadastrar = new List<string>();

        // Dado a referencia da mercadoria, retorna o item.
        private Dictionary<string, bool> listaVinculosMercadoriaFornecedorCadastrados = new Dictionary<string, bool>();

		private DataTable   tabelaVelha;
        
        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            // Faz hash de mercadorias formatadas

#if DEBUG
            String strConex�o =
            strConex�o = "Data Source=192.168.122.1";
            strConex�o += ";Database=imjoias";
            strConex�o += ";User Id=andrep";
            strConex�o += ";Password=***REMOVED***";
            strConex�o += ";Pooling=False";
            strConex�o += ";Port=3306";
#else
            String strConex�o =
            strConex�o = "Data Source=192.168.1.25";
            strConex�o += ";Database=imjoias";
            strConex�o += ";User Id=andrep";
            strConex�o += ";Password=***REMOVED***";
            strConex�o += ";Pooling=False";
            strConex�o += ";Port=46033";


#endif

            IDbConnection cn = Acesso.MySQL.ConectorMysql.Inst�ncia.CriarConex�o(strConex�o);
            cn.Open();

            IDbCommand cmd = cn.CreateCommand();
            cmd.CommandText = "select referencia from mercadoria where foradelinha=0";

            IDataReader leitor = null;

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        hashExisteRefer�ncia.Add(leitor.GetString(0), true);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }


            // Obtem fornecedor do mysql.
            cmd = cn.CreateCommand();
            cmd.CommandText = "select codigo, nome from fornecedor";

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int codigo = leitor.GetInt32(0);
                        string nome = leitor.GetString(1);

                        hashFornecedoresCadastrados.Add(nome, codigo);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

            // Levanta lista de fornecedores para cadastrar.
			tabelaVelha = dataSetVelho.Tables["gesano"];
            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteRefer�ncia.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim()))
                {
                    string nomeFornecedor = mercadoria["GA_FORNEC"].ToString().Trim();

                    if (!hashFornecedoresCadastrados.ContainsKey(nomeFornecedor)
                        && !hashFornecedoresParaCadastrar.ContainsKey(nomeFornecedor))
                    {
                        hashFornecedoresParaCadastrar.Add(nomeFornecedor, true);
                    }
                   
                }
            }
            
            // Cadastra por��o de fornecedores novos.
            // Obtem fornecedor do mysql.
            cmd = cn.CreateCommand();
            StringBuilder str = new StringBuilder("INSERT INTO fornecedor (nome) VALUES ");
            bool primeiro = true;

            foreach (KeyValuePair<string, bool> par in hashFornecedoresParaCadastrar)
            {
                if (!primeiro)
                    str.Append(",");

                str.Append("('");
                str.Append(par.Key.ToCharArray());
                str.Append("')");

                primeiro = false;
            }

            cmd.CommandText = str.ToString();
            if (!primeiro)
            {
                // existe pelo menos um para inserir.
                cmd.ExecuteNonQuery();
            }

            // Reobtem fornecedores.
            hashFornecedoresCadastrados.Clear();
            cmd = cn.CreateCommand();
            cmd.CommandText = "select codigo, nome from fornecedor";

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int codigo = leitor.GetInt32(0);
                        string nome = leitor.GetString(1);

                        hashFornecedoresCadastrados.Add(nome, codigo);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

            // Pega os vinculos atuais.
            cmd = cn.CreateCommand();
            cmd.CommandText = "select mercadoria from vinculomercadoriafornecedor";

            try
            {
                using (leitor = cmd.ExecuteReader()) 
                {
                    while (leitor.Read())
                    {
                        listaVinculosMercadoriaFornecedorCadastrados.Add(leitor.GetString(0), true);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }
            // Vai inserindo novos vinculos se necess�rios.
            str = new StringBuilder("INSERT into vinculomercadoriafornecedor (mercadoria, fornecedor, referenciafornecedor) values (");
            primeiro = true;

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteRefer�ncia.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
                    &&
                    !listaVinculosMercadoriaFornecedorCadastrados.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
                    )
                {
                    string nomeFornecedor = mercadoria["GA_FORNEC"].ToString().Trim();
                    int c�digoFornecedor = hashFornecedoresCadastrados[nomeFornecedor];
                    string refer�nciaFornecedor = mercadoria["GA_REFFOR"].ToString().Trim();

                    if (!primeiro)
                        str.Append(",(");


                    primeiro = false;

                    str.Append("'").Append(mercadoria["GA_CODMER"].ToString().Trim()).Append("',");
                    str.Append(c�digoFornecedor.ToString()).Append(",'");
                    str.Append(refer�nciaFornecedor).Append("')");

                    listaVinculosMercadoriaFornecedorCadastrados.Add(mercadoria["GA_CODMER"].ToString().Trim(), true);
                }
            }

            if (!primeiro)
            {
                // Existe pelo menos um para inserir.
                cmd = cn.CreateCommand();
                cmd.CommandText = str.ToString();
                cmd.ExecuteNonQuery();
            }
		}
	}
}
