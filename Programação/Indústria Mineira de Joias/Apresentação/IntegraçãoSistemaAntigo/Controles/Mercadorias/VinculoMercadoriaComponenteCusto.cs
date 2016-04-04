using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
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

            public void Transpor(StringBuilder saída)
            {
                string originalStringComponenteCusto;
                string referência;

                // Apaga vinculos antigos
                IDbConnection conexão = Acesso.Comum.Usuários.UsuárioAtual.Conexão;

                Acesso.Comum.Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                IDbCommand cmd = conexão.CreateCommand();
                cmd.CommandText = "delete from vinculomercadoriacomponentecusto";
                cmd.ExecuteNonQuery();

                foreach (DataRow itemAtual in cadmer.Rows)
                {
                    originalStringComponenteCusto = itemAtual["CM_CCUSTO"].ToString().Trim();
                    referência = itemAtual["CM_CODMER"].ToString().Trim();
                    
                    try
                    {
                        InserirVinculosComponenteCusto(originalStringComponenteCusto, referência, saída);
                    }
                    catch (Exception e)
                    {
                        saída.AppendLine("VinculoMercadoriaComponenteDeCusto: Não foi possível adicionar vinculo para referência: '" + referência + "'. Mais informações: " + e.Message);
                    }
                }

                Acesso.Comum.Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
            }

			/// <summary>
			/// Grava no data set dsNovo os vinculos
			/// </summary>
			/// <param name="originalString">múltiplo de 6 caracteres 00xxxx sendo 00 qtd, xxxx quantidade</param>
			/// <param name="referência">referencia a que se refere o componente de custo</param>
			private void InserirVinculosComponenteCusto(string originalString, string referência, StringBuilder saida)
			{
				string cc; 
				double qtd;

                // para cada referência existe uma lista de vínculos.
				vinculosCadastrados = new List<DataRow>();
				
                originalString = originalString.Replace(" ","0");

				if (( originalString.Length % 6 ) != 0 )   
					throw new Exception("Erro no componente de custo: '" + originalString + "', porque o número de caracteres (" + originalString.Length + ") não é múltiplo de 6. E deveria ser, porque são 2 de codigo e 4 de quantidade. total: 6 observe: '" + originalString + "'");

				while (originalString.Length > 0) 
				{
					cc = originalString.Substring(0,2);
					try
					{
						qtd = Double.Parse(originalString.Substring(2,4));

					} 
					catch
					{
						throw new Exception("Não foi possível transformar qtd para inteiro na string original. qtd = '" + originalString.Substring(2,4) + "'. string original de componentedecusto: " + originalString);
					}

					if ((cc != "00") && (qtd != 0) && (cc != "99") && (cc != "98"))
						InserirVinculoComponenteCusto(referência, (qtd/100), cc);

					originalString = originalString.Substring(6, originalString.Length-6);
				}
			}
		
			/// <summary>
			/// Verifica se o ítem já existe ou não. Caso já exista, deve-se apenas adicionar a quantidade. 
            /// Caso contrário, deve-se incluir novo elemento na tabela;
			/// </summary>
			/// <param name="referência"></param>
			/// <param name="quantidade"></param>
			/// <param name="data"></param>
			/// <param name="componenteCusto"></param>
			private void InserirVinculoComponenteCusto(string referência, double quantidade, string componenteCusto)
			{
				DataRow novoItem;

				foreach (DataRow itemAtual in vinculosCadastrados)
				{
#if DEBUG
					if (itemAtual["mercadoria"].ToString() != referência)
						throw new Exception("o ArrayList vinculosCadastrados só pode ter mercadorias de mesma referencia.");
#endif       
					if (itemAtual["componentecusto"].ToString() == componenteCusto)
					{
						//deve-se usar o mesmo item.
						itemAtual["quantidade"] = Double.Parse(itemAtual["quantidade"].ToString()) + quantidade;
						return;
					}
				}

                if (ExisteReferenciaNoNovo(referência))
                {
                    novoItem = tabelaNova.NewRow();
                    novoItem["mercadoria"] = referência;
                    novoItem["componentecusto"] = componenteCusto;
                    novoItem["quantidade"] = quantidade;


                    tabelaNova.Rows.Add(novoItem);
                    vinculosCadastrados.Add(novoItem);
                }
			}

            private bool ExisteReferenciaNoNovo(string refefência)
            {
                foreach (DataRow itemAtual in tabelaMercadoriasNova.Rows)
                {
                    if (itemAtual["referencia"].ToString().CompareTo(refefência) == 0)
                        return true;
                }

                return false;
            }
		}
	}
