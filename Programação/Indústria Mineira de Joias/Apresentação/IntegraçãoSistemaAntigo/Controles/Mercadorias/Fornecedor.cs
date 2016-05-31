using Apresentação.Formulários;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	public class Fornecedor
	{
        private static string COLUNA_GESANO_REFERÊNCIA_MERCADORIA = "GA_CODMER";
        private static string COLUNA_GESANO_PESO = "GA_PESO";
        private static string COLUNA_GESANO_CODIGO_FORNECEDOR = "GA_FORNEC";
        private static string COLUNA_GESANO_REFERÊNCIA_FORNECEDOR = "GA_REFFOR";
        private static string COLUNA_GESANO_INICIO = "GA_MESANO";
        private static string FORA_DE_LINHA_FORNECEDOR = "FFL";

        private static int TEMPO_MAXIMO_SQL_MINUTOS = 10;

        private Dictionary<string, bool> hashExisteReferência;
        private Dictionary<string, int> hashFornecedoresCadastrados;
        private Dictionary<string, bool> vinculosAtuais;
        private DataSet dataSetVelho;

        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection conexão;
            this.dataSetVelho = dataSetVelho;

            Dictionary<string, bool> referências = 
            ObterHashExisteReferência(Acesso.MySQL.MySQLUsuários.ObterÚltimaStrConexão().ToString(), out conexão);

            Dictionary<string, int> fornecedores = ObterNovosFornecedores(conexão);
            
            Dictionary<string, bool> fornecedoresParaCadastro =
                ObtemLegadoFornecedoresParaCadastrar();
            
            CadastrarFornecedores(conexão, fornecedoresParaCadastro);
            fornecedores = ObterNovosFornecedores(conexão);

            Dictionary<string, bool> vinculos = ObtemNovoVinculosAtuais(conexão);
            ApagaVínculosCoexistentes(conexão);

            vinculos = ObtemNovoVinculosAtuais(conexão);
            AdicionarNovosVínculos(conexão);

            SobrescreveInicio(conexão, referências, fornecedores);
		}

        private void ReportaErro(string referência, string mesano, StringBuilder erros)
        { 
            if (erros.Length == 0)
            {
                erros.Append("Erros do gesano.dbf são listados abaixo. Estes erros não interrompem a integração. ");
                erros.AppendLine("Porém o vinculomercadoriafornecedor ficará sem a informação de início para esta(s) mercadoria(s): ");
            }

            erros.AppendLine();
            erros.Append(" * mercadoria ");
            erros.Append(referência);
            erros.Append(" possui início fora do padrão MMyy: ");
            erros.Append(mesano);
        }

        private void SobrescreveInicio(IDbConnection cn, Dictionary<string, bool> referências, 
            Dictionary<string, int> fornecedores)
        {
            StringBuilder erros = new StringBuilder();
            StringBuilder sql = new StringBuilder();

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
                SobrescreveInicio(mercadoria, referências, fornecedores, sql, erros);

            ExecutaBatchSQL(cn, sql.ToString());
            MostrarErros(erros.ToString());
        }

        private void SobrescreveInicio(DataRow mercadoria, Dictionary<string, bool> referências, 
            Dictionary<string, int> fornecedores, StringBuilder sql, StringBuilder erros)
        {
            string referência = mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim();

            if (referências.ContainsKey(referência))
            {
                int codFornecedor = fornecedores[mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim()];
                string mesano = mercadoria[COLUNA_GESANO_INICIO].ToString().Trim();

                if (mesano != "")
                {
                    try
                    {
                        GeraSQLUpdateInicio(referência, mesano, sql);
                    }
                    catch (FormatException)
                    {
                        ReportaErro(referência, mesano, erros);
                    }
                }
            }
        }

        private void MostrarErros(string erros)
        {
            if (erros.Length > 0)
            {
                MessageBox.Show(erros, "Erros ignorados de início de fornecedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void ExecutaBatchSQL(IDbConnection cn, string sql)
        {
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandTimeout = (int)TimeSpan.FromMinutes(TEMPO_MAXIMO_SQL_MINUTOS).TotalSeconds;

                cmd.ExecuteNonQuery();
            }
        }

        private void GeraSQLUpdateInicio(string referência, string mesano, StringBuilder sql)
        {
            DateTime inicio = DateTime.ParseExact(mesano, "MMyy", System.Globalization.CultureInfo.CurrentCulture);

            sql.Append("update vinculomercadoriafornecedor set inicio=");
            sql.Append(Acesso.Comum.DbManipulaçãoSimples.DbTransformar(inicio));
            sql.Append(" where mercadoria='");
            sql.Append(referência);
            sql.Append("'; ");
        }

        private Dictionary<string, bool> ObterHashExisteReferência(String strConexão, out IDbConnection cn)
        {
            hashExisteReferência = new Dictionary<string, bool>();

            cn = Acesso.MySQL.ConectorMysql.Instância.CriarConexão(strConexão);
            cn.Open();

            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "select referencia from mercadoria where foradelinha=0";
                IDataReader leitor = null;

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

            return hashExisteReferência;

        }

        private Dictionary<string, int> ObterNovosFornecedores(IDbConnection cn)
        {
            hashFornecedoresCadastrados = new Dictionary<string, int>();
            IDataReader leitor = null;
            IDbCommand cmd = cn.CreateCommand();
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

        private DataTable ObterTabelaVelha()
        {
            return dataSetVelho.Tables["gesano"];
        }

        private Dictionary<string, bool> ObtemLegadoFornecedoresParaCadastrar()
        {
            Dictionary<string, bool> hashFornecedoresParaCadastrar = new Dictionary<string, bool>();
            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteReferência.ContainsKey(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim()))
                {
                    string nomeFornecedor = mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim();

                    if (!hashFornecedoresCadastrados.ContainsKey(nomeFornecedor)
                        && !hashFornecedoresParaCadastrar.ContainsKey(nomeFornecedor))
                    {
                        hashFornecedoresParaCadastrar.Add(nomeFornecedor, true);
                    }
                }
            }

            return hashFornecedoresParaCadastrar;
        }


        private void ApagaVínculosCoexistentes(IDbConnection cn)
        {
            IDbCommand cmd = null;
            StringBuilder sqlExclusão = new StringBuilder("DELETE FROM vinculomercadoriafornecedor where mercadoria in (");
            bool primeiro = true;

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                string referência = mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim();

                if (hashExisteReferência.ContainsKey(referência)
                    && vinculosAtuais.ContainsKey(referência)
                    )
                {
                    if (!primeiro)
                        sqlExclusão.Append(",");

                    primeiro = false;

                    sqlExclusão.Append("'");
                    sqlExclusão.Append(referência);
                    sqlExclusão.Append("'");
                }
            }

            sqlExclusão.Append(")");

            if (!primeiro)
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = sqlExclusão.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        private void AdicionarNovosVínculos(IDbConnection cn)
        {
            IDbCommand cmd = null;
            StringBuilder strNovosVinculos = new StringBuilder("INSERT into vinculomercadoriafornecedor ");
            strNovosVinculos.Append(" (mercadoria, fornecedor, referenciafornecedor, foradelinha, peso) values (");

            bool primeiro = true;
            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                bool adicionado = AdicionarVinculo(mercadoria, strNovosVinculos, primeiro);

                if (adicionado)
                    primeiro = false;
            }

            if (!primeiro)
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = strNovosVinculos.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        private bool AdicionarVinculo(DataRow mercadoria, StringBuilder strNovosVinculos, bool primeiro)
        {
            if (Existe(mercadoria) && !VinculoJáAdicionado(mercadoria))
            {
                string nomeFornecedor = mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim();
                int códigoFornecedor = hashFornecedoresCadastrados[nomeFornecedor];
                string referênciaFornecedor = mercadoria[COLUNA_GESANO_REFERÊNCIA_FORNECEDOR].ToString().Trim();

                if (!primeiro)
                    strNovosVinculos.Append(",(");

                strNovosVinculos.Append("'").Append(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim()).Append("',");
                strNovosVinculos.Append(códigoFornecedor.ToString()).Append(",'");
                strNovosVinculos.Append(referênciaFornecedor).Append("',");

                bool foraDelinha = referênciaFornecedor.ToUpper().Contains(FORA_DE_LINHA_FORNECEDOR.ToUpper());
                strNovosVinculos.Append(foraDelinha).Append(",");

                strNovosVinculos.Append(mercadoria[COLUNA_GESANO_PESO].ToString().Replace(",", ".").Trim()).Append(")");
                vinculosAtuais.Add(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim(), true);

                return true;
            }

            return false;
        }

        private bool Existe(DataRow mercadoria)
        {
            return hashExisteReferência.ContainsKey(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim());
        }

        private bool VinculoJáAdicionado(DataRow mercadoria)
        {
            return vinculosAtuais.ContainsKey(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim());
        }

        private void CadastrarFornecedores(IDbConnection cn, Dictionary<string, bool> hashFornecedoresParaCadastrar)
        {
            IDbCommand cmd = cn.CreateCommand();

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
                cmd.ExecuteNonQuery();
        }

        private Dictionary<string, bool> ObtemNovoVinculosAtuais(IDbConnection cn)
        {
            vinculosAtuais = new Dictionary<string, bool>();

            IDataReader leitor = null;
            IDbCommand cmd = cn.CreateCommand();
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
