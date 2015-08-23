using System;
using System.Data;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{

	/*
		 * Aqui � gerado o compoenentecusto e valorcomponentecusto.
		 * A atualiza��o � observando codigo e data dos componentes.
		 */

	public class ComponenteDeCusto
	{

		private DataSet		dsVelho;
		private DataSet		dsNovo;
		private Dbf	dbf;

		/// <summary>
        /// qual � o valor do componentecusto dolar no momento da tabela.  
        /// Os campos 'dolar' e 'valor' s�o transformados em 'valor' e 'multiplicarcomponentecusto'
		/// </summary>
        private double valorDolar; 
        		
		public ComponenteDeCusto(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
			dbf = dbfOrigem;
			dsVelho = dataSetVelho;
			dsNovo = dataSetNovo;
		}

        private DataRow ObterItemNovoEquivalalenteAoAntigo(DataRow antigo)
        {
            /*Para um componente de custo ser equivalente, 
                 * deve-se coincidir o CODIGO
                 * 
                 * Por�m, aqui s� vai procurar pelo codigo.
                 * Isso porque na nova tabela s� existe codigo e nome.
                 * 
                 */

            DataRow novo;

            foreach (DataRow itemMySql in dsNovo.Tables["componentecusto"].Rows)
            {
                if (itemMySql["codigo"].ToString().CompareTo(antigo["CC_COD"].ToString()) == 0)
                {
                    return itemMySql;
                }
            }

            novo = dsNovo.Tables["componentecusto"].NewRow();
            novo["codigo"] = antigo["CC_COD"];
            dsNovo.Tables["componentecusto"].Rows.Add(novo);
            return novo;
        }

		private void TransporItem(DataRow itemAtual)
		{
			DataRow novoItem;

			novoItem = ObterItemNovoEquivalalenteAoAntigo(itemAtual);
			novoItem["nome"] = itemAtual["CC_NOME"];

			if (itemAtual["CC_COD"].ToString() == "10")
			{//trata-se do dolar.
					
				valorDolar = Double.Parse(itemAtual["CC_VALOR"].ToString());
					
				novoItem["valor"] = itemAtual["CC_VALOR"];
                novoItem["multiplicarcomponentecusto"] = null;
			}
			else //n�o trata-se do dolar.
			{
				//vamos ver se existe informa��o em no campo 'cc_dolar'.
				if (ObterValorEmDolar(itemAtual) == 0)
				{
					//o componenteCusto N�O est� cotado em dolar.
					novoItem["valor"] = itemAtual["CC_VALOR"];
					novoItem["multiplicarcomponentecusto"] = null;
				} 
				else
				{
					//o componenteCusto est� cotado em dolar.

                    novoItem["valor"] = itemAtual["CC_DOLAR"];
                    novoItem["multiplicarcomponentecusto"] = "10";
				}
			}

		}
		
		public void Transpor()
		{
			foreach(DataRow itemAtual in dsVelho.Tables["ccusto"].Rows)
			{
			    TransporItem(itemAtual);
			}
		}
		private static double ObterValorEmDolar(DataRow antigo)
		{
			return Double.Parse(antigo["CC_DOLAR"].ToString());
		}

	}
}
