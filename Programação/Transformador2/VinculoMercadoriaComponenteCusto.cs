using System;
using System.Data;
using System.Collections;

namespace Transformador2
{
	/// <summary>
	/// Cria a tabela no mysql 'vinculomercadoriacomponentecusto'
	/// para isso, olha-se todas as mercadorias do cadmer
	/// e preenche.
	/// </summary>
	public class VinculoMercadoriaComponenteCusto
	{
		private Acesso.Dbf		dbf;
		private Acesso.MySql	mysql;
		private ArrayList		vinculosCadastrados; 
		//tipo: DataRow. � usado em InserirVinculoComponenteCusto(). Deve-se ter gravado porque v�rias entradas na string 'CM_CCUSTO' se referem ao mesmo v�nculo.
		
		public VinculoMercadoriaComponenteCusto(Acesso.Dbf meuDbf, Acesso.MySql meuMySql)
		{
			dbf = meuDbf;
			mysql = meuMySql;
			mysql.ComandoString("delete from vinculomercadoriacomponentecusto");
			mysql.AdicionarTabelaAoDataSet("vinculomercadoriacomponentecusto");
		}

		public void Transpor()
		{
			string originalStringComponenteCusto;
			string refer�ncia;

			foreach(DataRow itemAtual in dbf.ds.Tables["cadmer"].Rows)
			{
				originalStringComponenteCusto = itemAtual["CM_CCUSTO"].ToString().Trim();
				refer�ncia = itemAtual["CM_CODMER"].ToString().Trim();

				try
				{
					InserirVinculosComponenteCusto(originalStringComponenteCusto, refer�ncia);
				} 
				catch (Exception e)
				{
					System.Windows.Forms.MessageBox.Show("N�o foi poss�vel adicionar vinculo para refer�ncia: '" + refer�ncia + "'. Mais informa��es: " + e.Message);
				}
			}
			mysql.GravarDataSet("vinculomercadoriacomponentecusto");
		}

		/// <summary>
		/// Grava no data set mysql.ds os vinculos
		/// </summary>
		/// <param name="originalString">m�ltiplo de 6 caracteres 00xxxx sendo 00 qtd, xxxx quantidade</param>
		/// <param name="refer�ncia">referencia a que se refere o componente de custo</param>
		private void InserirVinculosComponenteCusto(string originalString, string refer�ncia)
		{
			string cc; 
			double qtd;
			
            vinculosCadastrados = new ArrayList(); // para cada refer�ncia existe uma lista de v�nculos.
			originalString = originalString.Replace(" ","0");

			if (( originalString.Length % 6 ) != 0 )   
				throw new Exception("Erro no componente de custo: '" + originalString + "', porque o n�mero de caracteres (" + originalString.Length + ") n�o � m�ltiplo de 6. E deveria ser, porque s�o 2 de codigo e 4 de quantidade. total: 6 observe: '" + originalString + "'");

			while (originalString.Length > 0) 
			{
				cc = originalString.Substring(0,2);
				try
				{
					qtd = Double.Parse(originalString.Substring(2,4));

				} 
				catch (Exception e)
				{
					throw new Exception("N�o foi poss�vel transformar qtd para inteiro na string original. qtd = '" + originalString.Substring(2,4) + "'. string original de componentedecusto: " + originalString);
				}

				if ((cc != "00") && (qtd != 0) && (cc != "99") && (cc != "98"))
				{
					InserirVinculoComponenteCusto(refer�ncia, (qtd/100), DateTime.Now, cc);
				}
				originalString = originalString.Substring(6, originalString.Length-6);
				//MessageBox.Show(" Resto:" + originalString);
			}
		}
		
		/// <summary>
		/// Verifica se o �tem j� existe ou n�o. Caso j� exista, deve-se apenas adicionar a quantidade. Caso contr�rio, deve-se incluir novo elemento na tabela;
		/// </summary>
		/// <param name="refer�ncia"></param>
		/// <param name="quantidade"></param>
		/// <param name="data"></param>
		/// <param name="componenteCusto"></param>
		private void InserirVinculoComponenteCusto(string refer�ncia, double quantidade, DateTime data, string componenteCusto)
		{
			DataRow novoItem;

			foreach (DataRow itemAtual in vinculosCadastrados)
			{
				if (itemAtual["mercadoria"].ToString() != refer�ncia)
					throw new Exception("Erro de programa��o mesmo: o ArrayList vinculosCadastrados s� pode ter mercadorias de mesma referencia.");
                
				if (itemAtual["componentecusto"].ToString() == componenteCusto)
				{
					//deve-se usar o mesmo item.
					itemAtual["quantidade"] = Double.Parse(itemAtual["quantidade"].ToString()) + quantidade;
					return;
				}
			}

			novoItem = mysql.ds.Tables["vinculomercadoriacomponentecusto"].NewRow();
			novoItem["mercadoria"]			= refer�ncia;
			novoItem["componentecusto"]		= componenteCusto;
			novoItem["quantidade"]			= quantidade;
			novoItem["data"]				= data;
			
			mysql.ds.Tables["vinculomercadoriacomponentecusto"].Rows.Add(novoItem);
			vinculosCadastrados.Add(novoItem);
		}
	}
}
