using System;
using System.Data;

namespace Transformador2
{
	/*
	 * Aqui � gerado o compoenentecusto e valorcomponentecusto.
	 * A atualiza��o � observando codigo e data dos componentes.
	 */

	public class ComponenteDeCusto
	{
		private Acesso.Dbf dbf;
		private Acesso.MySql mysql;
		
		private double valorDolar; //qual � o valor do componentecusto dolar no momento da tabela.  Os campos 'dolar' e 'valor' s�o transformados em 'valor' e 'multiplicarcomponentecusto'
        		
		public ComponenteDeCusto(Acesso.Dbf meuDbf, Acesso.MySql meuMySql)
		{
			dbf = meuDbf;
			mysql = meuMySql;
			
			dbf.AdicionarTabelaAoObterDataSet("ccusto");

			mysql.AdicionarTabelaAoDataSet("componentecusto");
			mysql.AdicionarTabelaAoDataSet("valorcomponentecusto");

		}

		public void Transpor()
		{
			DataRow novoItem;
			DataRow novoItemValor;

			
			foreach(DataRow itemAtual in dbf.ds.Tables["ccusto"].Rows)
			{
				novoItem = ObterItemNovoEquivalalenteAoAntigo(itemAtual);
				novoItem["nome"] = itemAtual["CC_NOME"];

				if (itemAtual["CC_COD"].ToString() == "10")
				{//trata-se do dolar.
					
					valorDolar = Double.Parse(itemAtual["CC_VALOR"].ToString());
					
					novoItemValor = ObterItemNovoEquivalalenteAoAntigoValor(itemAtual);
					novoItemValor["valor"] = itemAtual["CC_VALOR"];
					novoItemValor["multiplicarcomponentecusto"] = null;
				}
				else //n�o trata-se do dolar.
				{
					novoItemValor = ObterItemNovoEquivalalenteAoAntigoValor(itemAtual);
					
					//vamos ver se existe informa��o em no campo 'cc_dolar'.
					if (ObterValorEmDolar(itemAtual) == 0)
					{
						//o componenteCusto N�O est� cotado em dolar.
						novoItemValor["valor"] = itemAtual["CC_VALOR"];
						novoItemValor["multiplicarcomponentecusto"] = null;
					} 
					else
					{
						//o componenteCusto est� cotado em dolar.
					
						novoItemValor["valor"] = itemAtual["CC_DOLAR"];
						novoItemValor["multiplicarcomponentecusto"] = "10";
					}
				}
				
			}
			mysql.GravarDataSet("componentecusto"); //mesmo sendo usado posteriormente, deve-se gravar agora.
			mysql.GravarDataSet("valorcomponentecusto");
			LimparMem�ria();
		}
		private void LimparMem�ria()
		{	
			dbf.ds.Tables.Remove("ccusto");
			mysql.ds.Tables.Remove("valorcomponentecusto");
		}
		private double ObterValorEmDolar(DataRow antigo)
		{
			return Double.Parse(antigo["CC_DOLAR"].ToString());
		}
		private DataRow ObterItemNovoEquivalalenteAoAntigo(DataRow antigo)
		{
			/*Para um componente de custo ser equivalente, 
			 * deve-se coincidir o CODIGO e a DATA.
			 * 
			 * Por�m, aqui s� vai procurar pelo codigo.
			 * Isso porque na nova tabela s� existe codigo e nome.
			 * 
			 */ 

			DataRow novo;

			foreach(DataRow itemMySql in mysql.ds.Tables["componentecusto"].Rows)
			{
				if (itemMySql["codigo"].ToString().CompareTo(antigo["CC_COD"].ToString()) == 0)
				{
					return itemMySql;
				}
			}
			
			novo = mysql.ds.Tables["componentecusto"].NewRow();
			novo["codigo"] = antigo["CC_COD"];
			mysql.ds.Tables["componentecusto"].Rows.Add(novo);
			return novo;
		}
		private DataRow ObterItemNovoEquivalalenteAoAntigoValor(DataRow antigo)
		{
			DataRow novo;

			foreach(DataRow itemMySql in mysql.ds.Tables["valorcomponentecusto"].Rows)
			{
				if ( (itemMySql["componentecusto"].ToString().CompareTo(antigo["CC_COD"].ToString()) == 0)
					&&
					(itemMySql["data"].ToString().CompareTo(antigo["CC_DATA"].ToString()) == 0) )
				{
					return itemMySql;
				}
			}
			
			
			novo = mysql.ds.Tables["valorcomponentecusto"].NewRow();
			novo["data"] = antigo["CC_DATA"];
			novo["componentecusto"] = antigo["CC_COD"];
			mysql.ds.Tables["valorcomponentecusto"].Rows.Add(novo);
			return novo;
		}
	}
}
