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
        private static string COLUNA_GESANO_CODIGO_FORNECEDOR = "GA_FORNEC";
        private static string COLUNA_GESANO_REFER�NCIA_FORNECEDOR = "GA_REFFOR";
        private static string COLUNA_GESANO_INICIO = "GA_MESANO";

        public Fornecedor(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            IDbConnection conex�o;

            Dictionary<string, bool> refer�ncias = 
            ObterHashExisteRefer�ncia(Acesso.MySQL.MySQLUsu�rios.Obter�ltimaStrConex�o().ToString(), out conex�o);

            Dictionary<string, int> fornecedores = ObterNovosFornecedores(conex�o);
            
            Dictionary<string, bool> fornecedoresParaCadastro =
                ObtemLegadoFornecedoresParaCadastrar(dataSetVelho, refer�ncias, fornecedores);
            
            CadastrarFornecedores(conex�o, fornecedoresParaCadastro);
            fornecedores = ObterNovosFornecedores(conex�o);
            
            Dictionary<string, bool> vinculos = ObtemNovoVinculosAtuais(conex�o);
            AdicionarNovosV�nculos(conex�o, refer�ncias, fornecedores, vinculos, dataSetVelho);

            SobrescreveInicio(conex�o, dataSetVelho, refer�ncias, fornecedores);
		}

        private void SobrescreveInicio(IDbConnection cn, DataSet dataSetVelho, Dictionary<string, bool> refer�ncias, Dictionary<string, int> fornecedores)
        {
            StringBuilder erros = new StringBuilder();
            StringBuilder sql = new StringBuilder();

            DataTable tabelaVelha = ObterTabelaVelha(dataSetVelho);

            foreach (DataRow mercadoria in tabelaVelha.Rows)
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
                            DateTime inicio = DateTime.ParseExact(mesano, "MMyy", System.Globalization.CultureInfo.CurrentCulture);

                            sql.Append("update vinculomercadoriafornecedor set inicio=");
                            sql.Append(Acesso.Comum.DbManipula��oSimples.DbTransformar(inicio));
                            sql.Append(" where mercadoria='");
                            sql.Append(refer�ncia);
                            sql.Append("'; ");
                        } catch (FormatException)
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
                    }
                }
            }

            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql.ToString();
                cmd.ExecuteNonQuery();
            }

            if (erros.Length > 0)
            {
                AguardeDB.Fechar();
                MessageBox.Show(erros.ToString(), "Erros ignorados de in�cio de fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                MessageBox.Show(erros.ToString());
                AguardeDB.Mostrar();
            }
        }

        private Dictionary<string, bool> ObterHashExisteRefer�ncia(String strConex�o, out IDbConnection cn)
        {
            Dictionary<string, bool> hashExisteRefer�ncia = new Dictionary<string, bool>();

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
            Dictionary<string, int> hashFornecedoresCadastrados = new Dictionary<string, int>();
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

        private DataTable ObterTabelaVelha(DataSet dataSetVelho)
        {
            return dataSetVelho.Tables["gesano"];
        }

        private Dictionary<string, bool> ObtemLegadoFornecedoresParaCadastrar(DataSet dataSetVelho, 
            Dictionary<string, bool> hashExisteRefer�ncia,
            Dictionary<string, int> hashFornecedoresCadastrados)
        {
            Dictionary<string, bool> hashFornecedoresParaCadastrar = new Dictionary<string, bool>();

            DataTable tabelaVelha = ObterTabelaVelha(dataSetVelho);

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

        private void AdicionarNovosV�nculos(IDbConnection cn, 
            Dictionary<string, bool> hashExisteRefer�ncia,
            Dictionary<string, int> hashFornecedoresCadastrados,
            Dictionary<string, bool> vinculosAtuais, DataSet dataSetVelho)
        {
            IDbCommand cmd = null;
            StringBuilder strNovosVinculos = new StringBuilder("INSERT into vinculomercadoriafornecedor (mercadoria, fornecedor, referenciafornecedor) values (");
            bool primeiro = true;

            DataTable tabelaVelha = ObterTabelaVelha(dataSetVelho);

            foreach (DataRow mercadoria in tabelaVelha.Rows)
            {
                if (hashExisteRefer�ncia.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim())
                    &&
                    !vinculosAtuais.ContainsKey(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim())
                    )
                {
                    string nomeFornecedor = mercadoria[COLUNA_GESANO_CODIGO_FORNECEDOR].ToString().Trim();
                    int c�digoFornecedor = hashFornecedoresCadastrados[nomeFornecedor];
                    string refer�nciaFornecedor = mercadoria[COLUNA_GESANO_REFER�NCIA_FORNECEDOR].ToString().Trim();

                    if (!primeiro)
                        strNovosVinculos.Append(",(");


                    primeiro = false;

                    strNovosVinculos.Append("'").Append(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim()).Append("',");
                    strNovosVinculos.Append(c�digoFornecedor.ToString()).Append(",'");
                    strNovosVinculos.Append(refer�nciaFornecedor).Append("')");

                    vinculosAtuais.Add(mercadoria[COLUNA_GESANO_REFER�NCIA_MERCADORIA].ToString().Trim(), true);
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

        private void CadastrarFornecedores(IDbConnection cn, Dictionary<string, bool> hashFornecedoresParaCadastrar)
        {
            // Obtem fornecedor do mysql.
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
            {
                // existe pelo menos um para inserir.
                cmd.ExecuteNonQuery();
            }
        }

        private Dictionary<string, bool> ObtemNovoVinculosAtuais(IDbConnection cn)
        {
            Dictionary<string, bool> vinculosAtuais = new Dictionary<string, bool>();

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
