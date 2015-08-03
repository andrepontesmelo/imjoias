using System;
using System.Threading;

namespace Apresenta��o.Formul�rios.Consultas
{
	/// <summary>
	/// Coleta dados do banco de dados
	/// </summary>
	public abstract class Coletor
	{
		// Constantes
		private const int		tempoEsperaAltera��oInicial = 10;		// milissegundo
		private const int		tempoEsperaAltera��oM�ximo  = 200;		// milissegundo
		private const int       m�nimoAcr�scimo             = 10;		// milissegundo
		private const int       m�ximoAcr�scimo             = 700;
		private const int       incrementoAcr�scimo         = 50;
		private const int       decrementoAcr�scimo         = 5;

		// Atributos
		private volatile string chave;					// Chave a ser pesquisada
		private volatile bool	alterada;				// Chave foi alterada
		private volatile bool	pesquisando;			// Se a thread est� pesquisando
		private volatile string	�ltimaBusca = null;		// Grava para que duas buscas identicas n�o sejam poss�veis.
		private bool			ignorarTamanhoLetra = true; // Ignorar mai�sculo e min�sculo
		private volatile bool	cancelar = false;
		private volatile bool   ignorarAltera��o = false; // For�a a pesquisa, se o prefixo for o mesmo.
		private TaxaDigita��o   taxaDigita��o;
        private volatile bool   suspenso = false;

        /// <summary>
        /// Acr�scimo ao tempo dado como penaliza��o
        /// para espera por digita��o.
        /// </summary>
		private volatile int    acr�scimo;

        /// <summary>
        /// Tempo de espera por altera��o, antes de se realizar
        /// a pesquisa.
        /// </summary>
		private volatile int	tempoEsperaAltera��o;

		// Evento in�cio de busca
		public delegate void In�cioDeBuscaDelegate();
		public event In�cioDeBuscaDelegate In�cioDeBusca;

		// Evento final de busca
		public delegate void FinalDeBuscaDelegate();
		public event FinalDeBuscaDelegate FinalDeBusca;

        // M�todos ass�ncronos
        private delegate void LoopRecupera��oCallback();
        private LoopRecupera��oCallback m�todoLoopRecupera��o;
        private AsyncCallback callbackLoopRecupera��o;

        /// <summary>
        /// Verifica se o coletor est� suspenso.
        /// </summary>
        public bool Suspenso
        {
            get { return suspenso; }
        }

        /// <summary>
        /// Momento em que ocorreu a �ltima tecla digitada.
        /// </summary>
        public TimeSpan �ltimaDigita��o
        {
            get { return taxaDigita��o.�ltimoRegistro - DateTime.Now; }
        }

        /// <summary>
        /// Taxa m�dia de digita��o (ms/tecla)
        /// </summary>
        public double TaxaM�diaDigita��o
        {
            get { return taxaDigita��o.CalcularIntervalo(); }
        }

		/// <summary>
		/// Constr�i o coletor
		/// </summary>
		public Coletor()
		{
			taxaDigita��o           = new TaxaDigita��o();
			acr�scimo               = m�nimoAcr�scimo;
			tempoEsperaAltera��o    = tempoEsperaAltera��oInicial;
            m�todoLoopRecupera��o   = new LoopRecupera��oCallback(LoopRecupera��o);
            callbackLoopRecupera��o = new AsyncCallback(CallbackLoopRecupera��o);
		}

		#region Propriedades

		/// <summary>
		/// N�o diferenciar letra mai�scula de letra min�scula
		/// </summary>
		public bool IgnorarMai�sculoMin�sculo
		{
			get { return ignorarTamanhoLetra; }
			set { ignorarTamanhoLetra = value; }
		}

		/// <summary>
		/// Se o coletor est� pesquisando
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
		/// �ltima chave procurada.
		/// </summary>
		protected string �ltimaChave
		{
			get { return �ltimaBusca; }
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
        /// Retorna da suspens�o, permitindo novas pesquisas.
        /// </summary>
        /// <remarks>
        /// Ao recome�ar, uma eventual pesquisa interrompida
        /// N�O � RECOME�ADA. Ap�s este m�todo, apenas novas
        /// pesquisas ser�o realizadas.
        /// </remarks>
        public void Recome�ar()
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
                if (ignorarAltera��o && !chave.StartsWith(this.chave))
                    ignorarAltera��o = false;

                // Atribuir novo valor de chave
                this.chave = chave;
                this.alterada = true;

                taxaDigita��o.Registrar();

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
		/// Ativa a thread de procura, chamada quando o usu�rio
		/// aperta enter nos campos de busca.
		/// </summary>
		public void ProcurarImediatamente()
		{
            if (!suspenso)
            {
                cancelar = false;
                ignorarAltera��o = true;

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
                    m�todoLoopRecupera��o.BeginInvoke(callbackLoopRecupera��o, null);
                }
        }

        /// <summary>
        /// Ocorre ao t�rmino da recupera��o.
        /// </summary>
        /// <param name="resultado">Resultado da chamada ass�ncrona.</param>
        private void CallbackLoopRecupera��o(IAsyncResult resultado)
        {
            m�todoLoopRecupera��o.EndInvoke(resultado);
            
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
        private void LoopRecupera��o()
        {
            // Aguardar altera��es serem realizadas
            do
            {
                while (alterada && !ignorarAltera��o)
                {
                    alterada = false;
                    int tempoDormir = CalcularTempoEsperaAltera��o();
                    Console.WriteLine("Zzz..." + tempoDormir.ToString());
                    Thread.Sleep(tempoDormir);
                }

                if (!cancelar)
                {
                    try
                    {
                        ignorarAltera��o = false;
                        RealizarPesquisa();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());

#if DEBUG
                        System.Windows.Forms.MessageBox.Show(e.ToString());
#endif

                        Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(new Exception("Exce��o ignorada.", e));
                    }
                }

                /* Enquanto isso, podem ser feitas
                 * outras altera��es, necessitando
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
			DateTime debugIn�cio = DateTime.Now;
			Console.WriteLine("~ Coletor: Realizando pesquisa...");
#endif

#if DEBUG
			if (chave == null)
			{
				System.Windows.Forms.MessageBox.Show("Chave n�o pode ser nula!");

				throw new ApplicationException("Chave n�o pode ser nula!");
			}
#else
			// Este m�todo causou uma estranha excess�o dizendo que chave � nula.
			// A verifica��o contorna o problema:
			if (chave == null)
				return;
#endif

			lock (chave)
			{
				chaveLocal = chave;

				momento = taxaDigita��o.�ltimoRegistro;

				// Verificar se a busca � repetida
				if (!((!ignorarTamanhoLetra && �ltimaBusca == chaveLocal)
					|| (ignorarTamanhoLetra && string.Compare(�ltimaBusca, chaveLocal, true) == 0)))
				{
					// Dispara um evento para informar in�cio de busca
					if (In�cioDeBusca != null) 
						In�cioDeBusca();

#if DEBUG
					//Console.WriteLine("~ Coletor: Recuperando...");
#endif
					Recuperar(chaveLocal);
#if DEBUG
					//Console.WriteLine("~ Coletor: Dados recuperados!");
#endif
					�ltimaBusca = chaveLocal;
				}
			}

			AjustarTempo(alterada, chaveLocal, momento);

#if DEBUG
			TimeSpan debugDif = DateTime.Now - debugIn�cio;
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
		/// <param name="momentoAltera��o">Momento de �ltima pesquisa.</param>
		private void AjustarTempo(bool alterada, string chaveLocal, DateTime momento)
		{
			if (alterada)
			{
				// Penalizar.
				acr�scimo = Math.Max(m�ximoAcr�scimo, acr�scimo + incrementoAcr�scimo);
			}
			else if (acr�scimo > m�nimoAcr�scimo)
			{
				// Favorecer.
				acr�scimo = Math.Max(m�nimoAcr�scimo, acr�scimo - decrementoAcr�scimo);
			}
		}

		/// <summary>
		/// Calcula tempo de espera por altera��o.
		/// </summary>
		public int CalcularTempoEsperaAltera��o()
		{
			if (taxaDigita��o.Registros >= 2)
				return tempoEsperaAltera��o = (int) Math.Min(Math.Round(taxaDigita��o.CalcularIntervalo()) + acr�scimo, tempoEsperaAltera��oM�ximo);
            else
            {
                tempoEsperaAltera��o = tempoEsperaAltera��o / 2;
                if (tempoEsperaAltera��o < tempoEsperaAltera��oInicial)
                    tempoEsperaAltera��o = tempoEsperaAltera��oInicial;

                return tempoEsperaAltera��o;
            }
		}

        /// <summary>
        /// Deve ser chamado, quando o usu�rio retorna para a tela em que h� o controle.
        /// Se a tela limpa o campo de busca, este m�todo deve ser chamado
        /// Evita que o usu�rio n�o consiga fazer a �ltima presquiza.
        /// </summary>
        public void Reinicializar()
        {
            �ltimaBusca = null;
        }
	}
}
