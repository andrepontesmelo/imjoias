using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles.Mercadorias
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
		private DataTable   tabelaVelha;
		private DataTable	tabelaNova;
		private Dbf	dbf;
		//private BaseMercadorias.ReportarInconsistenciaDelegate ReportarErro;
        
        /// <summary>
        /// Relaciona uma referência com o índice em tabelaNova.Rows
        /// </summary>
        private Dictionary<string, int> hashReferênciaIndiceNovo;

        private void CriarHash()
        {
            DataRowCollection itens = tabelaNova.Rows;

            hashReferênciaIndiceNovo = new Dictionary<string, int>(itens.Count, StringComparer.Ordinal);

            for (int pos = 0; pos < itens.Count; pos++)
                hashReferênciaIndiceNovo.Add(itens[pos]["referencia"].ToString(), pos);
        }
		
		public Mercadorias(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            tabelaNova = dataSetNovo.Tables["mercadoria"];
			tabelaVelha = dataSetVelho.Tables["cadmer"];
			dbf = dbfOrigem;
//			ReportarErro = ReportarErroFunção;

            //if (tabelaNova.Rows.Count == 0)
            //{
            //    IDbConnection conexão = Acesso.Comum.Usuários.UsuárioAtual.GerenciadorConexões.ObterConexão();

            //    lock (conexão)
            //    {
            //        using (DbDataAdapter adaptador = Acesso.Comum.Usuários.UsuárioAtual.CriarAdaptadorDados(
            //            conexão,
            //            "SELECT * FROM mercadoria"))
            //        {
            //            adaptador.Fill(tabelaNova);
            //        }
            //    }
            //}

            foreach (DataRow linha in tabelaNova.Rows)
                linha["foradelinha"] = true;
		}
		
		private void TransporItem(DataRow itemAtual)
		{
			ItemMercadoria item;
			DataRow novoItem;
            string referênciaAntiga = itemAtual["CM_CODMER"].ToString().Trim();
            //bool excluir = false;

			//item = ObterItemNovoEquivalalenteAoAntigoValor(itemAtual);
            int posição;
            if (hashReferênciaIndiceNovo.TryGetValue(referênciaAntiga, out posição))
            {
                item = new ItemMercadoria(tabelaNova.Rows[posição], false);
            }
            else
            {
                DataRow novoRow = tabelaNova.NewRow();
                novoRow["referencia"] = referênciaAntiga;
                
                item = new ItemMercadoria(novoRow, true);
                hashReferênciaIndiceNovo.Add(referênciaAntiga, tabelaNova.Rows.Count - 1);
            }
			
			novoItem = item.DataRow;
            novoItem["nome"] = CorrigirNome(itemAtual["CM_NOME"].ToString());
            novoItem["teor"] = itemAtual["CM_TEOR"];
            novoItem["peso"] = itemAtual["CM_PESO"];
            novoItem["faixa"] = itemAtual["CM_FAIXA"];
            novoItem["digito"] = itemAtual["CM_DIGMER"];
            //novoItem["coeficienteatacado"] = DBNull.Value;
            //novoItem["coeficienteautoatacado"] = DBNull.Value;

            if (!Faixas.ExiteFaixa(novoItem["faixa"].ToString()))
            {
                string msgErr = "Mercadorias: faixa '" + novoItem["faixa"] + "' não existe.";
                msgErr += item.Novo ? " Esta ref. é nova no DB. e nao será inserida. " : " Esta ref. já existia no BD e não será alterada.";
                //ReportarErro(msgErr);

                if (!item.Novo) novoItem.RejectChanges();
                return;
            }

            if (itemAtual["CM_LINHA"].ToString().CompareTo("S") == 0)
                novoItem["foradelinha"] = false;
            else
                novoItem["foradelinha"] = true;

            try
            {
                if (ConferirÉDePeso(novoItem["referencia"].ToString(), itemAtual["CM_CCUSTO"].ToString().Trim()))
                {
                    novoItem["depeso"] = true;
                    novoItem["grupo"] = itemAtual["CM_GRUPO"]; //Grupo só faz sentido para merc. de peso.
                }
                else
                {
                    novoItem["depeso"] = false;
                    novoItem["grupo"] = DBNull.Value;
                }
            }
            catch (Exception)
            {
                //ReportarErro("Mercadorias: Erro no conferir se é de peso. Excluída! " + e.Message);
                //novoItem["depeso"] = false;
                if (!item.Novo) novoItem.RejectChanges();
                return;
            }

            if (item.Novo)
                tabelaNova.Rows.Add(item.DataRow);

		}


        private static Dictionary<string, string> hashCorreção;
        private static Dictionary<string, bool> stopWord;
        

        private static string CorrigirNome(string original)
        {
            if (hashCorreção == null)
            {
                hashCorreção = new Dictionary<string, string>(StringComparer.Ordinal);
                stopWord = new Dictionary<string, bool>(StringComparer.Ordinal);
                hashCorreção.Add("alianca", "aliança");
                hashCorreção.Add("perola", "pérola");
                hashCorreção.Add("perolas", "pérolas");
                hashCorreção.Add("conserto", "consertos");
                hashCorreção.Add("conseto", "consertos");
                //hashCorreção.Add("1", " uma ");
                //hashCorreção.Add("brilhs.", "brilhantes");
                //hashCorreção.Add("c/", " com ");

                stopWord["e"] = true;
                stopWord["de"] = true;
                stopWord["do"] = true;
                stopWord["da"] = true;
                stopWord["dos"] = true;
                stopWord["das"] = true;
                stopWord["em"] = true;
                stopWord["com"] = true;
                stopWord["uma"] = true;
            }

            string nomeFinal = original.ToLower().Trim();


            if (nomeFinal.Length == 0)
                return "";

            nomeFinal = nomeFinal.Replace("c/", " com ");
            nomeFinal = nomeFinal.Replace("brilhs.", " brilhantes ");
            nomeFinal = nomeFinal.Replace("esm", " esmeraldas ");

            string [] palavras = nomeFinal.Split(' ');
            foreach (string palavraAtual in palavras)
            {
                string melhorPalavra;

                if (hashCorreção.TryGetValue(palavraAtual, out melhorPalavra))
                    nomeFinal = nomeFinal.Replace(palavraAtual, melhorPalavra);
            }

            nomeFinal = nomeFinal.Replace("aliança ouro", "aliança de ouro");

            string textoTodo = nomeFinal;
            string textoArrumado = "";

            textoTodo = textoTodo.Trim();
            textoTodo = (textoTodo.Substring(0, 1)).ToUpper() + textoTodo.Substring(1, textoTodo.Length - 1).ToLower();

            while ((textoTodo.IndexOf("( ") >= 0) || (textoTodo.IndexOf(" )") >= 0))
            {
                textoTodo = textoTodo.Replace("( ", "("); // ( andre ) -> (andre)
                textoTodo = textoTodo.Replace(" )", ")");
            }
            palavras = textoTodo.Split(' ');

            for (int x = 0; x < palavras.Length; x++)
            {

                //if ((palavras[x].Length > 3) || (palavras[x].Substring(palavras[x].Length  -1,1) == ".")) 
                palavras[x] = palavras[x].Trim();

                if (palavras[x].Length != 0)
                {
                    if (x != 0)
                        textoArrumado += " ";


                    if (stopWord.ContainsKey(palavras[x].ToLower()))
                        textoArrumado += palavras[x].ToLower();
                    else if (palavras[x].StartsWith("(") && (palavras[x].Length > 1))
                    {
                        textoArrumado += palavras[x].Substring(0, 2).ToUpper();
                        textoArrumado += palavras[x].Substring(2, palavras[x].Length - 2).ToLower();
                    }
                    else
                        textoArrumado += palavras[x].Substring(0, 1).ToUpper() + palavras[x].Substring(1, palavras[x].Length - 1).ToLower();

                }
            }

            return textoArrumado;
        }
		
		public void Transpor()
		{
            CriarHash();

            //Apresentação.Formulários.Aguarde aguarde = new Apresentação.Formulários.Aguarde("", dsVelho.Tables["cadmer"].Rows.Count, "Transpondo Mercadorias", "As mercadorias do novo banco de dados estão sendo atualizadas com o dbf.");
            //aguarde.Abrir();

            foreach (DataRow itemAtual in tabelaVelha.Rows)
            {
                TransporItem(itemAtual);
                //aguarde.Passo(itemAtual["cm_nome"].ToString() + "  " + itemAtual["cm_codmer"].ToString());
            }

            //aguarde.Fechar();
		}

		private static bool ConferirÉDePeso(String referência, String componenteCusto)
		{
            if (componenteCusto.StartsWith("0A")
                || componenteCusto.StartsWith("1A")
                || componenteCusto.StartsWith("2A")
                || componenteCusto.StartsWith("3A")
                || componenteCusto.StartsWith("4A")
                || componenteCusto.StartsWith("5A")
                || componenteCusto.StartsWith("6A")
                || componenteCusto.StartsWith("7A")
                || componenteCusto.StartsWith("8A")
                || componenteCusto.StartsWith("9A")
                || componenteCusto.StartsWith("19"))
                return false;

            //if (referência == "21400140009")
            //{
            //    bool asd = true;
            //}

			/*
							 * primeiro digito 3 ou 2 -> peso
							 * quarto digito 9 ou 8   -> peso
							 */
		
			if (referência.Length < 4)
				throw new Exception("Não foi possível conferir se é de peso ou não para mercadoria '" + referência + "' pela flag.");

			return Entidades.Mercadoria.Mercadoria.ConferirSeÉDePeso(referência);
		}
	}
}
