//#define RASTRO
//#define DEBUG_VERBOSE

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data;
using Acesso.Comum.Adaptadores;

namespace Acesso.Comum
{
    [Serializable]
    public class GerenciadorConexões : System.Runtime.Remoting.Messaging.ILogicalThreadAffinative //, IDisposable
    {
		/// <summary>
		/// Usuário e senha do banco de dados
		/// </summary>
		private string nome, senha;

        /// <summary>
        /// Tempo com que o sistema aguardará antes de criar uma
        /// nova conexão enquanto outra estiver em uso.
        /// </summary>
        private TimeSpan tempoLimiteEspera = TimeSpan.FromMilliseconds(75);

        /// <summary>
        /// Limiar em que o sistema considera quantidade excessiva de conexões.
        /// </summary>
        private int limiarExcessoConexões = 8;

        /// <summary>
        /// Número de conexões iniciais.
        /// </summary>
        private const int nConexõesIniciais = 3;

        /// <summary>
        /// Número máximo de conexões.
        /// </summary>
        private const int máximoConexões = 4;

        /// <summary>
        /// Timer para verificar excesso de conexões.
        /// </summary>
        private Timer timerVerificarExcesso = null;

        /// <summary>
        /// Validade de uma conexão.
        /// </summary>
        private TimeSpan validadeConexão = new TimeSpan(0, 5, 0);
        
        /// <summary>
        /// Usuário cujas conexões estão sendo gerenciadas.
        /// </summary>
        private Usuário usuário;

        /// <summary>
        /// Hash de conexões baseado no domínio da aplicação.
        /// </summary>
        private Dictionary<AppDomain, Queue<ConexãoDbUsuário>> hashConexões = new Dictionary<AppDomain,Queue<ConexãoDbUsuário>>();

        /// <summary>
        /// Hash mapeamento conexão do banco de dados com informações de conexão.
        /// </summary>
        private volatile Dictionary<IDbConnection, ConexãoDbUsuário> hashMapConexão = new Dictionary<IDbConnection, ConexãoDbUsuário>();

        public delegate void AtualizarContextoCallback();

        public event AtualizarContextoCallback AtualizarContexto;

        public delegate void ConexãoPresaCallback(string comando, TimeSpan tempoPassado, System.Diagnostics.StackTrace pilha);
#pragma warning disable 0067
        public event ConexãoPresaCallback ConexãoPresa;
#pragma warning restore 0067
        private DateTime debugÚltimaSinalização = DateTime.Now;


        /// <summary>
        /// Constrói o gerenciador de conexões.
        /// </summary>
        /// <param name="usuário">Entidade de usuário.</param>
        /// <param name="nome">Nome do usuário no banco de dados.</param>
        /// <param name="senha">Senha do usuário do banco de dados.</param>
        public GerenciadorConexões(Usuário usuário, string nome, string senha)
        {
            Thread construirConexões;
            
            this.usuário = usuário;
            this.nome = nome;
            this.senha = senha;

            CriarNovaConexão();

            construirConexões = new Thread(new ThreadStart(EstabelecerMínimoConexões));
            construirConexões.Name = "Estabelecimento do mínimo de conexões";
            construirConexões.IsBackground = true;
            construirConexões.Start();
        }

        /// <summary>
        /// Cria conexões até alcançar o número mínimo de conexões estabelecido
        /// por usuário.
        /// </summary>
        /// <remarks>
        /// Este método corresponde a uma thread executada na construtora.
        /// </remarks>
        private void EstabelecerMínimoConexões()
        {
            Queue<ConexãoDbUsuário> conexões = ObterConexões();

            while (conexões.Count < nConexõesIniciais)
                lock (usuário)
                    // Verificar novamente, agora dentro do lock.
                    if (conexões.Count < nConexõesIniciais)
                        CriarNovaConexão();
        }

        /// <summary>
        /// Obtém conexões para o domínio da aplicação atual e,
        /// se não existir, ele cria.
        /// </summary>
        /// <returns>Conexões para o domínio atual.</returns>
        private Queue<ConexãoDbUsuário> ObterConexões()
        {
            Queue<ConexãoDbUsuário> conexões;

            if (!hashConexões.TryGetValue(AppDomain.CurrentDomain, out conexões))
                conexões = AdicionarDomínio(AppDomain.CurrentDomain);

            return conexões;
        }

        /// <summary>
        /// Adiciona um domínio à hash.
        /// </summary>
        /// <param name="domínio">Domínio a ser adicionado.</param>
        private Queue<ConexãoDbUsuário> AdicionarDomínio(AppDomain domínio)
        {
            Queue<ConexãoDbUsuário> conexões = new Queue<ConexãoDbUsuário>();

            Console.Out.WriteLine("Adicionando novo domínio: {0}", domínio.ToString());

            hashConexões.Add(domínio, conexões);

            domínio.DomainUnload += new EventHandler(AoDescarregarDomínio);

            return conexões;
        }

        /// <summary>
        /// Ocorre ao descarregar um domínio.
        /// </summary>
        void AoDescarregarDomínio(object sender, EventArgs e)
        {
            Queue<ConexãoDbUsuário> conexões;

            if (hashConexões.TryGetValue((AppDomain)sender, out conexões))
            {
                hashConexões.Remove((AppDomain)sender);

                foreach (IDbConnection conexão in conexões)
                {
                    conexão.Close();
                    conexão.Dispose();
                }
            }
        }

        /// <summary>
        /// Obtém conexão do domínio atual, realizando rodízio de conexões.
        /// Caso não haja nenhuma conexão disponível, uma nova conexão é criada.
        /// </summary>
        /// <returns>Conexão com o banco de dados.</returns>
        public ConexãoConcorrente ObterConexão()
        {
            Queue<ConexãoDbUsuário> conexões = ObterConexões();

#if DEBUG
            DateTime dtInício = DateTime.Now;
#endif

            bool insistir = false;

            do
            {
                lock (this)
                {
                    for (int i = 0; i < conexões.Count; i++)
                    {
                        ConexãoDbUsuário cUsr;
                        ConexãoConcorrente conexão;

                        cUsr = conexões.Dequeue();

                        if (cUsr == null)
                            continue;

                        conexão = cUsr.Conexão;
                        conexões.Enqueue(cUsr);

                        try
                        {
                            if (conexão.Ocupado > 0 || conexão.AguardarAté > DateTime.Now)
                            {
#if DEBUG
                                TimeSpan ts = DateTime.Now - conexão.cmdCriação;

#if DEBUG_VERBOSE
                                Console.WriteLine("\aConexão {1} ocupada ({2}) a {0} segundos!", ts.TotalSeconds, conexão.Debug_ID, conexão.Ocupado);
#endif

                                if (ts.TotalSeconds >= 5)
                                {
                                    TimeSpan tsd = DateTime.Now - debugÚltimaSinalização;

                                    if (tsd.TotalSeconds > 10)
                                    {
#if DEBUG_VERBOSE
                                        Console.WriteLine("\aObtida em:\n{0}", conexão.Debug_ObtençãoConexão);
#endif
                                        System.Diagnostics.Debug.Assert(conexão.Ocupado > 0, "Conexão presa sem estar ocupada! Verificar obtenção de conexão atoa sem uso de comandos no programa. Para isso, verifique a variável 'conexão.Debug_ObtençãoConexão'.");

                                        if (ConexãoPresa != null)
                                            ConexãoPresa(conexão.cmdTexto ?? "", ts, conexão.cmdPilha);

                                        debugÚltimaSinalização = DateTime.Now;
                                    }
                                }
#endif
                                continue;
                            }

                            if (Monitor.TryEnter(conexão, tempoLimiteEspera))
                            {
                                // Verificar estado da conexão
                                try
                                {
                                    System.Diagnostics.Debug.Assert(conexão.Ocupado == 0,
                                        "Conexão ocupada, mas sem lock!!!!");

                                    if (conexão.State == ConnectionState.Broken)
                                        Reconectar(conexão);

                                    else if (conexão.State == ConnectionState.Closed)
                                        conexão.Open();

                                    conexão.AguardarAté = DateTime.Now.AddSeconds(15);

#if DEBUG
//                                    conexão.cmdTexto = null;
                                    conexão.cmdPilha = new System.Diagnostics.StackTrace(3, true);
                                    conexão.cmdCriação = DateTime.Now;
                                    conexão.Debug_ObtençãoConexão = new System.Diagnostics.StackTrace(1).ToString();

                                    DebugVerificarDuração(dtInício);
#if DEBUG_VERBOSE
                                    Console.WriteLine("\aEntregando conexão {0}", conexão.Debug_ID);
#endif
#if RASTRO
                                    Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
#endif
#endif
                                    return conexão;
                                }
                                finally
                                {
                                    Monitor.Exit(conexão);
                                }
                            }
                        }
                        catch (System.Runtime.Remoting.RemotingException)
                        {
#if DEBUG
#if DEBUG_VERBOSE
                            Console.WriteLine("\aEntregando conexão {0}", conexão.Debug_ID);
#endif
#if RASTRO
                            Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
#endif
#endif
                            return ReconstruirConexão(conexão);
                        }
                        catch (Exception e)
                        {
                            conexão = ReconstruirConexão(conexão);

                            usuário.RegistrarErro(e);

#if DEBUG
#if DEBUG_VERBOSE
                            Console.WriteLine("\aEntregando conexão {0}", conexão.Debug_ID);
#endif
#if RASTRO
                            Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
#endif
#endif
                            return conexão;
                        }
                    }
                }

                // Limite de tempo estourado e nenhuma conexão disponível.
                if (conexões.Count < máximoConexões)
                    try
                    {
#if DEBUG
                        DebugVerificarDuração(dtInício);
#endif
                        return CriarNovaConexão();
                    }
                    catch (Exception e)
                    {
                        ConexãoDbUsuário cUsr;

                        Console.WriteLine("Não foi possível criar nova conexão: {0}", e.ToString());

                        lock (this)
                        {
                            if (conexões.Count > 0)
                            {
                                cUsr = conexões.Dequeue();
                                conexões.Enqueue(cUsr);
                            }
                        }

                        insistir = true;
                    }
                else
                    insistir = true;

            } while (insistir);

            throw new Exception("Código nunca deveria atingir este ponto em ObterConexão de GerenciadorConexões.");
        }

#if DEBUG
        private static void DebugVerificarDuração(DateTime dtInício)
        {
#if DEBUG_VERBOSE
            Console.WriteLine("\aTempo para conseguir conexão: {0} s", ((TimeSpan)(DateTime.Now - dtInício)).TotalSeconds);
#endif
        }
#endif

        /// <summary>
        /// Cria uma nova conexão.
        /// </summary>
        private ConexãoConcorrente CriarNovaConexão()
        {
            IDbConnection conexão;
            Queue<ConexãoDbUsuário> conexões = ObterConexões();
            ConexãoDbUsuário infoConexão;

            Console.Out.WriteLine("Criando nova conexão ({0}) com o banco de dados para o usuário {1}",
                conexões.Count + 1, nome);

            lock (conexões)
            {
                conexão = usuário.usuários.Conectar(nome, senha);
                infoConexão = AdicionarConexão(conexão, conexões);

                usuário.usuários.DispararAoCriarConexão(usuário);
            }

#if DEBUG
#if DEBUG_VERBOSE
            Console.WriteLine("\aEntregando conexão {0}", infoConexão.Conexão.Debug_ID);
#endif
#if RASTRO
            Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
#endif
#endif
            return infoConexão.Conexão;
        }

        /// <summary>
        /// Adiciona uma conexão à lista de conexões do usuário,
        /// ligando Timer para verificação de excesso de conexões.
        /// </summary>
        private ConexãoDbUsuário AdicionarConexão(IDbConnection conexão, Queue<ConexãoDbUsuário> conexões)
        {
            ConexãoDbUsuário infoConexão = new ConexãoDbUsuário(conexão);

            lock (this)
            {

                conexões.Enqueue(infoConexão);
                hashMapConexão[conexão] = infoConexão;

                if (conexões.Count > limiarExcessoConexões)
                    if (timerVerificarExcesso == null)
                        timerVerificarExcesso = new Timer(new TimerCallback(VerificarExcessoConexões), null, 10000, 60000);
            }

            DispararAtualizarContexto();

            return infoConexão;
        }

        /// <summary>
        /// Verifica excesso de conexões do usuário com o banco de dados.
        /// </summary>
        private void VerificarExcessoConexões(object estado)
        {
            Queue<ConexãoDbUsuário> conexões = ObterConexões();

            lock (this)
            {
                if (conexões.Count > limiarExcessoConexões)
                {
                    ConexãoDbUsuário cUsr = conexões.Peek();

                    if (DateTime.Now - cUsr.ÚltimoUso > validadeConexão)
                    {
                        Console.Out.WriteLine("Fechando excesso de conexão ({0}) com banco de dados.",
                            conexões.Count);

                        conexões.Dequeue();

                        //lock (cUsr.Conexão)
                        cUsr.Conexão.Close();

                        //hashMapConexão.Remove(cUsr.Conexão.ConexãoOriginal);

                        cUsr.Conexão.Dispose();
                        cUsr.Dispose();

                        return;
                    }
                    else if (timerVerificarExcesso != null)
                    {
                        timerVerificarExcesso.Dispose();
                        timerVerificarExcesso = null;
                    }
                }
            }
        }

		/// <summary>
		/// Reconstrói a conexão com banco de dados
		/// </summary>
		private ConexãoConcorrente ReconstruirConexão(IDbConnection antigaConexão)
		{
            IDbConnection conexão;
            ConexãoDbUsuário cUsr;
            int cnt = 0;
            Queue<ConexãoDbUsuário> conexões = ObterConexões();
            ConexãoDbUsuário dbConexão = null;

            lock (this)
            {
                cUsr = conexões.Dequeue();

                while (cUsr.Conexão != antigaConexão && cnt++ < conexões.Count)
                {
                    conexões.Enqueue(cUsr);
                    cUsr = conexões.Dequeue();
                }


                if (cUsr.Conexão == antigaConexão)
                {
                    //hashMapConexão.Remove(cUsr.Conexão.ConexãoOriginal);
                    cUsr.Dispose();
                }

                conexão = usuário.usuários.Conectar(nome, senha);

                dbConexão = new ConexãoDbUsuário(conexão);

                conexões.Enqueue(dbConexão);
                hashMapConexão[conexão] = dbConexão;

            }

			DispararAtualizarContexto();

            return dbConexão.Conexão;
		}

        /// <summary>
        /// Reconecta no banco de dados
        /// </summary>
        public void Reconectar(IDbConnection conexão)
        {
            Console.WriteLine("Reconectando!!!");

            if (conexão != null && conexão.State != ConnectionState.Closed)
                conexão.Close();

            conexão.Open();
        }

        /// <summary>
        /// Remove a conexão da fila.
        /// </summary>
        /// <param name="conexão">Conexão a ser removida.</param>
        public void RemoverConexão(IDbConnection conexão)
        {
            if (conexão == null)
                return;

            Queue<ConexãoDbUsuário> conexões = ObterConexões();

            lock (this)
            {
                for (int i = 0; i < conexões.Count; i++)
                {
                    ConexãoDbUsuário cUsr = conexões.Dequeue();

                    if (cUsr != null)
                    {
                        if (!cUsr.Equals(conexão))
                            conexões.Enqueue(cUsr);
                    }

                    // A conexão pode ser usada por fora, portanto o mapeamento é mantido:
                    // hashMapConexão.Remove(conexão);
                }
            }

            DispararAtualizarContexto();
        }

        /// <summary>
        /// Adiciona conexão à fila.
        /// </summary>
        /// <param name="conexão">Conexão a ser adicionada.</param>
        public void AdicionarConexão(IDbConnection conexão)
        {
            if (conexão == null)
            {
                throw new Exception("Tentativa de inserir conexão nula");
            }
            Queue<ConexãoDbUsuário> conexões = ObterConexões();

            AdicionarConexão(conexão, conexões);
        }

        /// <summary>
        /// Total de conexões disponíveis.
        /// </summary>
        public int TotalConexões
        {
            get { return ObterConexões().Count; }
        }

        /// <summary>
        /// Dispara evento para atualização de contexto.
        /// </summary>
        private void DispararAtualizarContexto()
        {
            if (AtualizarContexto != null)
                AtualizarContexto();
        }

        /// <summary>
        /// Altera a senha a ser utilizada na conexão.
        /// </summary>
        /// <param name="novaSenha">Nova senha a ser utilizada.</param>
        public void AlterarSenha(string novaSenha)
        {
            this.senha = novaSenha;
        }

        /// <summary>
        /// Determina se a senha do usuário é ruim.
        /// </summary>
        public bool SenhaRuim
        {
            get { return senha.Length < 4; }
        }

        /// <summary>
        /// Obtém informações sobre uma conexão.
        /// </summary>
        internal ConexãoDbUsuário ObterInfoConexão(IDbConnection conexão)
        {
            return hashMapConexão[((ConexãoConcorrente)conexão).ConexãoOriginal];
        }
    }
}
