using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Apresentação.Impressão.Pacotes;
using System.Threading;

namespace Apresentação.Impressão
{
    /// <summary>
    /// Classe abstrata responsável pelo controle de comunicação
    /// entre cliente e servidor, independente se o nó é um cliente
    /// ou servidor. Esta classe utiliza uma instância de socket
    /// UDP para requisições em broadcast e respostas em unicast.
    /// Requisições de impressões são realizadas via TCP, mantidas
    /// numa lista interna.
    /// </summary>
    /// <typeparam name="TSistema">Tipo do sistema a ser utilizado.</typeparam>
    /// <seealso cref="Apresentação.Impressão.Servidor.Serviço"/>
    /// <seealso cref="Apresentação.Impressão.Cliente.ControleImpressão"/>
    public abstract class Comunicador<TSistema> : IDisposable
    {
        public const double ProblemThreshold = 7;

        /// <summary>
        /// Socket UDP para descobrir impressoras.
        /// </summary>
        protected Socket sck;

        /// <summary>
        /// Lista de conexões TCP.
        /// </summary>
        private List<DadosConexão> listaConexões = new List<DadosConexão>();

        /// <summary>
        /// Temporizador para verificar conexões ociosas.
        /// </summary>
        private Timer tmrVerificarConexões;

        /// <summary>
        /// Tempo máximo permitido de ociosidade em uma conexão TCP.
        /// </summary>
        /// <remarks>
        /// Unidade de medida: minuto.
        /// </remarks>
        private const int tempoLimiteOciosidade = 10; // Minutos

        /// <summary>
        /// Controle para envio atrasado de pacotes.
        /// </summary>
        private EnvioAtrasado envioAtrasado;

        /// <summary>
        /// Thread para recepção de dados.
        /// </summary>
        private Thread recepção;

        /// <summary>
        /// Determina se o comunicador deve manter as conexões
        /// em funcionamento.
        /// </summary>
        protected volatile bool ligado = true;


        /// <summary>
        /// Constrói o comunicador, disparando o método abstrato ConstruirSocket().
        /// </summary>
        public Comunicador()
            : this(true)
        {
        }

        public Comunicador(bool ligar)
        {
            Console.WriteLine("Criando comunicador...");

            if (ligar)
                Ligar();
            else
                ligado = false;
        }

        public void Ligar()
        {
            PrepararUDP();

            recepção = new Thread(new ThreadStart(ReceberDados));
            recepção.Priority = ThreadPriority.BelowNormal;
            recepção.IsBackground = true;
            recepção.Start();

            Console.WriteLine("- Thread de recepção criada");

            tmrVerificarConexões = new Timer(new TimerCallback(VerificarConexões), null, tempoLimiteOciosidade * 60 * 1000, tempoLimiteOciosidade * 60 * 1000);

            Console.WriteLine("- Timer para verificar as conexões criada");

            ligado = true;
        }

        /// <summary>
        /// Prepara a UDP.
        /// </summary>
        private void PrepararUDP()
        {
            try
            {
                if (sck != null)
                {
                    envioAtrasado.Dispose();
                    sck.Close();

                    sck = null;
                    envioAtrasado = null;
                }
            }
            catch { }

            ConstruirSocket();

            Console.WriteLine("- Socket criado!");

            envioAtrasado = new EnvioAtrasado(sck);
        }

        /// <summary>
        /// Responsável pela atribuição do socket UDP "sck".
        /// </summary>
        protected abstract void ConstruirSocket();

        /// <summary>
        /// Verifica conexões abertas, removendo todas as conexões
        /// ociosas. Este método é disparado por um temporizador.
        /// </summary>
        private void VerificarConexões(object estado)
        {
            lock (listaConexões)
                foreach (DadosConexão conexão in listaConexões.FindAll(new Predicate<DadosConexão>(ConexãoInválida)))
                {
                    listaConexões.Remove(conexão);
                    conexão.Cliente.Close();
                }
        }

        /// <summary>
        /// Verifica se uma conexão é inválida, ou seja, está ociosa há
        /// muito tempo.
        /// </summary>
        private bool ConexãoInválida(DadosConexão conexão)
        {
            TimeSpan ts = DateTime.Now - conexão.ÚltimaComunicação;

            return ts.TotalMinutes <= tempoLimiteOciosidade;
        }

        /// <summary>
        /// Introduz comunicação por meio de cliente TCP.
        /// </summary>
        /// <param name="cliente">Cliente TCP.</param>
        protected DadosConexão IntroduzirComunicação(TcpClient cliente)
        {
            DadosConexão conexão = new DadosConexão(cliente);

            conexão.Estado = Apresentação.Impressão.Estado.EstadoComunicação.Normal;

            lock (listaConexões)
                listaConexões.Add(conexão);

            Thread recepção = new Thread(new ParameterizedThreadStart(ReceberDadosTcp));
            recepção.Name = "Comunicação com cliente " + cliente.Client.RemoteEndPoint.ToString();
            
            // Ao iniciar impressão, deve-se finalizá-la.
            //recepção.IsBackground = true;
            recepção.IsBackground = false;
            recepção.Priority = ThreadPriority.BelowNormal;
            recepção.Start(conexão);

            return conexão;
        }

        /// <summary>
        /// Recebe e interpreta os pacotes UDP da rede.
        /// </summary>
        private void ReceberDados()
        {
            início_thread:
            do
            {
                try
                {
                    byte[] buffer = new byte[Servidor.Serviço.TamPacote];
                    Interpretador<TSistema> interpretador = new Interpretador<TSistema>((TSistema)(object)this);
                    EndPoint remoto = new IPEndPoint(0, 0);
                    int qtd;
                    int blk_cnt = 0;        // Contador do erro WSAEINTR. 3 consecutivos invalidam a conexão.
                    int problem_cnt = 0;
                    DateTime ts_problem = DateTime.Now;

                    sck.Blocking = true;

                    do
                    {
                    início_leitura:
                        try
                        {
                            qtd = sck.ReceiveFrom(buffer, ref remoto);
                            blk_cnt = 0;
                            ts_problem = DateTime.Now;
                            problem_cnt = 0;
                        }
                        catch (SocketException e)
                        {
                            qtd = 1;
                            problem_cnt++;

                            Console.WriteLine(e.ToString());

                            switch (e.ErrorCode)
                            {
                                /* WSAEINTR - Interrupted function call.
                                 * A blocking operation was interrupted by a call to WSACancelBlockingCall
                                 */
                                case 10004:
                                    if (++blk_cnt >= 3)
                                        goto case 10058;
                                    goto início_leitura;
                                    //continue;

                                // WSAESHUTDOWN - Cannot send after socket shutdown.
                                case 10058:
                                    Console.WriteLine("Finalizado.");
                                    goto verificar_continuidade;

                                // WSAENETUNREACH - Network is unreachable
                                case 10051:
                                // WSAENETRESET - Network dropped connection on reset. 
                                case 10052:
                                // WSAECONNABORTED - Software caused connection abort. 
                                case 10053:
                                // WSAECONNRESET - Connection reset by peer. 
                                case 10054:
                                // WSAECONNREFUSED - Connection refused. 
                                case 10061:
                                // WSAEHOSTDOWN - Host is down.
                                case 10064:
                                // WSAEHOSTUNREACH - No route to host. 
                                case 10065:
                                // WSATRY_AGAIN
                                case 11002:
                                    //continue;
                                    goto início_leitura;

                                default:
                                    // Temos vários "Unknown error 0x2736" registrados.
                                    //Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                                    //continue;
                                    goto início_leitura;
                            }
                        }
                        catch (ObjectDisposedException)
                        {
                            return;
                        }
                        // Temos vários "Unknown error 0x2736" registrados.
                        //catch (Exception e)
                        //{
                        //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                        //    return;
                        //}
                        catch
                        {
                            //qtd = 1;
                            //problem_cnt++;
                            //continue;
                            goto início_thread;
                        }
#if DEBUG
                            Console.WriteLine("Interpretando pacote de {0}", remoto.ToString());
#endif
                        try
                        {
                            interpretador.Interpretar(null, remoto, buffer, 0, qtd);
                        }
                        catch (SocketException)
                        {
                            //qtd = 1;
                            //continue;
                            goto início_leitura;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                            //qtd = 1;
                            //continue;
                            goto início_leitura;
                        }

                        if (DateTime.Now > ts_problem &&
                            problem_cnt / (double)((TimeSpan)(DateTime.Now - ts_problem)).Seconds > ProblemThreshold)
                        {
                            Console.WriteLine("Quantidade de problemas excessiva.");
                            //break;
                            throw new Exception("Quantidade de problemas excessiva no comunicador.");
                        }
                    } while (ligado && qtd > 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            verificar_continuidade:
                if (ligado)
                    PrepararUDP();
            } while (ligado);
        }

        /// <summary>
        /// Recebe e interpreta os pacotes TCP da rede.
        /// </summary>
        private void ReceberDadosTcp(object obj)
        {
            DadosConexão conexão = (DadosConexão)obj;
            EndPoint endpoint = conexão.Cliente.Client.RemoteEndPoint;

#if DEBUG
            Console.WriteLine("Recebida nova conexão de {0}.", endpoint.ToString());
#endif

            try
            {
                // Buffer para leitura dos dados
                byte[] buffer = new byte[Servidor.Serviço.TamPacote];

                // Interpretador do buffer
                Interpretador<TSistema> interpretador = new Interpretador<TSistema>((TSistema)(object)this);

                // Stream TCP
                NetworkStream stream;

                // Quantidade de bytes lidos
                int qtd;

                // Offset de leitura do socket
                int offset_sck = 0;

                // Offset de interpretação do buffer
                int offset_int;

                try
                {
                    stream = conexão.Cliente.GetStream();
                    conexão.Cliente.Client.Blocking = true;
                }
                catch
                {
                    return;
                }

                do
                {
                    int deslocamento = 0;

                    try
                    {
                        qtd = stream.Read(buffer, offset_sck, Servidor.Serviço.TamPacote - offset_sck);
                    }
                    //catch (SocketException)
                    //{
                    //    break;
                    //}
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                    // Temos vários "Unknown error 0x2736" registrados.
                    //catch (Exception e)
                    //{
                    //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                    //    return;
                    //}
                    catch
                    {
                        return;
                    }

#if DEBUG
                    Console.WriteLine("Recebidos {0} bytes.", qtd);
#endif
                    // Atualizar informações da comunicação.
                    conexão.ÚltimaComunicação = DateTime.Now;
                    offset_sck += qtd;
                    offset_int = 0;

                    do
                    {
                        deslocamento = interpretador.Interpretar(conexão, endpoint, buffer, offset_int, qtd);
                        offset_int += deslocamento;
                        qtd -= deslocamento;
#if DEBUG
                        Console.WriteLine("{0} bytes interpretados, restam {1}.", deslocamento, qtd);
#endif
                    } while (deslocamento > 0 && qtd >= 2);

                    if (offset_int == offset_sck)
                        offset_sck = 0;
                    else
                    {
#if DEBUG
                        Console.WriteLine("Deslocando buffer {0} bytes", offset_sck - offset_int);
#endif
                        // Deslocar bytes no buffer.
                        for (int i = offset_int; i < offset_sck; i++)
                            buffer[i - offset_int] = buffer[i];

                        offset_sck = offset_sck - offset_int;
                    }
                } while (ligado && offset_int > 0);
            }
            catch (SocketException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
            finally
            {
#if DEBUG
                Console.WriteLine("Deconectando cliente TCP");
#endif
                lock (listaConexões)
                    listaConexões.Remove(conexão);

                try
                {
                    conexão.Cliente.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// Gera buffer para envio de dados, sobrescrevendo o checksum.
        /// </summary>
        /// <param name="dados">Dados a serem enviados.</param>
        /// <param name="tamanho">Tamanho do buffer.</param>
        /// <returns>Vetor de bytes.</returns>
        protected unsafe byte[] GerarBuffer(void* dados, int tamanho)
        {
            byte[] buffer = new byte[tamanho];
            byte chksum = 0;

            for (int i = 0; i < tamanho; i++)
                buffer[i] = ((byte*)dados)[i];

            for (int i = 1; i < tamanho; i++)
                chksum ^= (byte)unchecked(buffer[i] + (byte)i);

            fixed (byte* aptr = buffer)
            {
                Cabeçalho* cabeçalho = (Cabeçalho*)aptr;
                cabeçalho->chksum = chksum;
            }

            return buffer;
        }

        /// <summary>
        /// Envia um pacote na rede.
        /// </summary>
        /// <param name="destino">Destinatário.</param>
        /// <param name="dados">Estrutura que respeita o cabeçalho.</param>
        /// <param name="tamanho">Tamanho da estrutura.</param>
        protected unsafe void Enviar(EndPoint destino, void* dados, int tamanho)
        {
            if (!ligado)
                Ligar();

            sck.SendTo(GerarBuffer(dados, tamanho), destino);
        }

        /// <summary>
        /// Envia um pacote na rede.
        /// </summary>
        /// <param name="conexão">Conexão com o cliente/servidor.</param>
        /// <param name="dados">Estrutura que respeita o cabeçalho.</param>
        /// <param name="tamanho">Tamanho da estrutura.</param>
        protected unsafe void Enviar(DadosConexão conexão, void* dados, int tamanho)
        {
            if (!ligado)
                Ligar();

            conexão.Cliente.GetStream().Write(
                                GerarBuffer(dados, tamanho), 0, tamanho);
            conexão.ÚltimaComunicação = DateTime.Now;
        }

        /// <summary>
        /// Envia um pacote na rede com um certo atraso.
        /// </summary>
        /// <param name="destino">Destinatário.</param>
        /// <param name="dados">Estrutura que respeita o cabeçalho.</param>
        /// <param name="tamanho">Tamanho da estrutura.</param>
        /// <param name="atrasoMilissegundos">Atraso em milissegundos.</param>
        protected unsafe void Enviar(EndPoint destino, void* dados, int tamanho, int atrasoMilissegundos)
        {
            byte[] buffer = GerarBuffer(dados, tamanho);

            if (!ligado)
                Ligar();

            envioAtrasado.Atrasar((IPEndPoint)destino, buffer, atrasoMilissegundos);
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
            ligado = false;

            if (tmrVerificarConexões != null)
                try
                {
                    tmrVerificarConexões.Dispose();
                }
                catch { }

            if (envioAtrasado != null)
                try
                {
                    envioAtrasado.Dispose();
                }
                catch { }

            try
            {
                if (sck != null)
                {
                    sck.Shutdown(SocketShutdown.Both);
                    sck.Close();
                }
            }
            catch { }

            lock (listaConexões)
                foreach (DadosConexão conexão in listaConexões)
                    try
                    {
                        conexão.Cliente.Close();
                    }
                    catch { }
        }

        #endregion
    }
}
