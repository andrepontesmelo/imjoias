using Apresenta��o.Formul�rios;
using Entidades;
using Entidades.Financeiro;
using Entidades.Moedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Apresenta��o.Integra��oSistemaAntigo.Fiscal
{
    public partial class BaseFiscal : BaseInferior
    {
        private static double cota��o;
        private static string nomeArquivoPrincipal;
        private static string nomeArquivoEAN;
        private static DataSet ds = new DataSet();

        public BaseFiscal()
        {
            InitializeComponent();
        }

        public static void ExportarAtacadoBR500()
        {
            string datayyyymmdd = DateTime.Now.Date.ToString("yyyyMMdd");

            // Solicita nome do arquivo
            using (SaveFileDialog dlgGrava = new SaveFileDialog())
            {
                dlgGrava.Title = "Escolha onde gravar o arquivo principal (CAD1A025.TXT)";

                dlgGrava.FileName = @"CAD1A025.TXT";
                dlgGrava.OverwritePrompt = false;
                dlgGrava.DefaultExt = "TXT";
                if (dlgGrava.ShowDialog() == DialogResult.OK)
                {
                    nomeArquivoPrincipal = dlgGrava.FileName;
                }
                else
                    return;

                dlgGrava.Dispose();
            }

            // Solicita nome do arquivo
            using (System.Windows.Forms.SaveFileDialog dlgGrava = new SaveFileDialog())
            {
                //dlgGrava.InitialDirectory = nomeArquivoPrincipal;
                dlgGrava.Title = "Escolha onde gravar o arquivo secund�rio, de c�digo de barras EAN(CAD1A090.TXT)";
                dlgGrava.FileName = @"CAD1A090.TXT";
                dlgGrava.OverwritePrompt = false;
                dlgGrava.DefaultExt = "TXT";
                if (dlgGrava.ShowDialog() == DialogResult.OK)
                {
                    nomeArquivoEAN = dlgGrava.FileName;
                }
                else
                    return;

                dlgGrava.Dispose();
            }


            // Obtem a cota��o de varejo
            cota��o = Cota��o.ObterCota��oVigente(Moeda.ObterMoeda(4)).Valor;

            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            // Abre banco de dados
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conex�esRemovidas);

            Aguarde janela = new Aguarde("Gerando entrada para impressora fiscal", ds.Tables["mercadoria"].Rows.Count);
            janela.Abrir();
            using (StreamWriter arquivoPrincipal = new StreamWriter(nomeArquivoPrincipal))
            {
                using (StreamWriter arquivoEAN = new StreamWriter(nomeArquivoEAN))
                {
                    foreach (DataRow m in ds.Tables["mercadoria"].Rows)
                    {
                        janela.Passo();
                        string referencia = (string)m["referencia"];
                        bool foraDeLinha = ((byte)m["foradelinha"]) != 0;

                        if (referencia.Length >= 10 && !foraDeLinha)
                        {
                            arquivoPrincipal.Write("0");
                            string referenciaCortada = Cortar(referencia.Remove(1, 1), 10, '0', false);
                            // Arquivo EAN

                            // Opera��o: Inclus�o
                            arquivoEAN.Write("0");

                            // Referencia da empresa, total 13 posicoes
                            arquivoEAN.Write(Cortar(referencia, 13, '0', false));

                            // Digito
                            arquivoEAN.Write(Cortar(m["digito"].ToString(), 1));

                            // C�digo reduzido
                            arquivoEAN.Write(referenciaCortada);

                            // Quantidade de unidades p/ EAN - total 7
                            string qtdEan = new String('0', 6) + "1";
                            arquivoEAN.Write(qtdEan);

                            // Uso espec�fico
                            arquivoEAN.Write(new String('0', 10));

                            // Uso Espec�fico
                            arquivoEAN.Write(new String(' ', 2));

                            // Divide pre�o pela EAN-QTD
                            arquivoEAN.Write("0");

                            // Para uso futuro
                            //arquivoEAN.Write(new String(' ', 23));
                            arquivoEAN.WriteLine();

                            // Arquivo Principal

                            arquivoPrincipal.Write(referenciaCortada);

                            // Se��o grupo subgrupo
                            arquivoPrincipal.Write("000100010001");

                            //Descri��o - 40
                            string descri��o = (string)m["nome"];

                            // Retirar os acentos
                            descri��o = Acentua��o.Singleton.TirarAcentos(descri��o);

                            arquivoPrincipal.Write(Cortar(descri��o, 40));

                            // Descri��o - 20 
                            arquivoPrincipal.Write(Cortar(descri��o, 20));

                            // Tipo de embalagem fornecedor
                            arquivoPrincipal.Write("UN");

                            // Qtd embalagem fornecedor
                            arquivoPrincipal.Write("0001");

                            // Tipo de embalagem de venda
                            arquivoPrincipal.Write("UN");

                            // Qtd embalagem venda
                            arquivoPrincipal.Write("0001");

                            // Peso vari�vel
                            bool dePeso = (byte)m["depeso"] != 0;
                            arquivoPrincipal.Write(dePeso ? "S" : "N");

                            // N�o emite etiqueta
                            arquivoPrincipal.Write("0");

                            // Tecla da balan�a 
                            arquivoPrincipal.Write("000");

                            // Validade do produto para balan�a
                            arquivoPrincipal.Write("000");

                            // Receita do produto para balan�a
                            arquivoPrincipal.Write(new String(' ', 100));

                            // % de IPI
                            arquivoPrincipal.Write(new String('0', 5));

                            // % bonifica��o
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor de despache acess�ria
                            arquivoPrincipal.Write(new String('0', 10));

                            // Valor de despache acess�ria tribut�ria
                            arquivoPrincipal.Write(new String('0', 10));

                            // % de frete cobrado
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor do ICM na fonte
                            arquivoPrincipal.Write(new String('0', 11));

                            // Valor do ICM na compra
                            arquivoPrincipal.Write(new String('0', 4));

                            // Data do c�lculo da sa�da m�dia ddmmaaaa
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor da sa�da m�dia
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o de custo do fornecedor
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o de custo do fornecedor anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Data pre�o custo fornecedor
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data pre�o custo fornecedor anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Pre�o de venda unit�rio 8,2-> "0000000000"
                            double pre�oVenda = ObterPre�o(referencia);
                            if (pre�oVenda <= 0)
                            {
                                //ReportarErro("Pre�o zero para refer�ncia " + referencia);
                            }
                            string pre�oVenda10Digitos = pre�oVenda.ToString("00000000.00").Replace(".", "").Replace(",", "");

                            if (pre�oVenda10Digitos.Length != 10)
                                MessageBox.Show("Erro, deveria ter 10 digitos");

                            arquivoPrincipal.Write(pre�oVenda10Digitos);

                            // Pre�o de venda 2 
                            arquivoPrincipal.Write(pre�oVenda10Digitos);

                            // Pre�o de venda anterior
                            arquivoPrincipal.Write(pre�oVenda10Digitos);

                            string pre�oVenda11Digitos = pre�oVenda.ToString("00000000.000").Replace(".", "").Replace(",", "");
                            if (pre�oVenda11Digitos.Length != 11)
                                MessageBox.Show("Erro: deveria ter 11 d�gitos");

                            // Pre�o de venda (Unit�rio)
                            arquivoPrincipal.Write(pre�oVenda11Digitos);

                            // Pre�o de venda 2
                            arquivoPrincipal.Write(pre�oVenda11Digitos);

                            // Pre�o de venda anterior
                            arquivoPrincipal.Write(pre�oVenda11Digitos);

                            // Data pre�o de venda
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data pre�o de venda anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // % margem de lucro
                            arquivoPrincipal.Write("00");

                            // % margem de lucro anterior
                            arquivoPrincipal.Write("00");

                            // Custo de reposi��o
                            arquivoPrincipal.Write(new String('0', 11));

                            // Custo de reposi��o anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o com margem zero
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o margem zero anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o oferta/promo��o
                            arquivoPrincipal.Write(new String('0', 10));

                            // Promo��o anterior
                            arquivoPrincipal.Write(new String('0', 10));

                            // Pre�o oferta/promo��o
                            arquivoPrincipal.Write(new String('0', 11));

                            // Pre�o oferta/promo��o anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Data do in�cio da oferta
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do fim da oferta
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do in�cio da oferta anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do fim da oferta anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // C�digo da natureza fiscal
                            arquivoPrincipal.Write("T18");

                            // Estado de origem
                            arquivoPrincipal.Write("MG");

                            // C�digo Associado
                            arquivoPrincipal.Write(new String('0', 10));

                            // Comiss�o praticada
                            arquivoPrincipal.Write(new String('0', 5));

                            // Estoque do produto no dep�sito
                            arquivoPrincipal.Write(new String('0', 10));

                            // Estoque do produto na loja
                            arquivoPrincipal.Write(new String('0', 10));

                            // Estoque m�nimo
                            arquivoPrincipal.Write(new String('0', 10));

                            // Barra a multiplica��o do produto no PDV
                            arquivoPrincipal.Write("0");

                            // Tipo de desconto
                            arquivoPrincipal.Write("0");

                            // % desconto m�ximo
                            arquivoPrincipal.Write(new String('0', 5));

                            // Venda fracionada
                            arquivoPrincipal.Write(dePeso ? "1" : "0");

                            // N�o tem dependencia
                            arquivoPrincipal.Write("0");

                            // T�tulo de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // 2o T�tulo de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // 3o T�tulo de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // Pode ser alterado
                            arquivoPrincipal.Write("1");

                            // Produto Cesta b�sica
                            arquivoPrincipal.Write("0");

                            // Se produto pertence a uma cesta
                            arquivoPrincipal.Write("0");

                            // Se produto � diferenciado de outros
                            arquivoPrincipal.Write("00"); // Normal

                            // Data da �ltima venda do produto
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write("0");

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write("00");

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write("0");

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write(new String(' ', 8));

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write(new String('0', 10));

                            // Modalidade hiperideal
                            arquivoPrincipal.Write("04");

                            // Pontua��o fidelidade
                            arquivoPrincipal.Write(new String('0', 7));

                            // Pontos extra fidelidade
                            arquivoPrincipal.Write(new String('0', 7));

                            // Peso a ser calculo em item unit�rio
                            arquivoPrincipal.Write(new String('0', 5));

                            // Flag de produto unit�rio vendido por peso
                            //sw.Write(dePeso ? "1" : "0");
                            arquivoPrincipal.Write("0");

                            // Quantidade m�xima a ser multiplaco no pdv
                            arquivoPrincipal.Write("000");

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write(new String(' ', 3));

                            // Qtd maxima a ser vendido
                            arquivoPrincipal.Write(new String('0', 5));

                            // Solicita senha do supervisor para venda
                            arquivoPrincipal.Write("0");

                            // Para uso futuro
                            //arquivoPrincipal.Write(new String(' ', 44));

                            arquivoPrincipal.WriteLine();
                        }
                    }
                }

                
                janela.Close();
                MessageBox.Show("Processo conclu�do.", "Exporta��o de arquivo fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void op��oIn�cio_Click(object sender, EventArgs e)
        {
            ExportarVEconnectVarejo();
        }

        /// <summary>
        /// Corta um texto colocando espa�os e preenchendo a direita.
        /// </summary>
        private static string Cortar(String texto, int quantidade)
        {
            return Cortar(texto, quantidade, true);
        }


        private static string Cortar(String texto, int quantidade, bool preencher�Direita)
        {
            return Cortar(texto, quantidade, ' ', preencher�Direita);
        }

        /// <summary>
        /// Corta um texto para ter 'quantidade' caracteres.
        /// Se tiver menos, coloca o caractere completude a esquerda
        /// se tiver mais, corta a direita
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="quantidade"></param>
        /// <param name="caractereCompletude"></param>
        /// <returns></returns>
        private static string Cortar(String texto, int quantidade, char caractereCompletude, bool preencher�Direita)
        {
            if (texto.Length > quantidade)
            {
                return texto.Substring(0, quantidade);
            }
            else
            {
                if (preencher�Direita)
                    return texto + new String(caractereCompletude, quantidade - texto.Length);
                else
                    return new String(caractereCompletude, quantidade - texto.Length) + texto;
            }
        }


        private static Dictionary<string, double> hashRefer�nciaPre�o = null;

        /// <summary>
        /// Retorna o pre�o em real de uma grama da mercadoria
        /// </summary>
        private static double ObterPre�o(string refer�ncia)
        {
            if (hashRefer�nciaPre�o == null)
            {
                // Construir a hash
                hashRefer�nciaPre�o = new Dictionary<string, double>(StringComparer.Ordinal);
                foreach (DataRow item in ds.Tables["tabelamercadoria"].Rows)
                {
                    if (((uint)item["tabela"]) == 1)
                        hashRefer�nciaPre�o.Add((string) item["mercadoria"], Math.Round((double)item["coeficiente"] * cota��o, 2));
                }
            }

            if (hashRefer�nciaPre�o.ContainsKey(refer�ncia))
            {
                return hashRefer�nciaPre�o[refer�ncia];
            }
            else
            {
//                ReportarErro("N�o achei pre�o para refer�ncia: " + refer�ncia + ", utilizando valor R$ 0,00");
                return 0;
            }
        }

        void ReportarErro(string erro)
        {
            quadroErros.Visible = true;
            txtErros.Text += erro + "\r\n";
        }

        /// <summary>
        /// Gera aquivos relacionados � impressora fiscal de varejo padr�o E-Connect.
        /// </summary>
        internal static void ExportarVEconnectVarejo()
        {
            // d:\
            string caminho;

            // Solicita nome do arquivo
            using (System.Windows.Forms.FolderBrowserDialog pasta = new FolderBrowserDialog())
            {
                if (pasta.ShowDialog() == DialogResult.OK)
                {
                    caminho = pasta.SelectedPath;
                }
                else
                    return;
            }

            // Abre banco de dados
            ds = new DataSet();
            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conex�esRemovidas);

            GeraArquivoProduto(Path.Combine(caminho, "PRODUTO"));
            GeraArquivoEAN(Path.Combine(caminho, "EAN"));
            GeraArquivoSecao(Path.Combine(caminho, "SECOES"));
            GeraArquivoPreco(Path.Combine(caminho, "NIVEL_PR"));

            MySQL.AdicionarConex�esRemovidas(conex�esRemovidas);
            MessageBox.Show("Exporta��o", "Conclu�do", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer", caminho);
        }

        /// <summary>
        /// 41|000024|2010-03-11 10:41:43|      2.05|2010-09-17 10:41:43|
        /// </summary>
        private static void GeraArquivoPreco(string caminhoCompletoPreco)
        {
            Aguarde aguarde = new Aguarde("Consultando pre�os", ds.Tables["mercadoria"].Rows.Count);

            aguarde.Show();

            using (StreamWriter strPreco = new StreamWriter(caminhoCompletoPreco))
            {
                foreach (DataRow m in ds.Tables["mercadoria"].Rows)
                {
                    aguarde.Passo();
                    string referencia = (string)m["referencia"];
                    bool foraDeLinha = ((byte)m["foradelinha"]) != 0;

                    if (foraDeLinha)
                        continue;

                    bool dePeso = ((byte)m["dePeso"]) != 0;
                    string descricao = (m["nome"] is DBNull ? "" : (string)m["nome"]);
                    double peso = (m["peso"] is DBNull ? 0 : (double)m["peso"]);

                    strPreco.Write("001|");
                    EscreveReferenciaComDigito(strPreco, referencia);
                    strPreco.Write("|");
                    strPreco.Write(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
                    strPreco.Write("|");

                    // Pre�o de venda
                    Entidades.Mercadoria.Mercadoria mercadoria;

                    if (Entidades.Mercadoria.Mercadoria.ConferirSe�DePeso(referencia))
                    {
                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia, 1,
                        Tabela.ObterPrimeiraTabela(Setor.ObterSetor(Setor.SetorSistema.Varejo)));
                    }
                    else
                    {
                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia,
                        Tabela.ObterPrimeiraTabela(Setor.ObterSetor(Setor.SetorSistema.Varejo)));
                    }


                    Pre�o pre�oMercadoria = mercadoria.CalcularPre�o(Cota��o.ObterCota��oVigente(Moeda.ObterMoeda(MoedaSistema.OuroVarejo)));
                    string pre�oStr = Math.Round(pre�oMercadoria.Valor, 2).ToString().Replace(',', '.').Trim();

                    //string pre�oStr = "99.99";

                    strPreco.Write(pre�oStr);
                    strPreco.Write("|");
                    strPreco.Write(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
                    strPreco.Write("|9999|");
                    strPreco.Write(pre�oStr);
                    strPreco.WriteLine("|");
                }
            }
            aguarde.Close();
        }

        /// <summary>
        /// 001|000|000||MATINAIS                 ||
        /// </summary>
        /// <param name="caminhoCompletoSecao"></param>
        private static void GeraArquivoSecao(string caminhoCompletoSecao)
        {
            using (StreamWriter strProduto = new StreamWriter(caminhoCompletoSecao))
            {
                strProduto.WriteLine("001|001|001|001|IMJOIAS| |0|0|0|");
            }
        }

        /// <summary>
        /// 0000000000024|000024|1.00|\N|0|2010-08-11 10:41:43|
        /// </summary>
        /// <param name="caminhoCompletoEAN"></param>
        private static void GeraArquivoEAN(string caminhoCompletoEAN)
        {
            using (StreamWriter strEAN = new StreamWriter(caminhoCompletoEAN))
            {
                foreach (DataRow m in ds.Tables["mercadoria"].Rows)
                {
                    string referencia = (string)m["referencia"];
                    bool foraDeLinha = ((byte)m["foradelinha"]) != 0;
                    bool dePeso = ((byte)m["dePeso"]) != 0;

                    if (foraDeLinha)
                        continue;

                    strEAN.Write(Cortar(ObtemReferenciaComDigito(referencia), 13, '0', false));
                    strEAN.Write("|");

                    EscreveReferenciaComDigito(strEAN, referencia);
                    strEAN.Write("|1.00|");

                    strEAN.Write(dePeso ? "Gr" : "PC");

                    strEAN.Write("|0|");
                    strEAN.Write(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
                    strEAN.WriteLine("|");
                }
            }
        }

        /// <summary>
        /// 000024|0|0|005|008|000|T07|FRANGO FRIAL MINEIRO KG|FRANGO FRIAL MINEIRO KG|UN|0|MG|55|0|0|0.00|0|0.00|0|0|0||2010-08-11 10:41:43|\N|\N|
        //  000031|0|0|005|008|000|T07|SOBRECOXA FRANGO PIF PAF KG|SOBRECOXA FRA.PIF PAF KG|UN|0|MG|55|0|0|0.00|0|0.00|0|0|0||2010-08-11 10:41:43|\N|\N|
        //  000062|0|0|005|008|000|F|SPETTIN AURORA KG|SPETTIN AURORA KG|UN|0|MG|55|0|0|0.00|0|0.00|0|0|0||2010-08-11 10:41:43|\N|\N|
        //  010306|0|0|005|008|000|T07|PEITO FRANGO REAL KG|PEITO FRANGO REAL KG|UN|0|MG|55|0|0|0.00|0|0.00|0|0|0||2010-08-11 10:41:43|\N|\N|
        //  019293|0|0|005|005|000|F|APRESUNTADO PIF PAF 3.8|APRESUNTADO PIF PAF 3.8|UN|0|MG|55|0|0|0.00|0|0.00|0|0|0||2010-08-11 10:41:43|\N|\N|
        /// </summary>
        /// <param name="caminhoCompletoProduto"></param>
        private static void GeraArquivoProduto(string caminhoCompletoProduto)
        {
            using (StreamWriter strProduto = new StreamWriter(caminhoCompletoProduto))
            {
                foreach (DataRow m in ds.Tables["mercadoria"].Rows)
                {
                    string referencia = (string)m["referencia"];
                    bool foraDeLinha = ((byte)m["foradelinha"]) != 0;

                    if (foraDeLinha)
                        continue;

                    bool dePeso = ((byte)m["dePeso"]) != 0;
                    string descricao = (m["nome"] is DBNull ? "" : (string)m["nome"]);
                    descricao = Entidades.Acentua��o.Singleton.TirarAcentos(descricao);

                    double peso = (m["peso"] is DBNull ? 0 : (double)m["peso"]);

                    // Verificar se vem com digito
                    EscreveReferenciaComDigito(strProduto, referencia);
                    strProduto.Write("|0|0|001|001|001|T18|");

                    // Descri��o completa
                    strProduto.Write(Cortar(descricao, 60, false).Trim());
                    strProduto.Write("|");

                    // Descri��o reduzida
                    strProduto.Write(Cortar(descricao, 20, false).Trim());
                    strProduto.Write("|");

                    // PC ou KG:
                    strProduto.Write(dePeso ? "GR|1" : "PC|0");
                    strProduto.Write("|MG|");

                    // Maxima quantidade
                    strProduto.Write(dePeso ? "100" : "1");
                    strProduto.Write("|");

                    // Fracionado
                    strProduto.Write(dePeso ? "1" : "0");
                    strProduto.Write("|0|");

                    // Peso padr�o
                    strProduto.Write((peso / 1000).ToString().Replace(',','.'));
                    strProduto.Write("|2|0|0|0|0||");

                    // Data atualiza��o
                    strProduto.Write(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
                    strProduto.Write("|\\N|\\N|");
                    strProduto.WriteLine();
                }
            }
        }

        private static void EscreveReferenciaComDigito(StreamWriter strProduto, string referencia)
        {
            strProduto.Write(ObtemReferenciaComDigito(referencia));
        }

        private static string ObtemReferenciaComDigito(string referencia)
        {
            int digito = Entidades.Mercadoria.Mercadoria.ObterD�gito(referencia);
            return referencia + digito.ToString();
        }
    }
}
