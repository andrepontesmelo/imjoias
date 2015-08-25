// update vinculomercadoriafornecedor set inicio='2001-01-01 00:00:00' where mercadoria='10356808100'

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	public class Fornecedor
	{
        // Dado a referência, se tiver na hash é pq existe cadastrado.
        private Dictionary<string, bool> hashExisteReferência = new Dictionary<string, bool>();

        // Dado o nome do fornecedor, retorna ele (codigo)
        private Dictionary<string, int> hashFornecedoresCadastrados = new Dictionary<string, int>();

        // Dado o "nome" do fornecedor.
        private Dictionary<string, bool> hashFornecedoresParaCadastrar = new Dictionary<string, bool>();

        // Dado a referencia da mercadoria, retorna o item.
        private Dictionary<string, bool> listaVinculosMercadoriaFornecedorCadastrados = new Dictionary<string, bool>();

		private DataTable   tabelaVelha;
        
        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection cn;
            IDbCommand cmd;
            IDataReader leitor;

            ObterMercadoriasSistemaNovo(Acesso.MySQL.MySQLUsuários.ObterÚltimaStrConexão().ToString(), out cn, out cmd, out leitor);

            ObtemFornecedoresSistemaNovo(cn, ref cmd, ref leitor);

            ObterFornecedoresLegado(dataSetVelho);
            
            CadastraNovosFornecedores(cn, ref cmd);
            ReobtemFornecedores(cn, ref cmd, ref leitor);
            ObtemVinculosAtuais(cn, ref cmd, ref leitor);
            cmd = InsereNovosVínculos(cn, cmd);
		}

        private void ObterMercadoriasSistemaNovo(String strConexão, out IDbConnection cn, out IDbCommand cmd, out IDataReader leitor)
        {
            cn = Acesso.MySQL.ConectorMysql.Instância.CriarConexão(strConexão);
            cn.Open();

            cmd = cn.CreateCommand();
            cmd.CommandText = "select referencia from mercadoria where foradelinha=0";

            leitor = null;

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        hashExisteReferência.Add(leitor.GetString(0), true);
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }
        }

        private void ObtemFornecedoresSistemaNovo(IDbConnection cn, ref IDbCommand cmd, ref IDataReader leitor)
        {
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
        }

        private void ObterFornecedoresLegado(DataSet dataSetVelho)
        {
            tabelaVelha = dataSetVelho.Tables["gesano"];
            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteReferência.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim()))
                {
                    string nomeFornecedor = mercadoria["GA_FORNEC"].ToString().Trim();

                    if (!hashFornecedoresCadastrados.ContainsKey(nomeFornecedor)
                        && !hashFornecedoresParaCadastrar.ContainsKey(nomeFornecedor))
                    {
                        hashFornecedoresParaCadastrar.Add(nomeFornecedor, true);
                    }

                }
            }
        }

        private IDbCommand InsereNovosVínculos(IDbConnection cn, IDbCommand cmd)
        {
            StringBuilder strNovosVinculos = new StringBuilder("INSERT into vinculomercadoriafornecedor (mercadoria, fornecedor, referenciafornecedor) values (");
            bool primeiro = true;

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteReferência.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
                    &&
                    !listaVinculosMercadoriaFornecedorCadastrados.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
                    )
                {
                    string nomeFornecedor = mercadoria["GA_FORNEC"].ToString().Trim();
                    int códigoFornecedor = hashFornecedoresCadastrados[nomeFornecedor];
                    string referênciaFornecedor = mercadoria["GA_REFFOR"].ToString().Trim();

                    if (!primeiro)
                        strNovosVinculos.Append(",(");


                    primeiro = false;

                    strNovosVinculos.Append("'").Append(mercadoria["GA_CODMER"].ToString().Trim()).Append("',");
                    strNovosVinculos.Append(códigoFornecedor.ToString()).Append(",'");
                    strNovosVinculos.Append(referênciaFornecedor).Append("')");

                    listaVinculosMercadoriaFornecedorCadastrados.Add(mercadoria["GA_CODMER"].ToString().Trim(), true);
                }
            }

            if (!primeiro)
            {
                // Existe pelo menos um para inserir.
                cmd = cn.CreateCommand();
                cmd.CommandText = strNovosVinculos.ToString();
                cmd.ExecuteNonQuery();
            }
            return cmd;
        }

        private void CadastraNovosFornecedores(IDbConnection cn, ref IDbCommand cmd)
        {
            // Obtem fornecedor do mysql.
            cmd = cn.CreateCommand();

            StringBuilder strNovosFornecedores = new StringBuilder("INSERT INTO fornecedor (nome) VALUES ");
            bool primeiro = true;

            foreach (KeyValuePair<string, bool> par in hashFornecedoresParaCadastrar)
            {
                if (!primeiro)
                    strNovosFornecedores.Append(",");

                strNovosFornecedores.Append("('");
                strNovosFornecedores.Append(par.Key.ToCharArray());
                strNovosFornecedores.Append("')");

                primeiro = false;
            }

            cmd.CommandText = strNovosFornecedores.ToString();
            if (!primeiro)
            {
                // existe pelo menos um para inserir.
                cmd.ExecuteNonQuery();
            }
        }

        private void ObtemVinculosAtuais(IDbConnection cn, ref IDbCommand cmd, ref IDataReader leitor)
        {
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
        }

        private void ReobtemFornecedores(IDbConnection cn, ref IDbCommand cmd, ref IDataReader leitor)
        {
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
        }
	}
}
