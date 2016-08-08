using Apresentação.Formulários;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	public class Indices
	{
        private const int TABELA_CONSIGNADO = 2;
        private const int TABELA_CONSIGNADO_X = 7;
        private const int TABELA_ATACADO = 3;
        private const int TABELA_ALTO_ATACADO = 4;
        private const int TABELA_VAREJO = 1;
        private const int TABELA_VAREJO_CONSULTA = 5;
        private const int TABELA_REPRESENTANTE = 6;

        private const string COLUNA_CADMER_VAREJO = "VR_3060902";
        private const string COLUNA_CADMER_VAREJO_CONSULTA = "VR_VISTA2";

        private const string MERCADORIA = "mercadoria";
        private const string REFERÊNCIA = "cm_codmer";
        private const string TABELA = "tabela";
        private const string GRUPO = "cm_grupo";
        private const string FAIXA = "cm_faixa";
        private const string LINHA = "cm_linha";

        private double cotaçãoVarejo;

		private DataTable cadmer, gramas;
		private DataTable tabelaCoeficiente;
	
		public Indices (DataSet dataSetVelho, DataSet dataSetNovo)
		{
            cadmer = dataSetVelho.Tables["cadmer"];
            gramas = dataSetVelho.Tables["gramas"];
            tabelaCoeficiente = dataSetNovo.Tables["tabelamercadoria"];
		}

		public void Transpor(double cotaçãoVarejo, StringBuilder saída)
		{
            int maxComandosPorVez = 200;

            IDbConnection cn = Acesso.MySQL.ConectorMysql.Instância.CriarConexão(
                Acesso.MySQL.MySQLUsuários.ObterÚltimaStrConexão());

            cn.Open();

            IDbTransaction t = cn.BeginTransaction();
            
            StringBuilder consulta = new StringBuilder("");

            this.cotaçãoVarejo = cotaçãoVarejo;
            
            CriarHash();
            int vezAtual = 0;

            Aguarde aguarde = new Aguarde(
                "Alterando indices do novo banco",
                cadmer.Rows.Count, "Transpondo banco de dados", 
                "Aguarde enquanto o banco de dados é sincronizado.");

            aguarde.Abrir();

			foreach(DataRow itemMercadoria in cadmer.Rows)
			{
                aguarde.Passo();
    
                TransporMercadoria(itemMercadoria, consulta, saída);
                vezAtual++;

                if (vezAtual >= maxComandosPorVez && consulta.Length > 0)
                {
                    vezAtual = 0;
                    IDbCommand cmd = cn.CreateCommand();
                    cmd.Transaction = t;
                    cmd.CommandText = consulta.ToString();
                    consulta.Clear();
                    cmd.ExecuteNonQuery();
                }                
			}

            if (vezAtual > 0 && consulta.Length > 0)
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = consulta.ToString();
                cmd.Transaction = t;
                cmd.ExecuteNonQuery();
                t.Commit();
            }

            aguarde.Close();
		}

        
        private Dictionary<string, DataRow> hashTabelaDataRowAntigo;

        private void CriarHash()
        {
            hashTabelaDataRowAntigo = new Dictionary<string, DataRow>(tabelaCoeficiente.Rows.Count, StringComparer.Ordinal);

            foreach (DataRow atual in tabelaCoeficiente.Rows)
                hashTabelaDataRowAntigo.Add(atual[TABELA].ToString().Trim() + atual[MERCADORIA].ToString().Trim(), atual);
        }

		private void TransporMercadoria(DataRow itemMercadoria, StringBuilder consulta, StringBuilder saida)
		{
            double coeficienteAtacado = 0;
            double coeficienteAutoAtacado = 0;
            double valorVarejo = 0;
            double valorVarejoConsulta = 0;
            bool erro = false;
            bool deLinha = itemMercadoria[LINHA].ToString().Trim().ToUpper() == "S";

            if (!deLinha)
                return;

            if (Mercadorias.ConferirÉDePeso(itemMercadoria))
                CalcularCoeficienteDePeso(itemMercadoria, saida, ref coeficienteAtacado, ref coeficienteAutoAtacado, ref valorVarejo, ref valorVarejoConsulta, ref erro);
			else 
                CalcularCoeficienteDePeça(itemMercadoria, saida, ref coeficienteAtacado, ref coeficienteAutoAtacado, ref valorVarejo, ref valorVarejoConsulta, ref erro);

            DataRow linha;

            linha = TransporAtacado(itemMercadoria, consulta, coeficienteAtacado, erro);
            linha = TranporRepresentante(itemMercadoria, consulta, coeficienteAtacado, erro, linha);
            linha = TransporConsignado(itemMercadoria, consulta, coeficienteAtacado, erro, linha);
            linha = TransporConsignadoX(itemMercadoria, consulta, coeficienteAtacado, erro, linha);
            linha = TransporVarejo(itemMercadoria, consulta, valorVarejo, erro, linha);
            linha = TransporVarejoConsulta(itemMercadoria, consulta, valorVarejoConsulta, erro, linha);
            linha = TransporAA(itemMercadoria, consulta, coeficienteAutoAtacado, erro, linha);

            if (erro)
                saida.AppendLine("Erro ao importar índice de: " + itemMercadoria[REFERÊNCIA].ToString());
		}

        private DataRow TransporAA(DataRow itemMercadoria, StringBuilder consulta, double coeficienteAutoAtacado, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_ALTO_ATACADO.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_ALTO_ATACADO, coeficienteAutoAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_ALTO_ATACADO, coeficienteAutoAtacado, consulta);
            }

            return linha;
        }

        private DataRow TransporVarejoConsulta(DataRow itemMercadoria, StringBuilder consulta, double valorVarejoConsulta, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_VAREJO_CONSULTA.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_VAREJO_CONSULTA, valorVarejoConsulta, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_VAREJO_CONSULTA, valorVarejoConsulta, consulta);
            }
            return linha;
        }

        private DataRow TransporVarejo(DataRow itemMercadoria, StringBuilder consulta, double valorVarejo, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_VAREJO.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_VAREJO, valorVarejo, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_VAREJO, valorVarejo, consulta);
            }
            return linha;
        }

        private DataRow TransporConsignado(DataRow itemMercadoria, StringBuilder consulta, double coeficienteAtacado, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_CONSIGNADO.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_CONSIGNADO, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_CONSIGNADO, coeficienteAtacado, consulta);
            }
            return linha;
        }

        private DataRow TransporConsignadoX(DataRow itemMercadoria, StringBuilder consulta, double coeficienteAtacado, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_CONSIGNADO_X.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_CONSIGNADO_X, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_CONSIGNADO_X, coeficienteAtacado, consulta);
            }
            return linha;
        }

        private DataRow TranporRepresentante(DataRow itemMercadoria, StringBuilder consulta, double coeficienteAtacado, bool erro, DataRow linha)
        {
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_REPRESENTANTE.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_REPRESENTANTE, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_REPRESENTANTE, coeficienteAtacado, consulta);
            }

            return linha;
        }

        private DataRow TransporAtacado(DataRow itemMercadoria, StringBuilder consulta, double coeficienteAtacado, bool erro)
        {
            DataRow linha;
            if (hashTabelaDataRowAntigo.TryGetValue(TABELA_ATACADO.ToString().Trim() + itemMercadoria[REFERÊNCIA].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, TABELA_ATACADO, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, TABELA_ATACADO, coeficienteAtacado, consulta);
            }
            return linha;
        }

        private static void CalcularCoeficienteDePeça(DataRow itemMercadoria, StringBuilder saida, ref double coeficienteAtacado, ref double coeficienteAutoAtacado, ref double valorVarejo, ref double valorVarejoConsulta, ref bool erro)
        {
            try
            {
                coeficienteAtacado = double.Parse(itemMercadoria["CM_VISTA"].ToString());
                coeficienteAutoAtacado = coeficienteAtacado;
                valorVarejo = double.Parse(itemMercadoria[COLUNA_CADMER_VAREJO].ToString());
                valorVarejoConsulta = double.Parse(itemMercadoria[COLUNA_CADMER_VAREJO_CONSULTA].ToString());
            }
            catch (Exception err)
            {
                saida.AppendLine("Coeficiente: cm_vista é nulo para '" + itemMercadoria[REFERÊNCIA].ToString() + "'. coeficienete será 99999. " + err.Message);

                coeficienteAtacado
                    = coeficienteAutoAtacado
                    = valorVarejo = valorVarejoConsulta = 99999;

                erro = true;
            }
        }

        private void CalcularCoeficienteDePeso(DataRow itemMercadoria, StringBuilder saida, ref double coeficienteAtacado, ref double coeficienteAutoAtacado, ref double valorVarejo, ref double valorVarejoConsulta, ref bool erro)
        {
            try
            {
                coeficienteAtacado =
                    ObterGVistaDeGramas(4, itemMercadoria[FAIXA].ToString(), int.Parse(itemMercadoria[GRUPO].ToString()));

                coeficienteAutoAtacado =
                    ObterGVistaDeGramas(8, itemMercadoria[FAIXA].ToString(), int.Parse(itemMercadoria[GRUPO].ToString()));


                valorVarejo = double.Parse(itemMercadoria[COLUNA_CADMER_VAREJO].ToString());
                valorVarejoConsulta = double.Parse(itemMercadoria[COLUNA_CADMER_VAREJO_CONSULTA].ToString());
            }
            catch (Exception e)
            {
                saida.AppendLine("Coeficiente: Erro ao cadastrar coeficiente para '" + itemMercadoria[REFERÊNCIA].ToString() + "'. valor será 99999. " + e.Message);

                coeficienteAtacado
                    = coeficienteAutoAtacado
                    = valorVarejo = valorVarejoConsulta = 99999;

                erro = true;
            }
        }

        private static string DbTransformar(double valor)
        {
            return valor.ToString().Replace(',', '.');
        }

        private static void AlterarIndiceExistente(DataRow itemMercadoria, int tabela, double coeficiente, StringBuilder consulta)
        {

            consulta.Append("update tabelamercadoria set coeficiente = '" + DbTransformar(coeficiente) + "' WHERE "
                + " mercadoria = '" + itemMercadoria[REFERÊNCIA].ToString() + "' AND tabela = " + tabela.ToString() + ";");
        }

        private static void AdicionarIndiceNaoExistente(DataRow itemMercadoria, int tabela, double coeficiente, StringBuilder consulta)
        {
            consulta.Append("insert into tabelamercadoria (coeficiente,mercadoria,tabela) VALUES ('" +  DbTransformar(coeficiente) + "',"
                + "'" + itemMercadoria[REFERÊNCIA].ToString() + "'," + tabela.ToString() + ");");
        }

		/// <summary>
		/// Peça é de grama.
		/// Ver no inicio comentário no inicio da classe para saber para quê serve.
		/// </summary>
		/// <param name=FAIXA></param>
		/// <param name=GRUPO></param>
		/// <returns></returns>
		private double ObterGVistaDeGramas(int tabela, string faixa, int grupo)
		{
			foreach(DataRow atual in gramas.Rows)
			{
				if ((int.Parse(atual["G_GRUPO"].ToString()) == grupo)
					&&
					(atual["G_FAIXA"].ToString().Trim().CompareTo(faixa) == 0)
					&&
						(Int32.Parse(atual["G_CODTAB"].ToString()) == tabela))
				{
					return double.Parse(atual["G_VISTA"].ToString());
				}
			}
			throw new Exception("Não encontrei no gramas.dbf faixa =" + faixa.Trim() + ", grupo ="  + grupo.ToString().Trim() + ", codtab =" + tabela.ToString());
		}
	}
}
