using Apresentação.Formulários;
using Entidades;
using Entidades.Financeiro;
using Entidades.Moedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Apresentação.IntegraçãoSistemaAntigo.Fiscal
{
    public partial class BaseFiscal : BaseInferior
    {
        private static double cotação;
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
                dlgGrava.Title = "Escolha onde gravar o arquivo secundário, de código de barras EAN(CAD1A090.TXT)";
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


            // Obtem a cotação de varejo
            cotação = Cotação.ObterCotaçãoVigente(Moeda.ObterMoeda(4)).Valor;

            List<IDbConnection> conexõesRemovidas = new List<IDbConnection>();
            // Abre banco de dados
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conexõesRemovidas);

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

                            // Operação: Inclusão
                            arquivoEAN.Write("0");

                            // Referencia da empresa, total 13 posicoes
                            arquivoEAN.Write(Cortar(referencia, 13, '0', false));

                            // Digito
                            arquivoEAN.Write(Cortar(m["digito"].ToString(), 1));

                            // Código reduzido
                            arquivoEAN.Write(referenciaCortada);

                            // Quantidade de unidades p/ EAN - total 7
                            string qtdEan = new String('0', 6) + "1";
                            arquivoEAN.Write(qtdEan);

                            // Uso específico
                            arquivoEAN.Write(new String('0', 10));

                            // Uso Específico
                            arquivoEAN.Write(new String(' ', 2));

                            // Divide preço pela EAN-QTD
                            arquivoEAN.Write("0");

                            // Para uso futuro
                            //arquivoEAN.Write(new String(' ', 23));
                            arquivoEAN.WriteLine();

                            // Arquivo Principal

                            arquivoPrincipal.Write(referenciaCortada);

                            // Seção grupo subgrupo
                            arquivoPrincipal.Write("000100010001");

                            //Descrição - 40
                            string descrição = (string)m["nome"];

                            // Retirar os acentos
                            descrição = Acentuação.Singleton.TirarAcentos(descrição);

                            arquivoPrincipal.Write(Cortar(descrição, 40));

                            // Descrição - 20 
                            arquivoPrincipal.Write(Cortar(descrição, 20));

                            // Tipo de embalagem fornecedor
                            arquivoPrincipal.Write("UN");

                            // Qtd embalagem fornecedor
                            arquivoPrincipal.Write("0001");

                            // Tipo de embalagem de venda
                            arquivoPrincipal.Write("UN");

                            // Qtd embalagem venda
                            arquivoPrincipal.Write("0001");

                            // Peso variável
                            bool dePeso = (byte)m["depeso"] != 0;
                            arquivoPrincipal.Write(dePeso ? "S" : "N");

                            // Não emite etiqueta
                            arquivoPrincipal.Write("0");

                            // Tecla da balança 
                            arquivoPrincipal.Write("000");

                            // Validade do produto para balança
                            arquivoPrincipal.Write("000");

                            // Receita do produto para balança
                            arquivoPrincipal.Write(new String(' ', 100));

                            // % de IPI
                            arquivoPrincipal.Write(new String('0', 5));

                            // % bonificação
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor de despache acessória
                            arquivoPrincipal.Write(new String('0', 10));

                            // Valor de despache acessória tributária
                            arquivoPrincipal.Write(new String('0', 10));

                            // % de frete cobrado
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor do ICM na fonte
                            arquivoPrincipal.Write(new String('0', 11));

                            // Valor do ICM na compra
                            arquivoPrincipal.Write(new String('0', 4));

                            // Data do cálculo da saída média ddmmaaaa
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Uso exclusivo do sistema
                            arquivoPrincipal.Write(new String('0', 5));

                            // Valor da saída média
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço de custo do fornecedor
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço de custo do fornecedor anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Data preço custo fornecedor
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data preço custo fornecedor anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Preço de venda unitário 8,2-> "0000000000"
                            double preçoVenda = ObterPreço(referencia);
                            if (preçoVenda <= 0)
                            {
                                //ReportarErro("Preço zero para referência " + referencia);
                            }
                            string preçoVenda10Digitos = preçoVenda.ToString("00000000.00").Replace(".", "").Replace(",", "");

                            if (preçoVenda10Digitos.Length != 10)
                                MessageBox.Show("Erro, deveria ter 10 digitos");

                            arquivoPrincipal.Write(preçoVenda10Digitos);

                            // Preço de venda 2 
                            arquivoPrincipal.Write(preçoVenda10Digitos);

                            // Preço de venda anterior
                            arquivoPrincipal.Write(preçoVenda10Digitos);

                            string preçoVenda11Digitos = preçoVenda.ToString("00000000.000").Replace(".", "").Replace(",", "");
                            if (preçoVenda11Digitos.Length != 11)
                                MessageBox.Show("Erro: deveria ter 11 dígitos");

                            // Preço de venda (Unitário)
                            arquivoPrincipal.Write(preçoVenda11Digitos);

                            // Preço de venda 2
                            arquivoPrincipal.Write(preçoVenda11Digitos);

                            // Preço de venda anterior
                            arquivoPrincipal.Write(preçoVenda11Digitos);

                            // Data preço de venda
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data preço de venda anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // % margem de lucro
                            arquivoPrincipal.Write("00");

                            // % margem de lucro anterior
                            arquivoPrincipal.Write("00");

                            // Custo de reposição
                            arquivoPrincipal.Write(new String('0', 11));

                            // Custo de reposição anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço com margem zero
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço margem zero anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço oferta/promoção
                            arquivoPrincipal.Write(new String('0', 10));

                            // Promoção anterior
                            arquivoPrincipal.Write(new String('0', 10));

                            // Preço oferta/promoção
                            arquivoPrincipal.Write(new String('0', 11));

                            // Preço oferta/promoção anterior
                            arquivoPrincipal.Write(new String('0', 11));

                            // Data do início da oferta
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do fim da oferta
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do início da oferta anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Data do fim da oferta anterior
                            arquivoPrincipal.Write(datayyyymmdd);

                            // Código da natureza fiscal
                            arquivoPrincipal.Write("T18");

                            // Estado de origem
                            arquivoPrincipal.Write("MG");

                            // Código Associado
                            arquivoPrincipal.Write(new String('0', 10));

                            // Comissão praticada
                            arquivoPrincipal.Write(new String('0', 5));

                            // Estoque do produto no depósito
                            arquivoPrincipal.Write(new String('0', 10));

                            // Estoque do produto na loja
                            arquivoPrincipal.Write(new String('0', 10));

                            // Estoque mínimo
                            arquivoPrincipal.Write(new String('0', 10));

                            // Barra a multiplicação do produto no PDV
                            arquivoPrincipal.Write("0");

                            // Tipo de desconto
                            arquivoPrincipal.Write("0");

                            // % desconto máximo
                            arquivoPrincipal.Write(new String('0', 5));

                            // Venda fracionada
                            arquivoPrincipal.Write(dePeso ? "1" : "0");

                            // Não tem dependencia
                            arquivoPrincipal.Write("0");

                            // Título de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // 2o Título de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // 3o Título de dependencia
                            arquivoPrincipal.Write(new String(' ', 10));

                            // Pode ser alterado
                            arquivoPrincipal.Write("1");

                            // Produto Cesta básica
                            arquivoPrincipal.Write("0");

                            // Se produto pertence a uma cesta
                            arquivoPrincipal.Write("0");

                            // Se produto é diferenciado de outros
                            arquivoPrincipal.Write("00"); // Normal

                            // Data da última venda do produto
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

                            // Pontuação fidelidade
                            arquivoPrincipal.Write(new String('0', 7));

                            // Pontos extra fidelidade
                            arquivoPrincipal.Write(new String('0', 7));

                            // Peso a ser calculo em item unitário
                            arquivoPrincipal.Write(new String('0', 5));

                            // Flag de produto unitário vendido por peso
                            //sw.Write(dePeso ? "1" : "0");
                            arquivoPrincipal.Write("0");

                            // Quantidade máxima a ser multiplaco no pdv
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
                MessageBox.Show("Processo concluído.", "Exportação de arquivo fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void opçãoInício_Click(object sender, EventArgs e)
        {
            ExportarVEconnectVarejo();
        }

        /// <summary>
        /// Corta um texto colocando espaços e preenchendo a direita.
        /// </summary>
        private static string Cortar(String texto, int quantidade)
        {
            return Cortar(texto, quantidade, true);
        }


        private static string Cortar(String texto, int quantidade, bool preencherÁDireita)
        {
            return Cortar(texto, quantidade, ' ', preencherÁDireita);
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
        private static string Cortar(String texto, int quantidade, char caractereCompletude, bool preencherÁDireita)
        {
            if (texto.Length > quantidade)
            {
                return texto.Substring(0, quantidade);
            }
            else
            {
                if (preencherÁDireita)
                    return texto + new String(caractereCompletude, quantidade - texto.Length);
                else
                    return new String(caractereCompletude, quantidade - texto.Length) + texto;
            }
        }


        private static Dictionary<string, double> hashReferênciaPreço = null;

        /// <summary>
        /// Retorna o preço em real de uma grama da mercadoria
        /// </summary>
        private static double ObterPreço(string referência)
        {
            if (hashReferênciaPreço == null)
            {
                // Construir a hash
                hashReferênciaPreço = new Dictionary<string, double>(StringComparer.Ordinal);
                foreach (DataRow item in ds.Tables["tabelamercadoria"].Rows)
                {
                    if (((uint)item["tabela"]) == 1)
                        hashReferênciaPreço.Add((string) item["mercadoria"], Math.Round((double)item["coeficiente"] * cotação, 2));
                }
            }

            if (hashReferênciaPreço.ContainsKey(referência))
            {
                return hashReferênciaPreço[referência];
            }
            else
            {
//                ReportarErro("Não achei preço para referência: " + referência + ", utilizando valor R$ 0,00");
                return 0;
            }
        }

        void ReportarErro(string erro)
        {
            quadroErros.Visible = true;
            txtErros.Text += erro + "\r\n";
        }

        /// <summary>
        /// Gera aquivos relacionados à impressora fiscal de varejo padrão E-Connect.
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
            List<IDbConnection> conexõesRemovidas = new List<IDbConnection>();
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conexõesRemovidas);

            GeraArquivoProduto(Path.Combine(caminho, "PRODUTO"));
            GeraArquivoEAN(Path.Combine(caminho, "EAN"));
            GeraArquivoSecao(Path.Combine(caminho, "SECOES"));
            GeraArquivoPreco(Path.Combine(caminho, "NIVEL_PR"));

            MySQL.AdicionarConexõesRemovidas(conexõesRemovidas);
            MessageBox.Show("Exportação", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer", caminho);
        }

        /// <summary>
        /// 41|000024|2010-03-11 10:41:43|      2.05|2010-09-17 10:41:43|
        /// </summary>
        private static void GeraArquivoPreco(string caminhoCompletoPreco)
        {
            Aguarde aguarde = new Aguarde("Consultando preços", ds.Tables["mercadoria"].Rows.Count);

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

                    // Preço de venda
                    Entidades.Mercadoria.Mercadoria mercadoria;

                    if (Entidades.Mercadoria.Mercadoria.ConferirSeÉDePeso(referencia))
                    {
                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia, 1,
                        Tabela.ObterPrimeiraTabela(Setor.ObterSetor(Setor.SetorSistema.Varejo)));
                    }
                    else
                    {
                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(referencia,
                        Tabela.ObterPrimeiraTabela(Setor.ObterSetor(Setor.SetorSistema.Varejo)));
                    }


                    Preço preçoMercadoria = mercadoria.CalcularPreço(Cotação.ObterCotaçãoVigente(Moeda.ObterMoeda(MoedaSistema.OuroVarejo)));
                    string preçoStr = Math.Round(preçoMercadoria.Valor, 2).ToString().Replace(',', '.').Trim();

                    //string preçoStr = "99.99";

                    strPreco.Write(preçoStr);
                    strPreco.Write("|");
                    strPreco.Write(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
                    strPreco.Write("|9999|");
                    strPreco.Write(preçoStr);
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
                    descricao = Entidades.Acentuação.Singleton.TirarAcentos(descricao);

                    double peso = (m["peso"] is DBNull ? 0 : (double)m["peso"]);

                    // Verificar se vem com digito
                    EscreveReferenciaComDigito(strProduto, referencia);
                    strProduto.Write("|0|0|001|001|001|T18|");

                    // Descrição completa
                    strProduto.Write(Cortar(descricao, 60, false).Trim());
                    strProduto.Write("|");

                    // Descrição reduzida
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

                    // Peso padrão
                    strProduto.Write((peso / 1000).ToString().Replace(',','.'));
                    strProduto.Write("|2|0|0|0|0||");

                    // Data atualização
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
            int digito = Entidades.Mercadoria.Mercadoria.ObterDígito(referencia);
            return referencia + digito.ToString();
        }
    }
}
