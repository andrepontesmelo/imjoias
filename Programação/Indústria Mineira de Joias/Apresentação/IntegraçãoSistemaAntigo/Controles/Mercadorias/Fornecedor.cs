using Apresenta��o.Formul�rios;
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
        private Dictionary<string, int> hashFornecedoresCadastrados;
        private Dictionary<string, bool> vinculosAtuais;
        private DataSet dataSetVelho;

        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection conex�o;
            this.dataSetVelho = dataSetVelho;

            Dictionary<string, bool> refer�ncias = 
            ObterHashExisteRefer�ncia(Acesso.MySQL.MySQLUsu�rios.Obter�ltimaStrConex�o().ToString(), out conex�o);

            Dictionary<string, int> fornecedores = ObterNovosFornecedores(conex�o);
            
            Dictionary<string, bool> fornecedoresParaCadastro =
                ObtemLegadoFornecedoresParaCadastrar();
            
            CadastrarFornecedores(conex�o, fornecedoresParaCadastro);
            fornecedores = ObterNovosFornecedores(conex�o);

            Dictionary<string, bool> vinculos = ObtemNovoVinculosAtuais(conex�o);
            ApagaV�nculosCoexistentes(conex�o);

            vinculos = ObtemNovoVinculosAtuais(conex�o);
            AdicionarNovosV�nculos(conex�o);

            SobrescreveInicio(conex�o, refer�ncias, fornecedores);
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

        private void SobrescreveInicio(IDbConnection cn, Dictionary<string, bool> refer�ncias, 
            Dictionary<string, int> fornecedores)
        {
            StringBuilder erros = new StringBuilder();
            StringBuilder sql = new StringBuilder();

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
                SobrescreveInicio(mercadoria, refer�ncias, fornecedores, sql, erros);

            ExecutaBatchSQL(cn, sql.ToString());
            MostrarErros(erros.ToString());
        }

        private void SobrescreveInicio(DataRow mercadoria, Dictionary<string, bool> refer�ncias, 
            Dictionary<string, int> fornecedores, StringBuilder sql, StringBuilder erros)
        {
            string refer�ncia = mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim();

            if (refer�ncias.ContainsKey(refer�ncia))
            {
                int codFornecedor = fornecedores[mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim()];
                string mesano = mercadoria[COLUNA_GESANO_INICIO].ToString().Trim();

                if (mesano != "")
                {
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
                if (hashExisteRefer�ncia.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim()))
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


        private void ApagaV�nculosCoexistentes(IDbConnection cn)
        {
            IDbCommand cmd = null;
            StringBuilder sqlExclus�o = new StringBuilder("DELETE FROM vinculomercadoriafornecedor where mercadoria in (");
            bool primeiro = true;

            DataTable tabelaVelha = ObterTabelaVelha();

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                string refer�ncia = mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim();

                if (hashExisteRefer�ncia.ContainsKey(refer�ncia)
                    && vinculosAtuais.ContainsKey(refer�ncia)
                    )
                {
                    if (!primeiro)
                        sqlExclus�o.Append(",");

                    primeiro = false;

                    sqlExclus�o.Append("'");
                    sqlExclus�o.Append(refer�ncia);
                    sqlExclus�o.Append("'");
                }
            }

            sqlExclus�o.Append(")");

            if (!primeiro)
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = sqlExclus�o.ToString();
                cmd.ExecuteNonQuery();
            }
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
            if (Existe(mercadoria) && !VinculoJ�Adicionado(mercadoria))
            {
                string nomeFornecedor = mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim();
                int c�digoFornecedor = hashFornecedoresCadastrados[nomeFornecedor];
                string refer�nciaFornecedor = mercadoria[COLUNA_GESANO_REFER�NCIA_FORNECEDOR].ToString().Trim();

                if (!primeiro)
                    strNovosVinculos.Append(",(");

                strNovosVinculos.Append("'").Append(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim()).Append("',");
                strNovosVinculos.Append(c�digoFornecedor.ToString()).Append(",'");
                strNovosVinculos.Append(refer�nciaFornecedor).Append("',");

                bool foraDelinha = refer�nciaFornecedor.ToUpper().Contains(FORA_DE_LINHA_FORNECEDOR.ToUpper());
                strNovosVinculos.Append(foraDelinha).Append(",");

                strNovosVinculos.Append(mercadoria[COLUNA_GESANO_PESO].ToString().Replace(",", ".").Trim()).Append(")");
                vinculosAtuais.Add(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim(), true);

                return true;
            }

            return false;
        }

        private bool Existe(DataRow mercadoria)
        {
            return hashExisteRefer�ncia.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim());
        }

        private bool VinculoJ�Adicionado(DataRow mercadoria)
        {
            return vinculosAtuais.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim());
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
