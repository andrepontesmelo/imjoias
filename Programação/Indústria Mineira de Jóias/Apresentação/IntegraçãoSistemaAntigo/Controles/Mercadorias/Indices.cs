using System.Data;
using System.Collections.Generic;
using System;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
	/// <summary>
	/// 
	/// Preenchimento do campo 'coeficiente' de tabela 'mercadoria'
	/// </summary>
	/// 
	/* Esquema para se obter o ind�ce: (seguindo orienta��o do hoffman)
		* 	caso j�ia � peso �nico
			indice = cm_vista
		caso contr�rio

			olho no cadmer a faixa e grupo.
			olho no gramas acho a faixa e grupo da mercadoria.
			preciso do G_VISTA do gramas.
			indice = G_VISTA * peso_especifico_da_joia (mas n�o se sabe o peso_espec�fico_da_j�ia);
*/
	public class Indices
	{
        private const int tabelaConsignado = 2;
        private const int tabelaAtacado = 3;
        private const int tabelaAltoAtacado = 4;
        private const int tabelaVarejo = 1;
        private const int tabelaVarejoConsulta = 5;
        private const int tabelaRepresentante = 6;

        private double cota��oVarejo;

		private DataTable cadmer, gramas;
		private DataTable tabelaNovaMercadoria, tabelaCoeficiente;
		//private BaseMercadorias.ReportarInconsistenciaDelegate ReportarErro;
	
		public Indices (DataSet dataSetVelho, DataSet dataSetNovo)
		{
            cadmer = dataSetVelho.Tables["cadmer"];
            gramas = dataSetVelho.Tables["gramas"];
            tabelaNovaMercadoria = dataSetNovo.Tables["mercadoria"];
            tabelaCoeficiente = dataSetNovo.Tables["tabelamercadoria"];
			//ReportarErro = ReportarErroFun��o;
		}

		public void Transpor(double cota��oVarejo)
		{
            int maxComandosPorVez = 200;

            IDbConnection cn = Acesso.MySQL.ConectorMysql.Inst�ncia.CriarConex�o(
                Acesso.MySQL.MySQLUsu�rios.Obter�ltimaStrConex�o());

            cn.Open();

            IDbTransaction t = cn.BeginTransaction();
            
            StringBuilder consulta = new StringBuilder("");

            this.cota��oVarejo = cota��oVarejo;
            
            CriarHash();
            int vezAtual = 0;

            Apresenta��o.Formul�rios.Aguarde aguarde = new Apresenta��o.Formul�rios.Aguarde(
                "Alterando indices do novo banco",
                tabelaNovaMercadoria.Rows.Count, "Transpondo banco de dados", 
                "Aguarde enquanto o banco de dados � sincronizado.");

            aguarde.Abrir();

			foreach(DataRow itemMercadoria in tabelaNovaMercadoria.Rows)
			{
                aguarde.Passo();
                //10208701105
    
                TransporMercadoria(itemMercadoria, consulta);
                vezAtual++;

                if (vezAtual >= maxComandosPorVez && consulta.Length > 0)
                {
                    vezAtual = 0;
                    IDbCommand cmd = cn.CreateCommand();
                    cmd.Transaction = t;
                    cmd.CommandText = consulta.ToString();
                    consulta = new StringBuilder();
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

        
        // Item do banco de dados antigo
        private Dictionary<string, DataRow> hashRefer�nciaItem, hashTabRefItem;

        private void CriarHash()
        {
            hashRefer�nciaItem = new Dictionary<string, DataRow>(cadmer.Rows.Count, StringComparer.Ordinal);

            foreach (DataRow atual in cadmer.Rows)
                hashRefer�nciaItem.Add(atual["CM_CODMER"].ToString().Trim(), atual);

            hashTabRefItem = new Dictionary<string, DataRow>(tabelaCoeficiente.Rows.Count, StringComparer.Ordinal);

            foreach (DataRow atual in tabelaCoeficiente.Rows)
            {
                hashTabRefItem.Add(atual["tabela"].ToString().Trim() + atual["mercadoria"].ToString().Trim(), atual);
            }
            
        }

		private void TransporMercadoria(DataRow itemMercadoria, StringBuilder consulta)
		{
			DataRow itemMercadoriaAntiga; 
            double coeficienteAtacado = 0;
            double coeficienteAutoAtacado = 0;
            double valorVarejo = 0;
            double valorVarejoConsulta = 0;
            bool erro = false;
            bool depeso;

          
            if (!hashRefer�nciaItem.TryGetValue(itemMercadoria["referencia"].ToString().Trim(), out itemMercadoriaAntiga))
            {
                // Tabela coeficiente n�o ser� alterada. Deve continuar com coeficiente antigo, com foradelinha=true
                //ReportarErro("Coeficiente: A mercadoria foi apagada do dbf '" + itemMercadoria["referencia"].ToString() + "'.");
                //itemMercadoria["foradelinha"] = true;
                return;
            }

            depeso = ConferirDePeso(itemMercadoria);
           
            if (depeso)
			{
				try
				{
					coeficienteAtacado = 
						ObterGVistaDeGramas(4, itemMercadoria["faixa"].ToString(), int.Parse(itemMercadoria["grupo"].ToString()));

                    coeficienteAutoAtacado =
                        ObterGVistaDeGramas(8, itemMercadoria["faixa"].ToString(), int.Parse(itemMercadoria["grupo"].ToString()));

                    
                    valorVarejo = double.Parse(itemMercadoriaAntiga["VR_3060902"].ToString());
                    valorVarejoConsulta = Math.Round(Entidades.Pre�o.CorrigirInverso(60, valorVarejo, Entidades.Configura��o.DadosGlobais.Inst�ncia.Juros),2);

                    //valorVarejo = valorVarejo / cota��oVarejo;
                    //valorVarejoConsulta = valorVarejoConsulta / cota��oVarejo;
                } 
				catch (Exception)
				{
//					ReportarErro("Coeficiente: Erro ao cadastrar coeficiente para '" + itemMercadoria["referencia"].ToString() + "'. valor ser� 99999. " + e.Message);

                    coeficienteAtacado 
                        = coeficienteAutoAtacado 
                        = valorVarejo = valorVarejoConsulta = 99999;


                    erro = true;
				}
			}
		
			else //n�o � de peso. 
			{
				try
				{
					coeficienteAtacado =  double.Parse(itemMercadoriaAntiga["CM_VISTA"].ToString());
                    coeficienteAutoAtacado = coeficienteAtacado;

                    valorVarejo = double.Parse(itemMercadoriaAntiga["VR_3060902"].ToString());
                    valorVarejoConsulta =  Math.Round(Entidades.Pre�o.CorrigirInverso(60, valorVarejo, Entidades.Configura��o.DadosGlobais.Inst�ncia.Juros), 2);

                    //valorVarejo /= cota��oVarejo;
                    //valorVarejoConsulta = valorVarejoConsulta / cota��oVarejo;

				} 
				catch (Exception)
				{
//					ReportarErro("Coeficiente: cm_vista � nulo para '" + itemMercadoria["referencia"].ToString() + "'. coeficienete ser� 99999. " + err.Message);

                    coeficienteAtacado
                        = coeficienteAutoAtacado
                        = valorVarejo = valorVarejoConsulta =  99999;

                    erro = true;
				}
			}

            //// Realiza arredondamentos de indice com excecao do varejo:
            //coeficienteAtacado = Math.Round(coeficienteAtacado, 2);
            //coeficienteAutoAtacado = Math.Round(coeficienteAutoAtacado, 2);
            

            //DataRow[] linhas = tabelaCoeficiente.Select("mercadoria = '" + itemMercadoria["referencia"].ToString() + "'");
            DataRow linha;


            // Tabela Atacado
            if (hashTabRefItem.TryGetValue(tabelaAtacado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaAtacado, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaAtacado, coeficienteAtacado, consulta);
            }

            // Tabela Representante
            if (hashTabRefItem.TryGetValue(tabelaRepresentante.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaRepresentante, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaRepresentante, coeficienteAtacado, consulta);
            }
            

            // Tabela Consignado
            if (hashTabRefItem.TryGetValue(tabelaConsignado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaConsignado, coeficienteAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaConsignado, coeficienteAtacado, consulta);
            }

            // Tabela Varejo
            if (hashTabRefItem.TryGetValue(tabelaVarejo.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaVarejo, valorVarejo, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaVarejo, valorVarejo, consulta);
            }

            // Tabela Consulta Varejo 
            if (hashTabRefItem.TryGetValue(tabelaVarejoConsulta.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaVarejoConsulta, valorVarejoConsulta, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaVarejoConsulta, valorVarejoConsulta, consulta);
            }


            // Tabela Auto Atacado
            if (hashTabRefItem.TryGetValue(tabelaAltoAtacado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                AlterarIndiceExistente(itemMercadoria, tabelaAltoAtacado, coeficienteAutoAtacado, consulta);
            }
            else if (!erro)
            {
                AdicionarIndiceNaoExistente(itemMercadoria, tabelaAltoAtacado, coeficienteAutoAtacado, consulta);
            }

            if (erro)
                itemMercadoria["foradelinha"] = true;
            else
            {
                itemMercadoria["depeso"] = depeso;
            }
		}

        private static string DbTransformar(double valor)
        {
            return valor.ToString().Replace(',', '.');
        }

        private static void AlterarIndiceExistente(DataRow itemMercadoria, int tabela, double coeficiente, StringBuilder consulta)
        {

            consulta.Append("update tabelamercadoria set coeficiente = '" + DbTransformar(coeficiente) + "' WHERE "
                + " mercadoria = '" + itemMercadoria["referencia"].ToString() + "' AND tabela = " + tabela.ToString() + ";");
        }

        private static void AdicionarIndiceNaoExistente(DataRow itemMercadoria, int tabela, double coeficiente, StringBuilder consulta)
        {
            consulta.Append("insert into tabelamercadoria (coeficiente,mercadoria,tabela) VALUES ('" +  DbTransformar(coeficiente) + "',"
                + "'" + itemMercadoria["referencia"].ToString() + "'," + tabela.ToString() + ");");
        }

		private static bool ConferirDePeso(DataRow mercadoria)
		{
			if (mercadoria["depeso"].ToString() == "1") 
				return true;
			else
				return false;
		}

		/// <summary>
		/// Pe�a � de grama.
		/// Ver no inicio coment�rio no inicio da classe para saber para qu� serve.
		/// </summary>
		/// <param name="faixa"></param>
		/// <param name="grupo"></param>
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
			throw new Exception("N�o encontrei no gramas.dbf faixa =" + faixa.Trim() + ", grupo ="  + grupo.ToString().Trim() + ", codtab =" + tabela.ToString());
		}
	}
}
