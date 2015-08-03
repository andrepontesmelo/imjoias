using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.jsch.examples;
using Tamir.SharpSsh;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using System.Collections;

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
        // Configurações do servidor.
        private string host = "imj.ignorelist.com";
        private int porta = 9000;
        private string atualizadorUsuário = "atualizador";
        private string atualizadorSenha = "***REMOVED***";

        // Configurações do cliente.
        private string nomePastaCliente = @"SistemaIMJ\";
        private int numeroMáximoTentativasConexão = 3;

        private Apresentação.Formulários.Splash splash;
        private string diretórioSistema, arquivoEXELocal, arquivoZipLocal;

        public Form1()
        {
            splash = new Apresentação.Formulários.Splash();
            splash.MostrarCarregandoVersão();
            splash.Show();
            Application.DoEvents();

            
            // Mata toda as versões do aplicativo
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains("IMJ")
                    && (clsProcess.ProcessName != Process.GetCurrentProcess().ProcessName))
                {
                    clsProcess.Kill();
                }
            }

            // Constantes
            diretórioSistema = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), nomePastaCliente);
            arquivoEXELocal = Path.Combine(diretórioSistema, "IMJ.EXE");
            arquivoZipLocal = Path.Combine(diretórioSistema, "sistema.zip");


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
                    ExecutaProgramaFinalmente();
                }

                if (dataMeuAplicativo < dataAplicativoNoServidor)
                    DescarregarÚltimaVersão();
            }
            else
                DescarregarÚltimaVersão();

            if (!File.Exists(arquivoEXELocal))
                DescarregarÚltimaVersão();

            ExecutaProgramaFinalmente();
        }

        private void ExecutaProgramaFinalmente()
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
        private void DescarregarÚltimaVersão()
        {
            // Garante que a data de criação do arquivo local seja atualizada ao descarregar
            if (File.Exists(arquivoZipLocal))
                File.Delete(arquivoZipLocal);

            if (!Directory.Exists(diretórioSistema))
                Directory.CreateDirectory(diretórioSistema);

            Tamir.SharpSsh.Sftp sshCp = new Tamir.SharpSsh.Sftp(host, atualizadorUsuário, atualizadorSenha);

            sshCp.OnTransferProgress += new FileTransferEvent(sshCp_OnTransferProgress);

            sshCp.Connect(porta);
            sshCp.Get("sistema.zip", arquivoZipLocal);

            FastZip zip = new FastZip();
            zip.CreateEmptyDirectories = true;

  

            zip.ExtractZip(arquivoZipLocal, diretórioSistema, ".*");
        }

        private DateTime ObterDataÚltimaVersão()
        {
            SshShell shell = new SshShell(host, atualizadorUsuário, atualizadorSenha);

            //This statement must be prior to connecting
            shell.RedirectToConsole();

            shell.Connect(porta);

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
                    System.Threading.Thread.Sleep(1000);

                if (tentativaAtual > numeroMáximoTentativasConexão)
                {
                    throw new Exception();
                }
            }
            dadosRecebidos = System.Text.RegularExpressions.Regex.Match(dadosRecebidos, @"\d\d\d\d-\d\d-\d\d \d\d:\d\d:\d\d.\d* -\d\d\d\d").Value;
            //dadosRecebidos =  dadosRecebidos.Substring(posição + 8);
            //dadosRecebidos = dadosRecebidos.Substring(0, dadosRecebidos.IndexOf('.'));

            DateTime dataCriação = DateTime.Parse(dadosRecebidos);

            if (shell.ShellOpened)
            {
                shell.Close();
            }

            return dataCriação;
        }
    }
}
