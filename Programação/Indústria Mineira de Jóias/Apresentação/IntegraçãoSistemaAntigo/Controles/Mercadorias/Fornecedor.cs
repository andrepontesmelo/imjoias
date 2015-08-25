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
        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection cn;
            IDbCommand cmd;
            IDataReader leitor;

            Dictionary<string, bool> referências = 
            ObtemNovoMercadorias(Acesso.MySQL.MySQLUsuários.ObterÚltimaStrConexão().ToString(), out cn, out cmd, out leitor);

            Dictionary<string, int> fornecedores = ObtemNovoFornecedores(cn, ref cmd, ref leitor);
            
            Dictionary<string, bool> fornecedoresParaCadastro =
                ObtemLegadoFornecedoresParaCadastrar(dataSetVelho, referências, fornecedores);
            
            CadastraFornecedores(cn, ref cmd, fornecedoresParaCadastro);
            ObtemNovoFornecedores(cn, ref cmd, ref leitor);
            
            Dictionary<string, bool> vinculos = ObtemNovoVinculosAtuais(cn, ref cmd, ref leitor);
            InsereNovosVínculos(cn, cmd, referências, fornecedores, vinculos, dataSetVelho);
		}

        private Dictionary<string, bool> ObtemNovoMercadorias(String strConexão, out IDbConnection cn, out IDbCommand cmd, out IDataReader leitor)
        {
            Dictionary<string, bool> hashExisteReferência = new Dictionary<string, bool>();

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

            return hashExisteReferência;
        }

        private Dictionary<string, int> ObtemNovoFornecedores(IDbConnection cn, ref IDbCommand cmd, ref IDataReader leitor)
        {
            Dictionary<string, int> hashFornecedoresCadastrados = new Dictionary<string, int>();

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

            return hashFornecedoresCadastrados;
        }

        private DataTable ObterTabelaVelha(DataSet dataSetVelho)
        {
            return dataSetVelho.Tables["gesano"];
        }

        private Dictionary<string, bool> ObtemLegadoFornecedoresParaCadastrar(DataSet dataSetVelho, 
            Dictionary<string, bool> hashExisteReferência,
            Dictionary<string, int> hashFornecedoresCadastrados)
        {
            Dictionary<string, bool> hashFornecedoresParaCadastrar = new Dictionary<string, bool>();

            DataTable tabelaVelha = ObterTabelaVelha(dataSetVelho);

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

            return hashFornecedoresParaCadastrar;
        }

        private void InsereNovosVínculos(IDbConnection cn, IDbCommand cmd,
            Dictionary<string, bool> hashExisteReferência,
            Dictionary<string, int> hashFornecedoresCadastrados,
            Dictionary<string, bool> vinculosAtuais, DataSet dataSetVelho)
        {
            StringBuilder strNovosVinculos = new StringBuilder("INSERT into vinculomercadoriafornecedor (mercadoria, fornecedor, referenciafornecedor) values (");
            bool primeiro = true;

            DataTable tabelaVelha = ObterTabelaVelha(dataSetVelho);

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteReferência.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
                    &&
                    !vinculosAtuais.ContainsKey(mercadoria["GA_CODMER"].ToString().Trim())
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

                    vinculosAtuais.Add(mercadoria["GA_CODMER"].ToString().Trim(), true);
                }
            }

            if (!primeiro)
            {
                // Existe pelo menos um para inserir.
                cmd = cn.CreateCommand();
                cmd.CommandText = strNovosVinculos.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        private void CadastraFornecedores(IDbConnection cn, ref IDbCommand cmd, Dictionary<string, bool> hashFornecedoresParaCadastrar)
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

        private Dictionary<string, bool> ObtemNovoVinculosAtuais(IDbConnection cn, ref IDbCommand cmd, ref IDataReader leitor)
        {
            Dictionary<string, bool> vinculosAtuais = new Dictionary<string, bool>();

            cmd = cn.CreateCommand();
            cmd.CommandText = "select mercadoria from vinculomercadoriafornecedor";

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                        vinculosAtuais.Add(leitor.GetString(0), true);
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

            return vinculosAtuais;
        }
	}
}
