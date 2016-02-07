using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tamir.SharpSsh;
using Apresentação.Formulários;

namespace Sistema_IMJ
{
    /* Sistema de atualização de versão.
     *   É necessário um servidor ssh, com um usuário para download do arquivo zip com o 
     *   binário mais recente da versão do programa.
     *
     *  Este Projeto/Processo deve ser executado antes do sistema em sí. 
     *  Este é responsável por baixar nova versão da aplicação, e substituir os binários e dlls, 
     *  e então lançar o processo da nova versão.
     * 
     */
    public partial class Form1 : Form
    {
        
        // Servidor.
        private string HOST = "192.168.1.20";
        private int PORTA = 9000;
        private string USUARIO_ATUALIZADOR = "atualizador";
        private string SENHA_ATUALIZADOR = "";
        private const string NOME_ARQUIVO = "sistema.zip";
        private const int INTERVALO_TENTATIVA_MS = 1000;
        private const string NOME_PROCESSO = "IMJ";

        // Cliente.
        private string NOME_PASTA_CLIENTE = @"imjoias\";
        private int MÁXIMO_TENTATIVAS = 3;

        private Splash splash;
        private string diretórioSistema, arquivoEXELocal, arquivoZipLocal;

        private bool NecessárioAtualizar
        {
            get
            {
                if (File.Exists(arquivoZipLocal))
                {
                    DateTime dataMeuAplicativo = File.GetLastWriteTime(arquivoZipLocal);
                    DateTime dataAplicativoNoServidor = DateTime.MinValue;

                    try
                    {
                        dataAplicativoNoServidor = ObterDataÚltimaVersão();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível conectar-se ao servidor para atualização de versão.\nA versão local será lançada.");
                        ExecutarImjoias();
                    }

                    if (dataMeuAplicativo < dataAplicativoNoServidor)
                        return true;
                }
                else
                    return true;

                if (!File.Exists(arquivoEXELocal))
                    return true;

                return false;
            }
        }

        public Form1()
        {
            splash = new Splash();
            splash.MostrarCarregandoVersão();
            splash.Show();
            Application.DoEvents();

            MataAplicativoImjoias();

            // Constantes
            diretórioSistema = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), NOME_PASTA_CLIENTE);
            arquivoEXELocal = Path.Combine(diretórioSistema, NOME_PROCESSO + ".EXE");
            arquivoZipLocal = Path.Combine(diretórioSistema, NOME_ARQUIVO);

            if (NecessárioAtualizar)
                Atualizar();

            ExecutarImjoias();
        }

        private static void MataAplicativoImjoias()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(NOME_PROCESSO)
                    && (clsProcess.ProcessName != Process.GetCurrentProcess().ProcessName))
                {
                    try
                    {
                        clsProcess.Kill();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void ExecutarImjoias()
        {
            // Executa o programa 
            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = arquivoEXELocal;
            Proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            Proc.Start();

            // Sai deste atualizador.
            Environment.Exit(0);
        }

        void sshCp_OnTransferProgress(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            splash.Mensagem = "Atualizando a versão ... " + Math.Round(10 - (double)9 * transferredBytes / totalBytes, 0).ToString() ;
        }

        /// <summary>
        /// Vai no servidor, conecta via sftp
        /// e baixa o arquivo sistema.zip,
        /// descompacta no diretório diretórioSistema, sobrescrevendo os arquivos.
        /// </summary>
        private void Atualizar()
        {
            // Garante que a data de criação do arquivo local seja atualizada ao descarregar
            if (File.Exists(arquivoZipLocal))
                File.Delete(arquivoZipLocal);

            if (!Directory.Exists(diretórioSistema))
                Directory.CreateDirectory(diretórioSistema);

            Tamir.SharpSsh.Sftp sshCp = new Tamir.SharpSsh.Sftp(HOST, USUARIO_ATUALIZADOR, SENHA_ATUALIZADOR);

            sshCp.OnTransferProgress += new FileTransferEvent(sshCp_OnTransferProgress);

            sshCp.Connect(PORTA);
            sshCp.Get(NOME_ARQUIVO, arquivoZipLocal);

            FastZip zip = new FastZip();
            zip.CreateEmptyDirectories = true;

            zip.ExtractZip(arquivoZipLocal, diretórioSistema, ".*");
        }

        private DateTime ObterDataÚltimaVersão()
        {
            SshShell shell = new SshShell(HOST, USUARIO_ATUALIZADOR, SENHA_ATUALIZADOR);

            //This statement must be prior to connecting
            shell.RedirectToConsole();

            shell.Connect(PORTA);

            byte[] vetor = System.Text.Encoding.Unicode.GetBytes("stat sistema.zip | grep Change\n");
            MemoryStream entrada = new MemoryStream(vetor);
            MemoryStream saída = new MemoryStream();
            shell.SetStream(entrada, saída);
            entrada.Flush();
            int posição = -1;
            string dadosRecebidos = null;

            int tentativaAtual = 0;
            while (posição == -1)
            {
                tentativaAtual++;
                saída.Flush();

                System.Text.Encoding enc = System.Text.Encoding.UTF8;
                dadosRecebidos = enc.GetString(saída.ToArray());
                posição = dadosRecebidos.IndexOf("Change");
                
                if (posição == -1) 
                    System.Threading.Thread.Sleep(INTERVALO_TENTATIVA_MS);

                if (tentativaAtual > MÁXIMO_TENTATIVAS)
                
                    throw new Exception();
                
            }

            dadosRecebidos = Regex.Match(dadosRecebidos, @"\d\d\d\d-\d\d-\d\d \d\d:\d\d:\d\d.\d* -\d\d\d\d").Value;

            DateTime dataCriação = DateTime.Parse(dadosRecebidos);

            if (shell.ShellOpened)
                shell.Close();

            return dataCriação;
        }
    }
}
