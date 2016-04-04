using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
		/// <summary>
		/// Cria a tabela no mysql 'vinculomercadoriacomponentecusto'
		/// para isso, olha-se todas as mercadorias do cadmer
		/// e preenche.
		/// </summary>
		public class VinculoMercadoriaComponenteCusto
		{
			private DataTable cadmer;
			private DataTable tabelaNova;
            private DataTable tabelaMercadoriasNova;
			private List<DataRow> vinculosCadastrados; 

			public VinculoMercadoriaComponenteCusto(DataSet dataSetVelho, DataSet dataSetNovo)
			{
                tabelaNova = dataSetNovo.Tables["vinculomercadoriacomponentecusto"];
                cadmer = dataSetVelho.Tables["cadmer"];
                tabelaMercadoriasNova = dataSetNovo.Tables["mercadoria"];
			}

            public void Transpor(StringBuilder sa�da)
            {
                string originalStringComponenteCusto;
                string refer�ncia;

                // Apaga vinculos antigos
                IDbConnection conex�o = Acesso.Comum.Usu�rios.Usu�rioAtual.Conex�o;

                Acesso.Comum.Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                IDbCommand cmd = conex�o.CreateCommand();
                cmd.CommandText = "delete from vinculomercadoriacomponentecusto";
                cmd.ExecuteNonQuery();

                foreach (DataRow itemAtual in cadmer.Rows)
                {
                    originalStringComponenteCusto = itemAtual["CM_CCUSTO"].ToString().Trim();
                    refer�ncia = itemAtual["CM_CODMER"].ToString().Trim();
                    
                    try
                    {
                        InserirVinculosComponenteCusto(originalStringComponenteCusto, refer�ncia, sa�da);
                    }
                    catch (Exception e)
                    {
                        sa�da.AppendLine("VinculoMercadoriaComponenteDeCusto: N�o foi poss�vel adicionar vinculo para refer�ncia: '" + refer�ncia + "'. Mais informa��es: " + e.Message);
                    }
                }

                Acesso.Comum.Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
            }

			/// <summary>
			/// Grava no data set dsNovo os vinculos
			/// </summary>
			/// <param name="originalString">m�ltiplo de 6 caracteres 00xxxx sendo 00 qtd, xxxx quantidade</param>
			/// <param name="refer�ncia">referencia a que se refere o componente de custo</param>
			private void InserirVinculosComponenteCusto(string originalString, string refer�ncia, StringBuilder saida)
			{
				string cc; 
				double qtd;

                // para cada refer�ncia existe uma lista de v�nculos.
				vinculosCadastrados = new List<DataRow>();
				
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
					catch
					{
						throw new Exception("N�o foi poss�vel transformar qtd para inteiro na string original. qtd = '" + originalString.Substring(2,4) + "'. string original de componentedecusto: " + originalString);
					}

					if ((cc != "00") && (qtd != 0) && (cc != "99") && (cc != "98"))
						InserirVinculoComponenteCusto(refer�ncia, (qtd/100), cc);

					originalString = originalString.Substring(6, originalString.Length-6);
				}
			}
		
			/// <summary>
			/// Verifica se o �tem j� existe ou n�o. Caso j� exista, deve-se apenas adicionar a quantidade. 
            /// Caso contr�rio, deve-se incluir novo elemento na tabela;
			/// </summary>
			/// <param name="refer�ncia"></param>
			/// <param name="quantidade"></param>
			/// <param name="data"></param>
			/// <param name="componenteCusto"></param>
			private void InserirVinculoComponenteCusto(string refer�ncia, double quantidade, string componenteCusto)
			{
				DataRow novoItem;

				foreach (DataRow itemAtual in vinculosCadastrados)
				{
#if DEBUG
					if (itemAtual["mercadoria"].ToString() != refer�ncia)
						throw new Exception("o ArrayList vinculosCadastrados s� pode ter mercadorias de mesma referencia.");
#endif       
					if (itemAtual["componentecusto"].ToString() == componenteCusto)
					{
						//deve-se usar o mesmo item.
						itemAtual["quantidade"] = Double.Parse(itemAtual["quantidade"].ToString()) + quantidade;
						return;
					}
				}

                if (ExisteReferenciaNoNovo(refer�ncia))
                {
                    novoItem = tabelaNova.NewRow();
                    novoItem["mercadoria"] = refer�ncia;
                    novoItem["componentecusto"] = componenteCusto;
                    novoItem["quantidade"] = quantidade;


                    tabelaNova.Rows.Add(novoItem);
                    vinculosCadastrados.Add(novoItem);
                }
			}

            private bool ExisteReferenciaNoNovo(string refef�ncia)
            {
                foreach (DataRow itemAtual in tabelaMercadoriasNova.Rows)
                {
                    if (itemAtual["referencia"].ToString().CompareTo(refef�ncia) == 0)
                        return true;
                }

                return false;
            }
		}
	}
