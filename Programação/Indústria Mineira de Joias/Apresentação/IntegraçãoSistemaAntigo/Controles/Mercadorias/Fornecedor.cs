using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
    public class Fornecedor
	{
        private static string COLUNA_GESANO_REFER�NCIA_MERCADORIA = "GA_CODMER";
        private static string COLUNA_GESANO_PESO = "GA_PESO";
        private static string COLUNA_GESANO_CODIGO_FORNECEDOR = "GA_FORNEC";
        private static string COLUNA_GESANO_REFER�NCIA_FORNECEDOR = "GA_REFFOR";
        private static string COLUNA_GESANO_INICIO = "GA_MESANO";
        private static string FORA_DE_LINHA_FORNECEDOR = "FFL";

        private static int TEMPO_MAXIMO_SQL_MINUTOS = 10;

        private Dictionary<string, bool> hashExisteRefer�ncia;
        private Dictionary<string, bool> vinculosAtuais;
        private DataSet dataSetVelho;

        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection conex�o;
            this.dataSetVelho = dataSetVelho;

            Dictionary<string, bool> refer�ncias = 
            ObterHashExisteRefer�ncia(Acesso.MySQL.MySQLUsu�rios.Obter�ltimaStrConex�o().ToString(), out conex�o);

            ApagaFornecedores(conex�o);

            CadastrarFornecedores(conex�o, ObtemLegadoFornecedoresParaCadastrar());


            AdicionarNovosV�nculos(conex�o);
            SobrescreveInicio(conex�o, refer�ncias);
		}

        private void ReportaErro(string refer�ncia, string mesano, StringBuilder erros)
        { 
            if (erros.Length == 0)
            {
                erros.Append("Erros do gesano.dbf s�o listados abaixo. Estes erros n�o interrompem a integra��o. ");
                erros.AppendLine("Por�m o vinculomercadoriafornecedor ficar� sem a informa��o de in�cio para esta(s) mercadoria(s): ");
            }

            erros.AppendLine();
            erros.Append(" * mercadoria ");
            erros.Append(refer�ncia);
            erros.Append(" possui in�cio fora do padr�o MMyy: ");
            erros.Append(mesano);
        }

        private void SobrescreveInicio(IDbConnection cn, Dictionary<string, bool> refer�ncias)
        {
            StringBuilder erros = new StringBuilder();
            StringBuilder sql = new StringBuilder();

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
                SobrescreveInicio(mercadoria, refer�ncias, sql, erros);

            ExecutaBatchSQL(cn, sql.ToString());
            MostrarErros(erros.ToString());
        }

        private void SobrescreveInicio(DataRow mercadoria, Dictionary<string, bool> refer�ncias, StringBuilder sql, StringBuilder erros)
        {
            string refer�ncia = mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim();

            if (refer�ncias.ContainsKey(refer�ncia))
            {
                int codFornecedor =  int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString());
                string mesano = mercadoria[COLUNA_GESANO_INICIO].ToString().Trim();

                if (String.IsNullOrEmpty(mesano))
                    return;

                try
                {
                    GeraSQLUpdateInicio(refer�ncia, mesano, sql);
                }
                catch (FormatException)
                {
                    ReportaErro(refer�ncia, mesano, erros);
                }
            }
        }

        private void MostrarErros(string erros)
        {
            if (erros.Length > 0)
            {
                MessageBox.Show(erros, "Erros ignorados de in�cio de fornecedor",
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

        private void GeraSQLUpdateInicio(string refer�ncia, string mesano, StringBuilder sql)
        {
            DateTime inicio = DateTime.ParseExact(mesano, "MMyy", System.Globalization.CultureInfo.CurrentCulture);

            sql.Append("update vinculomercadoriafornecedor set inicio=");
            sql.Append(Acesso.Comum.DbManipula��oSimples.DbTransformar(inicio));
            sql.Append(" where mercadoria='");
            sql.Append(refer�ncia);
            sql.Append("'; ");
        }

        private Dictionary<string, bool> ObterHashExisteRefer�ncia(String strConex�o, out IDbConnection cn)
        {
            hashExisteRefer�ncia = new Dictionary<string, bool>();

            cn = Acesso.MySQL.ConectorMysql.Inst�ncia.CriarConex�o(strConex�o);
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
                            hashExisteRefer�ncia.Add(leitor.GetString(0), true);
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }
            }

            return hashExisteRefer�ncia;

        }

        private DataTable ObterTabelaVelha()
        {
            return dataSetVelho.Tables["gesano"];
        }

        private SortedSet<int> ObtemLegadoFornecedoresParaCadastrar()
        {
            SortedSet<int> c�digos = new SortedSet<int>();
            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (ExisteRefer�ncia(mercadoria))
                    c�digos.Add(int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString()));
            }

            return c�digos;
        }

        private bool ExisteRefer�ncia(DataRow mercadoria)
        {
            return hashExisteRefer�ncia.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim());
        }

        private void ApagaFornecedores(IDbConnection cn)
        {
            IDbCommand cmd = cn.CreateCommand();
            cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM vinculomercadoriafornecedor";
            cmd.ExecuteNonQuery();

            cmd = cn.CreateCommand();
            cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM fornecedor";
            cmd.ExecuteNonQuery();

        }

        private void AdicionarNovosV�nculos(IDbConnection cn)
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
            if (ExisteRefer�ncia(mercadoria) && !VinculoJ�Adicionado(mercadoria))
            {
                int c�digoFornecedor = int.Parse(mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString());
                string refer�nciaFornecedor = mercadoria[COLUNA_GESANO_REFER�NCIA_FORNECEDOR].ToString().Trim();

                if (!primeiro)
                    strNovosVinculos.Append(",(");

                strNovosVinculos.Append("'").Append(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim()).Append("',");
                strNovosVinculos.Append(c�digoFornecedor.ToString()).Append(",'");
                strNovosVinculos.Append(refer�nciaFornecedor.Replace(FORA_DE_LINHA_FORNECEDOR, "")).Append("',");

                bool foraDelinha = refer�nciaFornecedor.ToUpper().Contains(FORA_DE_LINHA_FORNECEDOR.ToUpper());
                strNovosVinculos.Append(foraDelinha).Append(",");

                strNovosVinculos.Append(mercadoria[COLUNA_GESANO_PESO].ToString().Replace(",", ".").Trim()).Append(")");
                V�nculosAtuais.Add(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim(), true);

                return true;
            }

            return false;
        }

        private bool VinculoJ�Adicionado(DataRow mercadoria)
        {
            return V�nculosAtuais.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim());
        }

        private Dictionary<string, bool> V�nculosAtuais
        {
            get
            {
                if (vinculosAtuais == null)
                    vinculosAtuais = new Dictionary<string, bool>();

                return vinculosAtuais;
            }
        }

        private void CadastrarFornecedores(IDbConnection cn, SortedSet<int> c�digos)
        {
            IDbCommand cmd = cn.CreateCommand();

            string strNovosFornecedores = "INSERT INTO fornecedor (codigo) VALUES ";
            bool primeiro = true;

            foreach (int c�digo in c�digos)
            {
                if (!primeiro)
                    strNovosFornecedores += ",";

                strNovosFornecedores += "(" + c�digo + ")";
                primeiro = false;
            }

            cmd.CommandText = strNovosFornecedores;

            if (!primeiro)
                cmd.ExecuteNonQuery();
        }
	}
}
