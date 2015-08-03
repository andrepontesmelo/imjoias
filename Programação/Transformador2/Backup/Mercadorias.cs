using System;
using System.Data;

namespace Transformador2
{
	/// <summary>
	/// Transpõe-se aqui o mercadorias.
	/// Porém não transpoe o indice. é feito em Indice.cs
	/// Também não transpoe o vinculo entre mercadoria e componenete custo
	/// 
	/// A atualização é feita assim:
	/// se existe uma mercadoria com determinado código, então todos os outros
	/// valores são sobrescritos.
	/// </summary>
	public class Mercadorias
	{
		private Acesso.Dbf dbf;
		private Acesso.MySql mysql;
		
		
		public Mercadorias(Acesso.Dbf meuDbf, Acesso.MySql meuMySql)
		{
			dbf = meuDbf;
			mysql = meuMySql;
			
			dbf.AdicionarTabelaAoObterDataSet("cadmer");
			mysql.AdicionarTabelaAoDataSet("mercadoria");
			mysql.AdicionarTabelaAoDataSet("vinculomercadoriacomponentecusto");
		}

		public void Transpor()
		{
			DataRow novoItem;

			foreach(DataRow itemAtual in dbf.ds.Tables["cadmer"].Rows)
			{
				novoItem = ObterItemNovoEquivalalenteAoAntigoValor(itemAtual);
				novoItem["nome"] = itemAtual["CM_NOME"];
				novoItem["teor"] = itemAtual["CM_TEOR"];
				novoItem["peso"] = itemAtual["CM_PESO"];
				novoItem["faixa"] = itemAtual["CM_FAIXA"];
				novoItem["grupo"] = itemAtual["CM_GRUPO"];
				novoItem["digito"] = itemAtual["CM_DIGMER"];
				novoItem["indice"] = DBNull.Value;
				
				if (itemAtual["CM_LINHA"].ToString().CompareTo("S") == 0)
					novoItem["foradelinha"] = false;
				else 
					novoItem["foradelinha"] = true;

				try
				{
					if (ConferirÉDePeso(novoItem["referencia"].ToString()))
						novoItem["depeso"] = true;
					else
						novoItem["depeso"] = false;
				} 
				catch (Exception e)
				{
					System.Windows.Forms.MessageBox.Show("Erro no conferir se é de peso. Valor escolhido será null. Mais informações: " + e.Message);
					novoItem["depeso"] = DBNull.Value;
				}
				
			}
		}

		private bool ConferirÉDePeso(String referência)
		{
			String quartoDigito;
			/*
			 * primeiro digito 3 ou 2 -> peso
			 * quarto digito 9 ou 8   -> peso
			 */
			if (referência.Length < 4)
				throw new Exception("Não foi possível conferir se é de peso ou não para mercadoria '" + referência + "' pela flag.");

			if (referência.StartsWith("3") || referência.StartsWith("2"))
				return true;
			
			quartoDigito = referência.Substring(3,1);
			if ((quartoDigito == "9") || (quartoDigito == "8"))
				return true;

			return false;	
		}
		
		/// <summary>
		/// Verifica se já existe o que queira adicionar no mysql. Caso sim, retorna o dataRow correspondente
		/// Caso não, cria-se um dataRow com as informações não-alteráveis (básicas). Neste caso, referência.
		/// </summary>
		/// <param name="antigo"></param>
		/// <returns></returns>
		private DataRow ObterItemNovoEquivalalenteAoAntigoValor(DataRow antigo)
		{
			DataRow novo;

			foreach(DataRow itemMySql in mysql.ds.Tables["mercadoria"].Rows)
			{
				if (itemMySql["referencia"].ToString().CompareTo(antigo["CM_CODMER"].ToString().Trim()) == 0)
				{
					return itemMySql;
				}
			}
			
			novo = mysql.ds.Tables["mercadoria"].NewRow();
			novo["referencia"] = antigo["CM_CODMER"].ToString().Trim();
			mysql.ds.Tables["mercadoria"].Rows.Add(novo);
			return novo;
		}

	}
}
