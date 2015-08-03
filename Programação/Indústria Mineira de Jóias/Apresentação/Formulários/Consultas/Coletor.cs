using System;
using System.Threading;

namespace Apresentação.Formulários.Consultas
{
	/// <summary>
	/// Coleta dados do banco de dados
	/// </summary>
	public abstract class Coletor
	{
		// Constantes
		private const int		tempoEsperaAlteraçãoInicial = 10;		// milissegundo
		private const int		tempoEsperaAlteraçãoMáximo  = 200;		// milissegundo
		private const int       mínimoAcréscimo             = 10;		// milissegundo
		private const int       máximoAcréscimo             = 700;
		private const int       incrementoAcréscimo         = 50;
		private const int       decrementoAcréscimo         = 5;

		// Atributos
		private volatile string chave;					// Chave a ser pesquisada
		private volatile bool	alterada;				// Chave foi alterada
		private volatile bool	pesquisando;			// Se a thread está pesquisando
		private volatile string	últimaBusca = null;		// Grava para que duas buscas identicas não sejam possíveis.
		private bool			ignorarTamanhoLetra = true; // Ignorar maiúsculo e minúsculo
		private volatile bool	cancelar = false;
		private volatile bool   ignorarAlteração = false; // Força a pesquisa, se o prefixo for o mesmo.
		private TaxaDigitação   taxaDigitação;
        private volatile bool   suspenso = false;

        /// <summary>
        /// Acréscimo ao tempo dado como penalização
        /// para espera por digitação.
        /// </summary>
		private volatile int    acréscimo;

        /// <summary>
        /// Tempo de espera por alteração, antes de se realizar
        /// a pesquisa.
        /// </summary>
		private volatile int	tempoEsperaAlteração;

		// Evento início de busca
		public delegate void InícioDeBuscaDelegate();
		public event InícioDeBuscaDelegate InícioDeBusca;

		// Evento final de busca
		public delegate void FinalDeBuscaDelegate();
		public event FinalDeBuscaDelegate FinalDeBusca;

        // Métodos assíncronos
        private delegate void LoopRecuperaçãoCallback();
        private LoopRecuperaçãoCallback métodoLoopRecuperação;
        private AsyncCallback callbackLoopRecuperação;

        /// <summary>
        /// Verifica se o coletor está suspenso.
        /// </summary>
        public bool Suspenso
        {
            get { return suspenso; }
        }

        /// <summary>
        /// Momento em que ocorreu a última tecla digitada.
        /// </summary>
        public TimeSpan ÚltimaDigitação
        {
            get { return taxaDigitação.ÚltimoRegistro - DateTime.Now; }
        }

        /// <summary>
        /// Taxa média de digitação (ms/tecla)
        /// </summary>
        public double TaxaMédiaDigitação
        {
            get { return taxaDigitação.CalcularIntervalo(); }
        }

		/// <summary>
		/// Constrói o coletor
		/// </summary>
		public Coletor()
		{
			taxaDigitação           = new TaxaDigitação();
			acréscimo               = mínimoAcréscimo;
			tempoEsperaAlteração    = tempoEsperaAlteraçãoInicial;
            métodoLoopRecuperação   = new LoopRecuperaçãoCallback(LoopRecuperação);
            callbackLoopRecuperação = new AsyncCallback(CallbackLoopRecuperação);
		}

		#region Propriedades

		/// <summary>
		/// Não diferenciar letra maiúscula de letra minúscula
		/// </summary>
		public bool IgnorarMaiúsculoMinúsculo
		{
			get { return ignorarTamanhoLetra; }
			set { ignorarTamanhoLetra = value; }
		}

		/// <summary>
		/// Se o coletor está pesquisando
		/// </summary>
		public bool Pesquisando
		{
			get { return pesquisando; }
		}

		/// <summary>
		/// Chave procurada
		/// </summary>
		protected string Chave
		{
			get { return chave; }
		}

		/// <summary>
		/// Última chave procurada.
		/// </summary>
		protected string ÚltimaChave
		{
			get { return últimaBusca; }
		}

		#endregion

        /// <summary>
        /// Suspende a pesquisa.
        /// </summary>
        public void Suspender()
        {
            suspenso = true;
            Cancelar();
        }

        /// <summary>
        /// Retorna da suspensão, permitindo novas pesquisas.
        /// </summary>
        /// <remarks>
        /// Ao recomeçar, uma eventual pesquisa interrompida
        /// NÃO É RECOMEÇADA. Após este método, apenas novas
        /// pesquisas serão realizadas.
        /// </remarks>
        public void Recomeçar()
        {
            suspenso = false;
        }

		/// <summary>
		/// Realiza pesquisa de uma chave
		/// </summary>
		/// <param name="chave">Chave a ser pesquisada</param>
		public void Pesquisar(string chave)
		{
            if (!suspenso)
            {
                if (ignorarAlteração && !chave.StartsWith(this.chave))
                    ignorarAlteração = false;

                // Atribuir novo valor de chave
                this.chave = chave;
                this.alterada = true;

                taxaDigitação.Registrar();

                cancelar = false;

                lock (this)
                    if (!pesquisando)
                        PesquisarEmSegundoPlano();
            }
		}

		/// <summary>
		/// Cancela pesquisa
		/// </summary>
		public void Cancelar()
		{
			cancelar = true;
		}

		/// <summary>
		/// Ativa a thread de procura, chamada quando o usuário
		/// aperta enter nos campos de busca.
		/// </summary>
		public void ProcurarImediatamente()
		{
            if (!suspenso)
            {
                cancelar = false;
                ignorarAlteração = true;

                if (!pesquisando)
                    RealizarPesquisa();
            }
		}

        /// <summary>
        /// Inicia pesquisa em segundo plano.
        /// </summary>
        private void PesquisarEmSegundoPlano()
        {
            lock (this)
                if (!pesquisando)
                {
                    pesquisando = true;
                    métodoLoopRecuperação.BeginInvoke(callbackLoopRecuperação, null);
                }
        }

        /// <summary>
        /// Ocorre ao término da recuperação.
        /// </summary>
        /// <param name="resultado">Resultado da chamada assíncrona.</param>
        private void CallbackLoopRecuperação(IAsyncResult resultado)
        {
            métodoLoopRecuperação.EndInvoke(resultado);
            
            lock (this)
            {
                pesquisando = false;
                cancelar = false;

                if (alterada)
                    PesquisarEmSegundoPlano();
            }
        }

		/// <summary>
		/// Loop para recuperar dados do banco de dados.
		/// </summary>
        private void LoopRecuperação()
        {
            // Aguardar alterações serem realizadas
            do
            {
                while (alterada && !ignorarAlteração)
                {
                    alterada = false;
                    int tempoDormir = CalcularTempoEsperaAlteração();
                    Console.WriteLine("Zzz..." + tempoDormir.ToString());
                    Thread.Sleep(tempoDormir);
                }

                if (!cancelar)
                {
                    try
                    {
                        ignorarAlteração = false;
                        RealizarPesquisa();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());

#if DEBUG
                        System.Windows.Forms.MessageBox.Show(e.ToString());
#endif

                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(new Exception("Exceção ignorada.", e));
                    }
                }

                /* Enquanto isso, podem ser feitas
                 * outras alterações, necessitando
                 * nova pesquisa.
                 */
            } while (alterada);

            if (FinalDeBusca != null && !suspenso)
                FinalDeBusca();
        }

		/// <summary>
		/// Realiza pesquisa
		/// </summary>
		private void RealizarPesquisa()
		{
			string chaveLocal;
			DateTime    momento;

#if DEBUG
			DateTime debugInício = DateTime.Now;
			Console.WriteLine("~ Coletor: Realizando pesquisa...");
#endif

#if DEBUG
			if (chave == null)
			{
				System.Windows.Forms.MessageBox.Show("Chave não pode ser nula!");

				throw new ApplicationException("Chave não pode ser nula!");
			}
#else
			// Este método causou uma estranha excessão dizendo que chave é nula.
			// A verificação contorna o problema:
			if (chave == null)
				return;
#endif

			lock (chave)
			{
				chaveLocal = chave;

				momento = taxaDigitação.ÚltimoRegistro;

				// Verificar se a busca é repetida
				if (!((!ignorarTamanhoLetra && últimaBusca == chaveLocal)
					|| (ignorarTamanhoLetra && string.Compare(últimaBusca, chaveLocal, true) == 0)))
				{
					// Dispara um evento para informar início de busca
					if (InícioDeBusca != null) 
						InícioDeBusca();

#if DEBUG
					//Console.WriteLine("~ Coletor: Recuperando...");
#endif
					Recuperar(chaveLocal);
#if DEBUG
					//Console.WriteLine("~ Coletor: Dados recuperados!");
#endif
					últimaBusca = chaveLocal;
				}
			}

			AjustarTempo(alterada, chaveLocal, momento);

#if DEBUG
			TimeSpan debugDif = DateTime.Now - debugInício;
			Console.WriteLine("~ Coletor: Pesquisa pronta! {0} ms <<<-------", debugDif.TotalMilliseconds);
#endif
		}

		/// <summary>
		/// Recupera os dados
		/// </summary>
		/// <param name="chave">Chave a ser recuperada</param>
		protected abstract void Recuperar(string chave);

		/// <summary>
		/// Ajusta o tempo de espera.
		/// </summary>
		/// <param name="alterada">Se a chave foi alterada enquanto pesquisava.</param>
		/// <param name="chaveLocal">Chave local da pesquisa realizada.</param>
		/// <param name="momentoAlteração">Momento de última pesquisa.</param>
		private void AjustarTempo(bool alterada, string chaveLocal, DateTime momento)
		{
			if (alterada)
			{
				// Penalizar.
				acréscimo = Math.Max(máximoAcréscimo, acréscimo + incrementoAcréscimo);
			}
			else if (acréscimo > mínimoAcréscimo)
			{
				// Favorecer.
				acréscimo = Math.Max(mínimoAcréscimo, acréscimo - decrementoAcréscimo);
			}
		}

		/// <summary>
		/// Calcula tempo de espera por alteração.
		/// </summary>
		public int CalcularTempoEsperaAlteração()
		{
			if (taxaDigitação.Registros >= 2)
				return tempoEsperaAlteração = (int) Math.Min(Math.Round(taxaDigitação.CalcularIntervalo()) + acréscimo, tempoEsperaAlteraçãoMáximo);
            else
            {
                tempoEsperaAlteração = tempoEsperaAlteração / 2;
                if (tempoEsperaAlteração < tempoEsperaAlteraçãoInicial)
                    tempoEsperaAlteração = tempoEsperaAlteraçãoInicial;

                return tempoEsperaAlteração;
            }
		}

        /// <summary>
        /// Deve ser chamado, quando o usuário retorna para a tela em que há o controle.
        /// Se a tela limpa o campo de busca, este método deve ser chamado
        /// Evita que o usuário não consiga fazer a última presquiza.
        /// </summary>
        public void Reinicializar()
        {
            últimaBusca = null;
        }
	}
}
