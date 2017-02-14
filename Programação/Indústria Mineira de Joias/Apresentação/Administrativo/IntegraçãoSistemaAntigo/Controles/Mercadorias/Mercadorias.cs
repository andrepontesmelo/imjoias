using Entidades.Mercadoria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
		}

        public void MarcarMercadoriasForaDeLinha()
        {
            foreach (DataRow linha in tabelaNova.Rows)
                linha["foradelinha"] = true;
        }
		
		private void TransporItem(DataRow itemAtual, DataSet dsNovo, StringBuilder saida)
		{
			ItemMercadoria item;
			DataRow novoItem;
            string referênciaAntiga = itemAtual["CM_CODMER"].ToString().Trim();

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
            novoItem["classificacaofiscal"] = itemAtual["CM_CLASFIS"];
            novoItem["tipounidade"] = ObterTipoUnidadeFiscal(itemAtual["CM_UNID"].ToString());

            if (!Faixas.ExiteFaixa(novoItem["faixa"].ToString(), dsNovo))
            {
                saida.Append("Mercadoria ");
                saida.Append(referênciaAntiga);
                saida.Append(" faixa '" + novoItem["faixa"] + "' não existe.");
                saida.AppendLine(item.Novo ? " Esta ref. existe no sistema legado e não existe neste sistema. Solução: Não será inserida. " : 
                    " Esta mercadoria existe em ambos sistemas, mas não terá atualizações propagadas para este sistema.");

                if (!item.Novo) novoItem.RejectChanges();
                return;
            }

            if (itemAtual["CM_LINHA"].ToString().CompareTo("S") == 0)
                novoItem["foradelinha"] = false;
            else
                novoItem["foradelinha"] = true;

            try
            {
                if (ConferirÉDePeso(itemAtual))
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
            catch (Exception e)
            {
                saida.AppendLine(e.Message);
                if (!item.Novo) novoItem.RejectChanges();
                return;
            }

            if (item.Novo)
                tabelaNova.Rows.Add(item.DataRow);

		}

        private int ObterTipoUnidadeFiscal(string nome)
        {
            return (int) Entidades.Fiscal.Tipo.TipoUnidadeInterpretação.Interpretar(nome);
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
            nomeFinal = nomeFinal.Replace("esm ", " esmeraldas ");
            nomeFinal = nomeFinal.Replace("esm. ", " esmeraldas ");

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
		
		public void Transpor(StringBuilder saída, bool matériasPrimas, DataSet dsNovo)
		{
            CriarHash();

            foreach (DataRow itemAtual in tabelaVelha.Rows)
            {
                if (matériasPrimas == MatériaPrima.ÉMatériaPrima(itemAtual["cm_codmer"].ToString()))
                    TransporItem(itemAtual, dsNovo, saída);
            }
		}

		public static bool ConferirÉDePeso(DataRow cadmerItem)
		{
            string referência = cadmerItem["cm_codmer"].ToString().Trim();

            return MercadoriaDePeso.Hash.Contains(referência);
        }
    }
}
