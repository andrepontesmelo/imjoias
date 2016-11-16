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
        private Dictionary<string, bool> vinculosAtuais;
        private DataSet dataSetVelho;

        private IDbConnection conexão;
        private IDbTransaction transação;

        public Fornecedor(DataSet dataSetVelho)
        {
            this.dataSetVelho = dataSetVelho;
        }

        public void Transpor()
        {
            conexão = ObterConexãoAberta();
            transação = conexão.BeginTransaction();

            Dictionary<string, bool> referências = ObterHashExisteReferência();
            ApagaFornecedores();
            CadastrarFornecedores(ObtemLegadoFornecedoresParaCadastrar());
            CadastrarVínculos();
            SobrescreveInicio(referências);

            transação.Commit();
            conexão.Close();
        }

        private static IDbConnection ObterConexãoAberta()
        {
            IDbConnection conexão = Acesso.MySQL.ConectorMysql.Instância.CriarConexão(Acesso.MySQL.MySQLUsuários.ObterÚltimaStrConexão());
            conexão.Open();
            return conexão;
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

        private void SobrescreveInicio(Dictionary<string, bool> referências)
        {
            StringBuilder erros = new StringBuilder();
            StringBuilder sql = new StringBuilder();

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
                SobrescreveInicio(mercadoria, referências, sql, erros);

            ExecutaBatchSQL(sql.ToString());
            MostrarErros(erros.ToString());
        }

        private void SobrescreveInicio(DataRow mercadoria, Dictionary<string, bool> referências, StringBuilder sql, StringBuilder erros)
        {
            string referência = mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim();

            if (referências.ContainsKey(referência))
            {
                int codFornecedor =  int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString());
                string mesano = mercadoria[COLUNA_GESANO_INICIO].ToString().Trim();

                if (String.IsNullOrEmpty(mesano))
                    return;

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

        private void MostrarErros(string erros)
        {
            if (erros.Length > 0)
            {
                MessageBox.Show(erros, "Erros ignorados de início de fornecedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void ExecutaBatchSQL(string sql)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = sql;
                cmd.CommandTimeout = (int) TimeSpan.FromMinutes(TEMPO_MAXIMO_SQL_MINUTOS).TotalSeconds;

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

        private Dictionary<string, bool> ObterHashExisteReferência()
        {
            hashExisteReferência = new Dictionary<string, bool>();

            using (IDbCommand cmd = conexão.CreateCommand())
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

        private DataTable ObterTabelaVelha()
        {
            return dataSetVelho.Tables["gesano"];
        }

        private SortedSet<int> ObtemLegadoFornecedoresParaCadastrar()
        {
            SortedSet<int> códigos = new SortedSet<int>();
            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (ExisteReferência(mercadoria))
                    códigos.Add(int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString()));
            }

            return códigos;
        }

        private bool ExisteReferência(DataRow mercadoria)
        {
            return hashExisteReferência.ContainsKey(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim());
        }

        private void ApagaFornecedores()
        {
            IDbCommand cmd = conexão.CreateCommand();
            cmd.Transaction = transação;
            cmd = conexão.CreateCommand();
            cmd.CommandText = "DELETE FROM vinculomercadoriafornecedor";
            cmd.ExecuteNonQuery();

            cmd = conexão.CreateCommand();
            cmd.Transaction = transação;
            cmd.CommandText = "DELETE FROM fornecedor";
            cmd.ExecuteNonQuery();
        }

        private void CadastrarVínculos()
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

            if (primeiro)
                return;

            cmd = conexão.CreateCommand();
            cmd.Transaction = transação;
            cmd.CommandText = strNovosVinculos.ToString();
            cmd.ExecuteNonQuery();
        }

        private bool AdicionarVinculo(DataRow mercadoria, StringBuilder strNovosVinculos, bool primeiro)
        {
            if (ExisteReferência(mercadoria) && !VinculoJáAdicionado(mercadoria))
            {
                int códigoFornecedor = int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString());
                string referênciaFornecedor = mercadoria[COLUNA_GESANO_REFERÊNCIA_FORNECEDOR].ToString().Trim();

                if (!primeiro)
                    strNovosVinculos.Append(",(");

                strNovosVinculos.Append("'").Append(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim()).Append("',");
                strNovosVinculos.Append(códigoFornecedor.ToString()).Append(",'");
                strNovosVinculos.Append(referênciaFornecedor.Replace(FORA_DE_LINHA_FORNECEDOR, "")).Append("',");

                bool foraDelinha = referênciaFornecedor.ToUpper().Contains(FORA_DE_LINHA_FORNECEDOR.ToUpper());
                strNovosVinculos.Append(foraDelinha).Append(",");

                strNovosVinculos.Append(mercadoria[COLUNA_GESANO_PESO].ToString().Replace(",", ".").Trim()).Append(")");
                VínculosAtuais.Add(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim(), true);

                return true;
            }

            return false;
        }

        private bool VinculoJáAdicionado(DataRow mercadoria)
        {
            return VínculosAtuais.ContainsKey(mercadoria[COLUNA_GESANO_REFERÊNCIA_MERCADORIA].ToString().Trim());
        }

        private Dictionary<string, bool> VínculosAtuais
        {
            get
            {
                if (vinculosAtuais == null)
                    vinculosAtuais = new Dictionary<string, bool>();

                return vinculosAtuais;
            }
        }

        private void CadastrarFornecedores(SortedSet<int> códigos)
        {
            IDbCommand cmd = conexão.CreateCommand();
            cmd.Transaction = transação;

            string strNovosFornecedores = "INSERT INTO fornecedor (codigo) VALUES ";
            bool primeiro = true;

            foreach (int código in códigos)
            {
                if (!primeiro)
                    strNovosFornecedores += ",";

                strNovosFornecedores += "(" + código + ")";
                primeiro = false;
            }

            cmd.CommandText = strNovosFornecedores;

            if (!primeiro)
                cmd.ExecuteNonQuery();
        }
	}
}
