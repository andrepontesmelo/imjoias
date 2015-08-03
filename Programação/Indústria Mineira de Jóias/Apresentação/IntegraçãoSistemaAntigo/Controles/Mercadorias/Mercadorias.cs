using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
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
		private DataTable   tabelaVelha;
		private DataTable	tabelaNova;
		private Dbf	dbf;
		//private BaseMercadorias.ReportarInconsistenciaDelegate ReportarErro;
        
        /// <summary>
        /// Relaciona uma refer�ncia com o �ndice em tabelaNova.Rows
        /// </summary>
        private Dictionary<string, int> hashRefer�nciaIndiceNovo;

        private void CriarHash()
        {
            DataRowCollection itens = tabelaNova.Rows;

            hashRefer�nciaIndiceNovo = new Dictionary<string, int>(itens.Count, StringComparer.Ordinal);

            for (int pos = 0; pos < itens.Count; pos++)
                hashRefer�nciaIndiceNovo.Add(itens[pos]["referencia"].ToString(), pos);
        }
		
		public Mercadorias(DataSet dataSetVelho, DataSet dataSetNovo, Dbf dbfOrigem)
		{
            tabelaNova = dataSetNovo.Tables["mercadoria"];
			tabelaVelha = dataSetVelho.Tables["cadmer"];
			dbf = dbfOrigem;
//			ReportarErro = ReportarErroFun��o;

            //if (tabelaNova.Rows.Count == 0)
            //{
            //    IDbConnection conex�o = Acesso.Comum.Usu�rios.Usu�rioAtual.GerenciadorConex�es.ObterConex�o();

            //    lock (conex�o)
            //    {
            //        using (DbDataAdapter adaptador = Acesso.Comum.Usu�rios.Usu�rioAtual.CriarAdaptadorDados(
            //            conex�o,
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
            string refer�nciaAntiga = itemAtual["CM_CODMER"].ToString().Trim();
            //bool excluir = false;

			//item = ObterItemNovoEquivalalenteAoAntigoValor(itemAtual);
            int posi��o;
            if (hashRefer�nciaIndiceNovo.TryGetValue(refer�nciaAntiga, out posi��o))
            {
                item = new ItemMercadoria(tabelaNova.Rows[posi��o], false);
            }
            else
            {
                DataRow novoRow = tabelaNova.NewRow();
                novoRow["referencia"] = refer�nciaAntiga;
                
                item = new ItemMercadoria(novoRow, true);
                hashRefer�nciaIndiceNovo.Add(refer�nciaAntiga, tabelaNova.Rows.Count - 1);
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
                string msgErr = "Mercadorias: faixa '" + novoItem["faixa"] + "' n�o existe.";
                msgErr += item.Novo ? " Esta ref. � nova no DB. e nao ser� inserida. " : " Esta ref. j� existia no BD e n�o ser� alterada.";
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
                if (Conferir�DePeso(novoItem["referencia"].ToString(), itemAtual["CM_CCUSTO"].ToString().Trim()))
                {
                    novoItem["depeso"] = true;
                    novoItem["grupo"] = itemAtual["CM_GRUPO"]; //Grupo s� faz sentido para merc. de peso.
                }
                else
                {
                    novoItem["depeso"] = false;
                    novoItem["grupo"] = DBNull.Value;
                }
            }
            catch (Exception)
            {
                //ReportarErro("Mercadorias: Erro no conferir se � de peso. Exclu�da! " + e.Message);
                //novoItem["depeso"] = false;
                if (!item.Novo) novoItem.RejectChanges();
                return;
            }

            if (item.Novo)
                tabelaNova.Rows.Add(item.DataRow);

		}


        private static Dictionary<string, string> hashCorre��o;
        private static Dictionary<string, bool> stopWord;
        

        private static string CorrigirNome(string original)
        {
            if (hashCorre��o == null)
            {
                hashCorre��o = new Dictionary<string, string>(StringComparer.Ordinal);
                stopWord = new Dictionary<string, bool>(StringComparer.Ordinal);
                hashCorre��o.Add("alianca", "alian�a");
                hashCorre��o.Add("perola", "p�rola");
                hashCorre��o.Add("perolas", "p�rolas");
                hashCorre��o.Add("conserto", "consertos");
                hashCorre��o.Add("conseto", "consertos");
                //hashCorre��o.Add("1", " uma ");
                //hashCorre��o.Add("brilhs.", "brilhantes");
                //hashCorre��o.Add("c/", " com ");

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

                if (hashCorre��o.TryGetValue(palavraAtual, out melhorPalavra))
                    nomeFinal = nomeFinal.Replace(palavraAtual, melhorPalavra);
            }

            nomeFinal = nomeFinal.Replace("alian�a ouro", "alian�a de ouro");

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

            //Apresenta��o.Formul�rios.Aguarde aguarde = new Apresenta��o.Formul�rios.Aguarde("", dsVelho.Tables["cadmer"].Rows.Count, "Transpondo Mercadorias", "As mercadorias do novo banco de dados est�o sendo atualizadas com o dbf.");
            //aguarde.Abrir();

            foreach (DataRow itemAtual in tabelaVelha.Rows)
            {
                TransporItem(itemAtual);
                //aguarde.Passo(itemAtual["cm_nome"].ToString() + "  " + itemAtual["cm_codmer"].ToString());
            }

            //aguarde.Fechar();
		}

		private static bool Conferir�DePeso(String refer�ncia, String componenteCusto)
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

            //if (refer�ncia == "21400140009")
            //{
            //    bool asd = true;
            //}

			/*
							 * primeiro digito 3 ou 2 -> peso
							 * quarto digito 9 ou 8   -> peso
							 */
		
			if (refer�ncia.Length < 4)
				throw new Exception("N�o foi poss�vel conferir se � de peso ou n�o para mercadoria '" + refer�ncia + "' pela flag.");

			return Entidades.Mercadoria.Mercadoria.ConferirSe�DePeso(refer�ncia);
		}
	}
}
