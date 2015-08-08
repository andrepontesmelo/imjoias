using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa;
using System.Collections.Generic;

namespace Apresenta��o.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for TextBoxPessoa.
	/// </summary>
	public class TextBoxPessoa : System.Windows.Forms.UserControl
	{
		// Constantes
		public const int alturaM�nimaLista = 160;

		// Atributos
		private ListView		lista = null;
		private ColetorPessoas	coletor = null;			// Deve-se usar o 'Coletor'
		private volatile bool	travar = false;			// Proteger contra pesquisa
		private volatile bool	segurarLista = false;
		private bool			funcion�rios = false;	// Listar somente funcion�rios
        private bool            vendedores = false;	    // Listar somente vendedores (representantes + funcion�rios)
		private Hashtable		refPessoas = null;		// Refer�ncia de pessoas para a listview (lista invertida)
		//private Hashtable		setoresC�digo;			// Setores pelo c�digo
		private Entidades.Pessoa.Pessoa pessoa = null;			// Pessoa selecionada
		private Entidades.Pessoa.Pessoa pessoaAnterior = null;  // Sele��o anterior 
		private bool			mostrarCabe�alho = true;
		private bool			desligarPesquisa = false;
        private bool            somenteCadastrados = false;
		

		// Eventos
        [Description("Usu�rio seleciona uma pessoa da lista ou a pessoa � encontrada a partir do prefixo ou nome digitado pelo usu�rio.")]
		public event EventHandler Selecionado;
        public event EventHandler Deselecionado;
		
        [Description("Uma pessoa foi escolhida. O usu�rio pode ter alterado pela lista ou ent�o digitado um nome qualquer.")]
        public event EventHandler NomeAlterado;
        public event EventHandler TxtChanged;

        public new event KeyEventHandler KeyDown;

		// Listview
		private ColumnHeader colNome;
		private ColumnHeader colDados;

		// Designer
        private System.Windows.Forms.TextBox txt;
        private Button btnProcurar;
        private FormatadorNome formatadorNome;
        private PictureBox imagem;
        private IContainer components;

        int alturaProposta;

        /// <summary>
        /// Altura a ser considerada ao construir a lista
        /// </summary>
        public int AlturaProposta
        {
            get  { return alturaProposta; }
            set { alturaProposta = value; }
        }

		public TextBoxPessoa()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Cria colunas para listview
			colNome = new ColumnHeader();
			colNome.Text = "Nome";

			colDados = new ColumnHeader();
			colDados.Text = "Cidade";		// Ou setor, conforme propriedade funcion�rios
			colDados.Width = 200;

            this.AlturaProposta = 3 * this.Height;

			this.txt.ForeColor = SystemColors.ControlText;
            //setoresC�digo = new Hashtable();
		}

		/// <summary> 
		/// Clean up any resources being used.
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
            this.txt = new System.Windows.Forms.TextBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.formatadorNome = new Apresenta��o.Pessoa.FormatadorNome(this.components);
            this.imagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNome.SetFormatarNome(this.txt, true);
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(196, 20);
            this.txt.TabIndex = 0;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            this.txt.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            this.txt.Validated += new System.EventHandler(this.txt_Validated);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcurar.BackgroundImage = global::Apresenta��o.Resource.search4people;
            this.btnProcurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcurar.Location = new System.Drawing.Point(196, 0);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(20, 20);
            this.btnProcurar.TabIndex = 1;
            this.btnProcurar.TabStop = false;
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // imagem
            // 
            this.imagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagem.BackColor = System.Drawing.SystemColors.Window;
            this.imagem.Image = global::Apresenta��o.Resource.Lupa;
            this.imagem.Location = new System.Drawing.Point(179, 2);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(16, 16);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            this.imagem.Visible = false;
            // 
            // TextBoxPessoa
            // 
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txt);
            this.Name = "TextBoxPessoa";
            this.Size = new System.Drawing.Size(216, 20);
            this.Move += new System.EventHandler(this.TextBoxPessoa_Resize);
            this.Resize += new System.EventHandler(this.TextBoxPessoa_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Propriedades
        private bool podeSerNulo = true;
        [DefaultValue(false)]
        public bool N�oPodeSerNulo
        {
            get { return !podeSerNulo;  }
            set { podeSerNulo = !value;  }
        }

		[DefaultValue(false)]
		public bool DesligarPesquisa
		{
			get { return desligarPesquisa; }
			set
			{
				desligarPesquisa = value;

				if (value)
				{
					if (coletor != null)
						coletor.Cancelar();

					if (lista != null)
						lista.Visible = false;
				}
				else
					coletor.ProcurarImediatamente();
			}
		}

        [Browsable(false)]
		public Entidades.Pessoa.Pessoa Pessoa
		{
			get
            {
                if (somenteCadastrados && txt.Text.Length > 0 && pessoa == null)
                    ProcurarPessoaCadastrada();

                return pessoa;
            }
            set 
            {
                //bool v�lido;

                ////v�lido  = value == null || !funcion�rios || value is Funcion�rio || Funcion�rio.�Funcion�rio(value);
                ////v�lido &= value == null || !vendedores || value is Representante || value is Funcion�rio || Funcion�rio.�Funcion�rio(value) || Representante.�Representante(value);

                //v�lido  = value == null || !funcion�rios || value is Funcion�rio || Funcion�rio.�Funcion�rio(value);
                //v�lido &= value == null || !vendedores || value is Representante || value is Funcion�rio || Funcion�rio.�Funcion�rio(value) || Representante.�Representante(value);

                //if (v�lido)
                //{
                    // Atribui pessoa referente � linha selecionada
                    if (pessoa != null)
                        pessoaAnterior = pessoa;

                    pessoa = value;

                    // Garante que a textbox n�o vai requisitar pesquisa
                    travar = true;

                    AtualizarTextBox();

                    travar = false;
                //}
            }
        }

        private delegate void AtualizarCallback();

        private void AtualizarTextBox()
        {
            if (txt.InvokeRequired)
            {
                AtualizarCallback m�todo = new AtualizarCallback(AtualizarTextBox);
                txt.BeginInvoke(m�todo);
            }
            else
            {
                if (pessoa != null)
                {
                    txt.Text = pessoa.Nome;
                    txt.SelectAll();
                }
                else
                    txt.Text = "";
            }
        }

        /// <summary>
        /// C�digo da pessoa, c�digo entrado ou nulo caso esteja
        /// escrito apenas um nome n�o cadastrado.
        /// </summary>
        private ulong? C�digo
        {
            get
            {
                if (Pessoa != null)
                    return Pessoa.C�digo;
                else if (txt.Text.Length > 0)
                {
                    // Verifica se � n�mero
                    string texto = txt.Text.Trim();
                    bool �N�mero = true;
                    for (int x = 0; x < texto.Length; x++)
                        �N�mero &= char.IsNumber(texto, x);

                    if (�N�mero)
                        return ulong.Parse(txt.Text);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

		/// <summary>
		/// Coletor de pessoas.
		/// </summary>
		private ColetorPessoas Coletor
		{
			get 
			{ 
				if (coletor == null)
					CriarColetor();

				return coletor;
			}
		}

		/// <summary>
		/// Texto
		/// </summary>
		public override string Text
		{
			get { return txt.Text; }
			set
			{
				travar = true;
				txt.Text = value;
				travar = false;
			}
		}

		public TextBox TextBox
		{
			get { return txt; }
		}

		/// <summary>
		/// Lista est� sendo segurada
		/// </summary>
		public bool SegurandoLista
		{
			get { return segurarLista; }
		}

        /// <summary>
        /// Mostrar somente funcion�rios.
        /// </summary>
        [Description("Mostrar somente funcion�rios")]
		[DefaultValue(false)]
		public bool Funcion�rios
		{
			get { return funcion�rios; }
			set
			{
				funcion�rios = value;

				if (coletor != null)
					Coletor.Funcion�rios = value;

                colDados.Text = (funcion�rios || vendedores ? "Setor" : "Cidade");
			}
		}

        /// <summary>
        /// Define se deve ser exibido somente vendedores (funcion�rios + representantes).
        /// </summary>
        [DefaultValue(false), Description("Mostrar somente vendedores (funcion�rios + representates)")]
        public bool Vendedores
        {
            get { return vendedores; }
            set
            {
                vendedores = value;

                if (coletor != null)
                    Coletor.Vendedores = value;

                colDados.Text = (vendedores || funcion�rios ? "Setor" : "Cidade");
            }
        }

		/// <summary>
		/// Mostrar cabe�alho das colunas
		/// </summary>
		[DefaultValue(true),
		 Description("Determina se o cabe�alho deve ser mostrado ou n�o")]
		public bool MostrarCabe�alho
		{
			get { return mostrarCabe�alho; }
			set
			{
				mostrarCabe�alho = value;

				if (lista != null)
					lista.HeaderStyle = value ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
			}
		}

        /// <summary>
        /// Aceita somente pessoas cadastradas.
        /// </summary>
        [DefaultValue(false),
        Description("Determina se somente pessoas cadastradas devem ser aceitas.")]
        public bool SomenteCadastrado
        {
            get { return somenteCadastrados; }
            set
            {
                somenteCadastrados = value;

                if (value && txt.Text.Length > 0 && Pessoa == null)
                    ProcurarPessoaAssincronamente();
            }
        }

        /// <summary>
        /// Determina se deve mostrar bot�o de procurar.
        /// </summary>
        [DefaultValue(true)]
        public bool MostrarBot�oProcurar
        {
            get { return btnProcurar.Visible; }
            set
            {
                if (btnProcurar.Visible != value)
                {
                    btnProcurar.Visible = value;

                    if (value)
                    {
                        txt.Width = ClientSize.Width - btnProcurar.Width;
                        imagem.Left -= btnProcurar.Width;
                    }
                    else
                    {
                        txt.Width = ClientSize.Width;
                        imagem.Left += btnProcurar.Width;
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return txt.ReadOnly; }
            set
            {
                txt.ReadOnly = value;
                btnProcurar.Enabled = !value;
            }
        }

		#endregion

		/// <summary>
		/// Reposiciona a lista, conforme text box
		/// </summary>
		private void ReposicionarLista()
		{
			if (lista != null)
			{
				int larguraProposta = this.Width;

				Point pontoZeroRa�z;	//zero absoluto do formulario toppest
				Point pontoZeroMeu;		//zero absoluto do formulario top
				Point posi��oLista;		//� o novoZero um pouco para direita
				Point novoZero;			
				/* novoZero:
				 * seu zero corresponde � coordenada relativa 
				 * do top em rela��o ao toppest
				 */
				
				// Obtem coordenada relativa
                if (this.ParentForm != null)
                {
                    pontoZeroRa�z = this.ParentForm.PointToScreen(new Point(0, 0));
                    pontoZeroMeu = this.PointToScreen(new Point(0, 0));

                    //novoZero = pontoZeromeu - pontoZeroRa�z;
                    novoZero = pontoZeroMeu;
                    novoZero.Offset(-1 * pontoZeroRa�z.X, -1 * pontoZeroRa�z.Y);

                    //abaixa:
                    posi��oLista = novoZero;
                    posi��oLista.Offset(0, this.Height);
                }
                else
                    posi��oLista = new Point(lista.Left, lista.Top);

				//lista.Bounds = new Rectangle
				//	(posi��oLista, new Size(larguraProposta < larguraM�nimaLista ? larguraM�nimaLista : larguraProposta, alturaProposta < alturaM�nimaLista ? alturaM�nimaLista : alturaProposta));

				lista.Bounds = new Rectangle
					(posi��oLista, new Size(larguraProposta, alturaProposta < alturaM�nimaLista ? alturaM�nimaLista : alturaProposta));

				if (lista.Bottom > lista.Parent.ClientSize.Height)
					lista.Height -= lista.Bottom - lista.Parent.ClientSize.Height;

				colNome.Width = lista.Width - colDados.Width - 25;
				
				lista.BringToFront();
			}
		}

        private delegate void Sinaliza��oCallback();

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
                UseWaitCursor = true;
                Parent.UseWaitCursor = true;

                //imagem.Visible = true;
                //imagem.BringToFront();
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
            else
            {
                //txt.BackColor = Color.White;
                UseWaitCursor = false;
                Parent.UseWaitCursor = false;

                //imagem.Visible = false;
            }
        }

		/// <summary>
		/// Cria lista
		/// </summary>
		private void CriarLista()
		{
			// Constr�i a listview
            lista = new ListView();

			// Atributos visuais
			int alturaProposta = 3 * this.Height;
			lista.Height		= alturaProposta < alturaM�nimaLista ? alturaM�nimaLista : alturaProposta;
			lista.Visible		= false;
			lista.Name			= this.Name + "Lista";
			lista.FullRowSelect = true;
			lista.MultiSelect	= false;
			lista.HideSelection = false;
			lista.View			= View.Details;
			lista.BorderStyle = BorderStyle.FixedSingle;
			lista.HeaderStyle	= mostrarCabe�alho ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
	
			// Eventos
			lista.SelectedIndexChanged += new EventHandler(lista_SelectedIndexChanged);
			lista.Click				   += new EventHandler(lista_Click);
			lista.MouseMove			   += new MouseEventHandler(lista_MouseMove);
			lista.MouseLeave		   += new EventHandler(lista_MouseLeave);

			// Colunas
			lista.Columns.Add(colNome);
			lista.Columns.Add(colDados);
			
			this.TopLevelControl.SuspendLayout();
			this.TopLevelControl.Controls.Add(lista);
			
			lista.BringToFront();

            ///* Se a lista for oculta antes de inserir no controle,
            // * o programa trava. (Bug do .net, talvez?)
            // */
            //lista.Visible = false;
		}

		/// <summary>
		/// Constr�i coletor de dados.
		/// </summary>
		private void CriarColetor()
		{
			coletor = new ColetorPessoas(new ColetorPessoas.Recupera��oPessoasDelegate(Recupera��o));
			coletor.Funcion�rios = funcion�rios;
			coletor.FinalDeBusca += new Apresenta��o.Formul�rios.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
            coletor.In�cioDeBusca += new Apresenta��o.Formul�rios.Consultas.Coletor.In�cioDeBuscaDelegate(coletor_In�cioDeBusca);
			coletor.IgnorarMai�sculoMin�sculo = true;
		}

        void coletor_In�cioDeBusca()
        {
            SinalizarProcura();
        }

		/// <summary>
		/// Reconstruir lista de auto-complete
		/// </summary>
		private void txt_TextChanged(object sender, System.EventArgs e)
		{
            if (TxtChanged != null)
                TxtChanged(sender, e);

 			// Verificar se inicia pesquisa
			if (txt.Focused && !travar && !desligarPesquisa && lista != null)
			{
                if (txt.Text.Length == 0)
                {
                    lista.Visible = false;
                    pessoa = null;
                }
                else if (pessoa != null && string.Compare(pessoa.Nome, txt.Text, true) != 0)
                    pessoa = null;

                /* Movido para OnKeyUp, visto que altera��es na
                 * formata��o do TextBox -- provenientes do FormatadorNome --,
                 * disparam TextChanged, influenciando na marca��o de tempo
                 * do Coletor.
                 * -- J�lio, 21/04/2006
                 */
                //else
                //    Coletor.Pesquisar(txt.Text);
			}

            if ((pessoaAnterior == null) || ((pessoa != null) && (pessoa.C�digo != pessoaAnterior.C�digo)))
            {
                if (NomeAlterado != null && V�lido)
                    NomeAlterado(sender, e);
            }
		}

        private delegate void Recupera��oCallback(List<Entidades.Pessoa.Pessoa> pessoas);

		/// <summary>
		/// Ocorre quando o coletor recupera nomes
		/// </summary>
		/// <param name="nomes">Nomes recuperados da camada de acesso</param>
		private void Recupera��o(List<Entidades.Pessoa.Pessoa> pessoas)
		{
            try
            {
                if (lista.InvokeRequired)
                {
                    Recupera��oCallback m�todo = new Recupera��oCallback(Recupera��o);
                    lista.BeginInvoke(m�todo, new object[] { pessoas });
                }
                else
                {
                    // Limpar lista
                    lista.Visible = false;
                    lista.Items.Clear();

                    // Recriar hashtable para encontrar entidades pela linha selecionada do listview
                    refPessoas = new Hashtable(pessoas.Count);

                    // Verificar se h� pessoas para mostrar
                    if (pessoas.Count == 0)
                    {
                        // Mostrar lista vazia para que o usu�rio n�o espere
                        //lista.Visible = Focused && !travar && txt.Text.Length > 0;

                        lista.Visible = false;

                        return;
                    }


                    ListViewItem[] itens = new ListViewItem[pessoas.Count];
                    int x = 0;

                    // Inserir pessoas
                    foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
                    {
                        if (pessoa is Entidades.Pessoa.Funcion�rio)
                        {
                            Entidades.Setor setor;
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;

                            setor = ((Entidades.Pessoa.Funcion�rio)pessoa).Setor;

                            // A pessoa pode n�o ter setor
                            linha.SubItems.Add(setor == null ? "" : setor.Nome);
                            lista.Items.Add(linha);

                            refPessoas[linha] = pessoa;
                        }
                        else if (pessoa is Entidades.Pessoa.Representante)
                        {
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;
                            linha.SubItems.Add("Representante");
                            lista.Items.Add(linha);

                            refPessoas[linha] = pessoa;
                        }
                        else if (pessoa != null)
                        {
                            ListViewItem linha = new ListViewItem();

                            linha.Text = pessoa.Nome;

                            List<Entidades.Pessoa.Endere�o.Endere�o> endere�os
                                = pessoa.Endere�os.ExtrairElementos();

                            if (endere�os.Count != 0
                                && (endere�os[0].Localidade != null)
                                && (endere�os[0].Localidade.Estado != null))
                                linha.SubItems.Add(endere�os[0].Localidade.Nome + " / " + endere�os[0].Localidade.Estado.Sigla);
                            else
                                linha.SubItems.Add("");
                                
                            //linha.SubItems.Add(((Entidades.Pessoa.PessoaCPFCNPJRG)pessoa).Documento);

                            itens[x++] = linha;

                            refPessoas[linha] = pessoa;
                        }
                    }

                    lista.Items.AddRange(itens);

                    /* Verificar se o controle ainda ret�m o foco para mostrar a lista
                     * O foco no TextBox � sempre falso neste ponto, talvez porque esta
                     * fun��o � chamada externamente pelo ColetorPessoas. (Estranho)
                     * Portanto, utiliza-se o travar para verificar se o controle est�
                     * com foco.
                     *                      -- J�lio, 06/03/2004
                     */
                    if (!travar)
                    {
                        lista.Visible = Focused;
                        lista.BringToFront();
                    }
                }
            }
            catch (ObjectDisposedException)
            { /* Ignorar */ }
		}

		/// <summary>
		/// Ocorre quando se seleciona um item na lista
		/// </summary>
		private void lista_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lista.SelectedItems.Count != 1)
				return;

            AoSelecionar(lista.SelectedItems[0]);
		}

        /// <summary>
        /// Ocorre ao selecionar um item na lista.
        /// </summary>
        private void AoSelecionar(ListViewItem item)
        {
            if (!ReadOnly)
            {
                // Precisa ser a propriedade para n�o abrir a listView
                Pessoa = refPessoas[item] as Entidades.Pessoa.Pessoa;

                // Verificar se foi clicada
                if (lista.Focused)
                {
                    lista.Visible = false;
                    txt.Focus();
                }

                // Como foi selecionada uma pessoa, n�o � mais necess�rio segurar a lista
                segurarLista = false;

                //if (Selecionado != null)
                //    Selecionado(this, null);
            }
        }

		/// <summary>
		/// Ocorre quando se pressiona uma tecla no textbox
		/// </summary>
		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (!Enabled)
                return;

			if (lista == null)
				return;

            // A chamada get da propriedade Pessoa zera txt.Text.
            string texto = txt.Text;

            try
			{
				int idx = -1;

				if (lista.SelectedIndices.Count > 0)
					idx = lista.SelectedIndices[0];

				switch (e.KeyCode)
				{
                    case Keys.Delete:
                        if (txt.SelectionLength == txt.TextLength)
                            Limpar();
                        break;

					case Keys.Down:
						if (++idx >= lista.Items.Count)
							idx = lista.Items.Count - 1;

						lista.Items[idx].Selected = true;
						lista.Items[idx].EnsureVisible();
						e.Handled = true;
						break;

					case Keys.Up:
						if (--idx < 0)
							idx = 0;

						lista.Items[idx].Selected = true;
						lista.Items[idx].EnsureVisible();
						e.Handled = true;
						break;

					case Keys.Enter:
                        if (Pessoa != null && Pessoa.Nome.Trim() == texto.Trim())
                        {
                            if (lista != null)
                                lista.Visible = false;

                            return;
                        }

                        if (somenteCadastrados && lista.Items.Count > 0)
                        {
                            Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(texto.Trim());
                            Apresenta��o.Formul�rios.AguardeDB.Fechar();
                            using (ProcurarPessoaResultados dlg = new ProcurarPessoaResultados(pessoas))
                            {
                                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                                    Pessoa = dlg.PessoaSelecionada;
                            }
                            
                        }
						lista.Visible = false;
						e.Handled = true;
						break;

					case Keys.Escape:
						lista.Visible = false;
						break;
				}
			}
			catch
			{
				e.Handled = true;
			}
			finally
			{
				this.OnKeyDown(e);
			}

            if (KeyDown != null)
                KeyDown(this, e);            
		}

		/// <summary>
		/// Ocorre quando o mouse entra na lista
		/// </summary>
		private void lista_MouseMove(object sender, MouseEventArgs e)
		{
			segurarLista = true;
		}

		/// <summary>
		/// Ocorre quando o mouse sai da lista
		/// </summary>
		private void lista_MouseLeave(object sender, EventArgs e)
		{
			segurarLista = false;
		}

		/// <summary>
		/// Ocorre quando o textbox perde o foco
		/// </summary>
		private void txt_Leave(object sender, System.EventArgs e)
		{
            if (!Enabled)
                return;

			travar = true;

			if (!segurarLista && lista != null)
				lista.Visible = false;

            if (pessoa == null && funcion�rios && txt.Text.Length != 0 && lista.Items.Count > 0 && V�lido)
                AoSelecionar(lista.Items[0]);
            else if (somenteCadastrados && !Focused && txt.Text.Length > 0 && Pessoa == null && V�lido)
                ProcurarPessoaAssincronamente();
            else if (C�digo.HasValue && Pessoa == null && V�lido)
                ProcurarPessoaAssincronamente();
            else if (Deselecionado != null && Pessoa == null && V�lido)
                Deselecionado(this, EventArgs.Empty);
            else if (Selecionado != null && Pessoa != null && V�lido)
                Selecionado(this, EventArgs.Empty);

            UseWaitCursor = false;
        }

		/// <summary>
		/// Ocorre quando o textbox ganha o foco
		/// </summary>
		private void txt_Enter(object sender, System.EventArgs e)
		{
            if (!Enabled)
                return;

            if (lista != null)
            {
                //lista.Visible = lista.Items.Count > 0;
            }
            else if (!this.DesignMode && this.TopLevelControl != null)
            {
                this.ParentForm.Cursor = Cursors.WaitCursor;

                CriarLista();
                ReposicionarLista();
                CriarColetor();

                this.TopLevelControl.ResumeLayout();

                this.ParentForm.Cursor = Cursors.Default;
            }

			travar = false;
		}

		/// <summary>
		/// Textbox redimensionado
		/// </summary>
		private void TextBoxPessoa_Resize(object sender, System.EventArgs e)
		{
			if (this.Height > 20)
			{
				this.SuspendLayout();
				this.Height = 20;
				this.ResumeLayout(true);
			}

			ReposicionarLista();
		}

		/// <summary>
		/// Usu�rio selecionou na lista clicando
		/// </summary>
		private void lista_Click(object sender, EventArgs e)
		{
			lista.Visible = false;
			segurarLista = false;
		}

        private delegate void FinalDeBuscaCallback();

		/// <summary>
		/// A busca foi cancelada pelo coletor ou finalizada
		/// </summary>
		private void coletor_FinalDeBusca()
		{
            if (lista.InvokeRequired)
            {
                FinalDeBuscaCallback m�todo = new FinalDeBuscaCallback(coletor_FinalDeBusca);
                lista.BeginInvoke(m�todo);
            }
            else
            {
                // Mostrar os resultados atuais, se o controle continua com foco
                if (lista != null && Focused && !travar)
                    lista.Visible = txt.Text.Length > 0;

                else if (pessoa == null && funcion�rios && !Focused && lista != null && lista.Items.Count > 0)
                    AoSelecionar(lista.Items[0]);

                Dessinalizar();
            }
		}

		private void txt_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (!Enabled)
                return;

            if (txt.Focused && !travar && !desligarPesquisa && lista != null && pessoa == null && e.KeyCode != Keys.Enter)
            {
                /* Requisitar pesquisa de nome ou esconder janela,
                 * conforme dados digitados.
                 */
                lista.Visible = false;

                Coletor.Pesquisar(txt.Text);
            }

            this.OnKeyUp(e);
		}

		private void txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            if (!Enabled)
                return;

            if (e.KeyChar == (char)8 && txt.SelectionLength == txt.TextLength)
                Limpar();

            this.OnKeyPress(e);
		}

        private void Limpar()
        {
            txt.Text = "";
        }

        public override bool Focused
        {
            get
            {
                return base.Focused || txt.Focused || (lista != null && lista.Focused) || btnProcurar.Focused;
            }
        }

        /// <summary>
        /// Ocorre ao clicar em procurar.
        /// </summary>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            if (vendedores && !funcion�rios)
            {
                using (EscolherVendedor dlg = new EscolherVendedor(
                    "Escolha o vendedor desejado.",
                    txt.Text))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        Pessoa = dlg.Vendedor;
                }
            }
            else if (funcion�rios)
            {
                using (EscolherFuncion�rio dlg = new EscolherFuncion�rio(
                    "Escolha o funcion�rio desejado.",
                    txt.Text))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        Pessoa = dlg.Funcion�rio;
                }
            }
            else
                Pessoa = ProcurarPessoa.Procurar(ParentForm);


            if (V�lido)
            {
                if (Pessoa != null)
                {
                    if (Selecionado != null)
                        Selecionado(this, null);
                }
                else
                    if (Deselecionado != null)
                        Deselecionado(this, null);
            }

            UseWaitCursor = false;
        }

        /// <summary>
        /// Procura pessoa cadastrada assincronamente.
        /// </summary>
        private void ProcurarPessoaAssincronamente()
        {
            ProcurarPessoaCadastradaCallback m�todo;

            m�todo = new ProcurarPessoaCadastradaCallback(ProcurarPessoaCadastrada);
            m�todo.BeginInvoke(new AsyncCallback(AoTerminarProcuraPessoa), m�todo);
        }

        private delegate void ProcurarPessoaCadastradaCallback();

        /// <summary>
        /// Procura pessoa cadastrada.
        /// </summary>
        private void ProcurarPessoaCadastrada()
        {
            if (txt.Text.Length == 0)
                return;

            // Verifica se � um c�digo que est� digitado.
            if (char.IsNumber(txt.Text[0]))
            {
                ulong c�digo = ulong.Parse(txt.Text);

                if (this.funcion�rios)
                    Pessoa = Entidades.Pessoa.Funcion�rio.ObterPessoa(c�digo);
                else
                    Pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(c�digo);
            }
            else
            {
                if (this.vendedores && !this.funcion�rios)
                {
                    List<Entidades.Pessoa.Pessoa> funcion�rios;

                    funcion�rios = Entidades.Pessoa.Funcion�rio.ObterFuncion�rios(txt.Text, 2);

                    if (funcion�rios.Count == 1)
                        Pessoa = funcion�rios[0];
                    else
                    {
                        Entidades.Pessoa.Representante[] representantes;

                        representantes = Entidades.Pessoa.Representante.ObterRepresentantes(txt.Text, 2);

                        if (representantes.Length == 1)
                            Pessoa = representantes[0];
                        else
                            Pessoa = null;
                    }
                }
                else if (this.funcion�rios)
                {
                    List<Entidades.Pessoa.Pessoa> funcion�rios;

                    funcion�rios = Entidades.Pessoa.Funcion�rio.ObterFuncion�rios(txt.Text, 2);

                    if (funcion�rios.Count == 1)
                        Pessoa = funcion�rios[0];
                    else
                        Pessoa = null;
                }
                else
                {
                    List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(txt.Text, 2);

                    if (pessoas.Count == 1)
                        Pessoa = pessoas[0];
                    else
                        Pessoa = null;
                }
            }

            if (V�lido)
            {
                if (pessoa != null)
                {
                    if (Selecionado != null)
                        Selecionado(this, null);
                }
                else
                    if (Deselecionado != null)
                        Deselecionado(this, null);
            }
        }

        /// <summary>
        /// Ocorre ao terminar a procura por pessoa cadastrada.
        /// </summary>
        private void AoTerminarProcuraPessoa(IAsyncResult resultado)
        {
            ProcurarPessoaCadastradaCallback m�todo;

            m�todo = (ProcurarPessoaCadastradaCallback)resultado.AsyncState;
            m�todo.EndInvoke(resultado);
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !V�lido;
        }

        private void txt_Validated(object sender, EventArgs e)
        {
        }

        private bool V�lido
        {
            get
            {
                return podeSerNulo || Pessoa != null;
            }
        }
	}
}
