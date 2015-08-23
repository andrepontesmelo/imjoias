using System;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
{

	/*
		 * Aqui é gerado o compoenentecusto e valorcomponentecusto.
		 * A atualização é observando codigo e data dos componentes.
		 */

	public class ComponenteDeCusto
	{

		private DataSet		dsVelho;
		private DataSet		dsNovo;
		private Dbf	dbf;

		/// <summary>
        /// qual é o valor do componentecusto dolar no momento da tabela.  
        /// Os campos 'dolar' e 'valor' são transformados em 'valor' e 'multiplicarcomponentecusto'
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
                 * Porém, aqui só vai procurar pelo codigo.
                 * Isso porque na nova tabela só existe codigo e nome.
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
			else //não trata-se do dolar.
			{
				//vamos ver se existe informação em no campo 'cc_dolar'.
				if (ObterValorEmDolar(itemAtual) == 0)
				{
					//o componenteCusto NÂO está cotado em dolar.
					novoItem["valor"] = itemAtual["CC_VALOR"];
					novoItem["multiplicarcomponentecusto"] = null;
				} 
				else
				{
					//o componenteCusto está cotado em dolar.

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
