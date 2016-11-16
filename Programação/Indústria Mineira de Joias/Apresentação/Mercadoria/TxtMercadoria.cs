using Entidades;
using Entidades.Mercadoria;
using Negócio;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public class TxtMercadoria : UserControl
	{
        private const int taxaMáximaDigitaçãoHumana = 15;
        private const int validadeParaRepetição = 60;

        private bool utilizarListView = true;
		private bool utilizarCompletarReferência = true;
		private bool mostrarBalãoRefNãoEncontrada = true; 
		private bool mostrarLista                 = false;
		private bool permitirSomenteCadastrado    = false;
        private bool permitirSomenteDelinha       = true;
        private bool confirmada = false;
        private ColetorMercadoria coletor;
        private ListViewMercadoria lst;
        private bool referênciaCadastrada = false;
        private string referênciaAnterior;
        private Tabela tabela = null;
        private bool forçarManual = false;
        private DateTime últimoUso;

        private AMS.TextBox.NumericTextBox controlePeso;
        private AMS.TextBox.MaskedTextBox txt;
        private PictureBox imagem;
        private ToolTip toolTip;
        private BackgroundWorker bgPrepararMercadoria;
        private IContainer components;

        [Description("Referência entrada encontra-se cadastrada no banco de dados.")]
        public event EventHandler ReferênciaConfirmada;
        public event EventHandler ReferênciaAlterada;
        public event EventHandler EscPressionado;

		public TxtMercadoria()
		{
			InitializeComponent();
		}

        void ConfirmarReferência()
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

                if (ReferênciaConfirmada != null)
                    ReferênciaConfirmada(this, new EventArgs());

                if (m != null && m.ForaDeLinha)
                {
                    try
                    {
                        BalãoReferênciaForaDeLinha balão = new BalãoReferênciaForaDeLinha();

                        balão.ShowBalloon(this);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "Atenção!\n\nEsta mercadoria está fora de linha!",
                            "Mercadoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                    }
                }
            }
        }

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
		/// Informa se digitação imediata está sendo manual
		/// ou via leitor optico.
		/// </summary>
        [Browsable(false)]
		public bool DigitaçãoManual
		{
			get
            {
                /* O controle de tempo é ruim nas primeiras digitações. 
                 * pois a média no início seja baixa, e assim códigos
                 * humanos são interpretados como barras. Por isto, 
                 * o OU (||) abaixo melhora o acerto, uma vez que só
                 * existem código-de-barras 6 ou mais dígitos.
                 * 
                 * Uma alternativa seria iniciar o controle de tempo
                 * com valores médios, ao invés de iniciar zerado.
                 */

                if (coletor == null) 
                    return true;
                
                return forçarManual || (coletor.TaxaMédiaDigitação >= taxaMáximaDigitaçãoHumana)
                    || (txt.Text.Length <= 5);
            }
		}

		[Browsable(true), DefaultValue(true), Description("Mostrar a listview para auxiliar o usuário na escolha da referência correta")]
		public bool UtilizarListView
		{
			get { return utilizarListView; }
			set { utilizarListView = value; }
		}

		[Browsable(true), DefaultValue(true), Description("Quando o usuário pressionar enter ou asterisco, o controle completa com a referência mais próxima")]
		public bool UtilizarCompletarReferência
		{
			get { return utilizarCompletarReferência; }
			set { utilizarCompletarReferência = value; }
		}

		[Browsable(true), DefaultValue(true), Description("Assim que o usuário solicita uma referência não encontrada, a caixa mostra um balão com a mensagem.")]
		public bool MostrarBalãoRefNãoEncontrada
		{
			get { return mostrarBalãoRefNãoEncontrada; }
			set { mostrarBalãoRefNãoEncontrada = value; }
		}

		/// <summary>
		/// Informa se a referência entrada é cadastrada ou não no BD.
		/// Não faz consulta ao BD.
		/// Informação sempre atualizada, não precisando que o usuário saida da caixa de texto
		/// para atualizar.
		/// </summary>
        [Browsable(false)]
		public bool ReferênciaCadastrada
		{
			get { return referênciaCadastrada; }
		}

		/// <summary>
		/// Número escrito na caixa, não necessariamente válido.
		/// </summary>
        /// <remarks>
        /// A referência numérica não deve incorporar o dígito verificador.
        /// </remarks>
        [Browsable(false)]
		public string ReferênciaNumérica
		{
			get 
            {
                return txt.NumericText.Length == 12 ? txt.NumericText.Substring(0, txt.NumericText.Length - 1) : 
                    txt.NumericText;
            }
		}

        private void CorrigePeso(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            // Corrige o peso
            if (mercadoria != null && mercadoria.DePeso && controlePeso != null)
                mercadoria.Peso = controlePeso.Double;
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

                if (referênciaCadastrada)
                {
                    mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoriaComCache(txt.Text, tabela);

                    CorrigePeso(mercadoria);

                    return mercadoria;
                }

                return null;
            }
		}

		#endregion

		private void ConstruirColetor()
		{
			coletor = new ColetorMercadoria(lst, tabela);
            coletor.SomenteDeLinha = permitirSomenteDelinha;
			coletor.InícioDeBusca += new Apresentação.Formulários.Consultas.Coletor.InícioDeBuscaDelegate(coletor_InícioDeBusca);
			coletor.FinalDeBusca  += new Apresentação.Formulários.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
		}

		private delegate void MostrarListaCallback(bool mostrar);

		private void MostrarLista(bool mostrar)
		{
			if (lst.InvokeRequired)
			{
				MostrarListaCallback método = new MostrarListaCallback(MostrarLista);
				lst.BeginInvoke(método, new object[] { mostrar });
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

		private void coletor_InícioDeBusca()
		{
			if (lst.Visible)
				MostrarLista(false);
        
            SinalizarProcura();
        }

		private void coletor_FinalDeBusca()
		{
            if (mostrarLista && txt.Text.Length > 0)
            {
                if (lst.Items.Count > 0)
                {
                    MostrarLista(true);
                    Dessinalizar();
                }
                else
                    SinalizarReferênciaInválida();
            }
            else
                Dessinalizar();
		}

		private delegate void ConstruirListViewCallback();

		private void ConstruirListView()
		{
			if (this.InvokeRequired)
			{
				ConstruirListViewCallback método = new ConstruirListViewCallback(ConstruirListView);
				this.BeginInvoke(método);
			}
			else
			{
                ConstruirAdicionarLista();
				ConstruirColetor();
			}
		}

        private void ConstruirAdicionarLista()
        {
            ConstruirLista();
            AdicionarListaFormulário();
        }

        private void AdicionarListaFormulário()
        {
            if (this.Parent == null)
                return;

            this.Parent.SuspendLayout();
            this.Parent.Controls.Add(lst);

            if (utilizarListView)
            {
                ReposicionarLista();
                lst.BringToFront();
            }

            this.Parent.ResumeLayout();
        }

        private void ConstruirLista()
        {
            lst = new ListViewMercadoria();
            lst.Width = this.Width;
            lst.Height = this.Height * 10;
            lst.Name = this.Name + "Lista";
            lst.AoAlterarMercadoriaSelecionada += new ListViewMercadoria.SeleçãoMercadoria(lst_AoAlterarMercadoriaSelecionada);
            lst.AoSelecionarMercadoria += Lst_AoSelecionarMercadoria;
        }

        private void Lst_AoSelecionarMercadoria(string referência)
        {
            ConfirmarReferência();
        }

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

		private void txt_TextChanged(object sender, System.EventArgs e)
		{
            if (txt.Text.Length == txt.MaxLength)
            {
                if (coletor != null)
                    coletor.Cancelar();

                referênciaCadastrada = Entidades.Mercadoria.Mercadoria.VerificarExistência(txt.Text, true);

                if (referênciaCadastrada)
                    Dessinalizar();
                else if (Focused)
                    SinalizarReferênciaInválida();
            }
            else
            {
                referênciaCadastrada = false;

                if (txt.Text.Length == 0)
                {
                    forçarManual = false;

                    if (Focused && referênciaAnterior != null)
                        SinalizarRepetiçãoPossível();
                }
            }

			if (coletor == null && utilizarListView && Focused)
				ConstruirListView();

			if (coletor != null && mostrarLista && Focused && !referênciaCadastrada)
			{
				coletor.Pesquisar(txt.Text);

				if (txt.Text.Length == 10)
					coletor.ProcurarImediatamente();
			}

            if (ReferênciaAlterada != null)
                ReferênciaAlterada(this, e);

            confirmada = false;
		}

		private void txt_Enter(object sender, System.EventArgs e)
		{
            bgPrepararMercadoria.CancelAsync();

			if (utilizarListView)
				mostrarLista = true;

            if (txt.Text.Length == 0 && referênciaAnterior != null)
                SinalizarRepetiçãoPossível();

            else if (referênciaAnterior != null)
                referênciaAnterior = null;
		}

        private bool deveMostrarBalão()
        {
            return !referênciaCadastrada && mostrarBalãoRefNãoEncontrada && !Focused && (txt.NumericText.Length != 0);
        }

		private void txt_Leave(object sender, System.EventArgs e)
		{
            if (!ValidateChildren())
            {
                txt.Text = "";
                return;
            }

            últimoUso = DateTime.Now;

			lock (this)
			{
				mostrarLista = false;

				if (lst != null && lst.Visible)
					MostrarLista(false);
			}

            if (deveMostrarBalão())
                MostrarBalão();


            if (referênciaCadastrada)
            {
                referênciaAnterior = txt.Text;
                ConfirmarReferência();
            }

            Dessinalizar();

            if (!bgPrepararMercadoria.IsBusy)
                bgPrepararMercadoria.RunWorkerAsync();
		}

        private void MostrarBalão()
        {
            Control controleAtual = this.ParentForm.ActiveControl;

            BalãoReferênciaNãoEncontrada balão = new BalãoReferênciaNãoEncontrada();

            balão.ShowBalloon(this.txt);
            controleAtual.Focus();

            Beepador.BalãoReferênciaNãoEncontrada();
        }

        private void txt_Move(object sender, System.EventArgs e)
		{
			if (utilizarListView)
				ReposicionarLista();
		}

		private void txtMercadoria_Resize(object sender, System.EventArgs e)
		{
			this.Height = txt.Height;
		}

        public TextBox Txt => txt; 
		
		private void lst_AoAlterarMercadoriaSelecionada(string referência)
		{
			lock (this)
			{
				mostrarLista = false;
				txt.Text = referência;
				txt.Select(txt.SelectionStart, txt.Text.Length - txt.SelectionStart);
			}

			if (utilizarListView)
				mostrarLista = true;

			txt_Validating(this, new CancelEventArgs());

            Dessinalizar();
		}

		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((coletor == null) && (utilizarListView))
				ConstruirListView();

            Dessinalizar();
            
            if (utilizarListView && txt.Text.Length > 0 && coletor.ÚltimaDigitação.Milliseconds > taxaMáximaDigitaçãoHumana)
                forçarManual = true;

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
							lst.SelecionarPróximo();
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
                    if (UtilizarCompletarReferência)
					    e.Handled = CompletarReferência();
					break;

				case Keys.Escape:
					MostrarLista(false);
                    txt.Text = "";
                    if (EscPressionado != null)
                        EscPressionado(null, null);
					break;

                case Keys.Enter:
                    if (DigitaçãoManual && UtilizarCompletarReferência)
                        e.Handled = CompletarReferência();
                    else
                    {
                        if (lst != null)
                            MostrarLista(false);

                        if (txt.Text.Length == 0) return;

                        if (txt.Text.Length < txt.Mask.Length)
                        {
                            if (coletor != null)
                                coletor.Cancelar();

                            if (!SubstituirCódigoBarras())
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
                        ConfirmarReferência();
                        mostrarLista = utilizarListView;
                    }
                    break;
            }
		}

        public bool CompletarReferência()
        {
            if (txt.Text.Length == 0 && referênciaAnterior != null)
            {
                string aux = referênciaAnterior;
                referênciaAnterior = null;
                txt.Text = aux;
                return true;
            }
            else if (utilizarListView)
            {
                string referência = null;

                UseWaitCursor = true;

                try
                {
                    try
                    {
                        string refNumérica;
                        int dígito;

                        Entidades.Mercadoria.Mercadoria.DesmascararReferência(txt.Text, out refNumérica, out dígito);

                        referência = coletor.RecuperarPrimeiroSomente(refNumérica);

                        if (referência != null && !referência.StartsWith(txt.Text))
                            referência = null;
                    }
                    catch (NullReferenceException erro)
                    {
                        if (coletor == null && utilizarListView)
                        {
                            ConstruirListView();

                            return CompletarReferência();
                        }

                        throw new Exception("Erro ao completar referência " + txt.Text, erro);
                    }
                    catch (ArgumentException err)
                    {
                        Beepador.Erro();
                        MessageBox.Show(this, err.Message, "Erro ao procurar referência", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (referência != null)
                    {
                        lock (this)
                        {
                            mostrarLista = false;

                            if (lst != null)
                                MostrarLista(false);

                            txt.Text = referência;
                        }

                        mostrarLista = utilizarListView;

                        Dessinalizar();

                        return true;
                    }

                    SinalizarReferênciaInválida();

                    return false;
                }
                finally
                {
                    UseWaitCursor = false;
                }
            }

            return false;
        }

		private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (txt.Text.Length > 0)
            {
                referênciaCadastrada = Entidades.Mercadoria.Mercadoria.VerificarExistência(txt.Text, true);

                if (!referênciaCadastrada)
                {
                    e.Cancel = permitirSomenteCadastrado || permitirSomenteDelinha;
                }
                else
                {
                    e.Cancel = e.Cancel || (SomenteDeLinha && Mercadoria.ForaDeLinha);
                }
            }
		}

		[Bindable(true)]
		public string Referência
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
                    SinalizarRepetiçãoPossível();
                else
                    Dessinalizar();
			}
		}

		[DefaultValue(false),
			Description("Permitir somente referências cadastradas no banco de dados.")]
		public bool SomenteCadastrado
		{
			get { return permitirSomenteCadastrado; }
			set { permitirSomenteCadastrado = value; }
		}

        [DefaultValue(true)]
        public bool SomenteDeLinha
        {
            get { return permitirSomenteDelinha; }
            set {
                permitirSomenteDelinha = value;

                if (coletor != null)
                    coletor.SomenteDeLinha = value;
            }
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

		private bool SubstituirCódigoBarras()
		{
			string códigoNumérico = "";
			Entidades.Mercadoria.Mercadoria mercadoria;

			this.ParentForm.Cursor = Cursors.WaitCursor;

			mostrarLista = false;

			foreach (char c in txt.Text)
				if (Char.IsDigit(c))
					códigoNumérico += c;

			// Tentar decodificar código de barras.
			try
			{
				mercadoria = Entidades.Mercadoria.Mercadoria.Interpretar(códigoNumérico, tabela);

                if (mercadoria == null)
                    throw new NullReferenceException("Erro interpretando código de barras de número " + códigoNumérico.ToString() + ". Mercadoria não foi encontrada.");

				this.txt.Text = mercadoria.Referência;

				if (controlePeso != null)
					controlePeso.Text = mercadoria.Peso.ToString(NumberFormatInfo.CurrentInfo);

                if (mercadoria.ForaDeLinha)
                {
                    Beepador.Erro();

                    MessageBox.Show(
                        this.ParentForm,
                        "A mercadoria " + mercadoria.Referência + " está fora de linha. ",
                        "Código de barras inválido!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return false;
                }

                return true;
			}
			// Em caso de código de barras inválido, apenas informar.
			catch (CódigoBarrasInválido e)
			{
				Beepador.Erro();

				MessageBox.Show(
					this.ParentForm,
					e.Message + "\r\n\r\n"
					+ "O código de barras " + códigoNumérico + " não pode ser reconhecido. "
					+ "Tente a digitação manual da referência.",
					"Código de barras inválido!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);

				return false;
			}
			// Em caso de erro interno, registrar ocorrência.
			catch (Exception e)
			{
				Beepador.Erro();

				MessageBox.Show(
					this.ParentForm,
					e.Message + "\r\n\r\n"
					+ "Ocorreu um erro interno lendo o código de barras " + códigoNumérico + ". "
					+ "Tente a digitação manual da referência.",
					"Código de barras inválido!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);

				// Registrar ocorrência de erro.
				try
				{
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
				}
				catch
				{
					MessageBox.Show("Não foi possível enviar um relatório sobre este erro.\n\n" + e.ToString(),
						"Relatório de Erros",
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

		public override bool Focused
		{
			get
			{
				return base.Focused || txt.Focused || (lst != null ? lst.Focused : false);
			}
		}

        private delegate void SinalizaçãoCallback();

        private void SinalizarRepetiçãoPossível()
        {
            if (DateTime.Now - últimoUso < TimeSpan.FromSeconds(validadeParaRepetição))
            {
                if (InvokeRequired)
                {
                    SinalizaçãoCallback método = new SinalizaçãoCallback(SinalizarRepetiçãoPossível);

                    if (!Disposing)
                        BeginInvoke(método);
                }
                else
                {
                    imagem.Tag = null;
                    imagem.Image = Resource.Refazer;

                    try
                    {
                        toolTip.SetToolTip(imagem, "Pressione ENTER ou clique aqui para repetir a última referência: " + referênciaAnterior);
                    }
                    catch { }

                    imagem.Visible = true;
                    imagem.BringToFront();
                }
            }
        }

        private void SinalizarReferênciaInválida()
        {
            if (InvokeRequired)
            {
                SinalizaçãoCallback método = new SinalizaçãoCallback(SinalizarReferênciaInválida);

                if (!Disposing) 
                    BeginInvoke(método);
            }
            else
            {
                imagem.Tag = this.Referência;
                imagem.Image = Resource.Advertência;

                try
                {
                    toolTip.SetToolTip(imagem, "Não existe nenhuma referência com o prefixo digitado.");
                }
                catch
                {
                }

                imagem.Visible = true;
                imagem.BringToFront();
            }
        }

        private void SinalizarProcura()
        {
            if (InvokeRequired)
            {
                SinalizaçãoCallback método = new SinalizaçãoCallback(SinalizarProcura);

                if (!Disposing)
                    BeginInvoke(método);
            }
            else
            {
                imagem.Tag = null;
                imagem.Image = Resource.Lupa;

                try
                {
                    toolTip.SetToolTip(imagem, "O sistema está procurando a referência...");
                }
                catch { }

                imagem.Visible = true;
                imagem.BringToFront();
            }
        }

        private void Dessinalizar()
        {
            if (InvokeRequired)
            {
                SinalizaçãoCallback método = new SinalizaçãoCallback(Dessinalizar);
                
                if (!Disposing)
                    BeginInvoke(método);
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

        private void PrepararMercadoria(object sender, DoWorkEventArgs e)
        {
            try
            {
                Entidades.Mercadoria.Mercadoria mercadoria = this.Mercadoria;

                if (mercadoria != null)
                {
                    mercadoria.Preparar();
                }

                e.Result = mercadoria;
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

#if DEBUG
                MessageBox.Show(erro.ToString());
#endif
            }
        }

        private void AoPrepararMercadoria(object sender, RunWorkerCompletedEventArgs e)
        {
            if (referênciaCadastrada && e.Result != null && this.Mercadoria == (Entidades.Mercadoria.Mercadoria)e.Result)
            {
                imagem.Tag = Mercadoria;
                imagem.Image = Mercadoria.Ícone;
                imagem.Visible = true;
                imagem.BringToFront();
            }
        }
    }
}
