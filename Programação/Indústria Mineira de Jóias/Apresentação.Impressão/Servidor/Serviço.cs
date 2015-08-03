using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Apresentação.Impressão.Pacotes;
using Apresentação.Impressão.Relatórios;

namespace Apresentação.Impressão.Servidor
{
    /// <summary>
    /// Serviço de impressào via rede.
    /// </summary>
    public class Serviço : Comunicador<Serviço>
    {
        public const int PortaUDP = 8555;
        public const int PortaTCP = 8556;
        public const int TamPacote = 1200;

        private TcpListener tcp;

        private ulong velocidade;
        private PerformanceCounter cpuCounter; 
        private PerformanceCounter ramCounter;
        private Timer tmrAmostragem;

        private Random rnd = new Random();

        /// <summary>
        /// Média móvel.
        /// </summary>
        private float[] mmCPU = new float[120];
        private int idxMMCPU;

        private GerenteImpressoras gerenteImpressoras = new GerenteImpressoras();

        public delegate void DocumentoHandler(TipoDocumento documento, ulong código);
        public event DocumentoHandler AoIniciarImpressão;
        public event DocumentoHandler AoFinalizarImpressão;

        /// <summary>
        /// Constrói o servidor de impressão.
        /// </summary>
        public Serviço()
        {
            try
            {
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                cpuCounter = new PerformanceCounter();

                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                DescobrirVelocidade();

                tmrAmostragem = new Timer(new TimerCallback(Amostrar), null, 0, 1000);
            }
            catch
            {
                for (int i = 0; i < mmCPU.Length; i++)
                    mmCPU[i] = .5f;
            }

            tcp = new TcpListener(IPAddress.Any, PortaTCP);
            tcp.Start();

            Thread receptorConexões = new Thread(new ThreadStart(RecepçãoConexões));
            receptorConexões.IsBackground = true;
            receptorConexões.Name = "Receptor de conexões para impressão remota";
            receptorConexões.Start();
        }

        /// <summary>
        /// Constrói o socket UDP.
        /// </summary>
        protected override void ConstruirSocket()
        {
            if (sck != null)
            {
                try
                {
                    sck.Close();
                }
                catch { }
            }

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            sck.Bind(new IPEndPoint(0, PortaUDP));

            sck.EnableBroadcast = true;
            sck.DontFragment = true;
        }

        public void RecarregarImpressoras()
        {
            gerenteImpressoras = new GerenteImpressoras();
        }

        /// <summary>
        /// Recebe as conexões TCP.
        /// </summary>
        private void RecepçãoConexões()
        {
            do
            {
                TcpClient cliente = tcp.AcceptTcpClient();

                if (cliente != null && ligado)
                    IntroduzirComunicação(cliente);
            } while (ligado);
        }

        /// <summary>
        /// Descobre a velocidade do processador.
        /// </summary>
        private void DescobrirVelocidade()
        {
            try
            {
                Microsoft.Win32.RegistryKey key =
                    Microsoft.Win32.Registry.LocalMachine.
                    OpenSubKey("Hardware").OpenSubKey("Description").
                    OpenSubKey("System").OpenSubKey("CentralProcessor").OpenSubKey("0");

                velocidade = Convert.ToUInt64(key.GetValue("~MHz"));
            }
            catch
            {
                velocidade = 200;
            }
        }

        /// <summary>
        /// Obtém uso da CPU.
        /// </summary>
        /// <returns></returns>
        private float ObterCPU()
        {
            try
            {
                return cpuCounter.NextValue();
            }
            catch
            {
                return .5f;
            }
        }

        /// <summary>
        /// RAM disponível em MB
        /// </summary>
        /// <returns></returns>
        private float ObterRAM()
        {
            try
            {
                if (ramCounter == null)
                    return 16;
                else
                    return ramCounter.NextValue();
            }
            catch
            {
                return 2;
            }
        }

        /// <summary>
        /// Amostra dados para construir a média móvel.
        /// </summary>
        private void Amostrar(object obj)
        {
            mmCPU[idxMMCPU] = ObterCPU();
            idxMMCPU = (idxMMCPU + 1) % mmCPU.Length;
        }

        private float Média(float[] valores)
        {
            float soma = 0;

            foreach (float valor in valores)
                soma += valor;

            return soma / valores.Length;
        }


        /// <summary>
        /// Candidata-se à impressão.
        /// </summary>
        public void CandidatarSe(EndPoint remoto, TipoDocumento tipo)
        {
            if (ObterCPU() < 95 && ObterRAM() >= 4)
                foreach (GerenteImpressoras.InfoImpressora info in gerenteImpressoras)
                    if (info.Configuração.Compartilhar && info.Configuração.Suporta(tipo).Valor)
                        EnviarCandidatura(remoto, info, tipo);
        }

        private void EnviarCandidatura(EndPoint destino, GerenteImpressoras.InfoImpressora impressora, TipoDocumento tipo)
        {
            Candidatura candidatura = new Candidatura(impressora.Configuração.Nome);

            candidatura.Máquina = Environment.MachineName;
            candidatura.Colorido = impressora.Colorido;
            candidatura.CPU = Média(mmCPU);
            candidatura.RAM = ObterRAM();
            candidatura.Velocidade = velocidade;
            candidatura.Tipo = tipo;

            unsafe
            {
                // Enviar com atraso para evitar colisões.
                Enviar(destino, &candidatura, sizeof(Candidatura), rnd.Next(2000));
            }
        }

        /// <summary>
        /// Imprime documento.
        /// </summary>
        internal void Imprimir(DadosConexão conexão, string impressora, DadosDocumento dados)
        {
            ImpressãoCompleta pacote;

            try
            {
                try
                {
                    if (AoIniciarImpressão != null)
                        AoIniciarImpressão(dados.Tipo, dados.Código);
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
                }

                using (TrabalhoImpressão trabalho = new TrabalhoImpressão(dados, impressora))
                {
                    trabalho.Imprimir();
                }
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

                unsafe
                {
                    ErroImpressão erro = new ErroImpressão(dados.Tipo, dados.Código);

                    Enviar(conexão, &erro, sizeof(ErroImpressão));
                }

                return;
            }

            Console.WriteLine("Enviando feedback...");

            pacote = new ImpressãoCompleta(dados.Tipo, dados.Código);

            unsafe
            {
                Enviar(conexão, &pacote, sizeof(ImpressãoCompleta));
            }

            try
            {
                if (AoFinalizarImpressão != null)
                    AoFinalizarImpressão(dados.Tipo, dados.Código);
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
            }

            Console.WriteLine("Processo de impressão completo!");
        }

        /// <summary>
        /// Imprime relatóio.
        /// </summary>
        internal void Imprimir(DadosConexão conexão, string impressora, DadosRelatório dados)
        {
            ImpressãoCompleta pacote;

            try
            {
                using (RelatórioImpressão trabalho = new RelatórioImpressão(dados, impressora))
                {
                    trabalho.Imprimir();
                }
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

                unsafe
                {
                    ErroImpressão erro = new ErroImpressão(dados.Tipo, 0);

                    Enviar(conexão, &erro, sizeof(ErroImpressão));
                }

                return;
            }

            Console.WriteLine("Enviando feedback...");

            pacote = new ImpressãoCompleta(dados.Tipo, 0);

            unsafe
            {
                Enviar(conexão, &pacote, sizeof(ImpressãoCompleta));
            }

            Console.WriteLine("Processo de impressão completo!");
        }

        ///// <summary>
        ///// Imprime acerto.
        ///// </summary>
        //internal void Imprimir(DadosConexão conexão, string impressora, DadosDocumento dados, List<long> saídas, List<long> retornos, List<long> vendas)
        //{
        //    ImpressãoCompleta pacote;

        //    try
        //    {
        //        try
        //        {
        //            if (AoIniciarImpressão != null)
        //                AoIniciarImpressão(TipoDocumento.Acerto, 0);
        //        }
        //        catch (Exception erro)
        //        {
        //            Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
        //        }

        //        using (TrabalhoImpressão trabalho = new TrabalhoImpressão(dados, saídas, retornos, vendas, impressora))
        //        {
        //            trabalho.Imprimir();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);

        //        unsafe
        //        {
        //            ErroImpressão erro = new ErroImpressão(TipoDocumento.Acerto, 0);

        //            Enviar(conexão, &erro, sizeof(ErroImpressão));
        //        }

        //        return;
        //    }

        //    pacote = new ImpressãoCompleta(TipoDocumento.Acerto, 0);

        //    unsafe
        //    {
        //        Enviar(conexão, &pacote, sizeof(ImpressãoCompleta));
        //    }

        //    try
        //    {
        //        if (AoIniciarImpressão != null)
        //            AoFinalizarImpressão(TipoDocumento.Acerto, 0);
        //    }
        //    catch (Exception erro)
        //    {
        //        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
        //    }
        //}
    }
}
