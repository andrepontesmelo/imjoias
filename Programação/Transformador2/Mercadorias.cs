using System;
using System.Data;

namespace Transformador2
{
	/// <summary>
	/// Transp�e-se aqui o mercadorias.
	/// Por�m n�o transpoe o indice. � feito em Indice.cs
	/// Tamb�m n�o transpoe o vinculo entre mercadoria e componenete custo
	/// 
	/// A atualiza��o � feita assim:
	/// se existe uma mercadoria com determinado c�digo, ent�o todos os outros
	/// valores s�o sobrescritos.
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
					if (Conferir�DePeso(novoItem["referencia"].ToString()))
						novoItem["depeso"] = true;
					else
						novoItem["depeso"] = false;
				} 
				catch (Exception e)
				{
					System.Windows.Forms.MessageBox.Show("Erro no conferir se � de peso. Valor escolhido ser� null. Mais informa��es: " + e.Message);
					novoItem["depeso"] = DBNull.Value;
				}
				
			}
		}

		private bool Conferir�DePeso(String refer�ncia)
		{
			String quartoDigito;
			/*
			 * primeiro digito 3 ou 2 -> peso
			 * quarto digito 9 ou 8   -> peso
			 */
			if (refer�ncia.Length < 4)
				throw new Exception("N�o foi poss�vel conferir se � de peso ou n�o para mercadoria '" + refer�ncia + "' pela flag.");

			if (refer�ncia.StartsWith("3") || refer�ncia.StartsWith("2"))
				return true;
			
			quartoDigito = refer�ncia.Substring(3,1);
			if ((quartoDigito == "9") || (quartoDigito == "8"))
				return true;

			return false;	
		}
		
		/// <summary>
		/// Verifica se j� existe o que queira adicionar no mysql. Caso sim, retorna o dataRow correspondente
		/// Caso n�o, cria-se um dataRow com as informa��es n�o-alter�veis (b�sicas). Neste caso, refer�ncia.
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
