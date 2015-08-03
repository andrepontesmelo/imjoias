using System.Data;
using System.Collections.Generic;
using System;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{
	/// <summary>
	/// 
	/// Preenchimento do campo 'coeficiente' de tabela 'mercadoria'
	/// </summary>
	/// 
	/* Esquema para se obter o indíce: (seguindo orientação do hoffman)
		* 	caso jóia é peso único
			indice = cm_vista
		caso contrário

			olho no cadmer a faixa e grupo.
			olho no gramas acho a faixa e grupo da mercadoria.
			preciso do G_VISTA do gramas.
			indice = G_VISTA * peso_especifico_da_joia (mas não se sabe o peso_específico_da_jóia);
*/
	public class Indices
	{
        private const int tabelaConsignado = 2;
        private const int tabelaAtacado = 3;
        private const int tabelaAltoAtacado = 4;
        private const int tabelaVarejo = 1;

        private double cotaçãoVarejo;

		private DataTable cadmer, gramas;
		private DataTable tabelaNovaMercadoria, tabelaCoeficiente;
		private BaseMercadorias.ReportarInconsistenciaDelegate ReportarErro;
	
		public Indices (BaseMercadorias.ReportarInconsistenciaDelegate ReportarErroFunção, DataSet dataSetVelho, DataSet dataSetNovo)
		{
            cadmer = dataSetVelho.Tables["cadmer"];
            gramas = dataSetVelho.Tables["gramas"];
            tabelaNovaMercadoria = dataSetNovo.Tables["mercadoria"];
            tabelaCoeficiente = dataSetNovo.Tables["tabelamercadoria"];
			ReportarErro = ReportarErroFunção;
		}

		public void Transpor(double cotaçãoVarejo)
		{
            this.cotaçãoVarejo = cotaçãoVarejo;
            
            CriarHash();

			foreach(DataRow itemMercadoria in tabelaNovaMercadoria.Rows)
			{
				TransporMercadoria(itemMercadoria);
			}
		}

        // Item do banco de dados antigo
        private Dictionary<string, DataRow> hashReferênciaItem, hashTabRefItem;

        private void CriarHash()
        {
            hashReferênciaItem = new Dictionary<string,DataRow>(cadmer.Rows.Count);

            foreach (DataRow atual in cadmer.Rows)
                hashReferênciaItem.Add(atual["CM_CODMER"].ToString().Trim(), atual);

            hashTabRefItem = new Dictionary<string, DataRow>(tabelaCoeficiente.Rows.Count);

            foreach (DataRow atual in tabelaCoeficiente.Rows)
                hashTabRefItem.Add(atual["tabela"].ToString().Trim() + atual["mercadoria"].ToString().Trim(), atual);
        }

		private void TransporMercadoria(DataRow itemMercadoria)
		{
			DataRow itemMercadoriaAntiga; 
            double coeficienteAtacado = 0;
            double coeficienteAutoAtacado = 0;
            double valorVarejo = 0;
            bool deuPau = false;
            bool depeso;
		
            if (!hashReferênciaItem.TryGetValue(itemMercadoria["referencia"].ToString().Trim(), out itemMercadoriaAntiga))
            {
                // Tabela coeficiente não será alterada. Deve continuar com coeficiente antigo, com foradelinha=true
				ReportarErro("Coeficiente: A mercadoria foi apagada do dbf '" + itemMercadoria["referencia"].ToString() + "'.");
				itemMercadoria["foradelinha"] = true;
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
                    valorVarejo = valorVarejo / cotaçãoVarejo;
                } 
				catch (Exception e)
				{
					ReportarErro("Coeficiente: Erro ao cadastrar coeficiente para '" + itemMercadoria["referencia"].ToString() + "'. valor será 99999. " + e.Message);

                    coeficienteAtacado 
                        = coeficienteAutoAtacado 
                        = valorVarejo = 99999;


                    deuPau = true;
				}
			}
		
			else //não é de peso. 
			{
				try
				{
					coeficienteAtacado =  double.Parse(itemMercadoriaAntiga["CM_VISTA"].ToString());
                    coeficienteAutoAtacado = coeficienteAtacado;

                    valorVarejo = double.Parse(itemMercadoriaAntiga["VR_3060902"].ToString());
                    valorVarejo /= cotaçãoVarejo;
				} 
				catch (Exception err)
				{
					ReportarErro("Coeficiente: cm_vista é nulo para '" + itemMercadoria["referencia"].ToString() + "'. coeficienete será 99999. " + err.Message);

                    coeficienteAtacado
                        = coeficienteAutoAtacado
                        = valorVarejo = 99999;

                    deuPau = true;
				}
			}

            //DataRow[] linhas = tabelaCoeficiente.Select("mercadoria = '" + itemMercadoria["referencia"].ToString() + "'");
            DataRow linha;

            if (hashTabRefItem.TryGetValue(tabelaAtacado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
                linha["coeficiente"] = coeficienteAtacado;
            else if (!deuPau)
            {
                linha = tabelaCoeficiente.NewRow();
                linha["mercadoria"] = itemMercadoria["referencia"].ToString();
                linha["tabela"] = tabelaAtacado;
                linha["coeficiente"] = coeficienteAtacado;
                tabelaCoeficiente.Rows.Add(linha);
            }

            if (hashTabRefItem.TryGetValue(tabelaConsignado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                linha["coeficiente"] = coeficienteAtacado;
            }
            else if (!deuPau)
            {
                linha = tabelaCoeficiente.NewRow();
                linha["mercadoria"] = itemMercadoria["referencia"].ToString();
                linha["tabela"] = tabelaConsignado;
                linha["coeficiente"] = coeficienteAtacado;
                tabelaCoeficiente.Rows.Add(linha);
            }

            if (hashTabRefItem.TryGetValue(tabelaVarejo.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                linha["coeficiente"] = linha["coeficiente"];
            }
            else if (!deuPau)
            {
                linha = tabelaCoeficiente.NewRow();
                linha["mercadoria"] = itemMercadoria["referencia"].ToString();
                linha["tabela"] = tabelaVarejo;
                linha["coeficiente"] = valorVarejo;
                tabelaCoeficiente.Rows.Add(linha);
            }

            if (hashTabRefItem.TryGetValue(tabelaAltoAtacado.ToString().Trim() + itemMercadoria["referencia"].ToString().Trim(), out linha))
            {
                linha["coeficiente"] = coeficienteAutoAtacado;
            }
            else if (!deuPau)
            {
                linha = tabelaCoeficiente.NewRow();
                linha["mercadoria"] = itemMercadoria["referencia"].ToString();
                linha["tabela"] = tabelaAltoAtacado;
                linha["coeficiente"] = coeficienteAutoAtacado;
                tabelaCoeficiente.Rows.Add(linha);
            }

            if (deuPau)
                itemMercadoria["foradelinha"] = true;
            else
            {
                itemMercadoria["depeso"] = depeso;
            }
		}
		private bool ConferirDePeso(DataRow mercadoria)
		{
			if (mercadoria["depeso"].ToString() == "1") 
				return true;
			else
				return false;
		}

		/// <summary>
		/// Peça é de grama.
		/// Ver no inicio comentário no inicio da classe para saber para quê serve.
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
			throw new Exception("Não encontrei no gramas.dbf faixa =" + faixa.Trim() + ", grupo ="  + grupo.ToString().Trim() + ", codtab =" + tabela.ToString());
		}
	}
}
