using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Apresenta��o.Formul�rios.Consultas;
using Entidades;
using Balloon.NET;
using Entidades.Mercadoria;
using Neg�cio;

namespace Apresenta��o.Mercadoria
{
	/// <summary>
	/// TextBox para preenchimento da refer�ncia de mercadoria.
	/// </summary>
	public class TxtMercadoria : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Taxa de milissegundos/tecla que implica em velocidade
        /// m�xima considerada para um ser humano. Caso o valor da
        /// taxa seja menor, ser� considerado a digita��o de c�digo
        /// de barras.
		/// </summary>
        private const int taxaM�ximaDigita��oHumana = 15;

        // Taxa muito lenta. Em 3 semanas, uma vez detectou digita��o manual como c�digo de barras
        //private const int taxaM�ximaDigita��oHumana = 60;	 

#if ENSINAR_REPETI��O
        /// <summary>
        /// Determina o intervalo m�nimo entre repeti��es de exibi��o
        /// de bal�o, expresso em segundos.
        /// </summary>
        private const int intervaloRepeti��oBal�o = 60 * 15;    /* segundos */
#endif

        /// <summary>
        /// Determina o tempo de validade de uma entrada de mercadoria
        /// para que uma repeti��o implique em um desperd�cio de
        /// digita��o redundante de refer�ncia. Caso a mesma refer�ncia
        /// seja entrada duas vezes em um tempo inferior � validade para
        /// repeti��o, ser� exibido um bal�o instruindo o usu�rio a utilizar
        /// atalhos para repeti��o de mercadoria.
        /// </summary>
        private const int validadeParaRepeti��o = 60; /* segundos */
		
		// Atributos
		private ColetorMercadoria	coletor;
		private ListViewMercadoria	lst;
		private bool                refer�nciaCadastrada = false;
        private string              refer�nciaAnterior;
        private Tabela              tabela = null;

        /// <summary>
        /// Ignora verifica��o de taxa de digita��o, for�ando
        /// a considera��o de que � uma digita��o manual.
        /// </summary>
        /// <remarks>
        /// �til quando digita��o se inicia com TextBox j�
        /// parcialmente preenchido.
        /// </remarks>
        private bool for�arManual = false;

        /// <summary>
        /// Determina a �ltima vez que o TxtMercadoria foi utilizado.
        /// Este valor � utilizado para determinar se ser� exibido
        /// ou n�o o bal�o para aux�lio na redigita��o de mensagens.
        /// </summary>
        private DateTime �ltimoUso;

#if ENSINAR_REPETI��O
        /// <summary>
        /// Determina a �ltima vez que o bal�o de repeti��o apareceu.
        /// </summary>
        private DateTime �ltimoBal�oRepeti��o;
#endif

		// Propriedades
		private bool utilizarListView             = true;	
		private bool utilizarCompletarRefer�ncia  = true;
		private bool mostrarBal�oRefN�oEncontrada = true; 

        /// <summary>
        /// Usado com mudan�a de foco. 
        /// Mostrar ou n�o a lista ou quando obter os dados.
        /// </summary>
		private bool mostrarLista                 = false;
		private bool permitirSomenteCadastrado    = false;
        private bool permitirSomenteDelinha       = false;

        /// <summary>
        /// Determina se j� foi disparada a confirma��o de refer�ncia.
        /// </summary>
        private bool confirmada = false;

        /// <summary>
        /// Controle de edi��o de peso.
        /// </summary>
        private AMS.TextBox.NumericTextBox controlePeso;

		// Eventos
		public event EventHandler Refer�nciaAlterada;
        public event EventHandler EscPressionado;


        /// <summary>
        /// Refer�ncia est� confirmada como cadastrada no
        /// banco de dados.
        /// </summary>
        [Description("Refer�ncia entrada encontra-se cadastrada no banco de dados.")]
		public event EventHandler	Refer�nciaConfirmada;

		// Controle
		private AMS.TextBox.MaskedTextBox		txt;
        private PictureBox imagem;
        private ToolTip toolTip;
        private BackgroundWorker bgPrepararMercadoria;
        private IContainer components;


        /// <summary>
        /// Constr�i o TxtMercadoria.
        /// </summary>
		public TxtMercadoria()
		{
			InitializeComponent();
		}


        /// <summary>
        /// Dispara confirma��o de refer�ncia.
        /// </summary>
        void ConfirmarRefer�ncia()
        {
            Entidades.Mercadoria.Mercadoria m = Mercadoria;

            if (!confirmada)
            {
                confirmada = true;

                if (controlePeso != null)
                {
                    if (m != null)
                    {
                        if (m.DePeso)
                            controlePeso.Enabled = true;
                        else
                        {
                            controlePeso.Enabled = false;
                            controlePeso.Double = m.Peso;
                        }
                    }
                }

                if (Refer�nciaConfirmada != null)
                    Refer�nciaConfirmada(this, new EventArgs());

                if (m != null && m.ForaDeLinha)
                {
                    try
                    {
                        Bal�oRefer�nciaForaDeLinha bal�o = new Bal�oRefer�nciaForaDeLinha();

                        bal�o.ShowBalloon(this);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "Aten��o!\n\nEsta mercadoria est� fora de linha!",
                            "Mercadoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                    }
                }
            }
        }

        /// <summary>
        /// Libera recursos.
        /// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txt = new AMS.TextBox.MaskedTextBox();
            this.imagem = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bgPrepararMercadoria = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Flags = 0;
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Mask = "###.###.##.###-#";
            this.txt.MaxLength = 16;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(382, 20);
            this.txt.TabIndex = 0;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            this.txt.Move += new System.EventHandler(this.txt_Move);
            this.txt.Resize += new System.EventHandler(this.txt_Move);
            this.txt.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // imagem
            // 
            this.imagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagem.BackColor = System.Drawing.SystemColors.Window;
            this.imagem.Location = new System.Drawing.Point(363, 2);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(16, 16);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagem.TabIndex = 1;
            this.imagem.TabStop = false;
            this.imagem.Visible = false;
            // 
            // bgPrepararMercadoria
            // 
            this.bgPrepararMercadoria.WorkerSupportsCancellation = true;
            this.bgPrepararMercadoria.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrepararMercadoria);
            this.bgPrepararMercadoria.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AoPrepararMercadoria);
            // 
            // TxtMercadoria
            // 
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.txt);
            this.Name = "TxtMercadoria";
            this.Size = new System.Drawing.Size(382, 24);
            this.Resize += new System.EventHandler(this.txtMercadoria_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Propriedades

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public Tabela Tabela
        {
            get { return tabela; }
            set
            {
                tabela = value;
                
                if (coletor != null)
                    coletor.Tabela = value;
            }
        }

		/// <summary>
		/// Controle de peso
		/// </summary>
        [Browsable(true), DefaultValue(null)]
		public AMS.TextBox.NumericTextBox ControlePeso
		{
			get { return controlePeso; }
			set { controlePeso = value; }
		}

		/// <summary>
		/// Informa se digita��o imediata est� sendo manual
		/// ou via leitor optico.
		/// </summary>
        [Browsable(false)]
		public bool Digita��oManual
		{
			get
            {
                /* O controle de tempo � ruim nas primeiras digita��es. 
                 * pois a m�dia no in�cio seja baixa, e assim c�digos
                 * humanos s�o interpretados como barras. Por isto, 
                 * o OU (||) abaixo melhora o acerto, uma vez que s�
                 * existem c�digo-de-barras 6 ou mais d�gitos.
                 * 
                 * Uma alternativa seria iniciar o controle de tempo
                 * com valores m�dios, ao inv�s de iniciar zerado.
                 */

                if (coletor == null) 
                    return true;
                
                return for�arManual || (coletor.TaxaM�diaDigita��o >= taxaM�ximaDigita��oHumana)
                    || (txt.Text.Length <= 5);
            }
		}

		[Browsable(true), DefaultValue(true), Description("Mostrar a listview para auxiliar o usu�rio na escolha da refer�ncia correta")]
		public bool UtilizarListView
		{
			get { return utilizarListView; }
			set { utilizarListView = value; }
		}

		[Browsable(true), DefaultValue(true), Description("Quando o usu�rio pressionar enter ou asterisco, o controle completa com a refer�ncia mais pr�xima")]
		public bool UtilizarCompletarRefer�ncia
		{
			get { return utilizarCompletarRefer�ncia; }
			set { utilizarCompletarRefer�ncia = value; }
		}

		[Browsable(true), DefaultValue(true), Description("Assim que o usu�rio solicita uma refer�ncia n�o encontrada, a caixa mostra um bal�o com a mensagem.")]
		public bool MostrarBal�oRefN�oEncontrada
		{
			get { return mostrarBal�oRefN�oEncontrada; }
			set { mostrarBal�oRefN�oEncontrada = value; }
		}

		/// <summary>
		/// Informa se a refer�ncia entrada � cadastrada ou n�o no BD.
		/// N�o faz consulta ao BD.
		/// Informa��o sempre atualizada, n�o precisando que o usu�rio saida da caixa de texto
		/// para atualizar.
		/// </summary>
        [Browsable(false)]
		public bool Refer�nciaCadastrada
		{
			get { return refer�nciaCadastrada; }
		}

		/// <summary>
		/// N�mero escrito na caixa, n�o necessariamente v�lido.
		/// </summary>
        /// <remarks>
        /// A refer�ncia num�rica n�o deve incorporar o d�gito verificador.
        /// </remarks>
        [Browsable(false)]
		public string Refer�nciaNum�rica
		{
			get 
            {
                return txt.NumericText.Length == 12 ? txt.NumericText.Substring(0, txt.NumericText.Length - 1) : 
                    txt.NumericText;
            }
		}

		/// <summary>
		/// Mercadoria atual.
		/// </summary>
        [Browsable(false)]
		public Entidades.Mercadoria.Mercadoria Mercadoria
		{
			get
			{
				Entidades.Mercadoria.Mercadoria mercadoria = null;

                if (refer�nciaCadastrada)
                {
                    /* Mercadoria retornada deve ser fresca do Bd.
                     * Caso seja cacheada, v�rios saquinhos da bandeja
                     * poder�o referenciar a mesma mercadoria.
                     */
                    //if (lst != null)
                        //mercadoria = lst.ObterMercadoriaLista(txt.Text);

                    mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(txt.Text, tabela);

                    // Corrige o peso
                    if (mercadoria != null && mercadoria.DePeso && controlePeso != null)
                        mercadoria.Peso = controlePeso.Double;

                    return mercadoria;
                }
                else
                {
                    // Mercadoria nao cadastrada
                    return null;
                }

            }
		}

		#endregion

		/// <summary>
		/// Constr�i o coletor
		/// </summary>
		/// <remarks>
		/// Necess�rio que a ListView j� esteja constru�da.
		/// </remarks>
		private void ConstruirColetor()
		{
			// Constr�i o coletor
			coletor = new ColetorMercadoria(lst, tabela);
			coletor.In�cioDeBusca += new Apresenta��o.Formul�rios.Consultas.Coletor.In�cioDeBuscaDelegate(coletor_In�cioDeBusca);
			coletor.FinalDeBusca  += new Apresenta��o.Formul�rios.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
		}

		private delegate void MostrarListaCallback(bool mostrar);

		/// <summary>
		/// Define se a lista � exibida ou n�o.
		/// </summary>
		/// <param name="mostrar">Se deve mostrar a lista.</param>
		private void MostrarLista(bool mostrar)
		{
			if (lst.InvokeRequired)
			{
				MostrarListaCallback m�todo = new MostrarListaCallback(MostrarLista);
				lst.BeginInvoke(m�todo, new object[] { mostrar });
			}
			else
			{
				if (mostrar && this.mostrarLista && Focused)
				{
					lst.Visible = mostrar;
					lst.BringToFront();
				}
				else
					lst.Visible = false;
			}
		}

		/// <summary>
		/// Ocorre quando o coletor inicia sua busca
		/// </summary>
		private void coletor_In�cioDeBusca()
		{
			if (lst.Visible)
				MostrarLista(false);
        
            SinalizarProcura();
        }

		/// <summary>
		/// Ocorre quando o coletor finaliza sua busca
		/// </summary>
		private void coletor_FinalDeBusca()
		{
			// Verificar se controle cont�m o foco
            if (mostrarLista && txt.Text.Length > 0)
            {
                if (lst.Items.Count > 0)
                {
                    MostrarLista(true);
                    Dessinalizar();
                }
                else
                    SinalizarRefer�nciaInv�lida();
            }
            else
                Dessinalizar();
		}

		private delegate void ConstruirListViewCallback();

		/// <summary>
		/// Constr�i a ListView
		/// </summary>
		/// <remarks>
		/// Os m�todos que chamam, logo depois tem o segunte c�digo:
		/// Se coletor n�o � nulo, fecha coletor e abre um novo.
		/// este trecho foi retirado do ConstuirListView() porqu�
		/// existe o caso do listview n�o ser constuido, 
		/// e o coletor precisar ser construido
		/// que � o caso de ter a propriedade UtilizarListView = false 
		/// </remarks>
		private void ConstruirListView()
		{
			if (this.InvokeRequired)
			{
				ConstruirListViewCallback m�todo = new ConstruirListViewCallback(ConstruirListView);
				this.BeginInvoke(m�todo);
			}
			else
			{
#if DEBUG
				if ((!DesignMode) && (!utilizarListView))
					throw new Exception("Foi chamado ConstruirListView() com utilizarListView falso");
#endif

				// Constr�i a lista
				lst = new ListViewMercadoria();
				lst.Width = this.Width;
				lst.Height = this.Height * 10;
				lst.Name = this.Name + "Lista";
				lst.AoSelecionarMercadoria += new Apresenta��o.Mercadoria.ListViewMercadoria.Sele��oMercadoria(lst_AoSelecionarMercadoria);

                if (this.Parent == null)
                    return;

				// Adiciona ao formul�rio
				this.Parent.SuspendLayout();
				this.Parent.Controls.Add(lst);

				if (utilizarListView)
				{
					ReposicionarLista();
					lst.BringToFront();
				}

				this.Parent.ResumeLayout();

				//			txt.ForeColor = corTextoInconsistente;

				ConstruirColetor();
			}
		}

		/// <summary>
		/// Reposiciona lista
		/// </summary>
		private void ReposicionarLista()
		{
#if DEBUG
			if ((!DesignMode) && (!utilizarListView))
				throw new Exception("Foi chamado ReposicionarLista() com utilizarListView falso!");
#endif

			if (lst != null)
			{
				lst.Width	= this.Width;
				lst.Left	= this.Left;
				lst.Top		= this.Top + this.Height;
				lst.Height	= this.Height * 10;

				if (lst.Height + lst.Top > this.Parent.Height)
					lst.Height = this.Parent.Height - lst.Top;
			}
		}

		/// <summary>
		/// Ocorre quando o texto � alterado
		/// </summary>
		private void txt_TextChanged(object sender, System.EventArgs e)
		{
            if (txt.Text.Length == txt.MaxLength)
            {
                if (coletor != null)
                    coletor.Cancelar();

                refer�nciaCadastrada = Entidades.Mercadoria.Mercadoria.VerificarExist�ncia(txt.Text, true);

                if (refer�nciaCadastrada)
                    Dessinalizar();
                else if (Focused)
                    SinalizarRefer�nciaInv�lida();
            }
            else
            {
                refer�nciaCadastrada = false;

                if (txt.Text.Length == 0)
                {
                    for�arManual = false;

                    if (Focused && refer�nciaAnterior != null)
                        SinalizarRepeti��oPoss�vel();
                }
            }

			if (coletor == null && utilizarListView && Focused)
				ConstruirListView();

			if (coletor != null && mostrarLista && Focused && !refer�nciaCadastrada)
			{
				coletor.Pesquisar(txt.Text);

				if (txt.Text.Length == 10)
					coletor.ProcurarImediatamente();
			}

            if (Refer�nciaAlterada != null)
                Refer�nciaAlterada(this, e);

            confirmada = false;
		}

		/// <summary>
		/// Ocorre quando o textbox ganha foco
		/// </summary>
		private void txt_Enter(object sender, System.EventArgs e)
		{
            bgPrepararMercadoria.CancelAsync();

			if (utilizarListView)
				mostrarLista = true;

            if (txt.Text.Length == 0 && refer�nciaAnterior != null)
                SinalizarRepeti��oPoss�vel();

            else if (refer�nciaAnterior != null)
                refer�nciaAnterior = null;
		}

		/// <summary>
		/// Ocorre quando o textbox perde o foco
		/// </summary>
		private void txt_Leave(object sender, System.EventArgs e)
		{
            �ltimoUso = DateTime.Now;

			lock (this)
			{
				mostrarLista = false;

				if (lst != null && lst.Visible)
					MostrarLista(false);
			}

			if (!refer�nciaCadastrada && mostrarBal�oRefN�oEncontrada && !Focused && (txt.NumericText.Length != 0))
			{
				Control controleAtual = this.ParentForm.ActiveControl;

				Bal�oRefer�nciaN�oEncontrada bal�o = new Bal�oRefer�nciaN�oEncontrada();
			
                bal�o.ShowBalloon(this.txt);
				controleAtual.Focus();

				Beepador.Bal�oRefer�nciaN�oEncontrada();
			}

#if ENSINAR_REPETI��O
            if ((txt.Text == refer�nciaAnterior) && Digita��oManual)
                EnsinarRepeti��o();
#endif

            if (refer�nciaCadastrada)
            {
                refer�nciaAnterior = txt.Text;
                ConfirmarRefer�ncia();
            }

            Dessinalizar();

            /* Aqui j� deu excessao dizendo que o Background n�o pode come�ar novo 
             * trabalho estando ele ocupado. Mesmo tento o trabalho j� cancelado anteriormente.
             */
            if (!bgPrepararMercadoria.IsBusy)
                bgPrepararMercadoria.RunWorkerAsync();
		}

		/// <summary>
		/// Ocorre quando o textbox muda de tamanho ou �
		/// redimensionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_Move(object sender, System.EventArgs e)
		{
			if (utilizarListView)
				ReposicionarLista();
		}

		/// <summary>
		/// Ocorre quando altera-se o tamanho da textbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtMercadoria_Resize(object sender, System.EventArgs e)
		{
			this.Height = txt.Height;
		}

		/// <summary>
		/// TextBox
		/// </summary>
		public TextBox Txt
		{
			get { return txt; }
		}
		
		/// <summary>
		/// Ocorre ao selecionar uma mercadoria no ListView
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia escolhida</param>
		private void lst_AoSelecionarMercadoria(string refer�ncia)
		{
			lock (this)
			{
				mostrarLista = false;
				txt.Text = refer�ncia;
				txt.Select(txt.SelectionStart, txt.Text.Length - txt.SelectionStart);
			}

			if (utilizarListView)
				mostrarLista = true;

			/* solu��o para bug:
			 * assim que voc� entra '1',
			 * e em seguida clica em alguma merc da lista,
			 * o valitating do txt � chamado, e aparece um bal�o
			 * de falando que mercadoria '1' n�o � v�lida.
			 * A solu��o foi chamar o validating novamente,
			 * assim que o usu�rio acaba de clicar no item da lista.
			 * Este validating ir� dar o dispose no bal�o que nem deveria
			 * ter aparecido.
			 * � dificil implementar de tal forma que o bal�o n�o apare�a,
			 * porque o validating ou o leave do txt s�o chamados antes do
			 * click ou index changed da lista. 
			 * Andr�, 12-mar�o-05
			 */
			txt_Validating(this, new CancelEventArgs());

            Dessinalizar();
		}

		/// <summary>
		/// Ocorre ao pressionar uma tecla no textbox
		/// </summary>
		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((coletor == null) && (utilizarListView))
				ConstruirListView();

            Dessinalizar();
            
            /* C�digo de barras somente funciona quando nenhum n�mero
             * foi digitado. Se algum n�mero j� tiver sido digitado em
             * um tempo maior que a digita��o do c�digo de barras, este
             * � um indicativo de que n�o se trata de c�digo de barras.
             */
            if (utilizarListView && txt.Text.Length > 0 && coletor.�ltimaDigita��o.Milliseconds > taxaM�ximaDigita��oHumana)
                for�arManual = true;

			// Verifica qual tecla foi pressionada.
			switch (e.KeyCode)
			{
				case Keys.Delete:
					this.txt.Text = "";
					break;

				case Keys.Down:
					if (lst != null && mostrarLista)
					{
						if (!lst.Visible)
						{
							coletor.ProcurarImediatamente();
						}
						else
						{
							lst.SelecionarPr�ximo();
							e.Handled = true;
						}
					}
					break;

				case Keys.Up:
					if (lst != null && mostrarLista)
					{
						if (!lst.Visible)
						{
							coletor.ProcurarImediatamente();
						}
						else
						{
							lst.SelecionarAnterior();
							e.Handled = true;
						}
					}
					break;

				case Keys.Multiply:
                    if (UtilizarCompletarRefer�ncia)
					    e.Handled = CompletarRefer�ncia();
					break;

				case Keys.Escape:
					MostrarLista(false);
                    txt.Text = "";
                    if (EscPressionado != null)
                        EscPressionado(null, null);
					break;

                case Keys.Enter:
                    if (Digita��oManual && UtilizarCompletarRefer�ncia)
                        e.Handled = CompletarRefer�ncia();
                    else
                    {
                        // Interpretar c�digo de barras:
                        if (lst != null)
                            MostrarLista(false);

                        if (txt.Text.Length == 0) return;

                        // Verificar c�digo de barras
                        if (txt.Text.Length < txt.Mask.Length)
                        {
                            if (coletor != null)
                                coletor.Cancelar();

                            if (!SubstituirC�digoBarras())
                            {
                                if (coletor != null)
                                    coletor.ProcurarImediatamente();

                                txt.Focus();
                            }
                            else
                                e.Handled = true;
                        }
                    }

                    if (e.Handled)
                    {
                        mostrarLista = false;
                        ConfirmarRefer�ncia();
                        mostrarLista = utilizarListView;
                    }
                    break;
            }
		}

        /// <summary>
        /// Completa a caixa com o resto da refer�ncia.
        /// </summary>
        /// <remarks>
        /// Este m�todo completa da seguinte maneira:
        /// - Se nada foi digitado, completa com a refer�ncia anterior;
        /// - Se a refer�ncia foi parcialmente digitada, completa
        ///   com a primeira refer�ncia que completa encontrada
        ///   no banco de dados.
        /// </remarks>
        /// <returns>
        /// Retorna verdadeiro se obteve sucesso.
        /// </returns>
        public bool CompletarRefer�ncia()
        {
            /* Isto n�o pode ser feito porque a refer�ncia pode ser inv�lida, 
             * necessitando verifica��o no banco de dados. Falso deve ser retornado nesse caso.
             */
            //if (txt.Text.Length == txt.MaxLength)
            //    return true;

            // Verificar se deve completar com refer�ncia anterior.
            if (txt.Text.Length == 0 && refer�nciaAnterior != null)
            {
                string aux = refer�nciaAnterior;
                refer�nciaAnterior = null;
                txt.Text = aux;
                return true;
            }
            /* S� � poss�vel continuar se existir o coletor.
             * O coletor s� existir� se existir ListView.
             * Portanto, � necess�ri oque o TxtMercadoria utilize
             * ListView para poder completar a refer�ncia.
             * -- J�lio, 20/06/2006
             */
            else if (utilizarListView)
            {
                string refer�ncia = null;

                UseWaitCursor = true;

                try
                {
                    try
                    {
                        string refNum�rica;
                        int d�gito;

                        Entidades.Mercadoria.Mercadoria.DesmascararRefer�ncia(txt.Text, out refNum�rica, out d�gito);

                        refer�ncia = coletor.RecuperarPrimeiroSomente(refNum�rica);

                        /* Como a consulta acima n�o verifica o d�gito,
                         * a condi��o abaixo garante que uma mercadoria digitada
                         * com d�gito errado n�o seja validada.
                         * -- J�lio, 10/01/2007
                         */
                        if (refer�ncia != null && !refer�ncia.StartsWith(txt.Text))
                            refer�ncia = null;
                    }
                    catch (NullReferenceException erro)
                    {
                        if (coletor == null && utilizarListView)
                        {
                            ConstruirListView();

                            return CompletarRefer�ncia();
                        }

                        throw new Exception("Erro ao completar refer�ncia " + txt.Text, erro);
                    }
                    catch (ArgumentException err)
                    {
                        Beepador.Erro();
                        MessageBox.Show(this, err.Message, "Erro ao procurar refer�ncia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (refer�ncia != null)
                    {
                        lock (this)
                        {
                            mostrarLista = false;

                            if (lst != null)
                                MostrarLista(false);

                            txt.Text = refer�ncia;
                        }

                        mostrarLista = utilizarListView;

                        Dessinalizar();

                        return true;
                    }

                    SinalizarRefer�nciaInv�lida();

                    return false;
                }
                finally
                {
                    UseWaitCursor = false;
                }
            }

            return false;
        }



		/// <summary>
		/// Valida��o da refer�ncia
		/// </summary>
		private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (txt.Text.Length > 0)
            {
                refer�nciaCadastrada = Entidades.Mercadoria.Mercadoria.VerificarExist�ncia(txt.Text, true);

                if (!refer�nciaCadastrada)
                {
                    //txt.ForeColor = corTextoInconsistente;

                    // Como nao t� cadastrado, qualquer exigencia � suficiente pra nao aceitar.
                    e.Cancel = permitirSomenteCadastrado || permitirSomenteDelinha;
                }
                else
                {
                    //txt.ForeColor = corTextoConsistente;

                    // Referencia est� cadastrada. Mas � de linha?
                    e.Cancel = e.Cancel || (SomenteDeLinha && Mercadoria.ForaDeLinha);
                }
            }
		}

		/// <summary>
		/// Refer�ncia, o que est� dentro da caixa. 
		/// </summary>
		[Bindable(true)]
		public string Refer�ncia
		{
			get { return txt.Text; }
			set
			{
				lock (this)
				{
					mostrarLista = false;
					txt.Text = value;
				}

                if (txt.Text.Length == 0)
                    SinalizarRepeti��oPoss�vel();
                else
                    Dessinalizar();
			}
		}

		/// <summary>
		/// Permitir somente refer�ncias cadastradas
		/// </summary>
		[DefaultValue(false),
			Description("Permitir somente refer�ncias cadastradas no banco de dados.")]
		public bool SomenteCadastrado
		{
			get { return permitirSomenteCadastrado; }
			set { permitirSomenteCadastrado = value; }
		}

        [DefaultValue(false)]
        public bool SomenteDeLinha
        {
            get { return permitirSomenteDelinha; }
            set {  permitirSomenteDelinha = value; }
        }

		public new event KeyEventHandler KeyDown
		{
			add { txt.KeyDown += value; }
			remove { txt.KeyDown -= value; }
		}

		public new event KeyEventHandler KeyUp
		{
			add { txt.KeyUp += value; }
			remove { txt.KeyUp -= value; }
		}

		/// <summary>
		/// Substitui c�digo de barras entrado por refer�ncia
		/// </summary>
		/// <returns>Se substitui��o foi feita com sucesso</returns>
		private bool SubstituirC�digoBarras()
		{
			string				 c�digoNum�rico = "";
			Entidades.Mercadoria.Mercadoria mercadoria;

			this.ParentForm.Cursor = Cursors.WaitCursor;

			mostrarLista = false;

			foreach (char c in txt.Text)
				if (Char.IsDigit(c))
					c�digoNum�rico += c;

			// Tentar decodificar c�digo de barras.
			try
			{
				mercadoria = Entidades.Mercadoria.Mercadoria.Interpretar(c�digoNum�rico, tabela);

                if (mercadoria == null)
                    throw new NullReferenceException("Erro interpretando c�digo de barras de n�mero " + c�digoNum�rico.ToString() + ". Mercadoria n�o foi encontrada.");

				this.txt.Text = mercadoria.Refer�ncia;

				if (controlePeso != null)
					controlePeso.Text = mercadoria.Peso.ToString(NumberFormatInfo.CurrentInfo);

                if (mercadoria.ForaDeLinha)
                {
                    Beepador.Erro();

                    MessageBox.Show(
                        this.ParentForm,
                        "A mercadoria " + mercadoria.Refer�ncia + " est� fora de linha. ",
                        "C�digo de barras inv�lido!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return false;
                }

                return true;
			}
			// Em caso de c�digo de barras inv�lido, apenas informar.
			catch (C�digoBarrasInv�lido e)
			{
				Beepador.Erro();

				MessageBox.Show(
					this.ParentForm,
					e.Message + "\r\n\r\n"
					+ "O c�digo de barras " + c�digoNum�rico + " n�o pode ser reconhecido. "
					+ "Tente a digita��o manual da refer�ncia.",
					"C�digo de barras inv�lido!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);

				return false;
			}
			// Em caso de erro interno, registrar ocorr�ncia.
			catch (Exception e)
			{
				Beepador.Erro();

				MessageBox.Show(
					this.ParentForm,
					e.Message + "\r\n\r\n"
					+ "Ocorreu um erro interno lendo o c�digo de barras " + c�digoNum�rico + ". "
					+ "Tente a digita��o manual da refer�ncia.",
					"C�digo de barras inv�lido!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);

				// Registrar ocorr�ncia de erro.
				try
				{
					Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
				}
				catch
				{
					MessageBox.Show("N�o foi poss�vel enviar um relat�rio sobre este erro.\n\n" + e.ToString(),
						"Relat�rio de Erros",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}

				return false;
			}
			finally
			{
				if (utilizarListView)
					mostrarLista = true;

				this.ParentForm.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Se o TxtMercadoria possui foco.
		/// </summary>
		public override bool Focused
		{
			get
			{
				return base.Focused || txt.Focused || (lst != null ? lst.Focused : false);
			}
		}

        private delegate void Sinaliza��oCallback();

        /// <summary>
        /// Sinaliza que � poss�vel fazer repeti��o.
        /// </summary>
        private void SinalizarRepeti��oPoss�vel()
        {
            if (DateTime.Now - �ltimoUso < TimeSpan.FromSeconds(validadeParaRepeti��o))
            {
                if (InvokeRequired)
                {
                    Sinaliza��oCallback m�todo = new Sinaliza��oCallback(SinalizarRepeti��oPoss�vel);

                    if (!Disposing)
                        BeginInvoke(m�todo);
                }
                else
                {
                    imagem.Tag = null;
                    imagem.Image = Resource.Refazer;

                    try
                    {
                        toolTip.SetToolTip(imagem, "Pressione ENTER ou clique aqui para repetir a �ltima refer�ncia: " + refer�nciaAnterior);
                    }
                    catch { }

                    imagem.Visible = true;
                    imagem.BringToFront();
                }
            }
        }

        /// <summary>
        /// Sinaliza que a refer�ncia que est� sendo digitada � inv�lida.
        /// </summary>
        private void SinalizarRefer�nciaInv�lida()
        {
            if (InvokeRequired)
            {
                Sinaliza��oCallback m�todo = new Sinaliza��oCallback(SinalizarRefer�nciaInv�lida);

                if (!Disposing) 
                    BeginInvoke(m�todo);
            }
            else
            {
                imagem.Tag = this.Refer�ncia;
                imagem.Image = Resource.Advert�ncia;

                try
                {
                    toolTip.SetToolTip(imagem, "N�o existe nenhuma refer�ncia com o prefixo digitado.");
                }
                catch
                {
                    // Adding the tip to the native ToolTip control did not succeed.
                }

                imagem.Visible = true;
                imagem.BringToFront();
            }
        }

        /// <summary>
        /// Sinaliza procura pela refer�ncia digitada.
        /// </summary>
        private void SinalizarProcura()
        {
            if (InvokeRequired)
            {
                Sinaliza��oCallback m�todo = new Sinaliza��oCallback(SinalizarProcura);

                if (!Disposing)
                    BeginInvoke(m�todo);
            }
            else
            {
                imagem.Tag = null;
                imagem.Image = Resource.Lupa;

                try
                {
                    toolTip.SetToolTip(imagem, "O sistema est� procurando a refer�ncia...");
                }
                catch { }

                imagem.Visible = true;
                imagem.BringToFront();
            }
        }

        /// <summary>
        /// Retira sinaliza��o.
        /// </summary>
        private void Dessinalizar()
        {
            if (InvokeRequired)
            {
                Sinaliza��oCallback m�todo = new Sinaliza��oCallback(Dessinalizar);
                
                if (!Disposing)
                    BeginInvoke(m�todo);
            }
            else if (imagem.Tag == null)
            {
                imagem.Visible = false;
                imagem.Image = null;

                try
                {
                    toolTip.SetToolTip(imagem, "");
                }
                catch { }
            }
        }

#if ENSINAR_REPETI��O
        /// <summary>
        /// Exibe bal�o ensinando como repetir a refer�ncia anterior.
        /// </summary>
        private void EnsinarRepeti��o()
        {
            if (DateTime.Now - �ltimoUso < TimeSpan.FromSeconds(validadeParaRepeti��o) && DateTime.Now - �ltimoBal�oRepeti��o > TimeSpan.FromSeconds(intervaloRepeti��oBal�o))
            {
                try
                {
                    if (InvokeRequired)
                    {
                        Sinaliza��oCallback m�todo = new Sinaliza��oCallback(EnsinarRepeti��o);
                        BeginInvoke(m�todo);
                    }
                    else
                    {
                        Control controleAtual;

                        if (ParentForm != null)
                            controleAtual = this.ParentForm.ActiveControl;
                        else
                            controleAtual = null;

                        Bal�oRefer�nciaRedigitada bal�o = new Bal�oRefer�nciaRedigitada();

                        bal�o.ShowBalloon(this);

                        if (controleAtual != null)
                            controleAtual.Focus();

                        �ltimoBal�oRepeti��o = DateTime.Now;
                    }
                }
                catch (Exception e)
                {
#if DEBUG
                    MessageBox.Show(e.ToString());
#endif
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
            }
        }
#endif

        /// <summary>
        /// Ocorre em segundo plano, preparando dados da
        /// mercadoria para uso no programa.
        /// </summary>
        private void PrepararMercadoria(object sender, DoWorkEventArgs e)
        {
            try
            {
                Entidades.Mercadoria.Mercadoria mercadoria = this.Mercadoria;

                if (mercadoria != null)
                {
#if DEBUG
                    Console.WriteLine("TxtMercadoria: Preparando mercadoria...");
#endif
                    mercadoria.Preparar();
                }

                e.Result = mercadoria;
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);

#if DEBUG
                MessageBox.Show(erro.ToString());
#endif
            }
        }

        /// <summary>
        /// Ocorre ao preparar a mercadoria.
        /// </summary>
        private void AoPrepararMercadoria(object sender, RunWorkerCompletedEventArgs e)
        {
            if (refer�nciaCadastrada && e.Result != null && this.Mercadoria == (Entidades.Mercadoria.Mercadoria)e.Result)
            {
                imagem.Tag = Mercadoria;
                imagem.Image = Mercadoria.�cone;
                imagem.Visible = true;
                imagem.BringToFront();
#if DEBUG
                Console.WriteLine("TxtMercadoria: Mercadoria preparada.");
#endif
            }
        }
    }
}
