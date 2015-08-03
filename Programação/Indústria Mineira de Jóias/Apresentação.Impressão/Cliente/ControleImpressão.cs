using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Apresentação.Impressão.Pacotes;
using Entidades.Acerto;
using System.Runtime.InteropServices;
using Apresentação.Impressão.Relatórios;

namespace Apresentação.Impressão.Cliente
{
    /// <summary>
    /// Controla uma impressão a ser realizada.
    /// </summary>
    public class ControleImpressão : Comunicador<ControleImpressão>
    {
        private TipoDocumento tipo;

        private DadosConexão conexão;
        private DadosCandidatura eleito;
        private bool remoto = false;

        /* Para compatibilidade com Windows 98, é necessário ter
         * sempre um gerente.
         */
        private Apresentação.Impressão.Servidor.GerenteImpressoras gerente = new Apresentação.Impressão.Servidor.GerenteImpressoras();

        /// <summary>
        /// Thread para consulta de disponibilidade.
        /// </summary>
        private Thread threadConsulta;

        /// <summary>
        /// Define se o controle deve consultar impressoras.
        /// </summary>
        private volatile bool consultar = false;

        /// <summary>
        /// Define se o controle está imprimindo.
        /// </summary>
        private volatile int imprimindo = 0;

        /// <summary>
        /// Hash de candidatos.
        /// </summary>
        private Dictionary<string, DadosCandidatura> hashCandidatos = new Dictionary<string, DadosCandidatura>();
        private Dictionary<string, EndPoint> hashEndPoint = new Dictionary<string,EndPoint>();

        /// <summary>
        /// Lista de candidatos.
        /// </summary>
        private List<DadosCandidatura> listaCandidatos = new List<DadosCandidatura>();
        private bool desordenado = false;
        private bool ordenar = false;

        public delegate void CandidaturaHandler(ControleImpressão sender, object chave, DadosCandidatura candidatura);
        public event CandidaturaHandler AoReceberCandidatura;

        public delegate void EventoImpressão(TipoDocumento tipo, ulong código);
        public event EventoImpressão ImpressãoCompleta;
        public event EventoImpressão ErroImpressão;

        public TipoDocumento Tipo { get { return tipo; } }

        public bool Ordenar
        {
            get { return ordenar; }
            set { ordenar = value; }
        }

        /// <summary>
        /// Permite impressão remota.
        /// </summary>
        public bool Remoto
        {
            get { return remoto; }
            set
            {
                remoto = value;

                if (value)
                    EnviarConsultaDisponibilidade();
            }
        }

        /// <summary>
        /// Constrói um controle de impressão.
        /// </summary>
        public ControleImpressão(TipoDocumento tipo) : base(false)
        {
            this.tipo = tipo;

            if (remoto)
                EnviarConsultaDisponibilidade();
        }

        protected override void ConstruirSocket()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            sck.Bind(new IPEndPoint(0, 0));

            sck.EnableBroadcast = true;
            sck.DontFragment = true;
        }

        public override void Dispose()
        {
            consultar = false;
            base.Dispose();
        }

        /// <summary>
        /// Envia consulta de disponibilidade.
        /// </summary>
        private void EnviarConsultaDisponibilidade()
        {
            if (!consultar && remoto)
            {
                consultar = true;

                Console.WriteLine("- Criando thread para consulta de disponibilidade...");

                threadConsulta = new Thread(new ThreadStart(ThreadConsultaDisponibilidade));
                threadConsulta.IsBackground = true;
                threadConsulta.Name = "Consulta de disponibilidade de impressão";
                //threadConsulta.Priority = ThreadPriority.BelowNormal;
                threadConsulta.Start();

                Console.WriteLine("- Criada thread para consulta de disponibilidade!");
            }
        }

        /// <summary>
        /// Envia consulta de disponibilidade.
        /// </summary>
        private void ThreadConsultaDisponibilidade()
        {
            ConsultaDisponibilidade pacote = new ConsultaDisponibilidade(tipo);
            Random rnd = new Random();

            do
            {
                unsafe
                {
                    Enviar(new IPEndPoint(IPAddress.Broadcast, Servidor.Serviço.PortaUDP),
                        &pacote, sizeof(ConsultaDisponibilidade));
                }

                Thread.Sleep(1000 + rnd.Next(500));

                lock (listaCandidatos)
                {
                    listaCandidatos.RemoveAll(new Predicate<DadosCandidatura>(VerificarCandidaturaAntiga));

                    if (desordenado && ordenar)
                    {
                        listaCandidatos.Sort(new Comparison<DadosCandidatura>(CompararCandidatura));
                        desordenado = false;
                    }
                }
            } while (consultar && remoto);
        }

        /// <summary>
        /// Avalia candidatura de um nó.
        /// </summary>
        internal void AvaliarCandidatura(EndPoint origem, DadosCandidatura candidatura)
        {
            string chave = candidatura.Máquina + candidatura.Impressora;

            lock (listaCandidatos)
            {
                int idx = -1;

                /* Estar na hash não implica que está na lista.
                 * O item pode ter sido removido da lista em outro
                 * ponto do código. (Veja o RemoveAll com condição
                 * lá em cima)
                 */
                if (hashCandidatos.ContainsKey(chave))
                    idx = listaCandidatos.IndexOf(hashCandidatos[chave]);

                if (idx >= 0)
                    listaCandidatos[idx] = candidatura;
                else
                    listaCandidatos.Add(candidatura);

                hashCandidatos[chave] = candidatura;
                desordenado = true;
            }

            hashEndPoint[chave] = origem;

            try
            {
                if (AoReceberCandidatura != null)
                    AoReceberCandidatura(this, chave, candidatura);
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }

        /// <summary>
        /// Lista de candidatos.
        /// </summary>
        public List<DadosCandidatura> Candidatos
        {
            get
            {
                if (gerente != null)
                    foreach (Apresentação.Impressão.Servidor.GerenteImpressoras.InfoImpressora infoImpressora in gerente)
                        if (infoImpressora.Configuração.Suporta(tipo) && !hashCandidatos.ContainsKey(infoImpressora.Configuração.Nome))
                            AvaliarCandidatura(new IPEndPoint(IPAddress.Loopback, Servidor.Serviço.PortaUDP), new DadosCandidatura(Environment.MachineName, infoImpressora.Configuração.Nome, 0.0f, Environment.OSVersion.Version.Major < 5 ? 0.0f : 1000.0f, Environment.OSVersion.Version.Major < 5 ? (ulong)0 : (ulong)2400, infoImpressora.Colorido));

                if (!desordenado)
                    return new List<DadosCandidatura>(listaCandidatos);
                else
                {
                    List<DadosCandidatura> lista = new List<DadosCandidatura>(listaCandidatos);
                    
                    if (ordenar)
                        lista.Sort(new Comparison<DadosCandidatura>(CompararCandidatura));

                    return lista;
                }
            }
        }

        /// <summary>
        /// Compra a nota de dois candidatos.
        /// </summary>
        public int CompararCandidatura(DadosCandidatura a, DadosCandidatura b)
        {
            return a.Nota.CompareTo(b.Nota);
        }

        /// <summary>
        /// Verifica se candidatura é antiga.
        /// </summary>
        private bool VerificarCandidaturaAntiga(DadosCandidatura candidatura)
        {
            TimeSpan ts = DateTime.Now - candidatura.Quando;

            return ts.TotalSeconds > 10;
        }

        /// <summary>
        /// Requisita impressão ao candidato eleito.
        /// </summary>
        /// <param name="eleito">Candidato eleito.</param>
        public void RequisitarImpressão(DadosCandidatura eleito, DadosDocumento documento)
        {
            RequisiçãoImpressão pacote;

            if (documento.Tipo != tipo)
                throw new ArgumentException("Tipo de documento apresentado se difere do tipo declarado inicialmente.", "documento");

            //if (tipo == TipoDocumento.Acerto)
            //    throw new NotSupportedException("O método RequisitarImpressão utilizado não pode imprimir acertos.");

            // Desliga thread de consulta.
            lock (this)
            {
                consultar = false;
                imprimindo++;
            }

            // Imprime localmente ou requisita impressão remota
            if (eleito.Máquina == Environment.MachineName)
            {
                try
                {
                    using (TrabalhoImpressão trabalho = new TrabalhoImpressão(documento, eleito.Impressora))
                    {
                        trabalho.Imprimir();
                    }
                    DispararImpressãoCompleta(documento.Tipo, documento.Código);
                }
                catch (Exception e)
                {
                    DispararErroImpressão(documento.Tipo, documento.Código);
                }
            }
            else
            {
                // Preenche pacote.
                pacote = new RequisiçãoImpressão(eleito.Impressora);
                pacote.Tipo = documento.Tipo;
                pacote.CódigoDocumento = documento.Código;
                pacote.Cópias = documento.Cópias;
                pacote.Collated = documento.Collated;
                pacote.PágInicial = documento.PágInicial;
                pacote.PágFinal = documento.PágFinal;

                // Inicia comunicação.
                if (eleito.Máquina != this.eleito.Máquina && conexão != null)
                {
                    conexão.Cliente.Close();
                    conexão = null;
                }

                this.eleito = eleito;

                if (conexão == null)
                {
                    try
                    {
                        TcpClient cliente;

                        cliente = new TcpClient();
                        cliente.Connect(new IPEndPoint(
                            ((IPEndPoint)hashEndPoint[eleito.Máquina + eleito.Impressora]).Address,
                            Servidor.Serviço.PortaTCP));

                        conexão = IntroduzirComunicação(cliente);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Não foi possível requisitar impressão.", e);
                    }
                }

                unsafe
                {
                    Enviar(conexão, &pacote, sizeof(RequisiçãoImpressão));
                }
            }
        }

        /// <summary>
        /// Requisita impressão ao candidato eleito.
        /// </summary>
        /// <param name="eleito">Candidato eleito.</param>
        public void RequisitarImpressão(DadosCandidatura eleito, DadosRelatório relatório)
        {
            RequisiçãoRelatório pacote;

            if (relatório.Tipo != tipo)
                throw new ArgumentException("Tipo de documento apresentado se difere do tipo declarado inicialmente.", "documento");

            //if (tipo == TipoDocumento.Acerto)
            //    throw new NotSupportedException("O método RequisitarImpressão utilizado não pode imprimir acertos.");

            // Desliga thread de consulta.
            lock (this)
            {
                consultar = false;
                imprimindo++;
            }

            // Imprime localmente ou requisita impressão remota
            if (eleito.Máquina == Environment.MachineName)
            {
                try
                {
                    using (RelatórioImpressão trabalho = new RelatórioImpressão(relatório, eleito.Impressora))
                    {
                        trabalho.Imprimir();
                    }
                    DispararImpressãoCompleta(relatório.Tipo, 0);
                }
                catch
                {
                    DispararErroImpressão(relatório.Tipo, 0);
                }
            }
            else
            {
                // Preenche pacote.
                pacote = new RequisiçãoRelatório(eleito.Impressora);
                pacote.Tipo = relatório.Tipo;
                pacote.PeríodoInicial = relatório.PeríodoInicial;
                pacote.PeríodoFinal = relatório.PeríodoFinal;
                pacote.Cópias = relatório.Cópias;
                pacote.Collated = relatório.Collated;
                pacote.PágInicial = relatório.PágInicial;
                pacote.PágFinal = relatório.PágFinal;

                // Inicia comunicação.
                if (eleito.Máquina != this.eleito.Máquina && conexão != null)
                {
                    conexão.Cliente.Close();
                    conexão = null;
                }

                this.eleito = eleito;

                if (conexão == null)
                {
                    try
                    {
                        TcpClient cliente;

                        cliente = new TcpClient();
                        cliente.Connect(new IPEndPoint(
                            ((IPEndPoint)hashEndPoint[eleito.Máquina + eleito.Impressora]).Address,
                            Servidor.Serviço.PortaTCP));

                        conexão = IntroduzirComunicação(cliente);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Não foi possível requisitar impressão.", e);
                    }
                }

                unsafe
                {
                    Enviar(conexão, &pacote, Marshal.SizeOf(typeof(RequisiçãoRelatório)));
                }
            }
        }
        
        ///// <summary>
        ///// Requisita impressão ao candidato eleito de um acerto.
        ///// </summary>
        ///// <param name="eleito">Candidato eleito.</param>
        //public void RequisitarImpressão(DadosCandidatura eleito, DadosDocumento documento, ControleAcertoMercadorias acerto)
        //{
        //    RequisiçãoImpressão pacote;
        //    InfoDocumento info;
        //    Cabeçalho conclusão;

        //    if (documento.Tipo != TipoDocumento.Acerto)
        //        throw new ArgumentException("O método utilizado só suporta impressão de acerto.");

        //    // Desliga thread de consulta.
        //    lock (this)
        //    {
        //        consultar = false;
        //        imprimindo++;
        //    }

        //    // Preenche pacote.
        //    pacote = new RequisiçãoImpressão(eleito.Impressora);
        //    pacote.Tipo = TipoDocumento.Acerto;
        //    pacote.CódigoDocumento = acerto.Pessoa.Código;  // Mudança de semântica.
        //    pacote.Cópias = documento.Cópias;
        //    pacote.Collated = documento.Collated;
        //    pacote.PágInicial = documento.PágInicial;
        //    pacote.PágFinal = documento.PágFinal;

        //    // Inicia comunicação.
        //    if (eleito.Máquina != this.eleito.Máquina && conexão != null)
        //    {
        //        conexão.Cliente.Close();
        //        conexão = null;
        //    }

        //    if (conexão == null)
        //    {
        //        try
        //        {
        //            TcpClient cliente;

        //            cliente = new TcpClient();
        //            cliente.Connect(new IPEndPoint(
        //                ((IPEndPoint)hashEndPoint[eleito.Máquina + eleito.Impressora]).Address,
        //                Servidor.Serviço.PortaTCP));

        //            conexão = IntroduzirComunicação(cliente);
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Não foi possível requisitar impressão.", e);
        //        }
        //    }

        //    unsafe
        //    {
        //        Enviar(conexão, &pacote, sizeof(RequisiçãoImpressão));

        //        foreach (long código in acerto.Documentos.CódigoSaídas)
        //        {
        //            info = new InfoDocumento(TipoDocumento.Saída, (ulong)código);
        //            Enviar(conexão, &info, sizeof(InfoDocumento));
        //        }

        //        foreach (long código in acerto.Documentos.CódigoRetornos)
        //        {
        //            info = new InfoDocumento(TipoDocumento.Retorno, (ulong)código);
        //            Enviar(conexão, &info, sizeof(InfoDocumento));
        //        }

        //        foreach (long código in acerto.Documentos.CódigoVendas)
        //        {
        //            info = new InfoDocumento(TipoDocumento.Venda, (ulong)código);
        //            Enviar(conexão, &info, sizeof(InfoDocumento));
        //        }

        //        conclusão.comando = Comando.ConcluirAcerto;

        //        Enviar(conexão, &conclusão, sizeof(Cabeçalho));
        //    }
        //}

        /// <summary>
        /// Dispara evento de impressão completa.
        /// </summary>
        internal void DispararImpressãoCompleta(TipoDocumento tipoDocumento, ulong código)
        {
            lock (this)
                imprimindo--;

            try
            {
                if (ImpressãoCompleta != null)
                    ImpressãoCompleta(tipo, código);
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }

        internal void DispararErroImpressão(TipoDocumento tipoDocumento, ulong código)
        {
            lock (this)
                imprimindo--;

            try
            {
                if (ErroImpressão != null)
                    ErroImpressão(tipo, código);
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }
    }
}
